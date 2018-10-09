using Common;
using MimeTypes;
using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpListenerTool
{
    public partial class MainForm : Form
    {
        private HttpListener listener;

        public MainForm()
        {
            InitializeComponent();

            // Response status codes
            ComboboxItem<HttpStatusCode> selected = null;
            foreach(HttpStatusCode code in Enum.GetValues(typeof(HttpStatusCode)))
            {
                ComboboxItem<HttpStatusCode> item = new ComboboxItem<HttpStatusCode>($"{(int)code} - {code}", code);
                responseStatusCode.Items.Add(item);
                if (code == HttpStatusCode.OK)
                {
                    selected = item;
                }
            }
            responseStatusCode.SelectedItem = selected;
        }

        private async void start_Click(object sender, EventArgs e)
        {
            try
            {
                listener = new HttpListener();
                listener.Prefixes.Add(uri.Text);
                listener.Start();
                EnableDisable(false);
                while (listener.IsListening)
                {
                    await ListenAsync().ConfigureAwait(true);
                }
            }
            catch(Exception ex)
            {
                Log(ex.Message);
            }
        }

        private async Task ListenAsync()
        {
            HttpListenerContext context;
            try
            {
                context = await listener.GetContextAsync();
            }
            catch(HttpListenerException)
            {
                return;
            }
            HttpListenerRequest request = context.Request;
            Log($"[{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")}] Received {request.HttpMethod} request for resource {request.Url.OriginalString}");
            if(request.Headers.Count > 0)
            {
                Log($"{request.Headers}");
            }
            if (request.ContentLength64 > 0)
            {
                Log($"{new StreamReader(request.InputStream).ReadToEnd()}");
            }
            if (certificateAuth.Checked)
            {
                X509Certificate2 certificate = await context.Request.GetClientCertificateAsync();
                if (certificate == null)
                {
                    Log("Client certificate not received.");
                    return;
                }
                Log(string.Format("Received client certificate with thumbprint {0}.", certificate.Thumbprint));
            }
            try
            {
                SendResponse(context);
            }
            catch(Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void SendResponse(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            response.StatusCode = (int)((ComboboxItem<HttpStatusCode>)responseStatusCode.SelectedItem).Value;
            response.Headers.Add(responseHeaders.Get());
            if (!string.IsNullOrWhiteSpace(responseContentType.Text))
            {
                response.ContentType = responseContentType.Text;
            }
            byte[] data = responseContent.Bytes;
            response.OutputStream.Write(data, 0, data.Length);
            response.Close();
        }

        private void Log(string text)
        {
            log.AppendText(text);
            log.AppendText(Environment.NewLine);
        }

        private void stop_Click(object sender, EventArgs e)
        {
            listener.Stop();
            EnableDisable(true);
        }

        private void EnableDisable(bool enable)
        {
            start.Enabled = enable;
            stop.Enabled = !enable;
            uri.ReadOnly = !enable;
        }
    }
}
