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

                this.outputTextBox.BeginInvoke((Action)(() =>
                {
                    this.outputTextBox.AppendText($"Consumed message at offset '{eventData.Body.Offset}' on {DateTime.Now}:");
                    this.outputTextBox.AppendText(Environment.NewLine);
                    this.outputTextBox.AppendText(message);
                    this.outputTextBox.AppendText(Environment.NewLine);
                    this.outputTextBox.AppendText(Environment.NewLine);
                }));
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

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            this.SetStatusBarInfo("Sending message...");

            await EventSender.SendMessageAsync(this.inputTextBox.TextValue, this.textBoxSenEvHubConn.Text)
                .ContinueWith(t =>
                {
                    if(!t.IsFaulted)
                        statusStrip.BeginInvoke((Action)(() => this.SetStatusBarSuccess("Message Sent")));
                    else
                    {
                        this.BeginInvoke((Action)(() =>
                        {
                            string errorMessage = "Error while sending message";
                            this.SetStatusBarError(errorMessage);
                            MessageBox.Show($"{t.Exception.InnerException.GetType()}: {t.Exception.InnerException.Message}",
                                errorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                });
        }

        private void buttonRecConnect_Click(object sender, EventArgs e)
        {
            this.SetStatusBarInfo("Connecting...");

            this.buttonRecConnect.Enabled = false;
            this.buttonRecDisconnect.Enabled = false;

            this.eventReceiver.Connect(this.textBoxRecEvHubName.Text, this.textBoxRecEvHubConn.Text,
                this.textBoxRecStorageName.Text, this.textBoxRecStorageConn.Text)
                .ContinueWith((t) =>
                {
                    if(t.IsFaulted)
                    {
                        this.BeginInvoke((Action)(() =>
                        {
                            this.buttonRecConnect.Enabled = true;
                            this.buttonRecDisconnect.Enabled = false;
                            string errorMessage = "Error while connecting";
                            this.SetStatusBarError(errorMessage);
                            MessageBox.Show($"{t.Exception.InnerException.GetType()}: {t.Exception.InnerException.Message}", 
                                errorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                    else
                    {
                        this.BeginInvoke((Action)(() =>
                        {
                            this.buttonRecConnect.Enabled = false;
                            this.buttonRecDisconnect.Enabled = true;
                            this.SetStatusBarSuccess("Connected");
                        }));
                    }
                });
        }

        private void buttonRecDisconnect_Click(object sender, EventArgs e)
        {
            this.SetStatusBarInfo("Disconnecting... (It might take a while)");

            this.buttonRecConnect.Enabled = false;
            this.buttonRecDisconnect.Enabled = false;

            this.eventReceiver.Disconnect()
                .ContinueWith((t) =>
                {
                    this.BeginInvoke((Action)(() =>
                    {
                        this.buttonRecConnect.Enabled = true;
                        this.buttonRecDisconnect.Enabled = false;
                        this.SetStatusBarInfo("Disconnected");
                    }));
                });
        }
    }
}
