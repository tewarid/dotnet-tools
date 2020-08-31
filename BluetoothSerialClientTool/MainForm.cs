using Common;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Devices.Enumeration;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace BluetoothSerialClientTool
{
    [MainForm(Name = "Bluetooth Serial Client Tool")]
    public partial class MainForm : Form
    {
        StreamSocket socket;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadDeviceList();
        }

        private async Task LoadDeviceList()
        {
            deviceList.Items.Clear();
            var list = await DeviceInformation.FindAllAsync(RfcommDeviceService.GetDeviceSelector(RfcommServiceId.SerialPort));
            foreach(var info in list)
            {
                var device = await BluetoothDevice.FromIdAsync(info.Id);
                var item = new ComboboxItem<string>(device.Name, info.Id);
                deviceList.Items.Add(item);
            }
        }

        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            if (deviceList.SelectedIndex == -1)
            {
                return;
            }
            try
            {
                ComboboxItem<string> item = (ComboboxItem<string>)deviceList.SelectedItem;
                RfcommDeviceService rfcommDeviceService = await RfcommDeviceService.FromIdAsync(item.Value);
                socket = new StreamSocket();
                await socket.ConnectAsync(rfcommDeviceService.ConnectionHostName, rfcommDeviceService.ConnectionServiceName);
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
            await ReadAsync(socket).ConfigureAwait(true);
        }

        private async Task ReadAsync(StreamSocket socket)
        {
            IBuffer readBuffer = new Windows.Storage.Streams.Buffer(1024);
            while (true)
            {
                IBuffer buffer;
                try
                {
                    buffer = await socket.InputStream.ReadAsync(readBuffer, 1024, InputStreamOptions.Partial);
                }
                catch
                {
                    await Stop();
                    return;
                }
                if (buffer.Length != 0)
                {
                    var data = new byte[buffer.Length];
                    using (DataReader dataReader = DataReader.FromBuffer(buffer))
                    {
                        dataReader.ReadBytes(data);
                        outputText.AppendBinary(data, data.Length);
                    }
                }
                else
                {
                    status.Text = "Disconnected.";
                    await Stop();
                    return;
                }
            }
        }

        private async Task Stop()
        {
            if (socket != null)
            {
                socket.Dispose();
                socket = null;
            }
            deviceList.Enabled = true;
            refreshButton.Enabled = true;
            connectButton.Enabled = false;
            closeButton.Enabled = false;
            sendButton.Enabled = false;
            await LoadDeviceList();
        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            await LoadDeviceList();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            socket.Dispose();
        }

        private void DeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            connectButton.Enabled = deviceList.SelectedIndex >= 0;
        }

        private async Task SendAsync(byte[] data)
        {
            int ticks = Environment.TickCount;
            using (DataWriter dataWriter = new DataWriter())
            {
                dataWriter.WriteBytes(data);
                IBuffer buffer = dataWriter.DetachBuffer();
                try
                {
                    await socket.OutputStream.WriteAsync(buffer);
                }
                catch (Exception ex)
                {
                    await Stop();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            ticks = Environment.TickCount - ticks;
            status.Text = $"Sent {data.Length} byte(s) in {ticks} milliseconds";
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            await SendAsync(input.BinaryValue).ConfigureAwait(true);
        }
    }
}
