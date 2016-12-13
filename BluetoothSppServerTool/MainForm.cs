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
                listener.BeginAcceptBluetoothClient(acceptBluetoothClient, null);
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

        private void acceptBluetoothClient(IAsyncResult ar)
        {
            if (client != null)
                Stop(false);

            if (listener == null)
            {
                Stop(true);
                return;
            }

            client = listener.EndAcceptBluetoothClient(ar);
            stream = client.GetStream();
            ReadAsync(stream);

            Invoke(new MethodInvoker(delegate
            {
                status.Text = string.Format("Connected to {0}.", client.RemoteMachineName);
                sendButton.Enabled = true;
            }));

            listener.BeginAcceptBluetoothClient(acceptBluetoothClient, null);
        }

        private async void ReadAsync(Stream stream)
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
                    if (this.Visible) { // we're not being closed
                        Invoke(new MethodInvoker(delegate
                        {
                            Stop(false);
                        }));
                    }
                    break;
                }
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            Stop(true);
        }

        private void Stop(bool stopListener)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate() 
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
                catch { }
                startButton.Enabled = true;
                stopButton.Enabled = false;
                sendButton.Enabled = false;
                status.Text = string.Format("Stopped.");
            }
        }

        private async void SendAsync(byte[] buffer)
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
                    Stop(false);
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
            SendAsync(input.Bytes);
        }
    }
}
