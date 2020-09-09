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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxReceiver = new System.Windows.Forms.GroupBox();
            this.textBoxRecConsumerGroup = new System.Windows.Forms.TextBox();
            this.labelRecConsumerGroup = new System.Windows.Forms.Label();
            this.outputTextBox = new Common.OutputTextBox();
            this.receiverDisconnect = new System.Windows.Forms.Button();
            this.receiverConnect = new System.Windows.Forms.Button();
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
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 8000;
            this.toolTip.InitialDelay = 250;
            this.toolTip.ReshowDelay = 50;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxReceiver);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxSender);
            this.splitContainer1.Size = new System.Drawing.Size(828, 505);
            this.splitContainer1.SplitterDistance = 414;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupBoxReceiver
            // 
            this.groupBoxReceiver.Controls.Add(this.textBoxRecConsumerGroup);
            this.groupBoxReceiver.Controls.Add(this.labelRecConsumerGroup);
            this.groupBoxReceiver.Controls.Add(this.outputTextBox);
            this.groupBoxReceiver.Controls.Add(this.receiverDisconnect);
            this.groupBoxReceiver.Controls.Add(this.receiverConnect);
            this.groupBoxReceiver.Controls.Add(this.textBoxRecStorageConn);
            this.groupBoxReceiver.Controls.Add(this.labelRecStorageConn);
            this.groupBoxReceiver.Controls.Add(this.textBoxRecStorageName);
            this.groupBoxReceiver.Controls.Add(this.labelRecStorageName);
            this.groupBoxReceiver.Controls.Add(this.textBoxRecEvHubConn);
            this.groupBoxReceiver.Controls.Add(this.labelRecEvHubConn);
            this.groupBoxReceiver.Controls.Add(this.textBoxRecEvHubName);
            this.groupBoxReceiver.Controls.Add(this.labelRecEvHubName);
            this.groupBoxReceiver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxReceiver.Location = new System.Drawing.Point(0, 0);
            this.groupBoxReceiver.Name = "groupBoxReceiver";
            this.groupBoxReceiver.Size = new System.Drawing.Size(414, 505);
            this.groupBoxReceiver.TabIndex = 2;
            this.groupBoxReceiver.TabStop = false;
            this.groupBoxReceiver.Text = "Consumer";
            // 
            // textBoxRecConsumerGroup
            // 
            this.textBoxRecConsumerGroup.Location = new System.Drawing.Point(12, 126);
            this.textBoxRecConsumerGroup.Name = "textBoxRecConsumerGroup";
            this.textBoxRecConsumerGroup.Size = new System.Drawing.Size(153, 20);
            this.textBoxRecConsumerGroup.TabIndex = 12;
            // 
            // labelRecConsumerGroup
            // 
            this.labelRecConsumerGroup.AutoSize = true;
            this.labelRecConsumerGroup.Location = new System.Drawing.Point(9, 109);
            this.labelRecConsumerGroup.Name = "labelRecConsumerGroup";
            this.labelRecConsumerGroup.Size = new System.Drawing.Size(86, 13);
            this.labelRecConsumerGroup.TabIndex = 11;
            this.labelRecConsumerGroup.Text = "Consumer Group";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTextBox.AppendBinaryChecked = false;
            this.outputTextBox.Location = new System.Drawing.Point(12, 153);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(397, 341);
            this.outputTextBox.TabIndex = 10;
            this.outputTextBox.TextValue = "";
            // 
            // buttonRecDisconnect
            // 
            this.receiverDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.receiverDisconnect.Location = new System.Drawing.Point(330, 124);
            this.receiverDisconnect.Name = "buttonRecDisconnect";
            this.receiverDisconnect.Size = new System.Drawing.Size(75, 23);
            this.receiverDisconnect.TabIndex = 9;
            this.receiverDisconnect.Text = "Disconnect";
            this.receiverDisconnect.UseVisualStyleBackColor = true;
            this.receiverDisconnect.Click += new System.EventHandler(this.ReceiverDisconnect_Click);
            // 
            // buttonRecConnect
            // 
            this.receiverConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.receiverConnect.Location = new System.Drawing.Point(249, 124);
            this.receiverConnect.Name = "buttonRecConnect";
            this.receiverConnect.Size = new System.Drawing.Size(75, 23);
            this.receiverConnect.TabIndex = 8;
            this.receiverConnect.Text = "Connect";
            this.receiverConnect.UseVisualStyleBackColor = true;
            this.receiverConnect.Click += new System.EventHandler(this.ReceiverConnect_Click);
            // 
            // textBoxRecStorageConn
            // 
            this.textBoxRecStorageConn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRecStorageConn.Location = new System.Drawing.Point(171, 84);
            this.textBoxRecStorageConn.Name = "textBoxRecStorageConn";
            this.textBoxRecStorageConn.Size = new System.Drawing.Size(234, 20);
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
            this.textBoxRecEvHubConn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRecEvHubConn.Location = new System.Drawing.Point(171, 42);
            this.textBoxRecEvHubConn.Name = "textBoxRecEvHubConn";
            this.textBoxRecEvHubConn.Size = new System.Drawing.Size(234, 20);
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
            this.groupBoxSender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSender.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSender.Name = "groupBoxSender";
            this.groupBoxSender.Size = new System.Drawing.Size(410, 505);
            this.groupBoxSender.TabIndex = 3;
            this.groupBoxSender.TabStop = false;
            this.groupBoxSender.Text = "Producer";
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(329, 474);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 11;
            this.buttonSend.Text = "Produce";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.Produce_Click);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputTextBox.BinaryChecked = false;
            this.inputTextBox.ChangeEndOfLine = true;
            this.inputTextBox.EndOfLine = Common.EndOfLine.Dos;
            this.inputTextBox.Location = new System.Drawing.Point(9, 69);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.SelectedTextValue = "";
            this.inputTextBox.Size = new System.Drawing.Size(394, 428);
            this.inputTextBox.TabIndex = 13;
            this.inputTextBox.TextValue = "";
            // 
            // textBoxSenEvHubConn
            // 
            this.textBoxSenEvHubConn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSenEvHubConn.Location = new System.Drawing.Point(9, 42);
            this.textBoxSenEvHubConn.Name = "textBoxSenEvHubConn";
            this.textBoxSenEvHubConn.Size = new System.Drawing.Size(394, 20);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 527);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(844, 566);
            this.Name = "MainForm";
            this.Text = "Azure EventHub Client Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxReceiver.ResumeLayout(false);
            this.groupBoxReceiver.PerformLayout();
            this.groupBoxSender.ResumeLayout(false);
            this.groupBoxSender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxReceiver;
        private System.Windows.Forms.TextBox textBoxRecConsumerGroup;
        private System.Windows.Forms.Label labelRecConsumerGroup;
        private Common.OutputTextBox outputTextBox;
        private System.Windows.Forms.Button receiverDisconnect;
        private System.Windows.Forms.Button receiverConnect;
        private System.Windows.Forms.TextBox textBoxRecStorageConn;
        private System.Windows.Forms.Label labelRecStorageConn;
        private System.Windows.Forms.TextBox textBoxRecStorageName;
        private System.Windows.Forms.Label labelRecStorageName;
        private System.Windows.Forms.TextBox textBoxRecEvHubConn;
        private System.Windows.Forms.Label labelRecEvHubConn;
        private System.Windows.Forms.TextBox textBoxRecEvHubName;
        private System.Windows.Forms.Label labelRecEvHubName;
        private System.Windows.Forms.GroupBox groupBoxSender;
        private System.Windows.Forms.Button buttonSend;
        private Common.InputTextBox inputTextBox;
        private System.Windows.Forms.TextBox textBoxSenEvHubConn;
        private System.Windows.Forms.Label labelSenEvHubConn;
    }
}