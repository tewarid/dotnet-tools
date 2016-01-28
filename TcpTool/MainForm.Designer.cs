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
            this.open = new System.Windows.Forms.Button();
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
            this.stopListener = new System.Windows.Forms.Button();
            this.useSSLListener = new System.Windows.Forms.CheckBox();
            this.browseForPfx = new System.Windows.Forms.Button();
            this.pfxPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.outputText = new Common.ReceiveTextBox();
            this.sourceIPAddress = new Common.InterfaceSelectorComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.open);
            this.panel1.Controls.Add(this.useSSL);
            this.panel1.Controls.Add(this.close);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.sendButton);
            this.panel1.Controls.Add(this.destinationPort);
            this.panel1.Controls.Add(this.destinationIPAddress);
            this.panel1.Controls.Add(this.input);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 439);
            this.panel1.TabIndex = 0;
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(5, 52);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 23);
            this.open.TabIndex = 18;
            this.open.Text = "Open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // useSSL
            // 
            this.useSSL.AutoSize = true;
            this.useSSL.Location = new System.Drawing.Point(255, 28);
            this.useSSL.Name = "useSSL";
            this.useSSL.Size = new System.Drawing.Size(68, 17);
            this.useSSL.TabIndex = 17;
            this.useSSL.Text = "Use SSL";
            this.useSSL.UseVisualStyleBackColor = true;
            // 
            // close
            // 
            this.close.Enabled = false;
            this.close.Location = new System.Drawing.Point(86, 52);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 19;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(152, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Destination Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Destination IP Address";
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.Location = new System.Drawing.Point(308, 406);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 30);
            this.sendButton.TabIndex = 21;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // destinationPort
            // 
            this.destinationPort.Location = new System.Drawing.Point(155, 26);
            this.destinationPort.Name = "destinationPort";
            this.destinationPort.Size = new System.Drawing.Size(94, 20);
            this.destinationPort.TabIndex = 16;
            // 
            // destinationIPAddress
            // 
            this.destinationIPAddress.Location = new System.Drawing.Point(4, 26);
            this.destinationIPAddress.Name = "destinationIPAddress";
            this.destinationIPAddress.Size = new System.Drawing.Size(145, 20);
            this.destinationIPAddress.TabIndex = 15;
            // 
            // input
            // 
            this.input.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input.Location = new System.Drawing.Point(2, 81);
            this.input.MinimumSize = new System.Drawing.Size(280, 130);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(381, 359);
            this.input.TabIndex = 20;
            // 
            // listen
            // 
            this.listen.Location = new System.Drawing.Point(6, 93);
            this.listen.Name = "listen";
            this.listen.Size = new System.Drawing.Size(75, 23);
            this.listen.TabIndex = 5;
            this.listen.Text = "Listen";
            this.listen.UseVisualStyleBackColor = true;
            this.listen.Click += new System.EventHandler(this.listen_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Interface";
            // 
            // sourcePort
            // 
            this.sourcePort.Location = new System.Drawing.Point(144, 23);
            this.sourcePort.Name = "sourcePort";
            this.sourcePort.Size = new System.Drawing.Size(82, 20);
            this.sourcePort.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.stopListener);
            this.panel2.Controls.Add(this.useSSLListener);
            this.panel2.Controls.Add(this.browseForPfx);
            this.panel2.Controls.Add(this.pfxPath);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.sourcePort);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.outputText);
            this.panel2.Controls.Add(this.sourceIPAddress);
            this.panel2.Controls.Add(this.listen);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 439);
            this.panel2.TabIndex = 1;
            // 
            // stopListener
            // 
            this.stopListener.Enabled = false;
            this.stopListener.Location = new System.Drawing.Point(87, 93);
            this.stopListener.Name = "stopListener";
            this.stopListener.Size = new System.Drawing.Size(75, 23);
            this.stopListener.TabIndex = 15;
            this.stopListener.Text = "Stop";
            this.stopListener.UseVisualStyleBackColor = true;
            this.stopListener.Click += new System.EventHandler(this.stopListener_Click);
            // 
            // useSSLListener
            // 
            this.useSSLListener.AutoSize = true;
            this.useSSLListener.Location = new System.Drawing.Point(232, 25);
            this.useSSLListener.Name = "useSSLListener";
            this.useSSLListener.Size = new System.Drawing.Size(68, 17);
            this.useSSLListener.TabIndex = 2;
            this.useSSLListener.Text = "Use SSL";
            this.useSSLListener.UseVisualStyleBackColor = true;
            this.useSSLListener.CheckedChanged += new System.EventHandler(this.useSSLListener_CheckedChanged);
            // 
            // browseForPfx
            // 
            this.browseForPfx.Enabled = false;
            this.browseForPfx.Location = new System.Drawing.Point(299, 65);
            this.browseForPfx.Name = "browseForPfx";
            this.browseForPfx.Size = new System.Drawing.Size(75, 23);
            this.browseForPfx.TabIndex = 4;
            this.browseForPfx.Text = "Browse...";
            this.browseForPfx.UseVisualStyleBackColor = true;
            this.browseForPfx.Click += new System.EventHandler(this.browseForPfx_Click);
            // 
            // pfxPath
            // 
            this.pfxPath.Enabled = false;
            this.pfxPath.Location = new System.Drawing.Point(6, 67);
            this.pfxPath.Name = "pfxPath";
            this.pfxPath.ReadOnly = true;
            this.pfxPath.Size = new System.Drawing.Size(287, 20);
            this.pfxPath.TabIndex = 3;
            this.pfxPath.Text = "mycompany.pfx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "PFX file path";
            // 
            // outputText
            // 
            this.outputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputText.Location = new System.Drawing.Point(6, 122);
            this.outputText.MinimumSize = new System.Drawing.Size(355, 95);
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(384, 317);
            this.outputText.TabIndex = 6;
            // 
            // sourceIPAddress
            // 
            this.sourceIPAddress.FormattingEnabled = true;
            this.sourceIPAddress.Location = new System.Drawing.Point(6, 23);
            this.sourceIPAddress.Name = "sourceIPAddress";
            this.sourceIPAddress.Size = new System.Drawing.Size(132, 21);
            this.sourceIPAddress.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip.Location = new System.Drawing.Point(0, 439);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(784, 439);
            this.splitContainer1.SplitterDistance = 392;
            this.splitContainer1.TabIndex = 14;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "pfx";
            this.openFileDialog.Filter = "PFX files|*.pfx";
            this.openFileDialog.Title = "Pick PFX file";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.Button close;
        private Common.InterfaceSelectorComboBox sourceIPAddress;
        private Common.SendTextBox input;
        private Common.ReceiveTextBox outputText;
        private System.Windows.Forms.CheckBox useSSL;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox useSSLListener;
        private System.Windows.Forms.Button browseForPfx;
        private System.Windows.Forms.TextBox pfxPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button stopListener;
        private System.Windows.Forms.Button open;
    }
}

