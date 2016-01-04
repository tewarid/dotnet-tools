using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace TcpTool
{
    public partial class MainForm : Form
    {
        TcpClient tcpClient;
        Stream stream;
        delegate void ShowReceivedDataDelegate(byte[] data, int length);
        TcpListener listener;
        byte[] buffer = new byte[100];

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (listener != null && tcpClient == null)
            {
                MessageBox.Show(this, "Listening for incoming TCP connection. Try again after a client has connected.", this.Text);
                return;
            }

            if (tcpClient == null || !tcpClient.Connected)
            {
                CreateTcpClient();
                if (tcpClient == null || !tcpClient.Connected) return;
            }

            sendButton.Enabled = false;

            int tickcount = 0;
            if (input.Length <= 0)
            {
                MessageBox.Show(this, "Nothing to send.", this.Text);
            }
            else
            {
                try
                {
                    tickcount = Environment.TickCount;
                    stream.Write(input.Bytes, 0, input.Length);
                    tickcount = Environment.TickCount - tickcount;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                }
            }

            status.Text = String.Format("Sent {0} byte(s) in {1} milliseconds", 
                input.Length, tickcount);
            sendButton.Enabled = true;
        }

        private void ShowReceivedData(byte[] data, int length)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    ShowReceivedData(data, length);
                });
                return;
            }

            outputText.Append(data, length);
            outputText.AppendText(Environment.NewLine, true);
            outputText.AppendText(Environment.NewLine, true);
        }

        private void CreateTcpClient()
        {
            if (tcpClient != null && tcpClient.Connected) return;

            try
            {
                IPEndPoint localEndPoint;
                if (!string.Empty.Equals(sourceIPAddress.Text)
                    && !string.Empty.Equals(sourcePort.Text))
                {
                    localEndPoint = new IPEndPoint(IPAddress.Parse(sourceIPAddress.Text),
                        int.Parse(sourcePort.Text));
                }
                else
                {
                    localEndPoint = new IPEndPoint(IPAddress.Any, 0);
                }
                if (tcpClient == null)
                {
                    tcpClient = new TcpClient(localEndPoint);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, this.Text);
                return;
            }

            try
            {
                if (string.Empty.Equals(destinationIPAddress.Text)
                    || string.Empty.Equals(destinationPort.Text))
                {
                    MessageBox.Show(this, "Please specify the destination IP address and/or port.", this.Text);
                    return;
                }

                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(destinationIPAddress.Text),
                    int.Parse(destinationPort.Text));
                tcpClient.Connect(remoteEndPoint);
                stream = tcpClient.GetStream();
                if (useSSL.Checked)
                {
                    SslStream ssls = new SslStream(tcpClient.GetStream(), 
                        true, ValidateCertificate);
                    ssls.AuthenticateAsClient(string.Empty);
                    stream = ssls;
                }
                stream.BeginRead(buffer, 0, buffer.Length, ReadCallback, null);
            }
            catch (Exception e)
            {
                if (tcpClient != null && tcpClient.Connected == true)
                {
                    tcpClient.Close();
                    tcpClient = null;
                    stream = null;
                }
                MessageBox.Show(this, e.Message, this.Text);
                return;
            }

            sourceIPAddress.Enabled = false;
            IPEndPoint endPoint = (IPEndPoint)tcpClient.Client.LocalEndPoint;
            sourceIPAddress.Text = endPoint.Address.ToString();
            sourcePort.Enabled = false;
            sourcePort.Text = endPoint.Port.ToString();
            listen.Enabled = false;
            destinationIPAddress.Enabled = false;
            destinationPort.Enabled = false;
            useSSL.Enabled = false;
            close.Enabled = true;
        }

        private bool ValidateCertificate(object sender, 
            X509Certificate certificate, X509Chain chain, 
            SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
            }
        }

        private void listen_Click(object sender, EventArgs e)
        {
            CreateTcpListener();
        }

        private void CreateTcpListener()
        {
            if (listener != null) return;

            try
            {
                IPEndPoint localEndPoint;
                int port = 0;
                if (!string.Empty.Equals(sourcePort.Text))
                {
                    port = int.Parse(sourcePort.Text);
                }
                if (!string.Empty.Equals(sourceIPAddress.Text))
                {
                    localEndPoint = new IPEndPoint(IPAddress.Parse(sourceIPAddress.Text),
                        port);
                }
                else
                {
                    localEndPoint = new IPEndPoint(IPAddress.Any, port);
                }
                if (listener == null)
                {
                    listener = new TcpListener(localEndPoint);
                }
                listener.Start();
                listener.BeginAcceptTcpClient(BeginAcceptCallback, null);
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, this.Text);
                return;
            }

            IPEndPoint ipEndPoint = (IPEndPoint)listener.LocalEndpoint;
            sourceIPAddress.Text = ipEndPoint.Address.ToString();
            sourcePort.Text = ipEndPoint.Port.ToString();

            listen.Enabled = false;
            sourceIPAddress.Enabled = false;
            sourcePort.Enabled = false;
            destinationIPAddress.Enabled = false;
            destinationPort.Enabled = false;
            useSSL.Enabled = false;
            close.Enabled = true;
        }

        private void BeginAcceptCallback(IAsyncResult ar)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    BeginAcceptCallback(ar);
                });
                return;
            }

            tcpClient = listener.EndAcceptTcpClient(ar);

            stream.BeginRead(buffer, 0, buffer.Length, ReadCallback, null);

            IPEndPoint ipEndPoint = (IPEndPoint)tcpClient.Client.RemoteEndPoint;
            destinationIPAddress.Text = ipEndPoint.Address.ToString();
            destinationPort.Text = ipEndPoint.Port.ToString();
        }

        private void ReadCallback(IAsyncResult ar)
        {
            if (tcpClient == null)
                return;

            try
            {
                int length = stream.EndRead(ar);
                if (length > 0)
                {
                    ShowReceivedData(buffer, length);
                    stream.BeginRead(buffer, 0, buffer.Length, ReadCallback, null);
                }
            }
            catch { }
        }

        private void close_Click(object sender, EventArgs e)
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
                tcpClient = null;
                sourceIPAddress.Enabled = true;
                sourcePort.Enabled = true;
                sourcePort.Text = "";
                destinationIPAddress.Enabled = true;
                destinationPort.Enabled = true;
                listen.Enabled = true;
            }

            if (listener != null)
            {
                listener.Stop();
                listener = null;
                listen.Enabled = true;
                sourceIPAddress.Enabled = true;
                sourcePort.Enabled = true;
                destinationIPAddress.Enabled = true;
                destinationPort.Enabled = true;
            }
            close.Enabled = false;
            useSSL.Enabled = true;
        }
    }
}
