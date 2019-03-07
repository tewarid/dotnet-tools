using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpListenerTool
{
    public partial class MainForm : Form
    {
        private TcpListener listener;
        private static int clientNum;

        public MainForm()
        {
            InitializeComponent();
            sourceIPAddress.InterfaceDeleted += SourceIPAddress_InterfaceDeleted;
        }

        private async void Listen_Click(object sender, EventArgs e)
        {
            await CreateTcpListener().ConfigureAwait(true);
        }

        private async Task CreateTcpListener()
        {
            if (listener != null)
            {
                return;
            }

            int port = 0;
            if (!string.Empty.Equals(sourcePort.Text))
            {
                try
                {
                    port = int.Parse(sourcePort.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                    return;
                }
            }
            IPAddress address = IPAddress.Any;
            if (!string.Empty.Equals(sourceIPAddress.TextValue))
            {
                try
                {
                    address = IPAddress.Parse(sourceIPAddress.TextValue);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                    return;
                }
            }
            IPEndPoint localEndPoint = new IPEndPoint(address, port);
            listener = new TcpListener(localEndPoint);
            if(reuseAddress.Checked)
            {
                listener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            }
            IPEndPoint ipEndPoint = (IPEndPoint)listener.LocalEndpoint;
            sourceIPAddress.TextValue = ipEndPoint.Address.ToString();
            sourcePort.Text = ipEndPoint.Port.ToString();
            try
            {
                listener.Start();
            }
            catch (SocketException ex)
            {
                listener = null;
                MessageBox.Show(this, ex.Message, this.Text);
                return;
            }
            EnableDisable(false);

            await AcceptTcpClient().ConfigureAwait(true);
        }

        private async Task AcceptTcpClient()
        {
            while(true)
            {
                TcpClient tcpClient;

                try
                {
                    tcpClient = await listener.AcceptTcpClientAsync().ConfigureAwait(true);
                }
                catch(SocketException ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                    break;
                }
                catch(ObjectDisposedException)
                {
                    break;
                }

                ShowClientForm(tcpClient);
            }
        }

        private void ShowClientForm(TcpClient tcpClient)
        {
            Stream stream;

            if (useSSLListener.Checked)
            {
                SslStream ssls = new SslStream(tcpClient.GetStream(), true,
                    (sender, certificate, chain, sslPolicyErrors) =>
                    {
                        return true;
                    });
                X509Certificate2 cert;
                try
                {
                    cert = new X509Certificate2(pfxPath.Text, pfxPassphrase.Text);
                }
                catch(CryptographicException ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                    return;
                }
                try
                {
                    ssls.AuthenticateAsServer(cert,
                        requestClientCertificate.Checked, SslProtocols.Tls12,
                        false);
                }
                catch(IOException)
                {
                    return;
                }
                stream = ssls;
            }
            else
            {
                stream = tcpClient.GetStream();
            }

            int value = Interlocked.Increment(ref clientNum);
            Form newForm = new TcpClientTool.MainForm(tcpClient, stream)
            {
                Text = "TCP Client " + (value)
            };
            newForm.Show(this);
        }

        private void BrowseForPfx_Click(object sender, EventArgs e)
        {
            DialogResult r = openFileDialog.ShowDialog();
            if (r == DialogResult.OK)
            {
                pfxPath.Text = openFileDialog.FileName;
            }
        }

        private void UseSSLListener_CheckedChanged(object sender, EventArgs e)
        {
            pfxPath.Enabled = useSSLListener.Checked;
            browseForPfx.Enabled = useSSLListener.Checked;
            pfxPassphrase.Enabled = useSSLListener.Checked;
            requestClientCertificate.Enabled = useSSLListener.Checked;
        }

        private void StopListener_Click(object sender, EventArgs e)
        {
            StopListener();
        }

        private void StopListener()
        {
            if (listener == null)
            {
                return;
            }

            try
            {
                listener.Stop();
            }
            catch (SocketException ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
            }
            listener = null;
            EnableDisable(true);
        }

        private void SourceIPAddress_InterfaceDeleted()
        {
            if (listener != null)
            {
                StopListener();
                sourceIPAddress.TextValue = string.Empty;
            }
        }

        private void EnableDisable(bool enable)
        {
            listen.Enabled = enable;
            stopListener.Enabled = !enable;
            sourceIPAddress.Enabled = enable;
            reuseAddress.Enabled = enable;
            sourcePort.Enabled = enable;
            useSSLListener.Enabled = enable;
            pfxPath.Enabled = enable;
            pfxPassphrase.Enabled = enable;
            requestClientCertificate.Enabled = enable;
        }
    }
}
