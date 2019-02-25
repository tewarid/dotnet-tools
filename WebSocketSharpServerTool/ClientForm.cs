using System;
using System.Windows.Forms;
using WebSocketSharp;

namespace WebSocketSharpServerTool
{
    public partial class ClientForm : Form
    {
        private readonly ServiceBehavior client;

        public ClientForm(ServiceBehavior client)
        {
			if (client == null)
			{
				throw new ArgumentNullException ("Parameter client is required.");
			}
			this.client = client;
            client.Message += Client_Message;
            client.Close += Client_Close;

            InitializeComponent();
        }

        private void Client_Close(CloseEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate {
                    Client_Close(e);
                });
                return;
            }

            status.Text = "Connection closed.";
        }

        private void Client_Message(MessageEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate {
                    Client_Message(e);
                });
                return;
            }

            outputText.AppendText(string.Format("Message Received on {0}:{1}",
                DateTime.Now, Environment.NewLine));

            if (e.IsBinary)
            {
                outputText.AppendBinary(e.RawData, e.RawData.Length);
            }
            else
            {
                outputText.AppendText(e.Data);
            }

            outputText.AppendText(Environment.NewLine);
            outputText.AppendText(Environment.NewLine);
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (input.Binary)
            {
                client.Send(input.BinaryValue);
            }
            else
            {
                client.Send(input.TextValue);
            }
        }
    }
}
