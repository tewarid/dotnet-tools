using System;
using System.IO.Ports;
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

        private void sendButton_Click(object sender, EventArgs e)
        {
            SendAsync();
        }

        private async void SendAsync()
        {
            int startTickCount = 0;
            int endTickCount = 0;

            sendButton.Enabled = false;

            if (input.Length <= 0)
            {
                MessageBox.Show(this, "Nothing to send.", this.Text);
            }
            else
            {
                try
                {
                    // this will run in a worker thread
                    await Task.Run(delegate {
                        startTickCount = Environment.TickCount;
                        port.Write(input.Bytes, 0, input.Length);
                        endTickCount = Environment.TickCount;
                    });

                    // main thread gets resumed at this point
                    // so invoke not required
                    status.Text = String.Format("Sent {0} byte(s) in {1} milliseconds", 
                        input.Length, endTickCount - startTickCount);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

            if (viewInHex.Checked)
            {
                StringBuilder sb = new StringBuilder(length);
                foreach (byte b in data)
                {
                    sb.Append(string.Format("{0:X2} ", b));
                }
                outputText.AppendText(sb.ToString());
                outputText.AppendText(Environment.NewLine);
                outputText.AppendText(Environment.NewLine);
            }
            else
            {
                StringBuilder output = new StringBuilder();
                for (int i = 0; i < length; i++)
                {
                    switch (data[i])
                    {
                        case (byte)'\r':
                            output.Append(Environment.NewLine);
                            break;

                        case (byte)'\n':
                            if (i > 0 && data[i - 1] != '\r') output.Append(Environment.NewLine);
                            break;

                        default:
                            // remove special char
                            if (data[i] < ' ' || data[i] > '~')
                                output.Append('.');
                            else
                                output.Append((char)data[i]);
                            break;
                    }
                }
                outputText.AppendText(output.ToString());
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
                port.WriteTimeout = timeOut.Checked ? (int)timeOutValue.Value * 1000
                    : SerialPort.InfiniteTimeout;
                port.DataReceived += port_DataReceived;
                port.ErrorReceived += port_ErrorReceived;
            }
            catch
            {
                MessageBox.Show("Invalid port name or unknown error.");
                port = null;
                openButton.Enabled = true;
                return;
            }

            serialPortName.Enabled = false;
            baudRate.Enabled = false;
            openButton.Enabled = false;
            sendButton.Enabled = true;
            closeButton.Enabled = true;
            refreshButton.Enabled = false;
        }

        void port_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            CloseSerialPort();
        }

        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
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

        private void clearButton_Click(object sender, EventArgs e)
        {
            outputText.Clear();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (port != null)
            {
                try
                {
                    port.Close();
                    port = null;
                }
                catch
                {
                    //
                }
            }
        }

        private void openButton_Click(object sender, EventArgs e)
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

        private void refreshButton_Click(object sender, EventArgs e)
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
                if (port.IsOpen)
                {
                        port.Close();
                        port = null;
                }
            }
            catch
            {
                port = null;
            }

            closeButton.Enabled = false;
            sendButton.Enabled = false;
            openButton.Enabled = true;
            refreshButton.Enabled = true;
            serialPortName.Enabled = true;
            baudRate.Enabled = true;
            timeOut.Checked = false;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            CloseSerialPort();
        }

        private void timeOut_CheckedChanged(object sender, EventArgs e)
        {
            timeOutValue.Enabled = timeOut.Checked;
            if (port != null)
            {
                port.WriteTimeout = timeOut.Checked ? (int)timeOutValue.Value * 1000
                    : SerialPort.InfiniteTimeout;
            }
        }
    }
}