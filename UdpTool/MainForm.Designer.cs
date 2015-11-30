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
            this.sourceIPAddress = new Common.InterfaceSelectorComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.multicastGroup = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.viewInHex = new System.Windows.Forms.CheckBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.outputText = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.panel1.Location = new System.Drawing.Point(391, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 435);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(149, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Destination Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Destination IP Address";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(310, 403);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 15;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // destinationPort
            // 
            this.destinationPort.Location = new System.Drawing.Point(152, 29);
            this.destinationPort.Name = "destinationPort";
            this.destinationPort.Size = new System.Drawing.Size(95, 20);
            this.destinationPort.TabIndex = 9;
            // 
            // destinationIPAddress
            // 
            this.destinationIPAddress.Location = new System.Drawing.Point(8, 29);
            this.destinationIPAddress.Name = "destinationIPAddress";
            this.destinationIPAddress.Size = new System.Drawing.Size(133, 20);
            this.destinationIPAddress.TabIndex = 8;
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(8, 56);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(379, 376);
            this.input.TabIndex = 10;
            // 
            // bind
            // 
            this.bind.Location = new System.Drawing.Point(220, 26);
            this.bind.Name = "bind";
            this.bind.Size = new System.Drawing.Size(75, 23);
            this.bind.TabIndex = 2;
            this.bind.Text = "Bind";
            this.bind.UseVisualStyleBackColor = true;
            this.bind.Click += new System.EventHandler(this.bind_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Interface";
            // 
            // sourcePort
            // 
            this.sourcePort.Location = new System.Drawing.Point(136, 28);
            this.sourcePort.Name = "sourcePort";
            this.sourcePort.Size = new System.Drawing.Size(75, 20);
            this.sourcePort.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.sourceIPAddress);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.multicastGroup);
            this.panel2.Controls.Add(this.add);
            this.panel2.Controls.Add(this.bind);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.viewInHex);
            this.panel2.Controls.Add(this.clearButton);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.outputText);
            this.panel2.Controls.Add(this.sourcePort);
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(390, 435);
            this.panel2.TabIndex = 0;
            // 
            // sourceIPAddress
            // 
            this.sourceIPAddress.FormattingEnabled = true;
            this.sourceIPAddress.Items.AddRange(new object[] {
            ((object)(resources.GetObject("sourceIPAddress.Items"))),
            ((object)(resources.GetObject("sourceIPAddress.Items1"))),
            ((object)(resources.GetObject("sourceIPAddress.Items2"))),
            ((object)(resources.GetObject("sourceIPAddress.Items3"))),
            ((object)(resources.GetObject("sourceIPAddress.Items4"))),
            ((object)(resources.GetObject("sourceIPAddress.Items5")))});
            this.sourceIPAddress.Location = new System.Drawing.Point(7, 27);
            this.sourceIPAddress.Name = "sourceIPAddress";
            this.sourceIPAddress.Size = new System.Drawing.Size(121, 21);
            this.sourceIPAddress.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Mutlicast Group Address e.g. 225.0.0.1";
            // 
            // multicastGroup
            // 
            this.multicastGroup.Enabled = false;
            this.multicastGroup.Location = new System.Drawing.Point(7, 71);
            this.multicastGroup.Name = "multicastGroup";
            this.multicastGroup.Size = new System.Drawing.Size(119, 20);
            this.multicastGroup.TabIndex = 3;
            // 
            // add
            // 
            this.add.Enabled = false;
            this.add.Location = new System.Drawing.Point(220, 69);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 4;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(352, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Data received (assumes UTF-8, special characters are replaced with a \'.\')";
            // 
            // viewInHex
            // 
            this.viewInHex.AutoSize = true;
            this.viewInHex.Location = new System.Drawing.Point(7, 406);
            this.viewInHex.Name = "viewInHex";
            this.viewInHex.Size = new System.Drawing.Size(153, 17);
            this.viewInHex.TabIndex = 6;
            this.viewInHex.Text = "View as hexadecimal string";
            this.viewInHex.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(312, 403);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // outputText
            // 
            this.outputText.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputText.Location = new System.Drawing.Point(6, 115);
            this.outputText.MaxLength = 1000000;
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.ReadOnly = true;
            this.outputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputText.Size = new System.Drawing.Size(380, 282);
            this.outputText.TabIndex = 5;
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
            this.Text = "UDP Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
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
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.TextBox sourcePort;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.CheckBox viewInHex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bind;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox multicastGroup;
        private Common.InterfaceSelectorComboBox sourceIPAddress;
        private Common.SendTextBox input;
    }
}

