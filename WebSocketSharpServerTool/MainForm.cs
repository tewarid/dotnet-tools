using System;
using System.Security;
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

        private void CreateServer(Uri uri, string thumbprint = null, string pfxPath = null, string pfxPassword = null)
        {
            server = new WebSocketServer(uri.GetLeftPart(System.UriPartial.Authority));

            if (!string.IsNullOrEmpty(pfxPath))
            {
                server.SslConfiguration.ServerCertificate = 
                    new X509Certificate2(pfxPath, pfxPassword);
            }
            else
            {
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
            }

            server.AddWebSocketService<ServiceBehavior>(uri.AbsolutePath);

            server.Start();
        }

        private void start_Click(object sender, System.EventArgs e)
        {
            if (server != null) return;

            try
            {
                if (pfxFileOption.Checked)
                {
                    CreateServer(new Uri(url.Text), pfxPath: this.pfxPath.Text, 
                        pfxPassword: this.pfxPassword.Text);
                }
                else
                {
                    CreateServer(new Uri(url.Text), this.thumbprint.Text);
                }
                LockControls(true);
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

        private void stop_Click(object sender, EventArgs e)
        {
            if (server == null) return;

            server.Stop();
            server = null;
            LockControls(false);
        }

        private void browseForPfx_Click(object sender, EventArgs e)
        {
            DialogResult r = openFileDialog.ShowDialog();
            if (r == DialogResult.OK)
            {
                pfxPath.Text = openFileDialog.FileName;
            }
        }

        private void pfxFileOption_CheckedChanged(object sender, EventArgs e)
        {
            EnablePfxControls(pfxFileOption.Checked);
        }

        private void EnablePfxControls(bool enabled)
        {
            pfxPath.Enabled = enabled;
            browseForPfx.Enabled = enabled;
            pfxPassword.Enabled = enabled;
            thumbprint.Enabled = !enabled;
        }

        private void LockControls(bool locked)
        {
            start.Enabled = !locked;
            stop.Enabled = locked;
            thumbprint.ReadOnly = locked;
            url.ReadOnly = locked;
            browseForPfx.Enabled = !locked;
            pfxPassword.ReadOnly = locked;
            privateKeyOption.Enabled = !locked;
        }
    }
}
