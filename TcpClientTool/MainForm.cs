using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpClientTool
{
    public partial class MainForm : Form
    {
        TcpClient tcpClient;
        Stream stream;
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public MainForm()
        {
            InitializeComponent();
            sourceIPAddress.InterfaceDeleted += SourceIPAddress_InterfaceDeleted;
        }

        public MainForm(TcpClient tcpClient, Stream stream = null) : this()
        {
            this.tcpClient = tcpClient;
            this.stream = stream;
            if (stream == null)
            {
                this.stream = tcpClient.GetStream();
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            if (stream != null)
            {
                useSSL.Checked = stream is SslStream;
                EnableDisable(true);
                try
                {
                    await ReadAsync(cancellationTokenSource.Token).ConfigureAwait(true);
                }
                catch(ObjectDisposedException)
                {
                    // happens when form is disposed
                }
            }
        }

        private void SourceIPAddress_InterfaceDeleted(string address)
        {
            CloseTcpClient();
            sourceIPAddress.Text = string.Empty;
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            if (tcpClient == null || !tcpClient.Connected)
            {
                CreateTcpClient();
                if (tcpClient == null || !tcpClient.Connected)
                {
                    return;
                }
                await SendAsync().ConfigureAwait(true);
                await ReadAsync(cancellationTokenSource.Token)
                    .ConfigureAwait(true); // will block here till ReadAsync is done
            }
            else
            {
                await SendAsync().ConfigureAwait(true);
            }
        }

        private async Task SendAsync()
        {
            sendButton.Enabled = false;

            int tickcount = 0;
            byte[] data = input.Bytes;
            if (data.Length <= 0)
            {
                sendButton.Enabled = true;
                MessageBox.Show(this, "Nothing to send.", this.Text);
                return;
            }

            tickcount = Environment.TickCount;
            try
            {
                await stream.WriteAsync(data, 0, data.Length).ConfigureAwait(true);
            }
            catch(IOException ex)
            {
                sendButton.Enabled = true;
                MessageBox.Show(this, ex.Message, this.Text);
                CloseTcpClient();
                return;
            }
            tickcount = Environment.TickCount - tickcount;

            status.Text = String.Format("Sent {0} byte(s) in {1} milliseconds",
                data.Length, tickcount);
            sendButton.Enabled = true;
        }

        private void ShowReceivedData(byte[] data, int length)
        {
            outputText.Append(data, length);
            outputText.AppendText(Environment.NewLine, true);
            outputText.AppendText(Environment.NewLine, true);
        }

        private void CreateTcpClient()
        {
            if (tcpClient != null && tcpClient.Connected) return;

            int port = 0;
            IPAddress ipAddress = IPAddress.Any;
            if (!string.Empty.Equals(sourceIPAddress.Text))
            {
                try
                {
                    ipAddress = IPAddress.Parse(sourceIPAddress.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                    return;
                }
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

            try
            {
                tcpClient.Client.Bind(localEndPoint);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
                return;
            }

            if (string.Empty.Equals(destinationIPAddress.Text)
                || string.Empty.Equals(destinationPort.Text))
            {
                MessageBox.Show(this, "Please specify the destination IP address and/or port.", this.Text);
                return;
            }
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(destinationIPAddress.Text),
                int.Parse(destinationPort.Text));
            try
            {
                tcpClient.Connect(remoteEndPoint);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
                CloseTcpClient();
                return;
            }
            stream = tcpClient.GetStream();
            if (useSSL.Checked)
            {
                SslStream ssls = new SslStream(stream,
                    true, ValidateCertificate);
                ssls.AuthenticateAsClient(string.Empty, null, SslProtocols.Tls12, false);
                stream = ssls;
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
            CloseTcpClient();
        }

        public async Task ReadAsync(CancellationToken cancellationToken)
        {
            byte[] data = new byte[1024];

            while (true)
            {
                int length = 0;
                try
                {
                    length = await 
                        stream.ReadAsync(data, 0, data.Length, cancellationToken)
                        .ConfigureAwait(true);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                    CloseTcpClient();
                    return;
                }
                catch(ObjectDisposedException)
                {
                    CloseTcpClient();
                    return;
                }
                if (length == 0)
                {
                    break;
                }
                ShowReceivedData(data, length);
            }
        }

        private void CloseTcpClient()
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
            EnableDisable(false);
        }

        private void close_Click(object sender, EventArgs e)
        {
            CloseTcpClient();
        }

        private async void open_Click(object sender, EventArgs e)
        {
            if (tcpClient != null && tcpClient.Connected)
            {
                return;
            }
            CreateTcpClient();
            if (tcpClient == null || !tcpClient.Connected)
            {
                return;
            }
            await ReadAsync(cancellationTokenSource.Token)
                .ConfigureAwait(true); // will block here till ReadAsync is done
        }
    }
}
