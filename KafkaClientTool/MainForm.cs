using Common;
using Confluent.Kafka;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KafkaClientTool
{
    public partial class MainForm : Form
    {
        IConsumer<Ignore, string> consumer;
        CancellationTokenSource consumerCancellationTS;
        IProducer<Null, string> producer;

        public MainForm()
        {
            InitializeComponent();
            securityProtocol.Items.Add(new ComboboxItem<SecurityProtocol>("Plain Text", SecurityProtocol.Plaintext));
            securityProtocol.Items.Add(new ComboboxItem<SecurityProtocol>("SASL Plain Text", SecurityProtocol.SaslPlaintext));
            securityProtocol.Items.Add(new ComboboxItem<SecurityProtocol>("SASL SSL", SecurityProtocol.SaslSsl));
            securityProtocol.Items.Add(new ComboboxItem<SecurityProtocol>("SSL", SecurityProtocol.Ssl));
            saslMechanism.Items.Add(new ComboboxItem<SaslMechanism>("GSS-API", SaslMechanism.Gssapi));
            saslMechanism.Items.Add(new ComboboxItem<SaslMechanism>("Plain", SaslMechanism.Plain));
            saslMechanism.Items.Add(new ComboboxItem<SaslMechanism>("SCRAM-SHA-256", SaslMechanism.ScramSha256));
            saslMechanism.Items.Add(new ComboboxItem<SaslMechanism>("SCRAM-SHA-512", SaslMechanism.ScramSha512));
        }

        private async void Produce_Click(object sender, EventArgs e)
        {
            if (producer == null)
            {
                var config = new ProducerConfig { BootstrapServers = bootstrapServers.Text };
                if (!string.IsNullOrWhiteSpace(username.Text) &&
                    !string.IsNullOrWhiteSpace(password.Text))
                {
                    config.SaslUsername = username.Text;
                    config.SaslPassword = password.Text;
                    if (securityProtocol.SelectedItem != null)
                    {
                        config.SecurityProtocol = ((ComboboxItem<SecurityProtocol>)securityProtocol.SelectedItem).Value;
                        if (config.SecurityProtocol == SecurityProtocol.SaslSsl
                            || config.SecurityProtocol == SecurityProtocol.Ssl)
                        {
                            config.SslCaLocation = caCertificateFileLocation.Text;
                        }
                    }
                    if (saslMechanism.SelectedItem != null)
                    {
                        config.SaslMechanism = ((ComboboxItem<SaslMechanism>)saslMechanism.SelectedItem).Value;
                    }
                }
                try
                {
                    producer = new ProducerBuilder<Null, string>(config).Build();
                }
                catch (ProduceException<Null, string> ex)
                {
                    MessageBox.Show(this, ex.Message);
                    return;
                }
            }
            try
            {
                var dr = await producer.ProduceAsync(produceToTopic.Text,
                    new Message<Null, string> { Value = input.TextValue }).ConfigureAwait(true);
                status.Text = $"Delivered to '{dr.TopicPartitionOffset}'";
            }
            catch (ProduceException<Null, string> ex)
            {
                MessageBox.Show(this, $"Delivery failed: {ex.Error.Reason}");
            }
        }

        private void Subscribe_Click(object sender, EventArgs e)
        {
            char[] separators = new char[] { ',', ' ' };
            string[] topics = subscribeToTopic.Text.Split(separators,
                StringSplitOptions.RemoveEmptyEntries);
            if (topics.Length == 0)
            {
                return;
            }
            if (consumer != null)
            {
                if (topics.Length == 1)
                {
                    consumer.Subscribe(topics[0]);
                }
                else
                {
                    consumer.Subscribe(topics);
                }
                return;
            }
            var config = new ConsumerConfig
            {
                BootstrapServers = bootstrapServers.Text,
                AutoOffsetReset = AutoOffsetReset.Earliest,
            };
            if (!string.IsNullOrWhiteSpace(clientGroupId.Text))
            {
                config.GroupId = clientGroupId.Text;
            }
            if (!string.IsNullOrWhiteSpace(username.Text) &&
                !string.IsNullOrWhiteSpace(password.Text))
            {
                config.SaslUsername = username.Text;
                config.SaslPassword = password.Text;
                if (securityProtocol.SelectedItem != null)
                {
                    config.SecurityProtocol = ((ComboboxItem<SecurityProtocol>)securityProtocol.SelectedItem).Value;
                    if (config.SecurityProtocol == SecurityProtocol.SaslSsl
                        || config.SecurityProtocol == SecurityProtocol.Ssl)
                    {
                        config.SslCaLocation = caCertificateFileLocation.Text;
                    }
                }
                if (saslMechanism.SelectedItem != null)
                {
                    config.SaslMechanism = ((ComboboxItem<SaslMechanism>)saslMechanism.SelectedItem).Value;
                }
            }
            Task.Run(() =>
            {
                CreateConsumer(config, topics);
            });
        }

        private void CreateConsumer(ConsumerConfig config, string[] topics)
        {
            try
            {
                consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            }
            catch (Exception ex)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    status.Text = $"Could not create consumer: {ex.Message}";
                }));
                return;
            }
            if (topics.Length == 1)
            {
                consumer.Subscribe(topics[0]);
            }
            else
            {
                consumer.Subscribe(topics);
            }
            consumerCancellationTS = new CancellationTokenSource();
            while (true)
            {
                try
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        status.Text = $"Consuming";
                    }));
                    var cr = consumer.Consume(consumerCancellationTS.Token);
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        output.AppendText($"Consumed message at '{cr.TopicPartitionOffset}' on {DateTime.Now}:");
                        output.AppendText(Environment.NewLine);
                        output.AppendText($"{cr.Value}");
                        output.AppendText(Environment.NewLine);
                        output.AppendText(Environment.NewLine);
                    }));
                }
                catch (ConsumeException ex)
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        status.Text = $"Error occured: {ex.Error.Reason}";
                    }));
                }
                catch (OperationCanceledException)
                {
                    // Ensure the consumer leaves the group cleanly and final offsets are committed.
                    consumer.Close();
                    break;
                }
            }
            consumer.Dispose();
            consumer = null;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            if (consumer != null)
            {
                consumer.Unsubscribe();
                consumerCancellationTS.Cancel();
                consumerCancellationTS.Dispose();
            }
            if (producer != null)
            {
                producer.Dispose();
                producer = null;
            }
            status.Text = "Reset complete";
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            output.ScrollToEnd();
            if (securityProtocol.Tag is SecurityProtocol)
            {
                int i = 0;
                foreach(ComboboxItem<SecurityProtocol> item in securityProtocol.Items)
                {
                    if ((SecurityProtocol)securityProtocol.Tag == item.Value)
                    {
                        securityProtocol.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }
            if (saslMechanism.Tag is SaslMechanism)
            {
                int i = 0;
                foreach (ComboboxItem<SaslMechanism> item in saslMechanism.Items)
                {
                    if ((SaslMechanism)saslMechanism.Tag == item.Value)
                    {
                        saslMechanism.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }
        }

        private void securityProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (securityProtocol.SelectedItem == null)
            {
                return;
            }
            securityProtocol.Tag = ((ComboboxItem<SecurityProtocol>)securityProtocol.SelectedItem).Value;
        }

        private void saslMechanism_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (saslMechanism.SelectedItem == null)
            {
                return;
            }
            saslMechanism.Tag = ((ComboboxItem<SaslMechanism>)saslMechanism.SelectedItem).Value;
        }
    }
}
