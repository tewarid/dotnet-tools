using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public partial class MainForm : Form
    {
        delegate void ShowReceivedDataDelegate(byte[] data, int length);
        private ClientWebSocket wsClient;
        private byte[] buffer = new byte[100];
        private bool newMessage = true;
        NameValueCollection headers;
        private string proxyUrl;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            await CreateWebSocketClient();
            if (wsClient == null || wsClient.State != WebSocketState.Open)
            {
                return;
            }

            sendButton.Enabled = false;

            int tickcount = 0;

            byte[] data = sendTextBox.Bytes;
            if (data.Length <= 0)
            {
                MessageBox.Show(this, "Nothing to send.", this.Text);
            }
            else
            {
                try
                {
                    tickcount = Environment.TickCount;
                    CancellationTokenSource source = new CancellationTokenSource();
                    CancellationToken token = source.Token;
                    await wsClient.SendAsync(new ArraySegment<byte>(data, 0, data.Length), 
                        sendTextBox.Binary ? WebSocketMessageType.Binary : WebSocketMessageType.Text, 
                        true, token);
                    tickcount = Environment.TickCount - tickcount;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                }
            }

            status.Text = String.Format("Sent {0} byte(s) in {1} milliseconds",
                data.Length, tickcount);
            sendButton.Enabled = true;
        }

        private void ShowReceivedData(byte[] data, int length, bool lastMessage)
        {
            if (newMessage)
            {
                outputText.AppendText(string.Format("Message Received on {0}:{1}", 
                    DateTime.Now, Environment.NewLine));
            }

            outputText.Append(data, length);

            if (lastMessage)
            {
                outputText.AppendText(Environment.NewLine);
                outputText.AppendText(Environment.NewLine);
            }

            newMessage = lastMessage;
        }

        private async Task CreateWebSocketClient()
        {
            if (wsClient != null && wsClient.State == WebSocketState.Open) return;
            wsClient = new ClientWebSocket();
            if (headers != null)
            { 
                foreach(string name in headers)
                {
                    wsClient.Options.SetRequestHeader(name, headers.Get(name));
                }
            }
            if (proxyUrl != null)
            {
                wsClient.Options.Proxy = new WebProxy(proxyUrl);
            }
            wsClient.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
            connect.Enabled = setHeaders.Enabled = proxyButton.Enabled = false;
            location.ReadOnly = true;
            try
            {
                Uri uri = new Uri(location.Text);
                CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken token = source.Token;
                await wsClient.ConnectAsync(uri, token);
                Task task = ReadCallback();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
                connect.Enabled = setHeaders.Enabled = proxyButton.Enabled = true;
                location.ReadOnly = false;
            }
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            await CloseWebSocketClient();
        }

        private async Task ReadCallback()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            WebSocketReceiveResult result = await wsClient.ReceiveAsync(new ArraySegment<byte>(buffer), token);
            if (result.Count > 0)
            {
                ShowReceivedData(buffer, result.Count, result.EndOfMessage);
            }
            if (wsClient.State != WebSocketState.Open)
            {
                await CloseWebSocketClient();
                if (wsClient.CloseStatus != WebSocketCloseStatus.NormalClosure)
                    MessageBox.Show(string.Format("WebSocket closed due to {0}.", 
                        wsClient.CloseStatus), this.Text);
                return;
            }
            Task task = ReadCallback();
        }

        private async void connect_Click(object sender, EventArgs e)
        {
            await CreateWebSocketClient();
        }

        private async void closeButton_Click(object sender, EventArgs e)
        {
            await CloseWebSocketClient();
        }

        private async Task CloseWebSocketClient()
        {
            if (wsClient != null && wsClient.State == WebSocketState.Open)
            {
                CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken token = source.Token;
                await wsClient.CloseAsync(WebSocketCloseStatus.NormalClosure, "bye", token);
            }
            connect.Enabled = setHeaders.Enabled = proxyButton.Enabled = true;
            location.ReadOnly = false;
            status.Text = "WebSocket closed.";
        }

        private void setHeaders_Click(object sender, EventArgs e)
        {
            NameValueCollection initialValues = new NameValueCollection();
            if (headers == null || headers.Count == 0)
            {
                initialValues.Add("Authorization", "Bearer token");
            }
            else
            {
                initialValues.Add(headers);
            }
            NameValueDialog headerForm = 
                new NameValueDialog("Request Headers", initialValues);
            headerForm.ShowDialog();
            headers = headerForm.NameValues;
        }

        private void proxyButton_Click(object sender, EventArgs e)
        {
            DialogResult result = InputDialog.Show<Uri>(this, "HTTP Proxy",
                string.IsNullOrEmpty(proxyUrl) ? "http://localhost:8888" : proxyUrl,
                out Uri value);
            if (result == DialogResult.OK)
            {
                proxyUrl = value == null ? null : value.AbsoluteUri;
            }
        }
    }
}