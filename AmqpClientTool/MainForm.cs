using Amqp;
using Amqp.Framing;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace AmqpClientTool
{
    public partial class MainForm : Form
    {
        class SenderLinkWrapper
        {
            public ISenderLink SenderLink { get; set; }
            public string Name
            {
                get
                {
                    return SenderLink.Name;
                }
                set
                {
                }
            }
            public SenderLinkWrapper(ISenderLink sender)
            {
                SenderLink = sender;
            }
        }

        class ReceiverLinkWrapper
        {
            public IReceiverLink ReceiverLink { get; set; }
            public string Name
            {
                get
                {
                    return ReceiverLink.Name;
                }
                set
                {
                }
            }
            public ReceiverLinkWrapper(IReceiverLink receiver)
            {
                ReceiverLink = receiver;
            }
        }

        private Connection connection;
        private Session session;
        private BindingList<SenderLinkWrapper> senders = new BindingList<SenderLinkWrapper>();
        private BindingList<ReceiverLinkWrapper> receivers = new BindingList<ReceiverLinkWrapper>();
        ISenderLink senderLink;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseConnection();
            Properties.Settings.Default.Save();
        }

        private async void Open_Click(object sender, EventArgs e)
        {
            string scheme = "AMQP";
            if (useWebSocket.Checked && useTls.Checked)
            {
                scheme = "WSS";
            }
            else if (useWebSocket.Checked && !useTls.Checked)
            {
                scheme = "WS";
            }
            else if (!useWebSocket.Checked && useTls.Checked)
            {
                scheme = "AMQPS";
            }
            Address amqpAddress = new Address(host.Text, int.Parse(port.Text),
                username.Text, password.Text, scheme: scheme);
            try
            {
                connection = await Connection.Factory.CreateAsync(amqpAddress);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                connection = null;
                return;
            }
            connection.Closed += Connection_Closed;
            session = new Session(connection);
            sendersListBox.DataSource = senders;
            sendersListBox.DisplayMember = "Name";
            sendersListBox.ValueMember = "Name";
            receiversListBox.DataSource = receivers;
            receiversListBox.DisplayMember = "Name";
            receiversListBox.ValueMember = "Name";
            status.Text = "Opened";
        }

        private void Connection_Closed(IAmqpObject sender, Error error)
        {
            status.Text = "Closed";
            senderLink = null;
            session = null;
            connection.Closed -= Connection_Closed;
            connection = null;
            for(int i = senders.Count - 1; i >= 0; i--)
            {
                senders.RemoveAt(i);
            }
            for (int i = receivers.Count - 1; i >= 0; i--)
            {
                receivers.RemoveAt(i);
            }
            BeginInvoke(new MethodInvoker(() =>
            {
                sendersListBox.DataSource = null;
                receiversListBox.DataSource = null;
            }));
        }

        private void Close_Click(object sender, EventArgs e)
        {
            CloseConnection();
        }

        private void CloseConnection()
        {
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
                AddSender();
                if (senderLink == null)
                {
                    return;
                }
            }
            Data data = new Data();
            data.Binary = input.SelectedBinaryValue;
            Amqp.Message message = new Amqp.Message();
            message.BodySection = data;
            message.Header = new Header()
            {
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

        private async void AddReceiver_Click(object sender, EventArgs e)
        {
            if (session == null)
            {
                return;
            }
            IReceiverLink receiverLink;
            Source receiveSource = new Source()
            {
                Address = receiverLinkAddress.Text,
            };
            try
            {
                receiverLink = new ReceiverLink(session, receiverLinkName.Text, receiveSource, (link, attach) =>
                {
                });
                receivers.Add(new ReceiverLinkWrapper(receiverLink));
            }
            catch(AmqpException ex)
            {
                MessageBox.Show(this, ex.Message);
                return;
            }
            while (receiverLink != null && !receiverLink.IsClosed)
            {
                Amqp.Message message;
                try
                {
                    message = await receiverLink.ReceiveAsync(TimeSpan.FromSeconds(5));
                    if (message == null)
                    {
                        continue;
                    }
                    receiverLink.Accept(message);
                }
                catch (AmqpException)
                {
                    break;
                }
                string subject = string.Empty;
                if (!string.IsNullOrEmpty(message.Properties.Subject))
                {
                    subject = $"received message with subject { message.Properties.Subject} ";
                }
                output.AppendText($"Receiver {receiverLink.Name} {subject}on {DateTime.Now}:{Environment.NewLine}");
                byte[] data;
                if (message.Body is byte[])
                {
                    data = (byte[])message.Body;
                }
                else
                {
                    data = Encoding.UTF8.GetBytes(message.Body.ToString());
                }
                output.AppendBinary(data, data.Length);
                output.AppendText($"{Environment.NewLine}");
                output.AppendText($"{Environment.NewLine}");
            }
        }

        private async void RemoveReceiver_Click(object sender, EventArgs e)
        {
            if (receiversListBox.SelectedItem == null)
            {
                return;
            }
            ReceiverLinkWrapper wrapper = (ReceiverLinkWrapper)receiversListBox.SelectedItem;
            IReceiverLink receiverLink = wrapper.ReceiverLink;
            await receiverLink.CloseAsync();
            receivers.Remove(wrapper);
        }

        private void AddSender_Click(object sender, EventArgs e)
        {
            AddSender();
        }

        private void AddSender()
        {
            if (session == null)
            {
                return;
            }
            Target sendTarget = new Target()
            {
                Address = senderLinkAddress.Text,
            };
            try
            {
                senderLink = new SenderLink(session, senderLinkName.Text, sendTarget, (link, attach) =>
                {
                });
                senders.Add(new SenderLinkWrapper(senderLink));
            }
            catch (AmqpException ex)
            {
                MessageBox.Show(this, ex.Message);
                return;
            }
        }

        private async void RemoveSender_Click(object sender, EventArgs e)
        {
            if (sendersListBox.SelectedItem == null)
            {
                return;
            }
            SenderLinkWrapper wrapper = (SenderLinkWrapper)sendersListBox.SelectedItem;
            ISenderLink senderLink = wrapper.SenderLink;
            if (senderLink.Equals(this.senderLink))
            {
                this.senderLink = null;
            }
            await senderLink.CloseAsync();
            senders.Remove(wrapper);
        }

        private void ReceiversListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // not needed at the moment
        }

        private void SendersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sendersListBox.SelectedItem == null)
            {
                return;
            }
            senderLink = ((SenderLinkWrapper)sendersListBox.SelectedItem).SenderLink;
        }
    }
}
