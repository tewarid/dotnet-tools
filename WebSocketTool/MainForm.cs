using HexToBinLib;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSocketSharpTool
{
    public partial class MainForm : Form
    {
        delegate void ShowReceivedDataDelegate(byte[] data, int length);
        private ClientWebSocket wsClient;
        private byte[] buffer = new byte[100];
        private bool newMessage = true;
        HeaderForm headerForm = new HeaderForm();

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
            if (sendTextBox.Length <= 0)
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
                    await wsClient.SendAsync(new ArraySegment<byte>(sendTextBox.Bytes, 0, sendTextBox.Length), 
                        WebSocketMessageType.Binary, true, token);
                    tickcount = Environment.TickCount - tickcount;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                }
            }

            status.Text = String.Format("Sent {0} byte(s) in {1} milliseconds", 
                sendTextBox.Length, tickcount);
            sendButton.Enabled = true;
        }

        private void ShowReceivedData(byte[] data, int length, bool lastMessage)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    ShowReceivedData(data, length, lastMessage);
                });
                return;
            }

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
            NameValueCollection headers = headerForm.Headers;
            foreach(string name in headers)
            {
                wsClient.Options.SetRequestHeader(name, headers.Get(name));
            }
            connect.Enabled = false;
            setHeaders.Enabled = false;
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
                connect.Enabled = true;
                setHeaders.Enabled = true;
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
                connect.Enabled = true;
                setHeaders.Enabled = true;
                location.ReadOnly = false;
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
            connect.Enabled = true;
            setHeaders.Enabled = true;
            location.ReadOnly = false;
        }

        private void setHeaders_Click(object sender, EventArgs e)
        {
            headerForm.ShowDialog();
        }

        private void outputText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}