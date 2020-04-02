using Common;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSocketServerTool
{
    [MainForm(Name = "WebSocket Server Tool")]
    public partial class MainForm : Form
    {
        private readonly Version MINIMUM_WINDOWS_VERSION = new Version(6, 2);

        HttpListener httpListener;

        public MainForm()
        {
            InitializeComponent();
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

        private void Start_Click(object sender, System.EventArgs e)
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

        private void Stop_Click(object sender, EventArgs e)
        {
            if (httpListener != null)
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
