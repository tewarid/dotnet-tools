using System;
using System.Threading;
using System.Windows.Forms;
using WebSocketSharp;

namespace WebSocketSharpTool
{
    public partial class MainForm : Form
    {
        delegate void ShowReceivedDataDelegate(byte[] data, int length);
        private WebSocket ws;
        private byte[] buffer = new byte[100];
        private bool newMessage = true;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            sendButton.Enabled = false;

            CreateWebSocketClient();

            if (ws == null || !ws.IsAlive)
            {
                sendButton.Enabled = true;
                return;
            }

            if (sendTextBox.Length <= 0)
            {
                MessageBox.Show(this, "Nothing to send.", this.Text);
                sendButton.Enabled = true;
            }
            else
            {
                try
                {
                    int tickcount = Environment.TickCount;

                    if (sendTextBox.Binary)
                    {
                        ws.SendAsync(sendTextBox.Bytes, delegate (bool completed) {
                            if (completed)
                            {
                                tickcount = Environment.TickCount - tickcount;
                                BeginInvoke((MethodInvoker)delegate ()
                                {
                                    status.Text = String.Format("Sent {0} byte(s) in {1} milliseconds",
                                    sendTextBox.Length, tickcount);
                                    sendButton.Enabled = true;
                                });
                            }
                        });
                    }
                    else
                    {
                        ws.SendAsync(sendTextBox.Text, delegate (bool completed) {
                            if (completed)
                            {
                                tickcount = Environment.TickCount - tickcount;
                                BeginInvoke((MethodInvoker)delegate ()
                                {
                                    status.Text = String.Format("Sent {0} byte(s) in {1} milliseconds",
                                    sendTextBox.Length, tickcount);
                                    sendButton.Enabled = true;
                                });
                            }
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                    sendButton.Enabled = true;
                }
            }
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

        private void CreateWebSocketClient()
        {
            if (ws != null && ws.IsAlive) return;

            ws = new WebSocket(location.Text);
            
            connect.Enabled = false;
            location.ReadOnly = true;
            bearerToken.ReadOnly = true;

            ws.SetBearerToken(bearerToken.Text);
            ws.OnError += Ws_OnError;
            ws.OnClose += Ws_OnClose;
            ws.OnMessage += Ws_OnMessage;
            ws.OnOpen += Ws_OnOpen;

            ws.ConnectAsync();
        }

        private void Ws_OnOpen(object sender, EventArgs e)
        {
        }

        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            ShowReceivedData(e.RawData, e.RawData.Length, true);
        }

        private void Ws_OnClose(object sender, CloseEventArgs e)
        {
            MessageBox.Show(string.Format("WebSocket closed due to {0}.",
                e.Reason), this.Text);
        }

        private void Ws_OnError(object sender, ErrorEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate ()
            {
                MessageBox.Show(e.Message, this.Text);
                connect.Enabled = true;
                location.ReadOnly = false;
                bearerToken.ReadOnly = false;
            });
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseWebSocketClient();
        }


        private void connect_Click(object sender, EventArgs e)
        {
            CreateWebSocketClient();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            CloseWebSocketClient();
        }

        private void CloseWebSocketClient()
        {
            if (ws != null && ws.IsAlive)
            {
                ws.OnClose -= Ws_OnClose;
                ws.Close();
                ws = null;
            }
            connect.Enabled = true;
            location.ReadOnly = false;
            bearerToken.ReadOnly = false;
        }

        private void outputText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}