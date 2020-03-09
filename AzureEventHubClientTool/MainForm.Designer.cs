namespace AzureEventHubClientTool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.groupBoxReceiver = new System.Windows.Forms.GroupBox();
            this.outputTextBox = new Common.OutputTextBox();
            this.buttonRecDisconnect = new System.Windows.Forms.Button();
            this.buttonRecConnect = new System.Windows.Forms.Button();
            this.textBoxRecStorageConn = new System.Windows.Forms.TextBox();
            this.labelRecStorageConn = new System.Windows.Forms.Label();
            this.textBoxRecStorageName = new System.Windows.Forms.TextBox();
            this.labelRecStorageName = new System.Windows.Forms.Label();
            this.textBoxRecEvHubConn = new System.Windows.Forms.TextBox();
            this.labelRecEvHubConn = new System.Windows.Forms.Label();
            this.textBoxRecEvHubName = new System.Windows.Forms.TextBox();
            this.labelRecEvHubName = new System.Windows.Forms.Label();
            this.groupBoxSender = new System.Windows.Forms.GroupBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.inputTextBox = new Common.InputTextBox();
            this.textBoxSenEvHubConn = new System.Windows.Forms.TextBox();
            this.labelSenEvHubConn = new System.Windows.Forms.Label();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.groupBoxReceiver.SuspendLayout();
            this.groupBoxSender.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 505);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(828, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // groupBoxReceiver
            // 
            this.groupBoxReceiver.Controls.Add(this.outputTextBox);
            this.groupBoxReceiver.Controls.Add(this.buttonRecDisconnect);
            this.groupBoxReceiver.Controls.Add(this.buttonRecConnect);
            this.groupBoxReceiver.Controls.Add(this.textBoxRecStorageConn);
            this.groupBoxReceiver.Controls.Add(this.labelRecStorageConn);
            this.groupBoxReceiver.Controls.Add(this.textBoxRecStorageName);
            this.groupBoxReceiver.Controls.Add(this.labelRecStorageName);
            this.groupBoxReceiver.Controls.Add(this.textBoxRecEvHubConn);
            this.groupBoxReceiver.Controls.Add(this.labelRecEvHubConn);
            this.groupBoxReceiver.Controls.Add(this.textBoxRecEvHubName);
            this.groupBoxReceiver.Controls.Add(this.labelRecEvHubName);
            this.groupBoxReceiver.Location = new System.Drawing.Point(4, 5);
            this.groupBoxReceiver.Name = "groupBoxReceiver";
            this.groupBoxReceiver.Size = new System.Drawing.Size(409, 497);
            this.groupBoxReceiver.TabIndex = 1;
            this.groupBoxReceiver.TabStop = false;
            this.groupBoxReceiver.Text = "RECEIVER";
            // 
            // outputTextBox
            // 
            this.outputTextBox.AppendBinaryChecked = false;
            this.outputTextBox.Location = new System.Drawing.Point(12, 141);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(391, 347);
            this.outputTextBox.TabIndex = 10;
            this.outputTextBox.TextValue = "";
            // 
            // buttonRecDisconnect
            // 
            this.buttonRecDisconnect.Location = new System.Drawing.Point(93, 110);
            this.buttonRecDisconnect.Name = "buttonRecDisconnect";
            this.buttonRecDisconnect.Size = new System.Drawing.Size(75, 23);
            this.buttonRecDisconnect.TabIndex = 9;
            this.buttonRecDisconnect.Text = "Disconnect";
            this.buttonRecDisconnect.UseVisualStyleBackColor = true;
            this.buttonRecDisconnect.Click += new System.EventHandler(this.buttonRecDisconnect_Click);
            // 
            // buttonRecConnect
            // 
            this.buttonRecConnect.Location = new System.Drawing.Point(12, 110);
            this.buttonRecConnect.Name = "buttonRecConnect";
            this.buttonRecConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonRecConnect.TabIndex = 8;
            this.buttonRecConnect.Text = "Connect";
            this.buttonRecConnect.UseVisualStyleBackColor = true;
            this.buttonRecConnect.Click += new System.EventHandler(this.buttonRecConnect_Click);
            // 
            // textBoxRecStorageConn
            // 
            this.textBoxRecStorageConn.Location = new System.Drawing.Point(171, 84);
            this.textBoxRecStorageConn.Name = "textBoxRecStorageConn";
            this.textBoxRecStorageConn.Size = new System.Drawing.Size(232, 20);
            this.textBoxRecStorageConn.TabIndex = 7;
            // 
            // labelRecStorageConn
            // 
            this.labelRecStorageConn.AutoSize = true;
            this.labelRecStorageConn.Location = new System.Drawing.Point(168, 67);
            this.labelRecStorageConn.Name = "labelRecStorageConn";
            this.labelRecStorageConn.Size = new System.Drawing.Size(131, 13);
            this.labelRecStorageConn.TabIndex = 6;
            this.labelRecStorageConn.Text = "Storage Connection String";
            // 
            // textBoxRecStorageName
            // 
            this.textBoxRecStorageName.Location = new System.Drawing.Point(12, 84);
            this.textBoxRecStorageName.Name = "textBoxRecStorageName";
            this.textBoxRecStorageName.Size = new System.Drawing.Size(153, 20);
            this.textBoxRecStorageName.TabIndex = 5;
            // 
            // labelRecStorageName
            // 
            this.labelRecStorageName.AutoSize = true;
            this.labelRecStorageName.Location = new System.Drawing.Point(9, 67);
            this.labelRecStorageName.Name = "labelRecStorageName";
            this.labelRecStorageName.Size = new System.Drawing.Size(123, 13);
            this.labelRecStorageName.TabIndex = 4;
            this.labelRecStorageName.Text = "Storage Container Name";
            // 
            // textBoxRecEvHubConn
            // 
            this.textBoxRecEvHubConn.Location = new System.Drawing.Point(171, 42);
            this.textBoxRecEvHubConn.Name = "textBoxRecEvHubConn";
            this.textBoxRecEvHubConn.Size = new System.Drawing.Size(232, 20);
            this.textBoxRecEvHubConn.TabIndex = 3;
            // 
            // labelRecEvHubConn
            // 
            this.labelRecEvHubConn.AutoSize = true;
            this.labelRecEvHubConn.Location = new System.Drawing.Point(168, 25);
            this.labelRecEvHubConn.Name = "labelRecEvHubConn";
            this.labelRecEvHubConn.Size = new System.Drawing.Size(142, 13);
            this.labelRecEvHubConn.TabIndex = 2;
            this.labelRecEvHubConn.Text = "EventHub Connection String";
            // 
            // textBoxRecEvHubName
            // 
            this.textBoxRecEvHubName.Location = new System.Drawing.Point(12, 42);
            this.textBoxRecEvHubName.Name = "textBoxRecEvHubName";
            this.textBoxRecEvHubName.Size = new System.Drawing.Size(153, 20);
            this.textBoxRecEvHubName.TabIndex = 1;
            // 
            // labelRecEvHubName
            // 
            this.labelRecEvHubName.AutoSize = true;
            this.labelRecEvHubName.Location = new System.Drawing.Point(9, 25);
            this.labelRecEvHubName.Name = "labelRecEvHubName";
            this.labelRecEvHubName.Size = new System.Drawing.Size(86, 13);
            this.labelRecEvHubName.TabIndex = 0;
            this.labelRecEvHubName.Text = "EventHub Name";
            // 
            // groupBoxSender
            // 
            this.groupBoxSender.Controls.Add(this.buttonSend);
            this.groupBoxSender.Controls.Add(this.inputTextBox);
            this.groupBoxSender.Controls.Add(this.textBoxSenEvHubConn);
            this.groupBoxSender.Controls.Add(this.labelSenEvHubConn);
            this.groupBoxSender.Location = new System.Drawing.Point(415, 5);
            this.groupBoxSender.Name = "groupBoxSender";
            this.groupBoxSender.Size = new System.Drawing.Size(409, 497);
            this.groupBoxSender.TabIndex = 2;
            this.groupBoxSender.TabStop = false;
            this.groupBoxSender.Text = "SENDER";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(326, 468);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 11;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // inputTextBox
            // 
            this.inputTextBox.BinaryChecked = false;
            this.inputTextBox.ChangeEndOfLine = true;
            this.inputTextBox.EndOfLine = Common.EndOfLine.Dos;
            this.inputTextBox.Location = new System.Drawing.Point(9, 69);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.SelectedTextValue = "";
            this.inputTextBox.Size = new System.Drawing.Size(392, 422);
            this.inputTextBox.TabIndex = 13;
            this.inputTextBox.TextValue = "";
            // 
            // textBoxSenEvHubConn
            // 
            this.textBoxSenEvHubConn.Location = new System.Drawing.Point(9, 42);
            this.textBoxSenEvHubConn.Name = "textBoxSenEvHubConn";
            this.textBoxSenEvHubConn.Size = new System.Drawing.Size(392, 20);
            this.textBoxSenEvHubConn.TabIndex = 12;
            // 
            // labelSenEvHubConn
            // 
            this.labelSenEvHubConn.AutoSize = true;
            this.labelSenEvHubConn.Location = new System.Drawing.Point(6, 25);
            this.labelSenEvHubConn.Name = "labelSenEvHubConn";
            this.labelSenEvHubConn.Size = new System.Drawing.Size(142, 13);
            this.labelSenEvHubConn.TabIndex = 11;
            this.labelSenEvHubConn.Text = "EventHub Connection String";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 527);
            this.Controls.Add(this.groupBoxSender);
            this.Controls.Add(this.groupBoxReceiver);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Azure EventHub Client Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBoxReceiver.ResumeLayout(false);
            this.groupBoxReceiver.PerformLayout();
            this.groupBoxSender.ResumeLayout(false);
            this.groupBoxSender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.GroupBox groupBoxReceiver;
        private System.Windows.Forms.GroupBox groupBoxSender;
        private Common.OutputTextBox outputTextBox;
        private System.Windows.Forms.Button buttonRecDisconnect;
        private System.Windows.Forms.Button buttonRecConnect;
        private System.Windows.Forms.TextBox textBoxRecStorageConn;
        private System.Windows.Forms.Label labelRecStorageConn;
        private System.Windows.Forms.TextBox textBoxRecStorageName;
        private System.Windows.Forms.Label labelRecStorageName;
        private System.Windows.Forms.TextBox textBoxRecEvHubConn;
        private System.Windows.Forms.Label labelRecEvHubConn;
        private System.Windows.Forms.TextBox textBoxRecEvHubName;
        private System.Windows.Forms.Label labelRecEvHubName;
        private System.Windows.Forms.Button buttonSend;
        private Common.InputTextBox inputTextBox;
        private System.Windows.Forms.TextBox textBoxSenEvHubConn;
        private System.Windows.Forms.Label labelSenEvHubConn;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}