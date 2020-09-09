using Common;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AzureEventHubClientTool
{
    [MainForm(Name = "Azure EventHub Client Tool")]
    public partial class MainForm : Form
    {
        EventReceiver eventReceiver;

        public MainForm()
        {
            InitializeComponent();
            SetUIComponentsInitialState();
            SetToolTips();
            SetEventReceiver();
        }

        private void SetUIComponentsInitialState()
        {
            textBoxSenEvHubConn.Text = Properties.Settings.Default.senderConnectionString;
            inputTextBox.TextValue = Properties.Settings.Default.input;
            textBoxRecEvHubName.Text = Properties.Settings.Default.receiverEvHubName;
            textBoxRecEvHubConn.Text = Properties.Settings.Default.receiverEvHubConnectionString;
            textBoxRecStorageName.Text = Properties.Settings.Default.receiverStorageName;
            textBoxRecStorageConn.Text = Properties.Settings.Default.receiverStorageConnectionString;
            textBoxRecConsumerGroup.Text = Properties.Settings.Default.consumerGroup;
            outputTextBox.TextValue = Properties.Settings.Default.output;

            receiverConnect.Enabled = true;
            receiverDisconnect.Enabled = false;
        }

        private void SetToolTips()
        {
            toolTip.SetToolTip(textBoxRecEvHubName, ConstantMessages.TooltipEventHubName);
            toolTip.SetToolTip(textBoxSenEvHubConn, ConstantMessages.TooltipEventHubConnectionString);
            toolTip.SetToolTip(textBoxRecEvHubConn, ConstantMessages.TooltipEventHubConnectionString);
            toolTip.SetToolTip(textBoxRecStorageName, ConstantMessages.TooltipStorageName);
            toolTip.SetToolTip(textBoxRecStorageConn, ConstantMessages.TooltipStorageConnectionString);
            toolTip.SetToolTip(textBoxRecConsumerGroup, ConstantMessages.TooltipConsumerGroup);
        }

        private void SetEventReceiver()
        {
            CustomEventProcessor.OnEventReceived += (o, data) =>
            {
                var eventData = data.EventData;
                string message = Encoding.UTF8.GetString(eventData.Body.Array, eventData.Body.Offset, eventData.Body.Count);

                outputTextBox.BeginInvoke((Action)(() =>
                {
                    outputTextBox.AppendText(string.Format(ConstantMessages.ConsumedMessageHeaderTemplate,
                        data.PartitionContext.PartitionId, eventData.Body.Offset, DateTime.Now));
                    outputTextBox.AppendText(Environment.NewLine);
                    outputTextBox.AppendText(message);
                    outputTextBox.AppendText(Environment.NewLine);
                    outputTextBox.AppendText(Environment.NewLine);
                }));
            };

            eventReceiver = new EventReceiver();
        }

        private void SetStatusBarInfo(string msg)
        {
            toolStripStatusLabel.Text = msg;
            toolStripStatusLabel.ForeColor = Color.Black;
        }

        private void SetStatusBarError(string errorMsg)
        {
            toolStripStatusLabel.Text = errorMsg;
            toolStripStatusLabel.ForeColor = Color.Red;
        }

        private void SetStatusBarSuccess(string errorMsg)
        {
            toolStripStatusLabel.Text = errorMsg;
            toolStripStatusLabel.ForeColor = Color.Green;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.senderConnectionString = textBoxSenEvHubConn.Text;
            Properties.Settings.Default.input = inputTextBox.TextValue;
            Properties.Settings.Default.receiverEvHubName = textBoxRecEvHubName.Text;
            Properties.Settings.Default.receiverEvHubConnectionString = textBoxRecEvHubConn.Text;
            Properties.Settings.Default.receiverStorageName = textBoxRecStorageName.Text;
            Properties.Settings.Default.receiverStorageConnectionString = textBoxRecStorageConn.Text;
            Properties.Settings.Default.consumerGroup = textBoxRecConsumerGroup.Text;
            Properties.Settings.Default.output = outputTextBox.TextValue;
            Properties.Settings.Default.Save();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            outputTextBox.ScrollToEnd();
        }

        private async void Produce_Click(object sender, EventArgs e)
        {
            SetStatusBarInfo(ConstantMessages.SendingMessage);

            try
            {
                await EventSender.SendMessageAsync(inputTextBox.TextValue, textBoxSenEvHubConn.Text);
            }
            catch (Exception ex)
            {
                string errorMessage = ConstantMessages.ErrorSendingMessage;
                SetStatusBarError(errorMessage);
                MessageBox.Show(
                    string.Format(ConstantMessages.ExceptionDisplayFormat, ex.GetType(), ex.Message),
                    errorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                return;
            }
            statusStrip.BeginInvoke((Action)(() => SetStatusBarSuccess(ConstantMessages.MessageSent)));
        }

        private async void ReceiverConnect_Click(object sender, EventArgs e)
        {
            SetStatusBarInfo(ConstantMessages.Connecting);
            receiverConnect.Enabled = false;
            receiverDisconnect.Enabled = false;
            try
            {
                await eventReceiver.Connect(textBoxRecEvHubName.Text, textBoxRecEvHubConn.Text,
                    textBoxRecStorageName.Text, textBoxRecStorageConn.Text,
                    textBoxRecConsumerGroup.Text);
            }
            catch (Exception ex)
            {
                receiverConnect.Enabled = true;
                receiverDisconnect.Enabled = false;
                SetStatusBarError(ConstantMessages.ErrorConnecting);
                MessageBox.Show(
                    string.Format(ConstantMessages.ExceptionDisplayFormat, ex.GetType(), ex.Message),
                    ConstantMessages.ErrorConnecting, MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                return;
            }
            receiverConnect.Enabled = false;
            receiverDisconnect.Enabled = true;
            SetStatusBarSuccess(ConstantMessages.Connected);
        }

        private async void ReceiverDisconnect_Click(object sender, EventArgs e)
        {
            SetStatusBarInfo(ConstantMessages.Disconnecting);

            receiverConnect.Enabled = false;
            receiverDisconnect.Enabled = false;

            await eventReceiver.Disconnect();
            
            receiverConnect.Enabled = true;
            receiverDisconnect.Enabled = false;
            SetStatusBarInfo(ConstantMessages.Disconnected);
        }
    }
}
