using Common;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace BluetoothSerialServerTool
{
    [MainForm(Name = "Bluetooth Serial Server Tool")]
    public partial class MainForm : Form
    {
        private StreamSocket socket;
        private RfcommServiceProvider rfcommProvider;
        private StreamSocketListener socketListener;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            await Start();
        }

        private async Task Start()
        {
            try
            {
                rfcommProvider = await RfcommServiceProvider.CreateAsync(RfcommServiceId.SerialPort);
                socketListener = new StreamSocketListener();
                socketListener.ConnectionReceived += OnConnectionReceived;
                await socketListener.BindServiceNameAsync(rfcommProvider.ServiceId.AsString(),
                    SocketProtectionLevel.BluetoothEncryptionAllowNullAuthentication);
                rfcommProvider.StartAdvertising(socketListener, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Could not start listener. {ex.Message}");
                return;
            }

            status.Text = "Listening for connections...";
            startButton.Enabled = false;
            stopButton.Enabled = true;
        }

        private async void OnConnectionReceived(StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args)
        {
            if (socket != null)
            {
                Stop(false);
            }

            if (socketListener == null)
            {
                Stop(true);
                return;
            }

            socket = args.Socket;
            
            var remoteDevice = await BluetoothDevice.FromHostNameAsync(socket.Information.RemoteHostName);

            BeginInvoke(new MethodInvoker(() =>
            {
                status.Text = $"Connected to {remoteDevice.Name}.";
                sendButton.Enabled = true;
            }));
            await ReadAsync(socket.InputStream);
        }

        private async Task ReadAsync(IInputStream stream)
        {
            IBuffer readBuffer = new Windows.Storage.Streams.Buffer(1024);
            while (true)
            {
                IBuffer buffer;
                try
                {
                    buffer = await stream.ReadAsync(readBuffer, 1024, InputStreamOptions.Partial);
                }
                catch
                {
                    Stop(false);
                    return;
                }
                if (buffer.Length != 0)
                {
                    var data = new byte[buffer.Length];
                    using (DataReader dataReader = DataReader.FromBuffer(buffer))
                    {
                        dataReader.ReadBytes(data);
                        BeginInvoke(new MethodInvoker(() =>
                        {
                            outputText.AppendBinary(data, data.Length);
                        }));
                    }
                }
                else
                {
                    status.Text = "Disconnected.";
                    Stop(false);
                    return;
                }
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            Stop(true);
        }

        private void Stop(bool stopListener)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate
                {
                    Stop(stopListener);
                }));
                return;
            }

            if (rfcommProvider != null)
            {
                rfcommProvider.StopAdvertising();
                rfcommProvider = null;
            }

            if (socket != null)
            {
                socket.Dispose();
                socket = null;
            }

            if (stopListener && socketListener != null)
            {
                socketListener.Dispose();
                socketListener = null;

                startButton.Enabled = true;
                stopButton.Enabled = false;
                status.Text = "Stopped.";
            }
            sendButton.Enabled = false;
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
                    Stop(false);
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            ticks = Environment.TickCount - ticks;
            status.Text = $"Sent {data.Length} byte(s) in {ticks} milliseconds";
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            await SendAsync(input.BinaryValue);
        }
    }
}
