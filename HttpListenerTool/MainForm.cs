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
        private Uri prefix;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void start_Click(object sender, EventArgs e)
        {
            try
            {
                listener = new HttpListener();
                prefix = new Uri(uri.Text);
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
            string path = GetAbsoluteLocalPath(context.Request);
            if (File.Exists(path))
            {
                ProcessFile(context.Request, context.Response, path);
            }
            else
            {
                ProcessDirectory(context.Request, context.Response, path);
            }
            context.Response.Close();
        }

        private void ProcessFile(HttpListenerRequest request, HttpListenerResponse response, string file)
        {
            string mimeType = MimeTypeMap.GetMimeType(Path.GetExtension(file));
            response.ContentType = mimeType;
            if (request.HttpMethod != "HEAD")
            {
                byte[] data = File.ReadAllBytes(file);
                response.OutputStream.Write(data, 0, data.Length);
            }
        }

        private void ProcessDirectory(HttpListenerRequest request, HttpListenerResponse response, string file)
        {
            string statusFile = GetFirstFile(file);
            if (string.IsNullOrEmpty(statusFile))
            {
                response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else
            {
                string statusCodeString = Path.GetFileNameWithoutExtension(statusFile);
                int statusCode;
                if (int.TryParse(statusCodeString, out statusCode))
                {
                    response.StatusCode = statusCode;
                    switch (statusCode)
                    {
                        case 302:
                            string[] location = File.ReadAllLines(statusFile);
                            response.AddHeader("Location", location.Length > 0 ? location[0] : string.Empty);
                            break;
                        default:
                            ProcessFile(request, response, statusFile);
                            break;
                    }
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                }
            }
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

        private string GetAbsoluteLocalPath(HttpListenerRequest request)
        {
            string localPath = prefix.MakeRelativeUri(request.Url).ToString();
            string path = string.Empty;
            if (Path.IsPathRooted(directory.Text))
            {
                path = Path.Combine(directory.Text, localPath);
            }
            else
            {
                path = Path.Combine(Environment.CurrentDirectory + Path.DirectorySeparatorChar, directory.Text, localPath);
            }
            if (!string.IsNullOrWhiteSpace(headers.Text))
            {
                string [] headerArray = headers.Text.Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                foreach(string header in headerArray)
                {
                    string value = request.Headers[header];
                    if (!string.IsNullOrEmpty(value))
                    {
                        path = Path.Combine(path, value.Replace("\"", ""));
                    }
                }
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
        }

        private void browse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(folderBrowser.SelectedPath))
            {
                folderBrowser.SelectedPath = Environment.CurrentDirectory;
            }
            DialogResult result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                Uri selectedPathUri = new Uri(folderBrowser.SelectedPath);
                Uri cwdUri = new Uri(Environment.CurrentDirectory + Path.DirectorySeparatorChar);
                directory.Text = cwdUri.MakeRelativeUri(selectedPathUri).ToString();
            }
        }
    }
}
