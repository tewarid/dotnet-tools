using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace TcpListenerTool
{
    public partial class MainForm : Form
    {
        TcpListener listener;
        int clientNum = 0;

        public MainForm()
        {
            InitializeComponent();
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
                if(reuseAddress.Checked)
                {
                    listener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                }
                listener.Start();
                listener.BeginAcceptTcpClient(BeginAcceptCallback, null);
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, this.Text);
                listener = null;
                return;
            }

            IPEndPoint ipEndPoint = (IPEndPoint)listener.LocalEndpoint;
            sourceIPAddress.Text = ipEndPoint.Address.ToString();
            sourcePort.Text = ipEndPoint.Port.ToString();

            listen.Enabled = false;
            stopListener.Enabled = true;
            sourceIPAddress.Enabled = false;
            sourcePort.Enabled = false;
            reuseAddress.Enabled = false;
            useSSLListener.Enabled = false;
        }

        private bool ValidateCertificate(object sender,
            X509Certificate certificate, X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private void BeginAcceptCallback(IAsyncResult ar)
        {
            TcpClient tcpClient;

            try
            {
                tcpClient = listener.EndAcceptTcpClient(ar);
            }
            catch
            {
                return;
            }

            listener.BeginAcceptTcpClient(BeginAcceptCallback, null);

            ShowClientForm(tcpClient);
        }

        private void ShowClientForm(TcpClient tcpClient)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    ShowClientForm(tcpClient);
                });
                return;
            }

            Stream stream;

            if (useSSLListener.Checked)
            {
                SslStream ssls = new SslStream(tcpClient.GetStream(),
                    true, ValidateCertificate);
                X509Certificate2 cert = new X509Certificate2(pfxPath.Text, "");
                ssls.AuthenticateAsServer(cert);
                stream = ssls;
            }
            else
            {
                stream = tcpClient.GetStream();
            }

            Form newForm = new TcpClientTool.MainForm(tcpClient, stream);
            newForm.Text = "TCP Client " + (++clientNum);
            newForm.Show(this);
        }

        private void browseForPfx_Click(object sender, EventArgs e)
        {
            DialogResult r = openFileDialog.ShowDialog();
            if (r == DialogResult.OK)
            {
                pfxPath.Text = openFileDialog.FileName;
            }
        }

        private void useSSLListener_CheckedChanged(object sender, EventArgs e)
        {
            pfxPath.Enabled = useSSLListener.Checked;
            browseForPfx.Enabled = useSSLListener.Checked;
        }

        private void stopListener_Click(object sender, EventArgs e)
        {
            StopListener();
        }

        private void StopListener()
        {
            if (listener != null)
            {
                listener.Stop();
                listener = null;
                listen.Enabled = true;
                stopListener.Enabled = false;
                sourceIPAddress.Enabled = true;
                reuseAddress.Enabled = true;
                sourcePort.Enabled = true;
                useSSLListener.Enabled = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            sourceIPAddress.InterfaceDeleted += SourceIPAddress_InterfaceDeleted;
        }

        private void SourceIPAddress_InterfaceDeleted(string address)
        {
            if (sourceIPAddress.Text.Equals(address))
            {
                StopListener();
                sourceIPAddress.Text = string.Empty;
            }
        }
    }
}
