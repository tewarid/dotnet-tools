using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using MQTTnet.Serializer;
using System;
using System.IO;
using System.Windows.Forms;

namespace MqttClientTool
{
    public partial class MainForm : Form
    {
        private IMqttClient mqttClient;

        public MainForm()
        {
            InitializeComponent();
            EnableDisable();
        }

        private void EnableDisable()
        {
            port.Enabled = !useWebSocket.Checked;
            useTls.Enabled = !useWebSocket.Checked;
        }

        private async void Publish_Click(object sender, EventArgs e)
        {
            if (mqttClient == null || !mqttClient.IsConnected)
            {
                return;
            }
            await mqttClient.PublishAsync(BuildMessage());
        }

        private MqttApplicationMessage BuildMessage()
        {
            byte[] data = input.SelectedBinaryValue;
            MqttApplicationMessageBuilder messageBuilder = new MqttApplicationMessageBuilder()
                .WithPayload(new MemoryStream(data), data.Length)
                .WithTopic(topicPublish.Text);
            if (qosPublish.SelectedIndex == -1)
            {
                qosPublish.SelectedIndex = 0;
            }
            messageBuilder.WithQualityOfServiceLevel((MqttQualityOfServiceLevel)qosPublish.SelectedIndex);
            messageBuilder.WithRetainFlag(retain.Checked);
            return messageBuilder.Build();
        }

        private void MqttClient_ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            BeginInvoke(new MethodInvoker(() => {
                output.AppendText($"Topic {e.ApplicationMessage.Topic} on {DateTime.Now}:{Environment.NewLine}");
                output.AppendBinary(e.ApplicationMessage.Payload, e.ApplicationMessage.Payload.Length);
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
                TopicFilterBuilder builder = new TopicFilterBuilder()
                    .WithTopic(topicSubscribe.Text);
                if (qosSubscribe.SelectedIndex == -1)
                {
                    qosSubscribe.SelectedIndex = 0;
                }
                builder.WithQualityOfServiceLevel((MqttQualityOfServiceLevel)qosSubscribe.SelectedIndex);
                try
                {
                    await mqttClient.SubscribeAsync(builder.Build());
                    if (!subscriptions.Items.Contains(topicSubscribe.Text))
                    {
                        subscriptions.Items.Add(topicSubscribe.Text);
                    }
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

        private async void Connect_Click(object sender, EventArgs e)
        {
            if (mqttClient == null)
            {
                mqttClient = new MqttFactory().CreateMqttClient();
                mqttClient.ApplicationMessageReceived += MqttClient_ApplicationMessageReceived;
                mqttClient.Disconnected += MqttClient_Disconnected;
                mqttClient.Connected += MqttClient_Connected;
            }
            if (mqttClient.IsConnected)
            {
                return;
            }
            status.Text = "Connecting...";
            var clientOptionsBuilder = new MqttClientOptionsBuilder();
            clientOptionsBuilder.WithProtocolVersion(MqttProtocolVersion.V311);
            if (!string.IsNullOrWhiteSpace(username.Text))
            {
                if (!string.IsNullOrWhiteSpace(password.Text))
                {
                    clientOptionsBuilder.WithCredentials(username.Text, password.Text);
                }
                else
                {
                    clientOptionsBuilder.WithCredentials(username.Text);
                }
            }
            if (!string.IsNullOrWhiteSpace(clientId.Text))
            {
                clientOptionsBuilder.WithClientId(clientId.Text);
            }
            if (useTls.Checked)
            {
                clientOptionsBuilder.WithTls();
            }
            if (useWebSocket.Checked)
            {
                clientOptionsBuilder.WithWebSocketServer(host.Text);
            }
            else
            {
                clientOptionsBuilder.WithTcpServer(host.Text, int.Parse(port.Text));
            }
            if (cleanSession.Checked)
            {
                clientOptionsBuilder.WithCleanSession(true);
            }
            else
            {
                clientOptionsBuilder.WithCleanSession(false);
            }
            if(setWill.Checked && !string.IsNullOrWhiteSpace(input.TextValue))
            {
                clientOptionsBuilder.WithWillMessage(BuildMessage());
            }
            try
            {
                await mqttClient.ConnectAsync(clientOptionsBuilder.Build());
                clientId.Text = mqttClient.Options.ClientId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void MqttClient_Connected(object sender, MqttClientConnectedEventArgs e)
        {
            status.Text = "Connected";
        }

        private void MqttClient_Disconnected(object sender, MqttClientDisconnectedEventArgs e)
        {
            status.Text = "Disconnected";
            ClearSubscriptions();
        }

        private void ClearSubscriptions()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(ClearSubscriptions));
                return;
            }
            subscriptions.Items.Clear();
        }

        private async void Disconnect_Click(object sender, EventArgs e)
        {
            if (mqttClient == null)
            {
                return;
            }
            status.Text = "Disconnecting...";
            await mqttClient.DisconnectAsync();
        }

        private void UseWebSocket_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisable();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            output.ScrollToEnd();
            input.ScrollToEnd();
        }
    }
}
