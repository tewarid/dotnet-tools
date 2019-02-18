using Common;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Serializer;
using System;
using System.IO;
using System.Windows.Forms;

namespace MqttClientTool
{
    public partial class MainForm : Form
    {
        private readonly InputDialog<Topic> dialog = new InputDialog<Topic>();
        private IManagedMqttClient mqttClient;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void Send_Click(object sender, EventArgs e)
        {
            if (mqttClient == null || !mqttClient.IsConnected)
            {
                return;
            }
            ManagedMqttApplicationMessage message = new ManagedMqttApplicationMessageBuilder()
                .WithApplicationMessage(new MqttApplicationMessageBuilder()
                .WithPayload(new MemoryStream(input.Bytes), input.Bytes.Length)
                .WithTopic(topic.Text)
                .Build())
                .Build();
            await mqttClient.PublishAsync(message);
        }

        private void MqttClient_ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            BeginInvoke(new MethodInvoker(() => {
                output.AppendText($"Topic {e.ApplicationMessage.Topic} on {DateTime.Now}:{Environment.NewLine}");
                output.Append(e.ApplicationMessage.Payload, e.ApplicationMessage.Payload.Length);
                output.AppendText(Environment.NewLine);
                output.AppendText(Environment.NewLine);
            }));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private async void Subscribe_Click(object sender, EventArgs e)
        {
            if (mqttClient == null || !mqttClient.IsConnected)
            {
                return;
            }
            if (dialog.Show(this, "Specify topic to subscribe to", string.Empty) == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(dialog.Value.Text))
                {
                    await mqttClient.SubscribeAsync(new TopicFilterBuilder()
                        .WithTopic(dialog.Value.Text).Build());
                    subscriptions.Items.Add(dialog.Value.Text);
                }
            }
        }

        private async void Unsubscribe_Click(object sender, EventArgs e)
        {
            if (mqttClient == null || !mqttClient.IsConnected)
            {
                return;
            }
            int index = subscriptions.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            await mqttClient.UnsubscribeAsync((string)subscriptions.Items[index]);
            subscriptions.Items.RemoveAt(index);
        }

        private async void Start_Click(object sender, EventArgs e)
        {
            if (mqttClient == null)
            {
                mqttClient = new MqttFactory().CreateManagedMqttClient();
                mqttClient.ApplicationMessageReceived += MqttClient_ApplicationMessageReceived;
                mqttClient.Disconnected += MqttClient_Disconnected;
                mqttClient.Connected += MqttClient_Connected;
                mqttClient.ConnectingFailed += MqttClient_ConnectingFailed;
            }
            if (mqttClient.IsConnected)
            {
                return;
            }
            status.Text = "Starting";
            var clientOptions = new MqttClientOptionsBuilder();
            clientOptions.WithProtocolVersion(MqttProtocolVersion.V311);
            if (!string.IsNullOrWhiteSpace(username.Text))
            {
                if (!string.IsNullOrWhiteSpace(password.Text))
                {
                    clientOptions.WithCredentials(username.Text, password.Text);
                }
                else
                {
                    clientOptions.WithCredentials(username.Text);
                }
            }
            if (useTls.Checked)
            {
                clientOptions.WithTls();
            }
            if (useWebSocket.Checked)
            {
                clientOptions.WithWebSocketServer(host.Text);
            }
            else
            {
                clientOptions.WithTcpServer(host.Text, int.Parse(port.Text));
            }
            var options = new ManagedMqttClientOptionsBuilder()
                .WithAutoReconnectDelay(TimeSpan.FromSeconds(30))
                .WithClientOptions(clientOptions)
                .Build();
            await mqttClient.StartAsync(options);
        }

        private void MqttClient_ConnectingFailed(object sender, MqttManagedProcessFailedEventArgs e)
        {
            status.Text = "Failed";
            mqttClient.StopAsync();
        }

        private void MqttClient_Connected(object sender, MqttClientConnectedEventArgs e)
        {
            status.Text = "Connected";
        }

        private void MqttClient_Disconnected(object sender, MqttClientDisconnectedEventArgs e)
        {
            status.Text = "Disconnected";
        }

        private async void Stop_Click(object sender, EventArgs e)
        {
            if (mqttClient == null || !mqttClient.IsConnected)
            {
                return;
            }
            await mqttClient.StopAsync();
        }
    }
}
