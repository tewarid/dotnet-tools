using InTheHand.Net.Sockets;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BluetoothSerialClientTool
{
    public partial class MainForm : Form
    {
        private readonly Guid MyServiceUuid = new Guid("{00001101-0000-1000-8000-00805F9B34FB}");
        // Android uses the well known SPP GUID 00001101-0000-1000-8000-00805F9B34FB

        BluetoothClient client;
        BluetoothDeviceInfo[] devices;
        NetworkStream stream;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            client = new BluetoothClient();
            devices = client.DiscoverDevices(10, true, true, false);

            deviceList.Items.Clear();
            foreach (BluetoothDeviceInfo device in devices)
            {
                deviceList.Items.Add(device.DeviceName);
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (deviceList.SelectedIndex >= devices.Length)
            {
                return;
            }
            try
            {
                client.Connect(devices[deviceList.SelectedIndex].DeviceAddress, MyServiceUuid);
                stream = client.GetStream();
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
                return;
            }
            Task t = ReadAsync(stream);
            deviceList.Enabled = false;
            refreshButton.Enabled = false;
            connectButton.Enabled = false;
            closeButton.Enabled = true;
            sendButton.Enabled = true;
        }

        private async Task ReadAsync(NetworkStream stream)
        {
            byte[] buffer = new byte[100];
            while (true)
            {
                try
                {
                    int length = await stream.ReadAsync(buffer, 0, buffer.Length);
                    Invoke(new MethodInvoker(delegate
                    {
                        outputText.Append(buffer, length);
                    }));
                }
                catch
                {
                    if (this.Visible)
                    { // we're not being closed
                        Invoke(new MethodInvoker(delegate
                        {
                            Stop();
                        }));
                    }
                    break;
                }
            }
        }

        private void Stop()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    Stop();
                }));
                return;
            }

            if (stream != null)
            {
                stream.Close();
                stream = null;
            }
            if (client != null)
            {
                client.Close();
            }
            deviceList.Enabled = true;
            refreshButton.Enabled = true;
            connectButton.Enabled = false;
            closeButton.Enabled = false;
            sendButton.Enabled = false;
            Initialize();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            client.Close();
        }

        private void deviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            connectButton.Enabled = deviceList.SelectedIndex >= 0;
        }

        private async Task SendAsync(byte[] buffer)
        {
            int startTickCount = 0;
            int endTickCount = 0;

            // this will run in a worker thread
            await Task.Run(delegate
            {
                try
                {
                    startTickCount = Environment.TickCount;
                    stream.Write(buffer, 0, buffer.Length);
                    endTickCount = Environment.TickCount;
                }
                catch (Exception ex)
                {
                    Stop();
                    MessageBox.Show(ex.Message);
                }
            });

            // main thread gets resumed at this point
            // so invoke not required
            if (endTickCount != 0)
                status.Text = String.Format("Sent {0} byte(s) in {1} milliseconds",
                    buffer.Length, endTickCount - startTickCount);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            Task t = SendAsync(input.Bytes);
        }
    }
}
