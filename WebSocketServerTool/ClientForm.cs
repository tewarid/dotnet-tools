using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WebSocketServerTool
{
    public partial class ClientForm : Form
    {
        private readonly IClientContext context;
        private bool newMessage = true;
        private static int id = 1;

        public ClientForm(IClientContext context)
        {
            InitializeComponent();
            int value = Interlocked.Increment(ref id);
            this.Text = $"Client {value}";
            this.context = context;
            context.Message += Context_Message;
            context.Closed += Context_Closed;
        }

        private void Context_Closed()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate {
                    Context_Closed();
                });
                return;
            }

            context.Message -= Context_Message;
            context.Closed -= Context_Closed;
            context.Close();
            status.Text = "WebSocket closed.";
        }

        private void Context_Message(byte[] message, int length, WebSocketMessageType type, bool lastMessage)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate {
                    Context_Message(message, length, type, lastMessage);
                });
                return;
            }

            if (newMessage)
            {
                outputText.AppendText(string.Format("Message Received on {0}:{1}",
                    DateTime.Now, Environment.NewLine));
            }

            if (type == WebSocketMessageType.Binary)
            {
                outputText.AppendBinary(message, length);
            }
            else
            {
                outputText.AppendText(Encoding.UTF8.GetString(message));
            }

            if (lastMessage)
            {
                outputText.AppendText(Environment.NewLine);
                outputText.AppendText(Environment.NewLine);
            }

            newMessage = lastMessage;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (input.Binary)
            {
                context.Send(input.BinaryValue, WebSocketMessageType.Binary);
            }
            else
            {
                context.Send(input.BinaryValue, WebSocketMessageType.Text);
            }
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            context.Message -= Context_Message;
            context.Closed -= Context_Closed;
            context.Close();
        }
    }
}
