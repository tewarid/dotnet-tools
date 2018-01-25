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
                    await ListenAsync();
                }
            }
            catch(Exception ex)
            {
                Log(ex.Message);
            }
        }

        private async Task ListenAsync()
        {
            HttpListenerContext context = await listener.GetContextAsync();
            HttpListenerRequest request = context.Request;
            Log(string.Format("Received {0} request with URL {1}.", request.HttpMethod, 
                request.Url.OriginalString));
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
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            string path = GetAbsoluteLocalPath(request.Url.LocalPath.Substring(1));
            string file;
            if (File.Exists(path))
            {
                file = path;
            }
            else
            {
                file = GetFirstFile(path);
                if (string.IsNullOrEmpty(file))
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Close();
                    return;
                }
            }
            string statusCodeString = Path.GetFileNameWithoutExtension(file);
            int statusCode;
            if (int.TryParse(statusCodeString, out statusCode))
            {
                response.StatusCode = statusCode;
            }
            switch (statusCode)
            {
                case 302:
                    string [] location = File.ReadAllLines(file);
                    response.AddHeader("Location", location.Length > 0 ? location[0] : string.Empty);
                    break;
                default:
                    string mimeType = MimeTypeMap.GetMimeType(Path.GetExtension(file));
                    response.ContentType = mimeType;
                    if (request.HttpMethod != "HEAD")
                    {
                        byte[] data = File.ReadAllBytes(file);
                        response.OutputStream.Write(data, 0, data.Length);
                    }
                    break;
            }
            response.Close();
        }

        private string GetFirstFile(string path)
        {
            string filename = null;
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                filename = files.Length > 0 ? files[0] : null;
            }
            return filename;
        }

        private string GetAbsoluteLocalPath(string localPath)
        {
            string path = string.Empty;
            if (Path.IsPathRooted(directory.Text))
            {
                path = Path.Combine(directory.Text, localPath);
            }
            else
            {
                path = Path.Combine(Environment.CurrentDirectory, directory.Text, localPath);
            }
            return path;
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
            directory.ReadOnly = !enable;
        }
    }
}
