using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Windows.Forms;

namespace HttpRequestTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Set SSL/TLS version options
            tlsVersion.Items.Add(new ComboboxItem("SSL 3", SecurityProtocolType.Ssl3));
            tlsVersion.Items.Add(new ComboboxItem("TLS", SecurityProtocolType.Tls));
            tlsVersion.Items.Add(new ComboboxItem("TLS 1.1", SecurityProtocolType.Tls11));
            tlsVersion.Items.Add(new ComboboxItem("TLS 1.2", SecurityProtocolType.Tls12));
            tlsVersion.SelectedIndex = 3;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Request Methods
            requestMethod.Items.Add(WebRequestMethods.Http.Get);
            requestMethod.Items.Add(WebRequestMethods.Http.Head);
            requestMethod.Items.Add(WebRequestMethods.Http.Post);
            requestMethod.Items.Add(WebRequestMethods.Http.Put);
            requestMethod.SelectedIndex = 0;
        }

        private void selectCertificateFile_Click(object sender, EventArgs e)
        {
            DialogResult r = fileDialog.ShowDialog();
            if (r == DialogResult.OK)
            {
                clientCertificateFile.Text = fileDialog.FileName;
            }
        }

        private void setClientCertificate_CheckedChanged(object sender, EventArgs e)
        {
            certificatePassword.Enabled = setClientCertificate.Checked;
            clientCertificateFile.Enabled = setClientCertificate.Checked;
            selectCertificateFile.Enabled = setClientCertificate.Checked;
        }

        private void tlsVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = ((ComboboxItem)tlsVersion.SelectedItem).Value;
        }

        private void go_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url.Text);
            if (setClientCertificate.Checked)
            {
                X509Certificate2Collection certificates = new X509Certificate2Collection();
                certificates.Import(clientCertificateFile.Text, certificatePassword.Text, X509KeyStorageFlags.DefaultKeySet);
                request.ClientCertificates = certificates;
            }
            WebResponse response = request.GetResponse();
            responseContent.AppendText(new StreamReader(response.GetResponseStream()).ReadToEnd());
            responseHeaders.Add(response.Headers);
        }

        private void url_TextChanged(object sender, EventArgs e)
        {
            Uri uri = new Uri(url.Text);
            queryParameters.Clear();
            queryParameters.Add(HttpUtility.ParseQueryString(uri.Query));
        }
    }
}
