using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.IO;
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
            if (listener == null) return;
            client = listener.EndAcceptBluetoothClient(ar);
            stream = client.GetStream();
            ReadAsync(stream);
            BeginInvoke(new MethodInvoker(delegate
            {
                status.Text = string.Format("Connected to {0}.", client.RemoteMachineName);
                sendButton.Enabled = true;
            }));
        }

        private async void ReadAsync(Stream stream)
        {
            byte[] buffer = new byte[100];
            while (true)
            {
                try
                {
                    int length = await stream.ReadAsync(buffer, 0, buffer.Length);
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        outputText.Append(buffer, length);
                    }));
                }
                catch
                {
                    if (this.Visible) { // we're not being closed
                        BeginInvoke(new MethodInvoker(delegate
                        {
                            Stop();
                        }));
                    }
                    break;
                }
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            Stop();
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
                client = null;
            }
            if (listener != null)
            {
                BluetoothListener l = listener;
                listener = null; // We want AsyncCallback to know we're done,
                try
                {
                    l.Stop();    // because it gets invoked when we call Stop.
                }
                catch { }
            }
            startButton.Enabled = true;
            stopButton.Enabled = false;
            sendButton.Enabled = false;
            status.Text = string.Format("Stopped.");
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            byte[] buffer = input.Bytes;
            try
            {
                stream.WriteAsync(buffer, 0, buffer.Length);
            }
            catch
            {
                Stop();
            }
        }
    }
}
