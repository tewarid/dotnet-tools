namespace UdpTool
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.destinationPort = new System.Windows.Forms.TextBox();
            this.destinationIPAddress = new System.Windows.Forms.TextBox();
            this.input = new Common.SendTextBox();
            this.bind = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sourcePort = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.multicastGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.join = new System.Windows.Forms.Button();
            this.multicastGroupAddress = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sourceIPAddress = new Common.InterfaceSelectorComboBox();
            this.close = new System.Windows.Forms.Button();
            this.reuseAddress = new System.Windows.Forms.CheckBox();
            this.outputText = new Common.ReceiveTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.multicastGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.sendButton);
            this.panel1.Controls.Add(this.destinationPort);
            this.panel1.Controls.Add(this.destinationIPAddress);
            this.panel1.Controls.Add(this.input);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 545);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(200, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Destination Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Destination IP Address";
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.Location = new System.Drawing.Point(414, 518);
            this.sendButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(100, 23);
            this.sendButton.TabIndex = 15;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // destinationPort
            // 
            this.destinationPort.Location = new System.Drawing.Point(204, 31);
            this.destinationPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.destinationPort.Name = "destinationPort";
            this.destinationPort.Size = new System.Drawing.Size(125, 22);
            this.destinationPort.TabIndex = 9;
            // 
            // destinationIPAddress
            // 
            this.destinationIPAddress.Location = new System.Drawing.Point(8, 31);
            this.destinationIPAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.destinationIPAddress.Name = "destinationIPAddress";
            this.destinationIPAddress.Size = new System.Drawing.Size(176, 22);
            this.destinationIPAddress.TabIndex = 8;
            // 
            // input
            // 
            this.input.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input.Location = new System.Drawing.Point(0, 63);
            this.input.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.input.MinimumSize = new System.Drawing.Size(373, 160);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(516, 479);
            this.input.TabIndex = 10;
            // 
            // bind
            // 
            this.bind.Location = new System.Drawing.Point(12, 103);
            this.bind.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bind.Name = "bind";
            this.bind.Size = new System.Drawing.Size(100, 28);
            this.bind.TabIndex = 3;
            this.bind.Text = "Bind";
            this.bind.UseVisualStyleBackColor = true;
            this.bind.Click += new System.EventHandler(this.Bind_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Interface";
            // 
            // sourcePort
            // 
            this.sourcePort.Location = new System.Drawing.Point(184, 43);
            this.sourcePort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sourcePort.Name = "sourcePort";
            this.sourcePort.Size = new System.Drawing.Size(99, 22);
            this.sourcePort.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.multicastGroupBox);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.outputText);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(522, 545);
            this.panel2.TabIndex = 0;
            // 
            // multicastGroupBox
            // 
            this.multicastGroupBox.Controls.Add(this.label3);
            this.multicastGroupBox.Controls.Add(this.join);
            this.multicastGroupBox.Controls.Add(this.multicastGroupAddress);
            this.multicastGroupBox.Enabled = false;
            this.multicastGroupBox.Location = new System.Drawing.Point(315, 4);
            this.multicastGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.multicastGroupBox.Name = "multicastGroupBox";
            this.multicastGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.multicastGroupBox.Size = new System.Drawing.Size(192, 111);
            this.multicastGroupBox.TabIndex = 14;
            this.multicastGroupBox.TabStop = false;
            this.multicastGroupBox.Text = "Multicast Groups";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Multicast IP Address";
            // 
            // join
            // 
            this.join.Location = new System.Drawing.Point(13, 74);
            this.join.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.join.Name = "join";
            this.join.Size = new System.Drawing.Size(100, 28);
            this.join.TabIndex = 6;
            this.join.Text = "Join";
            this.join.UseVisualStyleBackColor = true;
            this.join.Click += new System.EventHandler(this.Join_Click);
            // 
            // multicastGroupAddress
            // 
            this.multicastGroupAddress.Location = new System.Drawing.Point(13, 42);
            this.multicastGroupAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.multicastGroupAddress.Name = "multicastGroupAddress";
            this.multicastGroupAddress.Size = new System.Drawing.Size(167, 22);
            this.multicastGroupAddress.TabIndex = 5;
            this.toolTip1.SetToolTip(this.multicastGroupAddress, "Multicast IP Address");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sourceIPAddress);
            this.groupBox1.Controls.Add(this.sourcePort);
            this.groupBox1.Controls.Add(this.close);
            this.groupBox1.Controls.Add(this.reuseAddress);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.bind);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(8, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(299, 142);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bind";
            // 
            // sourceIPAddress
            // 
            this.sourceIPAddress.IncludeIPAddressAny = true;
            this.sourceIPAddress.Location = new System.Drawing.Point(12, 43);
            this.sourceIPAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sourceIPAddress.Name = "sourceIPAddress";
            this.sourceIPAddress.Size = new System.Drawing.Size(161, 26);
            this.sourceIPAddress.TabIndex = 0;
            // 
            // close
            // 
            this.close.Enabled = false;
            this.close.Location = new System.Drawing.Point(184, 103);
            this.close.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(100, 28);
            this.close.TabIndex = 4;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.Close_Click);
            // 
            // reuseAddress
            // 
            this.reuseAddress.AutoSize = true;
            this.reuseAddress.Location = new System.Drawing.Point(12, 75);
            this.reuseAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reuseAddress.Name = "reuseAddress";
            this.reuseAddress.Size = new System.Drawing.Size(127, 21);
            this.reuseAddress.TabIndex = 2;
            this.reuseAddress.Text = "Reuse Address";
            this.reuseAddress.UseVisualStyleBackColor = true;
            // 
            // outputText
            // 
            this.outputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputText.Location = new System.Drawing.Point(8, 153);
            this.outputText.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.outputText.MinimumSize = new System.Drawing.Size(473, 117);
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(510, 389);
            this.outputText.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 545);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1045, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
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
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1045, 545);
            this.splitContainer1.SplitterDistance = 522;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 567);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UDP Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.multicastGroupBox.ResumeLayout(false);
            this.multicastGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.Button bind;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.Button join;
        private System.Windows.Forms.TextBox multicastGroupAddress;
        private Common.SendTextBox input;
        private Common.ReceiveTextBox outputText;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox reuseAddress;
        private System.Windows.Forms.GroupBox multicastGroupBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Common.InterfaceSelectorComboBox sourceIPAddress;
        private System.Windows.Forms.Label label3;
    }
}

