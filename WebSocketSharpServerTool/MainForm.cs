using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using WebSocketSharp.Server;

namespace WebSocketServerTool
{
    public partial class MainForm : Form
    {
        WebSocketServer server;

        public MainForm()
        {
            InitializeComponent();
        }

        private void CreateServer(Uri uri, string thumbprint = null)
        {
            server = new WebSocketServer(uri.ToString());

            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certificates = 
                store.Certificates.Find(X509FindType.FindByThumbprint,
                thumbprint, false);
            if (certificates.Count > 0)
            {
                server.SslConfiguration.ServerCertificate = certificates[0];
            };
            store.Close();

            server.AddWebSocketService<ServiceBehavior>("/");

            server.Start();
        }

        private void open_Click(object sender, System.EventArgs e)
        {
            if (server != null) return;

            try
            {
                CreateServer(new Uri(url.Text), this.thumbprint.Text);

                start.Enabled = false;
                stop.Enabled = true;
                thumbprint.ReadOnly = true;
                url.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
                if (server != null)
                {
                    server.Stop();
                    server = null;
                }
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            if (server == null) return;

            server.Stop();
            server = null;

            start.Enabled = true;
            stop.Enabled = false;
            thumbprint.ReadOnly = false;
            url.ReadOnly = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
