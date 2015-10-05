using HexToBinLib;
using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSocketTool
{
    public partial class MainForm : Form
    {
        delegate void ShowReceivedDataDelegate(byte[] data, int length);
        private ClientWebSocket wsClient;
        private byte[] buffer = new byte[100];
        private bool newMessage = true;

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

            string text;

            if (endOfLineMac.Checked) // MAC - CR
            {
                text = inputText.Text.Replace("\r\n", "\r");
            }
            else if (endOfLineDos.Checked) // DOS - CR/LF
            {
                text = inputText.Text;
            }
            else // Unix - LF
            {
                text = inputText.Text.Replace("\r\n", "\n");
            }

            byte[] data;
            int length;

            if (inputInHex.Checked)
            {
                MemoryStream output = new MemoryStream();
                TextReader input = new StringReader(text);
                length = HexToBin.Convert(input, output);
                data = output.GetBuffer();
            }
            else
            {
                data = UTF8Encoding.UTF8.GetBytes(text);
                length = data.Length;
            }

            int tickcount = 0;
            if (length <= 0)
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
                    await wsClient.SendAsync(new ArraySegment<byte>(data, 0, length), 
                        WebSocketMessageType.Binary, true, token);
                    tickcount = Environment.TickCount - tickcount;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                }
            }

            status.Text = String.Format("Sent {0} byte(s) in {1} milliseconds", 
                length, tickcount);
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

            if (viewInHex.Checked)
            {
                for (int i = 0; i < length; i++)
                {
                    outputText.AppendText(string.Format("{0:X2} ", data[i]));
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    // remove special chars
                    if (data[i] == '\r' && data[i == length - 1 ? i : i + 1] == '\n')
                    {
                        i++; // maintain DOS end of line
                        continue;
                    }
                    else if (data[i] < (byte)' ' || data[i] > (byte)'~')
                    {
                        data[i] = (byte)'.';
                    }
                }

                outputText.AppendText(ASCIIEncoding.UTF8.GetString(data, 0, length));
            }

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
            connect.Enabled = false;
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
                location.ReadOnly = false;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            outputText.Clear();
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
                location.ReadOnly = false;
                if (wsClient.CloseStatus != WebSocketCloseStatus.NormalClosure)
                    MessageBox.Show(string.Format("WebSocket closed due to {0}.", 
                        wsClient.CloseStatus), this.Text);
                return;
            }
            Task task = ReadCallback();
        }

        private void inputInHex_CheckedChanged(object sender, EventArgs e)
        {
            if (inputInHex.Checked)
            {
                endOfLine.Enabled = false;
            }
            else
            {
                endOfLine.Enabled = true;
            }
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
            location.ReadOnly = false;
        }
    }
}