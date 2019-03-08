using Amqp;
using System;
using System.Windows.Forms;

namespace AmqpClientTool
{
    public partial class MainForm : Form
    {
        private Connection connection;
        private Session session;
        SenderLink senderLink;
        ReceiverLink receiver;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Address amqpAddress = new Address("amqp://guest:guest@172.24.6.221:5672");
            Connection connection = new Connection(amqpAddress);
            Session session = new Session(connection);

            Amqp.Message message = new Amqp.Message("Hello AMQP!");
            SenderLink senderLink = new SenderLink(session, "sender-link", "q1");
            senderLink.Send(message);
            Console.WriteLine("Sent Hello AMQP!");

            ReceiverLink receiver = new ReceiverLink(session, "receiver-link", "q1");

            Console.WriteLine("Receiver connected to broker.");
            message = receiver.Receive(TimeSpan.FromSeconds(5));
            Console.WriteLine("Received " + message.GetBody<string>());
            receiver.Accept(message);

            receiver.Close();
            senderLink.Close();
            session.Close();
            connection.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            string scheme = "AMQP";
            if (useTls.Checked)
            {
                scheme = "AMQPS";
            }
            Address amqpAddress = new Address(host.Text, int.Parse(port.Text),
                username.Text, password.Text, scheme: scheme);
            connection = new Connection(amqpAddress);
            connection.Closed += Connection_Closed;
            session = new Session(connection);
            status.Text = "Opened";
        }

        private void Connection_Closed(IAmqpObject sender, Amqp.Framing.Error error)
        {
            status.Text = "Closed";
        }

        private void Close_Click(object sender, EventArgs e)
        {
            if (receiver != null)
            {
                receiver.Close();
                receiver = null;
            }
            if (senderLink != null)
            {
                senderLink.Close();
                senderLink = null;
            }
            session.Close();
            connection.Close();
            connection.Closed -= Connection_Closed;
        }

        private void Send_Click(object sender, EventArgs e)
        {
            object body;
            if (input.BinaryChecked)
            {
                body = input.BinaryValue;
            }
            else
            {
                body = input.TextValue;
            }
            Amqp.Message message = new Amqp.Message(body);
            if (senderLink == null)
            {
                senderLink = new SenderLink(session,
                    senderLinkName.Text, senderLinkAddress.Text);
            }
            senderLink.Send(message, (s, m, outcome, state) =>
            {

            }, null);
        }

        private async void Receive_Click(object sender, EventArgs e)
        {
            if (receiver != null)
            {
                return;
            }
            receiver = new ReceiverLink(session,
                receiverLinkName.Text, receiverLinkAddress.Text);
            while (receiver != null && !receiver.IsClosed)
            {
                Amqp.Message message = await receiver.ReceiveAsync(TimeSpan.FromSeconds(5));
                if (message == null)
                {
                    continue;
                }
                receiver.Accept(message);
                output.AppendText(message.Body.ToString());
            }
        }
    }
}
