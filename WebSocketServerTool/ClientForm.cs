using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSocketServerTool
{
    public partial class ClientForm : Form
    {
        private ClientContext context;

        public ClientForm(ClientContext context)
        {
            InitializeComponent();
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

            status.Text = "Connection closed.";
        }

        private void Context_Message(byte[] message, WebSocketMessageType type)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate {
                    Context_Message(message, type);
                });
                return;
            }

            outputText.AppendText(string.Format("Message Received on {0}:{1}",
                DateTime.Now, Environment.NewLine));

            if (type == WebSocketMessageType.Binary)
            {
                outputText.Append(message, message.Length);
            }
            else
            {
                outputText.AppendText(Encoding.UTF8.GetString(message));
            }

            outputText.AppendText(Environment.NewLine);
            outputText.AppendText(Environment.NewLine);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (input.Binary)
            {
                context.Send(input.Bytes, WebSocketMessageType.Binary);
            }
            else
            {
                context.Send(input.Bytes, WebSocketMessageType.Text);
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
