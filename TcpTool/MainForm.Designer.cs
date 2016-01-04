namespace TcpTool
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.useSSL = new System.Windows.Forms.CheckBox();
            this.close = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.destinationPort = new System.Windows.Forms.TextBox();
            this.destinationIPAddress = new System.Windows.Forms.TextBox();
            this.input = new Common.SendTextBox();
            this.listen = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sourcePort = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.outputText = new Common.ReceiveTextBox();
            this.sourceIPAddress = new Common.InterfaceSelectorComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.useSSL);
            this.panel1.Controls.Add(this.close);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.sendButton);
            this.panel1.Controls.Add(this.destinationPort);
            this.panel1.Controls.Add(this.destinationIPAddress);
            this.panel1.Controls.Add(this.input);
            this.panel1.Location = new System.Drawing.Point(395, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 434);
            this.panel1.TabIndex = 0;
            // 
            // useSSL
            // 
            this.useSSL.AutoSize = true;
            this.useSSL.Location = new System.Drawing.Point(9, 54);
            this.useSSL.Name = "useSSL";
            this.useSSL.Size = new System.Drawing.Size(68, 17);
            this.useSSL.TabIndex = 9;
            this.useSSL.Text = "Use SSL";
            this.useSSL.UseVisualStyleBackColor = true;
            // 
            // close
            // 
            this.close.Enabled = false;
            this.close.Location = new System.Drawing.Point(272, 26);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 8;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(157, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Destination Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Destination IP Address";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(309, 397);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 30);
            this.sendButton.TabIndex = 13;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // destinationPort
            // 
            this.destinationPort.Location = new System.Drawing.Point(160, 28);
            this.destinationPort.Name = "destinationPort";
            this.destinationPort.Size = new System.Drawing.Size(94, 20);
            this.destinationPort.TabIndex = 7;
            // 
            // destinationIPAddress
            // 
            this.destinationIPAddress.Location = new System.Drawing.Point(9, 28);
            this.destinationIPAddress.Name = "destinationIPAddress";
            this.destinationIPAddress.Size = new System.Drawing.Size(134, 20);
            this.destinationIPAddress.TabIndex = 6;
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(7, 77);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(377, 354);
            this.input.TabIndex = 12;
            // 
            // listen
            // 
            this.listen.Location = new System.Drawing.Point(238, 25);
            this.listen.Name = "listen";
            this.listen.Size = new System.Drawing.Size(75, 23);
            this.listen.TabIndex = 2;
            this.listen.Text = "Listen";
            this.listen.UseVisualStyleBackColor = true;
            this.listen.Click += new System.EventHandler(this.listen_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Interface";
            // 
            // sourcePort
            // 
            this.sourcePort.Location = new System.Drawing.Point(144, 27);
            this.sourcePort.Name = "sourcePort";
            this.sourcePort.Size = new System.Drawing.Size(82, 20);
            this.sourcePort.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.outputText);
            this.panel2.Controls.Add(this.sourceIPAddress);
            this.panel2.Controls.Add(this.listen);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.sourcePort);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(389, 434);
            this.panel2.TabIndex = 1;
            // 
            // outputText
            // 
            this.outputText.Location = new System.Drawing.Point(6, 54);
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(380, 380);
            this.outputText.TabIndex = 3;
            // 
            // sourceIPAddress
            // 
            this.sourceIPAddress.FormattingEnabled = true;
            this.sourceIPAddress.Location = new System.Drawing.Point(6, 25);
            this.sourceIPAddress.Name = "sourceIPAddress";
            this.sourceIPAddress.Size = new System.Drawing.Size(121, 21);
            this.sourceIPAddress.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox destinationPort;
        private System.Windows.Forms.TextBox destinationIPAddress;
        private System.Windows.Forms.TextBox sourcePort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button listen;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.Button close;
        private Common.InterfaceSelectorComboBox sourceIPAddress;
        private Common.SendTextBox input;
        private Common.ReceiveTextBox outputText;
        private System.Windows.Forms.CheckBox useSSL;
    }
}

