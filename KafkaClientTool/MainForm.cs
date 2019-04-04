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
        IProducer<Null, string> producer;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void Produce_Click(object sender, EventArgs e)
        {
            if (producer == null)
            {
                var config = new ProducerConfig { BootstrapServers = bootstrapServers.Text };
                producer = new ProducerBuilder<Null, string>(config).Build();
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
            if (consumer != null)
            {
                consumer.Subscribe(subscribeToTopic.Text);
                return;
            }

            Task.Run(() =>
            {
                CreateConsumer();
            });
        }

        private void CreateConsumer()
        {
            var conf = new ConsumerConfig
            {
                GroupId = clientGroupId.Text,
                BootstrapServers = bootstrapServers.Text,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            consumer = new ConsumerBuilder<Ignore, string>(conf).Build();
            consumer.Subscribe(subscribeToTopic.Text);
            CancellationTokenSource cts = new CancellationTokenSource();
            while (true)
            {
                try
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        status.Text = $"Consuming...";
                    }));
                    var cr = consumer.Consume(cts.Token);
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
    }
}
