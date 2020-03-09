using Microsoft.Azure.EventHubs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureEventHubClientTool
{
    public partial class MainForm : Form
    {
        EventReceiver eventReceiver;

        public MainForm()
        {
            InitializeComponent();

            this.textBoxSenEvHubConn.Text = Properties.Settings.Default.senderConnectionString;
            this.inputTextBox.TextValue = Properties.Settings.Default.input;
            this.textBoxRecEvHubName.Text = Properties.Settings.Default.receiverEvHubName;
            this.textBoxRecEvHubConn.Text = Properties.Settings.Default.receiverEvHubConnectionString;
            this.textBoxRecStorageName.Text = Properties.Settings.Default.receiverStorageName;
            this.textBoxRecStorageConn.Text = Properties.Settings.Default.receiverStorageConnectionString;
            this.outputTextBox.TextValue = Properties.Settings.Default.output;

            this.buttonRecConnect.Enabled = true;
            this.buttonRecDisconnect.Enabled = false;

            CustomEventProcessor.OnEventReceived += (o, eventData) =>
            {
                string message = Encoding.UTF8.GetString(eventData.Body.Array, eventData.Body.Offset, eventData.Body.Count);

                this.outputTextBox.BeginInvoke((Action)(() => this.outputTextBox.AppendText($"Consumed message at '{eventData.Body.Offset}' on {DateTime.Now}:")));
                this.outputTextBox.BeginInvoke((Action)(() => this.outputTextBox.AppendText(Environment.NewLine)));
                this.outputTextBox.BeginInvoke((Action)(() => this.outputTextBox.AppendText(message)));
                this.outputTextBox.BeginInvoke((Action)(() => this.outputTextBox.AppendText(Environment.NewLine)));
                this.outputTextBox.BeginInvoke((Action)(() => this.outputTextBox.AppendText(Environment.NewLine)));
            };

            this.eventReceiver = new EventReceiver();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.senderConnectionString = this.textBoxSenEvHubConn.Text;
            Properties.Settings.Default.input = this.inputTextBox.TextValue;
            Properties.Settings.Default.receiverEvHubName = this.textBoxRecEvHubName.Text;
            Properties.Settings.Default.receiverEvHubConnectionString = this.textBoxRecEvHubConn.Text;
            Properties.Settings.Default.receiverStorageName = this.textBoxRecStorageName.Text;
            Properties.Settings.Default.receiverStorageConnectionString = this.textBoxRecStorageConn.Text;
            Properties.Settings.Default.output = this.outputTextBox.TextValue;
            Properties.Settings.Default.Save();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.outputTextBox.ScrollToEnd();
        }

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel.Text = "Sending message...";

            await EventSender.SendMessageAsync(this.inputTextBox.TextValue, this.textBoxSenEvHubConn.Text)
                .ContinueWith(t =>
                {
                    if(!t.IsFaulted)
                        statusStrip.BeginInvoke((Action)(() => toolStripStatusLabel.Text = "Message Sent"));
                    else
                        statusStrip.BeginInvoke((Action)(() => toolStripStatusLabel.Text = "Error while sending message"));
                });
        }

        private void buttonRecConnect_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel.Text = "Connecting...";

            this.buttonRecConnect.Enabled = false;
            this.buttonRecDisconnect.Enabled = false;

            this.eventReceiver.Connect(this.textBoxRecEvHubName.Text, this.textBoxRecEvHubConn.Text,
                this.textBoxRecStorageName.Text, this.textBoxRecStorageConn.Text)
                .ContinueWith((t) =>
                {
                    if(t.IsFaulted)
                    {
                        this.BeginInvoke((Action)(() => this.buttonRecConnect.Enabled = true));
                        this.BeginInvoke((Action)(() => this.buttonRecDisconnect.Enabled = false));
                        statusStrip.BeginInvoke((Action)(() => toolStripStatusLabel.Text = "Error while connecting"));
                    }
                    else
                    {
                        this.BeginInvoke((Action)(() => this.buttonRecConnect.Enabled = false));
                        this.BeginInvoke((Action)(() => this.buttonRecDisconnect.Enabled = true));
                        statusStrip.BeginInvoke((Action)(() => toolStripStatusLabel.Text = "Connected"));
                    }
                });
        }

        private void buttonRecDisconnect_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel.Text = "Disconnecting... (It might take a while)";

            this.buttonRecConnect.Enabled = false;
            this.buttonRecDisconnect.Enabled = false;

            this.eventReceiver.Disconnect()
                .ContinueWith((t) =>
                {
                    this.BeginInvoke((Action)(() => this.buttonRecConnect.Enabled = true));
                    this.BeginInvoke((Action)(() => this.buttonRecDisconnect.Enabled = false));
                    statusStrip.BeginInvoke((Action)(() => toolStripStatusLabel.Text = "Disconnected"));
                });
        }
    }
}
