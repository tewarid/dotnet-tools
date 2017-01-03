using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSocketServerTool
{
    public partial class MainForm : Form
    {
        ServiceHost host;
        HttpListener httpListener;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create a new service host with the specified Uri and certificate.
        /// </summary>
        /// <param name="uri">A Uri.</param>
        /// <param name="subjectName">Subject name of certificate in certificate store.</param>
        /// <returns></returns>
        private ServiceHost CreateServiceHost(Uri uri, string subjectName = null)
        {
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new ByteStreamMessageEncodingBindingElement());

            string scheme = ValidateWsGetHttp(uri);
            HttpTransportBindingElement transport;
            ServiceCredentials behavior = null;

            if (scheme.Equals(Uri.UriSchemeHttp))
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
                CreateNotificationOnConnection = true
            };
            binding.Elements.Add(transport);

            ServiceHost newHost = new ServiceHost(typeof(WebSocketServerTool.Service));

            UriBuilder newUri = new UriBuilder(uri)
            {
                Scheme = scheme
            };

            ServiceEndpoint endpoint = newHost.AddServiceEndpoint(typeof(IService), 
                binding, newUri.ToString());

            if (behavior != null)
                newHost.Description.Behaviors.Add(behavior);

            newHost.Open();

            return newHost;
        }

        private string ValidateWsGetHttp(Uri uri)
        {
            string scheme;
            if (uri.Scheme.Equals("ws", StringComparison.InvariantCultureIgnoreCase))
            {
                scheme = Uri.UriSchemeHttp;
            }
            else if (uri.Scheme.Equals("wss", StringComparison.InvariantCultureIgnoreCase))
            {
                scheme = Uri.UriSchemeHttps;
            }
            else
            {
                throw new UriFormatException(string.Format("Scheme {0} is not supported. Try ws or wss.", uri.Scheme));
            }
            return scheme;
        }

        private void start_Click(object sender, System.EventArgs e)
        {
            if (host != null) return;

            try
            {
                if (useWcf.Checked)
                {
                    host = CreateServiceHost(new Uri(url.Text), this.subjectName.Text);
                }
                else
                {
                    httpListener = CreateHttpListener(new Uri(url.Text), this.subjectName.Text);
                }
                start.Enabled = false;
                stop.Enabled = true;
                subjectName.ReadOnly = true;
                url.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
                if (host != null && host.State == CommunicationState.Opened)
                {
                    host.Close();
                }
                host = null;
            }
        }

        private HttpListener CreateHttpListener(Uri uri, string text)
        {
            HttpListener listener = new HttpListener();
            string scheme = ValidateWsGetHttp(uri);
            UriBuilder newUri = new UriBuilder(uri)
            {
                Scheme = scheme
            };
            listener.Prefixes.Add(newUri.ToString());
            listener.Start();
            Task task = new Task(delegate ()
            {
                while (true)
                {
                    HttpListenerContext listenerContext;
                    try
                    {
                        listenerContext = listener.GetContext();
                    }
                    catch
                    {
                        break;
                    }
                    if (listenerContext.Request.IsWebSocketRequest)
                    {
                        Invoke(new MethodInvoker(delegate()
                        {
                            HttpListenerClientContext clientContext = new HttpListenerClientContext(listenerContext);
                            ClientForm clientForm = new ClientForm(clientContext);
                            clientForm.Show();
                        }));
                    }
                    else
                    {
                        listenerContext.Response.StatusCode = 400;
                        listenerContext.Response.Close();
                    }
                }
            });
            task.Start();
            return listener;
        }

        private void stop_Click(object sender, EventArgs e)
        {
            if (host != null)
            {
                host.Close();
                host = null;
            }

            if (httpListener != null)
            {
                httpListener.Close();
                httpListener = null;
            }

            start.Enabled = true;
            stop.Enabled = false;
            subjectName.ReadOnly = false;
            url.ReadOnly = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
