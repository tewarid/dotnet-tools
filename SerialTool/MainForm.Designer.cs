namespace SerialTool
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.baudRate = new System.Windows.Forms.ComboBox();
            this.openButton = new System.Windows.Forms.Button();
            this.inputInHex = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.endOfLineUnix = new System.Windows.Forms.RadioButton();
            this.endOfLineDos = new System.Windows.Forms.RadioButton();
            this.endOfLineMac = new System.Windows.Forms.RadioButton();
            this.inputText = new System.Windows.Forms.TextBox();
            this.serialPortName = new System.Windows.Forms.ComboBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.viewInHex = new System.Windows.Forms.CheckBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.outputText = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.baudRate);
            this.panel1.Controls.Add(this.openButton);
            this.panel1.Controls.Add(this.inputInHex);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.inputText);
            this.panel1.Controls.Add(this.serialPortName);
            this.panel1.Controls.Add(this.sendButton);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 241);
            this.panel1.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(135, 22);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "&Update List";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Baud Rate";
            // 
            // baudRate
            // 
            this.baudRate.FormattingEnabled = true;
            this.baudRate.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.baudRate.Location = new System.Drawing.Point(10, 69);
            this.baudRate.Name = "baudRate";
            this.baudRate.Size = new System.Drawing.Size(119, 21);
            this.baudRate.TabIndex = 12;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(135, 67);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 11;
            this.openButton.Text = "&Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // inputInHex
            // 
            this.inputInHex.AutoSize = true;
            this.inputInHex.Location = new System.Drawing.Point(13, 207);
            this.inputInHex.Name = "inputInHex";
            this.inputInHex.Size = new System.Drawing.Size(347, 17);
            this.inputInHex.TabIndex = 9;
            this.inputInHex.Text = "Send binary, text is a hexadecimal string (e.g. 0xDE 0xAD or DE AD)";
            this.inputInHex.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Text to send";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Serial Port";
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
            // serialPortName
            // 
            this.serialPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serialPortName.FormattingEnabled = true;
            this.serialPortName.Location = new System.Drawing.Point(10, 24);
            this.serialPortName.Name = "serialPortName";
            this.serialPortName.Size = new System.Drawing.Size(119, 21);
            this.serialPortName.TabIndex = 0;
            // 
            // sendButton
            // 
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(496, 203);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 10;
            this.sendButton.Text = "&Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
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
            this.label6.Size = new System.Drawing.Size(272, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Data received (special characters are replaced with a \'.\')";
            // 
            // viewInHex
            // 
            this.viewInHex.AutoSize = true;
            this.viewInHex.Checked = true;
            this.viewInHex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewInHex.Location = new System.Drawing.Point(11, 104);
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
            this.clearButton.Text = "&Clear";
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
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(216, 67);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial Tool";
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
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.ComboBox serialPortName;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.CheckBox viewInHex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox inputInHex;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox baudRate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
    }
}

