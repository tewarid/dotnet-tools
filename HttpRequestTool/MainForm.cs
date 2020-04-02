using Common;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Windows.Forms;

namespace HttpRequestTool
{
    [MainForm(Name = "HTTP Request Tool")]
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Set SSL/TLS version options
            tlsVersion.Items.Add(new ComboboxItem<SecurityProtocolType>("TLS", SecurityProtocolType.Tls));
			#if __MonoCS__
			tlsVersion.SelectedIndex = 1;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
			#else 
			tlsVersion.Items.Add(new ComboboxItem<SecurityProtocolType>("TLS 1.1", SecurityProtocolType.Tls11));
			tlsVersion.Items.Add(new ComboboxItem<SecurityProtocolType>("TLS 1.2", SecurityProtocolType.Tls12));
			tlsVersion.SelectedIndex = 2;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			#endif

            // Request Methods
            requestMethod.Items.Add(HttpMethod.Get.Method);
            requestMethod.Items.Add(HttpMethod.Head.Method);
            requestMethod.Items.Add(HttpMethod.Post.Method);
            requestMethod.Items.Add(HttpMethod.Put.Method);
            requestMethod.SelectedIndex = 0;
        }

        private void SelectCertificateFile_Click(object sender, EventArgs e)
        {
            DialogResult r = fileDialog.ShowDialog();
            if (r == DialogResult.OK)
            {
                clientCertificateFile.Text = fileDialog.FileName;
            }
        }

        private void SetClientCertificate_CheckedChanged(object sender, EventArgs e)
        {
            certificatePassword.Enabled = setClientCertificate.Checked;
            clientCertificateFile.Enabled = setClientCertificate.Checked;
            selectCertificateFile.Enabled = setClientCertificate.Checked;
        }

        private void TlsVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = 
                ((ComboboxItem<SecurityProtocolType>)tlsVersion.SelectedItem).Value;
        }

        private void Go_Click(object sender, EventArgs e)
        {
            responseContent.Clear();
            responseHeaders.Clear();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.Text);
            if (setClientCertificate.Checked)
            {
                X509Certificate2Collection certificates = new X509Certificate2Collection();
                try
                {
                    certificates.Import(clientCertificateFile.Text,
                        certificatePassword.Text, X509KeyStorageFlags.DefaultKeySet);
                    request.ClientCertificates = certificates;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(this, ex.Message, clientCertificateFileLabel.Text);
                    return;
                }
                catch (CryptographicException ex)
                {
                    MessageBox.Show(this, ex.Message, clientCertificateFileLabel.Text);
                    return;
                }
            }
            NameValueCollection headers = requestHeaders.Get();
            if (headers.Count > 0)
            {
                request.Headers.Add(headers);
            }
            WebResponse response;
            try
            {
                if (HasContentBody())
                {
                    request.Method = requestMethod.Text;
                    if (!string.IsNullOrEmpty(requestContentType.Text))
                    {
                        request.ContentType = requestContentType.Text;
                    }
                    byte[] dataOut = requestContent.BinaryValue;
                    if (dataOut.Length > 0)
                    {
                        request.GetRequestStream().WriteAsync(dataOut, 0, dataOut.Length);
                    }
                }

                response = request.GetResponse();
            }
            catch (WebException w)
            {
                MessageBox.Show(w.Message, this.Text);
                if (w.Response == null)
                {
                    return;
                }
                response = w.Response;
            }
            byte[] dataIn = ReadAllBytes(response.GetResponseStream());
            responseContent.AppendBinary(dataIn, dataIn.Length);
            responseHeaders.Add(response.Headers);
        }

        private static byte[] ReadAllBytes(Stream s)
        {
            MemoryStream m = new MemoryStream();
            s.CopyTo(m);
            return m.ToArray();
        }

        private void Url_TextChanged(object sender, EventArgs e)
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

        private void RequestMethod_SelectedIndexChanged(object sender, EventArgs e)
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
