using System;
using System.IO;
using System.IO.Ports;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialTool
{
    public partial class MainForm : Form
    {
        SerialPort port;

        public MainForm()
        {
            InitializeComponent();

            string query = "SELECT * FROM __InstanceCreationEvent WITHIN 1 WHERE TargetInstance isa \"WIN32_SerialPort\"";
            ManagementEventWatcher watcher = new ManagementEventWatcher(query);
            watcher.EventArrived += Watcher_SerialPortCreation;
            watcher.Start();

            query = "SELECT * FROM __InstanceDeletionEvent WITHIN 1 WHERE TargetInstance isa \"WIN32_SerialPort\"";
            watcher = new ManagementEventWatcher(query);
            watcher.EventArrived += Watcher_SerialPortDeletion;
            watcher.Start();
        }

        private void Watcher_SerialPortCreation(object sender, EventArrivedEventArgs e)
        {
            Invoke((MethodInvoker)delegate {
                ManagementBaseObject target = (ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value;
                serialPortName.Items.Add(target.Properties["DeviceId"].Value.ToString());
            });
        }

        private void Watcher_SerialPortDeletion(object sender, EventArrivedEventArgs e)
        {
            Invoke((MethodInvoker)delegate {
                ManagementBaseObject target = (ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value;
                serialPortName.Items.Remove(target.Properties["DeviceId"].Value.ToString());
            });
        }

        private void ShowSerialPorts()
        {
            serialPortName.Items.Clear();
            foreach (string portName in SerialPort.GetPortNames())
            {
                serialPortName.Items.Add(portName);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowSerialPorts();
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            await SendAsync().ConfigureAwait(true);
        }

        private async Task SendAsync()
        {
            int startTickCount = 0;
            int endTickCount = 0;

            sendButton.Enabled = false;

            byte[] data = input.BinaryValue;
            if (data.Length <= 0)
            {
                MessageBox.Show(this, "Nothing to send.", this.Text);
                sendButton.Enabled = true;
                return;
            }

            // this will run in a worker thread
            try
            {
                await Task.Run(delegate {
                    port.WriteTimeout = timeOut.Checked ? (int)timeOutValue.Value * 1000
                        : SerialPort.InfiniteTimeout;
                    startTickCount = Environment.TickCount;
                    port.Write(data, 0, data.Length);
                    endTickCount = Environment.TickCount;
                }).ConfigureAwait(true);
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(this, ex.Message);
                return;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(this, ex.Message);
                CloseSerialPort();
                return;
            }

            // caller's context gets resumed at this point
            if (endTickCount != 0)
            {
                status.Text = String.Format("Sent {0} byte(s) in {1} milliseconds",
                      data.Length, endTickCount - startTickCount);
            }

            sendButton.Enabled = true;
        }

        private void ShowReceivedData(byte[] data, int length)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate {
                    ShowReceivedData(data, length);
                });
                return;
            }

            outputText.AppendBinary(data, length);
            if (outputText.AppendBinaryChecked)
            {
                outputText.AppendText(Environment.NewLine);
                outputText.AppendText(Environment.NewLine);
            }
        }

        private void CreateSerialPort()
        {
            port = new SerialPort(serialPortName.Text);
            port.Encoding = ASCIIEncoding.ASCII;
            if (!baudRate.Text.Equals(string.Empty))
            {
                port.BaudRate = int.Parse(baudRate.Text);
            }
            else
            {
                baudRate.Text = port.BaudRate.ToString();
            }

            try
            {
                port.Open();
                port.DataReceived += Port_DataReceived;
                port.ErrorReceived += Port_ErrorReceived;
            }
            catch
            {
                MessageBox.Show("Invalid port name or unknown error.");
                port = null;
                open.Enabled = true;
                return;
            }

            serialPortName.Enabled = false;
            baudRate.Enabled = false;
            open.Enabled = false;
            sendButton.Enabled = true;
            close.Enabled = true;
            refresh.Enabled = false;
        }

        void Port_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            // we'll do nothing with error
        }

        void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                byte[] data = new byte[port.BytesToRead];
                int readLength = port.Read(data, 0, data.Length);
                ShowReceivedData(data, readLength);
            }
            catch
            {
                return;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseSerialPort();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            if (string.Empty.Equals(serialPortName.Text))
            {
                MessageBox.Show("Need a port name to Open.");
                return;
            }

            if (port == null)
            {
                CreateSerialPort();
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            serialPortName.Text = "";
            ShowSerialPorts();
            if (serialPortName.Items.Count > 0)
            {
                serialPortName.SelectedIndex = 0;
            }
        }

        private void CloseSerialPort()
        {
            try
            {
                if (port != null && port.IsOpen)
                {
                    port.Close();
                }
                port = null;
            }
            catch(IOException)
            {
                // don't need user to do anything
            }

            close.Enabled = false;
            sendButton.Enabled = false;
            open.Enabled = true;
            refresh.Enabled = true;
            serialPortName.Enabled = true;
            baudRate.Enabled = true;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            CloseSerialPort();
        }

        private void TimeOut_CheckedChanged(object sender, EventArgs e)
        {
            timeOutValue.Enabled = timeOut.Checked;
            if (port != null)
            {
                port.WriteTimeout = timeOut.Checked ? (int)timeOutValue.Value * 1000
                    : SerialPort.InfiniteTimeout;
            }
        }

        private void SerialPortName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string description = string.Empty;
            string pnpDeviceID = string.Empty;
            string query = $"SELECT * FROM WIN32_SerialPort WHERE DeviceID=\"{serialPortName.Text}\"";
            using (var searcher = new ManagementObjectSearcher(query))
            {
                var ports = searcher.Get();
                foreach (var port in ports)
                {
                    description = port.Properties["Description"].Value.ToString();
                    pnpDeviceID = port.Properties["PNPDeviceID"].Value.ToString();
                    break;
                }
            }
            outputText.AppendText($"{description}");
            outputText.AppendText($"{Environment.NewLine}");
            outputText.AppendText($"{pnpDeviceID}");
            outputText.AppendText($"{Environment.NewLine}");
            outputText.AppendText($"{Environment.NewLine}");
        }
    }
}