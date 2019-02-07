using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSocketServerTool
{
    public partial class MainForm : Form
    {
        private readonly Version MINIMUM_WINDOWS_VERSION = new Version(6, 2);

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
        private ServiceHost CreateServiceHost(Uri uri)
        {
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new ByteStreamMessageEncodingBindingElement());

            string scheme = GetHttpScheme(uri);
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
            }

            transport.WebSocketSettings = new WebSocketTransportSettings
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

            newHost.AddServiceEndpoint(typeof(IService), 
                binding, newUri.ToString());

            if (behavior != null)
            {
                newHost.Description.Behaviors.Add(behavior);
            }

            newHost.Open();

            return newHost;
        }

        private static string GetHttpScheme(Uri uri)
        {
            string scheme;
            if (uri.Scheme.Equals("ws",
                StringComparison.InvariantCultureIgnoreCase))
            {
                scheme = Uri.UriSchemeHttp;
            }
            else if (uri.Scheme.Equals("wss",
                StringComparison.InvariantCultureIgnoreCase))
            {
                scheme = Uri.UriSchemeHttps;
            }
            else
            {
                throw new ArgumentException(string
                    .Format("Scheme {0} is not supported. Try ws or wss.",
                    uri.Scheme));
            }
            return scheme;
        }

        private void start_Click(object sender, System.EventArgs e)
        {
            if (useWcf.Checked)
            {
                if (host != null)
                {
                    return;
                }
                try
                {
                    host = CreateServiceHost(new Uri(url.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                    return;
                }
            }
            else
            {
                if (httpListener != null)
                {
                    return;
                }
                try
                {
                    httpListener = CreateHttpListener(new Uri(url.Text));
                }
                catch (HttpListenerException ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                    return;
                }
            }
            EnableDisable(false);
        }

        private HttpListener CreateHttpListener(Uri uri)
        {
            HttpListener listener = new HttpListener();
            string scheme = GetHttpScheme(uri);
            UriBuilder newUri = new UriBuilder(uri)
            {
                Scheme = scheme
            };
            listener.Prefixes.Add(newUri.ToString());
            listener.Start();
            Task task = new Task(delegate
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
                        Invoke(new MethodInvoker(delegate
                        {
                            HttpListenerClientContext clientContext =
                                new HttpListenerClientContext(listenerContext);
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
            else if (httpListener != null)
            {
                httpListener.Close();
                httpListener = null;
            }
            EnableDisable(true);
        }

        private void EnableDisable(bool enable)
        {
            start.Enabled = enable;
            stop.Enabled = !enable;
            subjectName.ReadOnly = !enable;
            url.ReadOnly = !enable;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Environment.OSVersion.Version < MINIMUM_WINDOWS_VERSION)
            {
                MessageBox.Show(this, "Native WebSocket support is only available in  Windows version 8.1 or better.");
                Close();
            }
        }
    }
}
