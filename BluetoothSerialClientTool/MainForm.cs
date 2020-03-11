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
            try
            {
                client = new BluetoothClient();
            }
            catch(PlatformNotSupportedException ex)
            {
                MessageBox.Show(ex.Message, this.Text);
                return;
            }

            devices = client.DiscoverDevices(10, true, true, false);

            deviceList.Items.Clear();
            foreach (BluetoothDeviceInfo device in devices)
            {
                deviceList.Items.Add(device.DeviceName);
            }
        }

        private async void ConnectButton_Click(object sender, EventArgs e)
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
            deviceList.Enabled = false;
            refreshButton.Enabled = false;
            connectButton.Enabled = false;
            closeButton.Enabled = true;
            sendButton.Enabled = true;
            await ReadAsync(stream).ConfigureAwait(true);
        }

        private async Task ReadAsync(NetworkStream stream)
        {
            byte[] buffer = new byte[100];
            int length = 0;
            while (true)
            {
                try
                {
                    length = await stream.ReadAsync(buffer, 0, buffer.Length)
                        .ConfigureAwait(true);
                }
                catch
                {
                    if (this.Visible)
                    {
                        // we're not being closed
                        Stop();
                    }
                    break;
                }
                if (length == 0)
                {
                    Stop();
                    break;
                }
                outputText.AppendBinary(buffer, length);
            }
        }

        private void Stop()
        {
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

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            client.Close();
        }

        private void DeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            connectButton.Enabled = deviceList.SelectedIndex >= 0;
        }

        private async Task SendAsync(byte[] buffer)
        {
            int ticks = Environment.TickCount;
            try
            {
                await stream.WriteAsync(buffer, 0, buffer.Length)
                    .ConfigureAwait(true);
                // UI context gets resumed at this point
                ticks = Environment.TickCount - ticks;
                status.Text = String.Format("Sent {0} byte(s) in {1} milliseconds",
                    buffer.Length,ticks);
            }
            catch (Exception ex)
            {
                Stop();
                MessageBox.Show(ex.Message);
            }
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            await SendAsync(input.BinaryValue).ConfigureAwait(true);
        }
    }
}
