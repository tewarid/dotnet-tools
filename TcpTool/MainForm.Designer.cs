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
            this.panel1 = new System.Windows.Forms.Panel();
            this.listen = new System.Windows.Forms.Button();
            this.inputInHex = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sourcePort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.endOfLineUnix = new System.Windows.Forms.RadioButton();
            this.endOfLineDos = new System.Windows.Forms.RadioButton();
            this.endOfLineMac = new System.Windows.Forms.RadioButton();
            this.inputText = new System.Windows.Forms.TextBox();
            this.sourceIPAddress = new System.Windows.Forms.ComboBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.destinationPort = new System.Windows.Forms.TextBox();
            this.destinationIPAddress = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.viewInHex = new System.Windows.Forms.CheckBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.outputText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listen);
            this.panel1.Controls.Add(this.inputInHex);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.sourcePort);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.inputText);
            this.panel1.Controls.Add(this.sourceIPAddress);
            this.panel1.Controls.Add(this.sendButton);
            this.panel1.Controls.Add(this.destinationPort);
            this.panel1.Controls.Add(this.destinationIPAddress);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 241);
            this.panel1.TabIndex = 0;
            // 
            // listen
            // 
            this.listen.Location = new System.Drawing.Point(242, 22);
            this.listen.Name = "listen";
            this.listen.Size = new System.Drawing.Size(75, 23);
            this.listen.TabIndex = 11;
            this.listen.Text = "Listen";
            this.listen.UseVisualStyleBackColor = true;
            this.listen.Click += new System.EventHandler(this.listen_Click);
            // 
            // inputInHex
            // 
            this.inputInHex.AutoSize = true;
            this.inputInHex.Location = new System.Drawing.Point(11, 203);
            this.inputInHex.Name = "inputInHex";
            this.inputInHex.Size = new System.Drawing.Size(347, 17);
            this.inputInHex.TabIndex = 9;
            this.inputInHex.Text = "Send binary, text is a hexadecimal string (e.g. 0xDE 0xAD or DE AD)";
            this.inputInHex.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Port (Optional)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Text to send (UTF-8)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Interface (Optional)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Destination Port";
            // 
            // sourcePort
            // 
            this.sourcePort.Location = new System.Drawing.Point(148, 24);
            this.sourcePort.Name = "sourcePort";
            this.sourcePort.Size = new System.Drawing.Size(82, 20);
            this.sourcePort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Destination IP Address";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.endOfLineUnix);
            this.groupBox1.Controls.Add(this.endOfLineDos);
            this.groupBox1.Controls.Add(this.endOfLineMac);
            this.groupBox1.Location = new System.Drawing.Point(324, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 45);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "End of Line";
            // 
            // endOfLineUnix
            // 
            this.endOfLineUnix.AutoSize = true;
            this.endOfLineUnix.Location = new System.Drawing.Point(84, 19);
            this.endOfLineUnix.Name = "endOfLineUnix";
            this.endOfLineUnix.Size = new System.Drawing.Size(67, 17);
            this.endOfLineUnix.TabIndex = 6;
            this.endOfLineUnix.Text = "Unix (LF)";
            this.endOfLineUnix.UseVisualStyleBackColor = true;
            // 
            // endOfLineDos
            // 
            this.endOfLineDos.AutoSize = true;
            this.endOfLineDos.Location = new System.Drawing.Point(157, 19);
            this.endOfLineDos.Name = "endOfLineDos";
            this.endOfLineDos.Size = new System.Drawing.Size(87, 17);
            this.endOfLineDos.TabIndex = 7;
            this.endOfLineDos.Text = "DOS (CR-LF)";
            this.endOfLineDos.UseVisualStyleBackColor = true;
            // 
            // endOfLineMac
            // 
            this.endOfLineMac.AutoSize = true;
            this.endOfLineMac.Checked = true;
            this.endOfLineMac.Location = new System.Drawing.Point(6, 19);
            this.endOfLineMac.Name = "endOfLineMac";
            this.endOfLineMac.Size = new System.Drawing.Size(72, 17);
            this.endOfLineMac.TabIndex = 5;
            this.endOfLineMac.TabStop = true;
            this.endOfLineMac.Text = "MAC (CR)";
            this.endOfLineMac.UseVisualStyleBackColor = true;
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(10, 127);
            this.inputText.Multiline = true;
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(561, 70);
            this.inputText.TabIndex = 8;
            // 
            // sourceIPAddress
            // 
            this.sourceIPAddress.FormattingEnabled = true;
            this.sourceIPAddress.Location = new System.Drawing.Point(10, 24);
            this.sourceIPAddress.Name = "sourceIPAddress";
            this.sourceIPAddress.Size = new System.Drawing.Size(119, 21);
            this.sourceIPAddress.TabIndex = 0;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(496, 203);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 10;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // destinationPort
            // 
            this.destinationPort.Location = new System.Drawing.Point(148, 78);
            this.destinationPort.Name = "destinationPort";
            this.destinationPort.Size = new System.Drawing.Size(82, 20);
            this.destinationPort.TabIndex = 4;
            // 
            // destinationIPAddress
            // 
            this.destinationIPAddress.Location = new System.Drawing.Point(10, 78);
            this.destinationIPAddress.Name = "destinationIPAddress";
            this.destinationIPAddress.Size = new System.Drawing.Size(120, 20);
            this.destinationIPAddress.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.viewInHex);
            this.panel2.Controls.Add(this.clearButton);
            this.panel2.Controls.Add(this.outputText);
            this.panel2.Location = new System.Drawing.Point(2, 248);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(588, 134);
            this.panel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(352, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Data received (assumes UTF-8, special characters are replaced with a \'.\')";
            // 
            // viewInHex
            // 
            this.viewInHex.AutoSize = true;
            this.viewInHex.Checked = true;
            this.viewInHex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewInHex.Location = new System.Drawing.Point(11, 100);
            this.viewInHex.Name = "viewInHex";
            this.viewInHex.Size = new System.Drawing.Size(153, 17);
            this.viewInHex.TabIndex = 12;
            this.viewInHex.Text = "View as hexadecimal string";
            this.viewInHex.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(497, 100);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 13;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // outputText
            // 
            this.outputText.Location = new System.Drawing.Point(11, 22);
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputText.Size = new System.Drawing.Size(562, 72);
            this.outputText.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 384);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton endOfLineUnix;
        private System.Windows.Forms.RadioButton endOfLineDos;
        private System.Windows.Forms.RadioButton endOfLineMac;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox destinationPort;
        private System.Windows.Forms.TextBox destinationIPAddress;
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.TextBox sourcePort;
        private System.Windows.Forms.ComboBox sourceIPAddress;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.CheckBox viewInHex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox inputInHex;
        private System.Windows.Forms.Button listen;
    }
}

