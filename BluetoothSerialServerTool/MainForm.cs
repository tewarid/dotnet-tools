using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BluetoothSppServerTool
{
    public partial class MainForm : Form
    {
        private readonly Guid MyServiceUuid = new Guid("{00001101-0000-1000-8000-00805F9B34FB}");
        // Android uses the well known SPP GUID 00001101-0000-1000-8000-00805F9B34FB

        BluetoothListener listener;
        BluetoothClient client;
        Stream stream;

        public MainForm()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            try
            {
                listener = new BluetoothListener(MyServiceUuid); // Listen on primary radio
                listener.Start();
                listener.BeginAcceptBluetoothClient(AcceptBluetoothClient, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("Could not start listener. {0}", ex.Message));
                return;
            }

            status.Text = string.Format("Listening at {0}, HCI version {1}...", 
                BluetoothRadio.PrimaryRadio.Name, BluetoothRadio.PrimaryRadio.HciVersion);
            startButton.Enabled = false;
            stopButton.Enabled = true;
        }

        private void AcceptBluetoothClient(IAsyncResult ar)
        {
            if (client != null)
            {
                Stop(false);
            }

            if (listener == null)
            {
                Stop(true);
                return;
            }

            client = listener.EndAcceptBluetoothClient(ar);
            stream = client.GetStream();

            BeginInvoke(new MethodInvoker(async delegate
            {
                status.Text = string.Format("Connected to {0}.", client.RemoteMachineName);
                sendButton.Enabled = true;
                await ReadAsync(stream).ConfigureAwait(true);
            }));

            listener.BeginAcceptBluetoothClient(AcceptBluetoothClient, null);
        }

        private async Task ReadAsync(Stream stream)
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
                catch(ObjectDisposedException)
                {
                    if (this.Visible)
                    {
                        Stop(false);
                    }
                    break;
                }

                if (length == 0)
                {
                    // Done
                    Stop(false);
                    break;
                }

                // UI context resumes here
                outputText.Append(buffer, length);
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

            if (stream != null)
            {
                stream.Close();
                stream = null;
            }
            if (client != null)
            {
                client.Close();
                client = null;
            }
            if (stopListener && listener != null)
            {
                BluetoothListener l = listener;
                listener = null; // We want AsyncCallback to know we're done,
                try
                {
                    l.Stop();    // because it gets invoked when we call Stop.
                }
                catch
                {
                    // nothing for program or user to do
                }
                startButton.Enabled = true;
                stopButton.Enabled = false;
                status.Text = "Stopped.";
            }
            sendButton.Enabled = false;
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
                    buffer.Length, ticks);
            }
            catch (Exception ex)
            {
                Stop(false);
                MessageBox.Show(ex.Message);
            }
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            await SendAsync(input.Bytes).ConfigureAwait(true);
        }
    }
}
