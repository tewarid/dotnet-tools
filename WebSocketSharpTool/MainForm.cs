using Common;
using System;
using System.Collections.Specialized;
using System.Windows.Forms;
using WebSocketSharp;

namespace WebSocketSharpTool
{
    public partial class MainForm : Form
    {
        private WebSocket ws;
        private bool newMessage = true;
        NameValueCollection headers;
        private string proxyUrl;

        public MainForm()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            sendButton.Enabled = false;

            try
            {
                Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
                return;
            }
            finally
            {
                sendButton.Enabled = true;
            }

            try
            {
                if (sendTextBox.Binary)
                {
                    byte[] data = sendTextBox.Bytes;

                    if (data.Length <= 0)
                    {
                        MessageBox.Show(this, "Nothing to send.", this.Text);
                    }
                    else
                    {
                        ws.SendAsync(data, delegate (bool completed) {
                            if (completed)
                            {
                                int tickcount = Environment.TickCount;
                                tickcount = Environment.TickCount - tickcount;
                                BeginInvoke((MethodInvoker)delegate
                                {
                                    status.Text = String.Format("Sent {0} byte(s) in {1} milliseconds",
                                    data.Length, tickcount);
                                });
                            }
                        });
                    }
                }
                else
                {
                    string text = sendTextBox.Text;
                    if (text.Length <= 0)
                    {
                        MessageBox.Show(this, "Nothing to send.", this.Text);
                    }
                    else
                    {
                        ws.SendAsync(text, delegate (bool completed)
                        {
                            if (completed)
                            {
                                int tickcount = Environment.TickCount;
                                tickcount = Environment.TickCount - tickcount;
                                BeginInvoke((MethodInvoker)delegate
                                {
                                    status.Text = String.Format("Sent {0} byte(s) in {1} milliseconds",
                                        text.Length, tickcount);
                                });
                            }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
            }
            finally
            {
                sendButton.Enabled = true;
            }
        }

        private void Log(byte[] data, int length, bool lastMessage)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    Log(data, length, lastMessage);
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

        private void Connect()
        {
            if (ws != null && ws.IsAlive)
            {
                return;
            }

            ws = new WebSocket(location.Text);
            
            connect.Enabled = false;
            setHeaders.Enabled = false;
            proxyButton.Enabled = false;
            location.ReadOnly = true;

            ws.SetHeaders(headers);
            ws.SetProxy(proxyUrl, string.Empty, string.Empty);
            ws.OnError += Ws_OnError;
            ws.OnClose += Ws_OnClose;
            ws.OnMessage += Ws_OnMessage;
            ws.OnOpen += Ws_OnOpen;

            ws.Connect();
        }

        private void Ws_OnOpen(object sender, EventArgs e)
        {
            // Nothing to do after ws is open
        }

        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            Log(e.RawData, e.RawData.Length, true);
        }

        private void Ws_OnClose(object sender, CloseEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    Ws_OnClose(sender, e);
                });
                return;
            }

            MessageBox.Show(this, string.Format("WebSocket closed. {0}",
                e.Reason), this.Text);

            CloseWebSocket();
        }

        private void Ws_OnError(object sender, ErrorEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate ()
                {
                    Ws_OnError(sender, e);
                });
                return;
            }

            MessageBox.Show(e.Message, this.Text);
            CloseWebSocket();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseWebSocket();
        }


        private void Connect_Click(object sender, EventArgs e)
        {
            try
            {
                Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            CloseWebSocket();
        }

        private void CloseWebSocket()
        {
            if (ws != null && ws.IsAlive)
            {
                ws.OnClose -= Ws_OnClose;
                ws.Close();
                ws = null;
            }
            connect.Enabled = true;
            setHeaders.Enabled = true;
            proxyButton.Enabled = true;
            location.ReadOnly = false;
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

        private void Location_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 1) // Control+A
            {
                location.SelectAll();
                e.Handled = true;
            }
        }
    }
}