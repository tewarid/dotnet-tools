using HexToBinLib;
using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSocketTool
{
    public partial class MainForm : Form
    {
        ClientWebSocket wsClient;

        delegate void ShowReceivedDataDelegate(byte[] data, int length);
        byte[] buffer = new byte[100];

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            if (wsClient == null || wsClient.State == WebSocketState.Closed)
            {
                await CreateWebSocketClient();
                if (wsClient == null || wsClient.State == WebSocketState.Closed) return;
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
                    await wsClient.SendAsync(new ArraySegment<byte>(data, 0, length), WebSocketMessageType.Binary, true, token);
                    tickcount = Environment.TickCount - tickcount;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                }
            }

            status.Text = String.Format("Sent {0} byte(s) in {1} milliseconds", length, tickcount);
            sendButton.Enabled = true;
        }

        private void ShowReceivedData(byte[] data, int length)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    ShowReceivedData(data, length);
                });
                return;
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
        }

        private async Task CreateWebSocketClient()
        {
            wsClient = new ClientWebSocket();
            connect.Enabled = false;
            location.ReadOnly = true;
            try
            {
                Uri uri = new Uri(location.Text);
                CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken token = source.Token;
                await wsClient.ConnectAsync(uri, token);
                ReadCallback();
            }
            catch (WebSocketException ex)
            {
                MessageBox.Show(ex.Message);
                connect.Enabled = true;
                location.ReadOnly = false;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            outputText.Clear();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (wsClient != null && wsClient.State != WebSocketState.Closed)
            {
                CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken token = source.Token;
                wsClient.CloseAsync(WebSocketCloseStatus.NormalClosure, "bye", token);
            }
        }

        private async Task ReadCallback()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            WebSocketReceiveResult result = await wsClient.ReceiveAsync(new ArraySegment<byte>(buffer), token);
            if (result.Count > 0)
            {
                ShowReceivedData(buffer, result.Count);
            }
            ReadCallback();
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
            if (wsClient == null || wsClient.State == WebSocketState.Closed)
            {
                await CreateWebSocketClient();
            }
        }
    }
}
