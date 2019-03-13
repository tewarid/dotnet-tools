using Amqp;
using Amqp.Framing;
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
            receiver = null;
            senderLink = null;
            session = null;
            connection.Closed -= Connection_Closed;
            connection = null;
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
            if (session != null)
            {
                session.Close();
                session = null;
            }
            if (connection != null)
            {
                connection.Close();
            }
        }

        private void Send_Click(object sender, EventArgs e)
        {
            if (senderLink == null)
            {
                if (session == null)
                {
                    return;
                }
                Target sendTarget = new Target()
                {
                    Address = senderLinkAddress.Text,
                    //Durable = 1,
                };
                try
                {
                    senderLink = new SenderLink(session, senderLinkName.Text, sendTarget, (link, attach) =>
                    {
                    });
                }
                catch (AmqpException ex)
                {
                    MessageBox.Show(this, ex.Message);
                    return;
                }
            }
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
            message.Header = new Header()
            {
                Durable = true
            };
            message.Properties = new Amqp.Framing.Properties();
            if (!string.IsNullOrWhiteSpace(subject.Text))
            {
                message.Properties.Subject = subject.Text;
            }
            try
            {
                senderLink.Send(message, (s, m, outcome, state) =>
                {

                }, null);
            }
            catch (AmqpException ex)
            {
                MessageBox.Show(this, ex.Message);
                return;
            }
        }

        private async void Receive_Click(object sender, EventArgs e)
        {
            if (receiver != null)
            {
                return;
            }
            if (session == null)
            {
                return;
            }
            Source receiveSource = new Source()
            {
                Address = receiverLinkAddress.Text,
                //Durable = 1,
            };
            receiver = new ReceiverLink(session, receiverLinkName.Text, receiveSource, (link, attach) =>
            {
            });
            status.Text = $"Receiver {receiverLinkName.Text} listening on address {receiverLinkAddress.Text}";
            while (receiver != null && !receiver.IsClosed)
            {
                Amqp.Message message;
                try
                {
                    message = await receiver.ReceiveAsync(TimeSpan.FromSeconds(5));
                    if (message == null)
                    {
                        continue;
                    }
                    receiver.Accept(message);
                }
                catch (AmqpException)
                {
                    return;
                }
                string subject = string.Empty;
                if (!string.IsNullOrEmpty(message.Properties.Subject))
                {
                    subject = $"with subject { message.Properties.Subject} ";
                }
                output.AppendText($"Message {subject}received on {DateTime.Now}:{Environment.NewLine}");
                if (message.Body is byte[])
                {
                    byte[] data = (byte[])message.Body;
                    output.AppendBinary(data, data.Length);
                }
                else
                {
                    output.AppendText(message.Body.ToString());
                }
                output.AppendText($"{Environment.NewLine}");
                output.AppendText($"{Environment.NewLine}");
            }
        }
    }
}
