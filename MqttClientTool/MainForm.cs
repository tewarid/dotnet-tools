using Common;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Protocol;
using MQTTnet.Serializer;
using System;
using System.IO;
using System.Windows.Forms;

namespace MqttClientTool
{
    public partial class MainForm : Form
    {
        private IManagedMqttClient mqttClient;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void Publish_Click(object sender, EventArgs e)
        {
            if (mqttClient == null || !mqttClient.IsConnected)
            {
                return;
            }
            MqttApplicationMessageBuilder messageBuilder = new MqttApplicationMessageBuilder()
                .WithPayload(new MemoryStream(input.Bytes), input.Bytes.Length)
                .WithTopic(topicPublish.Text);
            if (qosPublish.SelectedIndex >= 0)
            {
                messageBuilder.WithQualityOfServiceLevel((MqttQualityOfServiceLevel)qosPublish.SelectedIndex);
            }
            messageBuilder.WithRetainFlag(retain.Checked);
            ManagedMqttApplicationMessage message = new ManagedMqttApplicationMessageBuilder()
                .WithApplicationMessage(messageBuilder.Build())
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
            if (!string.IsNullOrWhiteSpace(topicSubscribe.Text))
            {
                int index = subscriptions.Items.IndexOf(topicSubscribe.Text);
                if (index >= 0)
                {
                    subscriptions.SelectedIndex = index;
                    return;
                }
                TopicFilterBuilder builder = new TopicFilterBuilder()
                    .WithTopic(topicSubscribe.Text);
                if (qosSubscribe.SelectedIndex >= 0)
                {
                    builder.WithQualityOfServiceLevel((MqttQualityOfServiceLevel)qosSubscribe.SelectedIndex);
                }
                try
                {
                    await mqttClient.SubscribeAsync(builder.Build());
                    subscriptions.Items.Add(topicSubscribe.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
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
            if (!string.IsNullOrWhiteSpace(clientId.Text))
            {
                clientOptions.WithClientId(clientId.Text);
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
            if (string.IsNullOrWhiteSpace(clientId.Text))
            {
                clientId.Text = mqttClient.Options.ClientOptions.ClientId;
            }
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

        private void UseWebSocket_CheckedChanged(object sender, EventArgs e)
        {
            port.Enabled = !useWebSocket.Checked;
        }
    }
}
