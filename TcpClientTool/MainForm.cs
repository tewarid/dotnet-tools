using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace TcpClientTool
{
    public partial class MainForm : Form
    {
        TcpClient tcpClient;
        Stream stream;
        delegate void ShowReceivedDataDelegate(byte[] data, int length);
        byte[] buffer = new byte[10000];

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(TcpClient tcpClient, Stream stream = null) : this()
        {
            if (stream == null)
            {
                this.stream = tcpClient.GetStream();
            }
            else
            {
                this.stream = stream;
            }
            this.tcpClient = tcpClient;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            sourceIPAddress.InterfaceDeleted += SourceIPAddress_InterfaceDeleted;
            if (stream != null)
            {
                useSSL.Checked = stream is SslStream;
                EnableDisable(true);
                stream.BeginRead(buffer, 0, buffer.Length, ReadCallback, null);
            }
        }

        private void SourceIPAddress_InterfaceDeleted(string address)
        {
            if (sourceIPAddress.Text.Equals(address))
            {
                CloseTcpClient();
                sourceIPAddress.Text = string.Empty;
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (tcpClient == null || !tcpClient.Connected)
            {
                CreateTcpClient();
                if (tcpClient == null || !tcpClient.Connected) return;
            }

            sendButton.Enabled = false;

            int tickcount = 0;
            byte[] data = input.Bytes;
            if (data.Length <= 0)
            {
                MessageBox.Show(this, "Nothing to send.", this.Text);
            }
            else
            {
                try
                {
                    tickcount = Environment.TickCount;
                    stream.Write(data, 0, data.Length);
                    tickcount = Environment.TickCount - tickcount;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                }
            }

            status.Text = String.Format("Sent {0} byte(s) in {1} milliseconds",
                data.Length, tickcount);
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
                int port = 0;
                IPAddress ipAddress = IPAddress.Any;
                if (!string.Empty.Equals(sourceIPAddress.Text))
                {
                    ipAddress = IPAddress.Parse(sourceIPAddress.Text);
                }
                if(!string.Empty.Equals(sourcePort.Text))
                {
                    port = int.Parse(sourcePort.Text);
                }
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
                tcpClient = new TcpClient();
                if (reuseAddress.Checked)
                {
                    tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket,
                        SocketOptionName.ReuseAddress, true);
                }
                tcpClient.Client.Bind(localEndPoint);
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, this.Text);
                return;
            }

            if (string.Empty.Equals(destinationIPAddress.Text)
                || string.Empty.Equals(destinationPort.Text))
            {
                MessageBox.Show(this, "Please specify the destination IP address and/or port.", this.Text);
                return;
            }

            try
            {
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
                if (tcpClient != null)
                {
                    if (tcpClient.Connected)
                    {
                        tcpClient.Close();
                    }
                    tcpClient = null;
                    stream = null;
                }
                MessageBox.Show(this, e.Message, this.Text);
                return;
            }

            EnableDisable(true);
        }

        private void EnableDisable(bool connected)
        {
            IPEndPoint localEndPoint = connected ? 
                (IPEndPoint)tcpClient.Client.LocalEndPoint : null;
            sourceIPAddress.Text = connected ? 
                localEndPoint.Address.ToString() : sourceIPAddress.Text;
            sourcePort.Text = connected ? 
                localEndPoint.Port.ToString() : sourcePort.Text;
            sourceIPAddress.Enabled = !connected;
            sourcePort.Enabled = !connected;
            reuseAddress.Enabled = !connected;
            IPEndPoint remoteEndPoint = connected ? 
                (IPEndPoint)tcpClient.Client.RemoteEndPoint : null;
            destinationIPAddress.Text = connected ? 
                remoteEndPoint.Address.ToString() : destinationIPAddress.Text;
            destinationPort.Text = connected ? 
                remoteEndPoint.Port.ToString() : destinationPort.Text;
            destinationIPAddress.Enabled = !connected;
            destinationPort.Enabled = !connected;
            useSSL.Enabled = !connected;
            close.Enabled = connected;
            open.Enabled = !connected;
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
                }
                stream.BeginRead(buffer, 0, buffer.Length, ReadCallback, null);
            }
            catch(IOException e)
            {
                BeginInvoke((MethodInvoker)delegate () {
                    CloseTcpClient();
                    MessageBox.Show(this, e.Message, this.Text);
                });
            }
            catch
            {
            }
        }

        private void CloseTcpClient()
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
                tcpClient = null;
            }
            EnableDisable(false);
        }

        private void close_Click(object sender, EventArgs e)
        {
            CloseTcpClient();
        }

        private void open_Click(object sender, EventArgs e)
        {
            if (tcpClient == null || !tcpClient.Connected)
            {
                CreateTcpClient();
            }
        }
    }
}
