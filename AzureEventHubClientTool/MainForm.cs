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
            this.SetUIComponentsInitialState();
            this.SetToolTips();
            this.SetEventReceiver();
        }

        private void SetUIComponentsInitialState()
        {
            this.textBoxSenEvHubConn.Text = Properties.Settings.Default.senderConnectionString;
            this.inputTextBox.TextValue = Properties.Settings.Default.input;
            this.textBoxRecEvHubName.Text = Properties.Settings.Default.receiverEvHubName;
            this.textBoxRecEvHubConn.Text = Properties.Settings.Default.receiverEvHubConnectionString;
            this.textBoxRecStorageName.Text = Properties.Settings.Default.receiverStorageName;
            this.textBoxRecStorageConn.Text = Properties.Settings.Default.receiverStorageConnectionString;
            this.outputTextBox.TextValue = Properties.Settings.Default.output;

            this.buttonRecConnect.Enabled = true;
            this.buttonRecDisconnect.Enabled = false;
        }

        private void SetToolTips()
        {
            this.toolTip.SetToolTip(this.textBoxRecEvHubName, ConstantMessages.TooltipEventHubName);
            this.toolTip.SetToolTip(this.textBoxSenEvHubConn, ConstantMessages.TooltipEventHubConnectionString);
            this.toolTip.SetToolTip(this.textBoxRecEvHubConn, ConstantMessages.TooltipEventHubConnectionString);
            this.toolTip.SetToolTip(this.textBoxRecStorageName, ConstantMessages.TooltipStorageName);
            this.toolTip.SetToolTip(this.textBoxRecStorageConn, ConstantMessages.TooltipStorageConnectionString);
        }

        private void SetEventReceiver()
        {
            CustomEventProcessor.OnEventReceived += (o, eventData) =>
            {
                string message = Encoding.UTF8.GetString(eventData.Body.Array, eventData.Body.Offset, eventData.Body.Count);

                this.outputTextBox.BeginInvoke((Action)(() =>
                {
                    this.outputTextBox.AppendText(string.Format(ConstantMessages.ConsumedMessageHeaderTemplate, eventData.Body.Offset, DateTime.Now));
                    this.outputTextBox.AppendText(Environment.NewLine);
                    this.outputTextBox.AppendText(message);
                    this.outputTextBox.AppendText(Environment.NewLine);
                    this.outputTextBox.AppendText(Environment.NewLine);
                }));
            };

            this.eventReceiver = new EventReceiver();
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
            this.SetStatusBarInfo(ConstantMessages.SendingMessage);

            await EventSender.SendMessageAsync(this.inputTextBox.TextValue, this.textBoxSenEvHubConn.Text)
                .ContinueWith(t =>
                {
                    if(!t.IsFaulted)
                        statusStrip.BeginInvoke((Action)(() => this.SetStatusBarSuccess(ConstantMessages.MessageSent)));
                    else
                    {
                        this.BeginInvoke((Action)(() =>
                        {
                            string errorMessage = ConstantMessages.ErrorSendingMessage;
                            this.SetStatusBarError(errorMessage);
                            MessageBox.Show(
                                string.Format(ConstantMessages.ExceptionDisplayFormat, t.Exception.InnerException.GetType(), t.Exception.InnerException.Message),
                                errorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error
                            );
                        }));
                    }
                });
        }

        private void buttonRecConnect_Click(object sender, EventArgs e)
        {
            this.SetStatusBarInfo(ConstantMessages.Connecting);

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
                            this.SetStatusBarError(ConstantMessages.ErrorConnecting);
                            MessageBox.Show(
                                string.Format(ConstantMessages.ExceptionDisplayFormat, t.Exception.InnerException.GetType(), t.Exception.InnerException.Message),
                                ConstantMessages.ErrorConnecting, MessageBoxButtons.OK, MessageBoxIcon.Error
                            );
                        }));
                    }
                    else
                    {
                        this.BeginInvoke((Action)(() =>
                        {
                            this.buttonRecConnect.Enabled = false;
                            this.buttonRecDisconnect.Enabled = true;
                            this.SetStatusBarSuccess(ConstantMessages.Connected);
                        }));
                    }
                });
        }

        private void buttonRecDisconnect_Click(object sender, EventArgs e)
        {
            this.SetStatusBarInfo(ConstantMessages.Disconnecting);

            this.buttonRecConnect.Enabled = false;
            this.buttonRecDisconnect.Enabled = false;

            this.eventReceiver.Disconnect().ContinueWith((t) =>
            {
                this.BeginInvoke((Action)(() =>
                {
                    this.buttonRecConnect.Enabled = true;
                    this.buttonRecDisconnect.Enabled = false;
                    this.SetStatusBarInfo(ConstantMessages.Disconnected);
                }));
            });
        }
    }
}
