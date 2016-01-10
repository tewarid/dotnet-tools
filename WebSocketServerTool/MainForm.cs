using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Windows.Forms;

namespace WebSocketServerTool
{
    public partial class MainForm : Form
    {
        ServiceHost host;

        public MainForm()
        {
            InitializeComponent();
        }

        private void CreateServiceHost(Uri uri, string subjectName = null)
        {
            if (host != null) return;

            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new ByteStreamMessageEncodingBindingElement());

            HttpTransportBindingElement transport;
            ServiceCredentials behavior = null;
            string scheme;
            if (uri.Scheme.Equals("ws"))
            {
                transport = new HttpTransportBindingElement();
                scheme = Uri.UriSchemeHttp;
            }
            else
            {
                transport = new HttpsTransportBindingElement();
                scheme = Uri.UriSchemeHttps;
                behavior = new ServiceCredentials();
                behavior.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine,
                    StoreName.My, X509FindType.FindBySubjectName, subjectName);
            }

            transport.WebSocketSettings = new WebSocketTransportSettings()
            {
                TransportUsage = WebSocketTransportUsage.Always,
                CreateNotificationOnConnection = false
            };
            binding.Elements.Add(transport);

            host = new ServiceHost(typeof(WebSocketServerTool.Service));

            UriBuilder newUri = new UriBuilder(uri)
            {
                Scheme = scheme
            };

            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(IService), 
                binding, newUri.ToString());

            if (behavior != null)
                host.Description.Behaviors.Add(behavior);

            host.Open();
        }

        private void open_Click(object sender, System.EventArgs e)
        {
            if (host != null) return;

            try
            {
                CreateServiceHost(new Uri(url.Text), this.subjectName.Text);

                open.Enabled = false;
                close.Enabled = true;
                subjectName.ReadOnly = true;
                url.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
                if (host != null)
                {
                    host.Close();
                    host = null;
                }
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            if (host == null) return;

            host.Close();
            host = null;

            open.Enabled = true;
            close.Enabled = false;
            subjectName.ReadOnly = false;
            url.ReadOnly = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
