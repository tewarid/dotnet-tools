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
        private readonly byte[] buffer = new byte[100];
        private bool newMessage = true;
        NameValueCollection headers;
        private string proxyUrl;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            if (wsClient == null || wsClient.State != WebSocketState.Open)
            {
                await CreateWebSocketClient().ConfigureAwait(true);
                if (wsClient == null || wsClient.State != WebSocketState.Open)
                {
                    return;
                }
                await SendAsync().ConfigureAwait(true);
                await ReadCallback().ConfigureAwait(true);
            }
            else
            {
                await SendAsync().ConfigureAwait(true);
            }
        }

        private async Task SendAsync()
        {
            byte[] data = sendTextBox.Bytes;
            if (data.Length <= 0)
            {
                MessageBox.Show(this, "Nothing to send.", this.Text);
                return;
            }
            sendButton.Enabled = false;
            int tickCount = Environment.TickCount;
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                CancellationToken token = cts.Token;
                await wsClient.SendAsync(new ArraySegment<byte>(data, 0, data.Length),
                    sendTextBox.Binary ? WebSocketMessageType.Binary : WebSocketMessageType.Text,
                    true, token).ConfigureAwait(true);
                cts.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
                sendButton.Enabled = true;
                return;
            }
            tickCount = Environment.TickCount - tickCount;
            status.Text = String.Format("Sent {0} byte(s) in {1} milliseconds",
                data.Length, tickCount);
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
            if (wsClient != null && wsClient.State == WebSocketState.Open)
            {
                return;
            }
            wsClient = new ClientWebSocket();
            if (headers != null)
            { 
                foreach(string name in headers)
                {
                    try
                    {
                        wsClient.Options.SetRequestHeader(name, headers.Get(name));
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, this.Text);
                        return;
                    }
                }
            }
            if (!string.IsNullOrEmpty(proxyUrl))
            {
                wsClient.Options.Proxy = new WebProxy(proxyUrl);
            }
            wsClient.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
            Uri uri;
            try
            {
                uri = new Uri(location.Text);
            }
            catch (UriFormatException ex)
            {
                MessageBox.Show(ex.Message, this.Text);
                return;
            }
            EnableDisable(false);
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                CancellationToken token = cts.Token;
                await wsClient.ConnectAsync(uri, token).ConfigureAwait(true);
                cts.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
                EnableDisable(true);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseWebSocketClient();
        }

        private async Task ReadCallback()
        {
            while(true)
            {
                WebSocketReceiveResult result;
                try
                {
                    CancellationTokenSource cts = new CancellationTokenSource();
                    CancellationToken token = cts.Token;
                     result = await wsClient
                        .ReceiveAsync(new ArraySegment<byte>(buffer),token)
                        .ConfigureAwait(true);
                    cts.Dispose();
                }
                catch (ObjectDisposedException)
                {
                    return;
                }
                if (result.Count > 0)
                {
                    ShowReceivedData(buffer, result.Count, result.EndOfMessage);
                }
                if (wsClient.State != WebSocketState.Open)
                {
                    await CloseWebSocketClient().ConfigureAwait(true);
                    if (wsClient.CloseStatus != WebSocketCloseStatus.NormalClosure)
                    {
                        MessageBox.Show(string.Format("WebSocket closed due to {0}.",
                            wsClient.CloseStatus), this.Text);
                    }
                    return;
                }
            }
        }

        private async void Connect_Click(object sender, EventArgs e)
        {
            await CreateWebSocketClient().ConfigureAwait(true);
            await ReadCallback().ConfigureAwait(true);
        }

        private async void CloseButton_Click(object sender, EventArgs e)
        {
            await CloseWebSocketClient().ConfigureAwait(true);
        }

        private async Task CloseWebSocketClient()
        {
            if (wsClient != null && wsClient.State == WebSocketState.Open)
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                CancellationToken token = cts.Token;
                await wsClient
                    .CloseAsync(WebSocketCloseStatus.NormalClosure, "bye", token)
                    .ConfigureAwait(true);
                cts.Dispose();
                status.Text = "WebSocket closed.";
                EnableDisable(true);
            }
        }

        private void SetHeaders_Click(object sender, EventArgs e)
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

        private void ProxyButton_Click(object sender, EventArgs e)
        {
            string defaultValue;
            if (string.IsNullOrEmpty(proxyUrl))
            {
                defaultValue = "http://localhost:8888";
            }
            else
            {
                defaultValue = proxyUrl;
            }
            InputDialog<Uri> dialog = new InputDialog<Uri>();
            DialogResult result = dialog.Show(this, "HTTP Proxy",
                defaultValue);
            if (result == DialogResult.OK)
            {
                proxyUrl = dialog.Value == null ? null : dialog.Value.AbsoluteUri;
            }
        }

        private void EnableDisable(bool enable)
        {
            connect.Enabled = enable;
            setHeaders.Enabled = enable;
            proxyButton.Enabled = enable;
            location.ReadOnly = !enable;
        }
    }
}