using Common;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Windows.Forms;

namespace Common
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Set SSL/TLS version options
            tlsVersion.Items.Add(new ComboboxItem<SecurityProtocolType>("SSL 3", SecurityProtocolType.Ssl3));
            tlsVersion.Items.Add(new ComboboxItem<SecurityProtocolType>("TLS", SecurityProtocolType.Tls));
            tlsVersion.Items.Add(new ComboboxItem<SecurityProtocolType>("TLS 1.1", SecurityProtocolType.Tls11));
            tlsVersion.Items.Add(new ComboboxItem<SecurityProtocolType>("TLS 1.2", SecurityProtocolType.Tls12));
            tlsVersion.SelectedIndex = 3;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Request Methods
            requestMethod.Items.Add(HttpMethod.Get.Method);
            requestMethod.Items.Add(HttpMethod.Head.Method);
            requestMethod.Items.Add(HttpMethod.Post.Method);
            requestMethod.Items.Add(HttpMethod.Put.Method);
            requestMethod.SelectedIndex = 0;

            // Request Content Type
            requestContentType.Items.Add(MimeTypes.MimeTypeMap.GetMimeType("txt"));
            requestContentType.Items.Add(MimeTypes.MimeTypeMap.GetMimeType("xml"));
            requestContentType.Items.Add(MimeTypes.MimeTypeMap.GetMimeType("json"));
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
            ServicePointManager.SecurityProtocol = ((ComboboxItem<SecurityProtocolType>)tlsVersion.SelectedItem).Value;
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
            if (HasContentBody())
            {
                request.Method = requestMethod.Text;
                if (!string.IsNullOrEmpty(requestContentType.Text))
                {
                    request.ContentType = requestContentType.Text;
                }
                byte[] dataOut = requestContent.Bytes;
                if (dataOut.Length > 0)
                {
                    request.GetRequestStream().WriteAsync(dataOut, 0, dataOut.Length);
                }
            }
            WebResponse response;
            try
            {
                response = request.GetResponse();
            }
            catch (WebException w)
            {
                MessageBox.Show(w.Message, this.Text);
                response = w.Response;
            }
            byte[] dataIn = ReadAllBytes(response.GetResponseStream());
            responseContent.Clear();
            responseContent.Append(dataIn, dataIn.Length);
            responseHeaders.Clear();
            responseHeaders.Add(response.Headers);
        }

        private byte[] ReadAllBytes(Stream s)
        {
            MemoryStream m = new MemoryStream();
            s.CopyTo(m);
            return m.ToArray();
        }

        private void url_TextChanged(object sender, EventArgs e)
        {
            Uri uri;
            try
            {
                uri = new Uri(url.Text);
            }
            catch (UriFormatException)
            {
                return;
            }
            queryParameters.Clear();
            queryParameters.Add(HttpUtility.ParseQueryString(uri.Query));
        }

        private void requestMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool enable = HasContentBody();
            requestContentType.Enabled = enable;
            requestContent.Enabled = enable;
        }

        private bool HasContentBody()
        {
            return requestMethod.Text.Equals(HttpMethod.Post.Method)
                || requestMethod.Text.Equals(HttpMethod.Put.Method);
        }
    }
}
