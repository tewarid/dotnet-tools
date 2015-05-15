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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.timeOutValue = new System.Windows.Forms.NumericUpDown();
            this.timeOut = new System.Windows.Forms.CheckBox();
            this.inputInHex = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.endOfLine = new System.Windows.Forms.GroupBox();
            this.endOfLineUnix = new System.Windows.Forms.RadioButton();
            this.endOfLineDos = new System.Windows.Forms.RadioButton();
            this.endOfLineMac = new System.Windows.Forms.RadioButton();
            this.inputText = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.baudRate = new System.Windows.Forms.ComboBox();
            this.openButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.serialPortName = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.viewInHex = new System.Windows.Forms.CheckBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.outputText = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeOutValue)).BeginInit();
            this.endOfLine.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.timeOutValue);
            this.panel1.Controls.Add(this.timeOut);
            this.panel1.Controls.Add(this.inputInHex);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.endOfLine);
            this.panel1.Controls.Add(this.inputText);
            this.panel1.Controls.Add(this.sendButton);
            this.panel1.Location = new System.Drawing.Point(395, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 433);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "seconds";
            // 
            // timeOutValue
            // 
            this.timeOutValue.Enabled = false;
            this.timeOutValue.Location = new System.Drawing.Point(92, 370);
            this.timeOutValue.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.timeOutValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeOutValue.Name = "timeOutValue";
            this.timeOutValue.Size = new System.Drawing.Size(51, 20);
            this.timeOutValue.TabIndex = 14;
            this.timeOutValue.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // timeOut
            // 
            this.timeOut.AutoSize = true;
            this.timeOut.Location = new System.Drawing.Point(8, 371);
            this.timeOut.Name = "timeOut";
            this.timeOut.Size = new System.Drawing.Size(78, 17);
            this.timeOut.TabIndex = 13;
            this.timeOut.Text = "Time out in";
            this.timeOut.UseVisualStyleBackColor = true;
            this.timeOut.CheckedChanged += new System.EventHandler(this.timeOut_CheckedChanged);
            // 
            // inputInHex
            // 
            this.inputInHex.AutoSize = true;
            this.inputInHex.Location = new System.Drawing.Point(8, 297);
            this.inputInHex.Name = "inputInHex";
            this.inputInHex.Size = new System.Drawing.Size(347, 17);
            this.inputInHex.TabIndex = 12;
            this.inputInHex.Text = "Send binary, text is a hexadecimal string (e.g. 0xDE 0xAD or DE AD)";
            this.inputInHex.UseVisualStyleBackColor = true;
            this.inputInHex.CheckedChanged += new System.EventHandler(this.inputInHex_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Text to send (UTF-8)";
            // 
            // endOfLine
            // 
            this.endOfLine.Controls.Add(this.endOfLineUnix);
            this.endOfLine.Controls.Add(this.endOfLineDos);
            this.endOfLine.Controls.Add(this.endOfLineMac);
            this.endOfLine.Location = new System.Drawing.Point(8, 320);
            this.endOfLine.Name = "endOfLine";
            this.endOfLine.Size = new System.Drawing.Size(247, 45);
            this.endOfLine.TabIndex = 5;
            this.endOfLine.TabStop = false;
            this.endOfLine.Text = "End of Line";
            // 
            // endOfLineUnix
            // 
            this.endOfLineUnix.AutoSize = true;
            this.endOfLineUnix.Location = new System.Drawing.Point(84, 19);
            this.endOfLineUnix.Name = "endOfLineUnix";
            this.endOfLineUnix.Size = new System.Drawing.Size(67, 17);
            this.endOfLineUnix.TabIndex = 10;
            this.endOfLineUnix.Text = "Unix (LF)";
            this.endOfLineUnix.UseVisualStyleBackColor = true;
            // 
            // endOfLineDos
            // 
            this.endOfLineDos.AutoSize = true;
            this.endOfLineDos.Location = new System.Drawing.Point(157, 19);
            this.endOfLineDos.Name = "endOfLineDos";
            this.endOfLineDos.Size = new System.Drawing.Size(87, 17);
            this.endOfLineDos.TabIndex = 11;
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
            this.endOfLineMac.TabIndex = 9;
            this.endOfLineMac.TabStop = true;
            this.endOfLineMac.Text = "MAC (CR)";
            this.endOfLineMac.UseVisualStyleBackColor = true;
            // 
            // inputText
            // 
            this.inputText.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputText.Location = new System.Drawing.Point(8, 27);
            this.inputText.MaxLength = 1000000;
            this.inputText.Multiline = true;
            this.inputText.Name = "inputText";
            this.inputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputText.Size = new System.Drawing.Size(378, 264);
            this.inputText.TabIndex = 8;
            // 
            // sendButton
            // 
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(311, 401);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 15;
            this.sendButton.Text = "&Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Enabled = false;
            this.closeButton.Location = new System.Drawing.Point(213, 70);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(132, 25);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "&Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 56);
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
            this.baudRate.Location = new System.Drawing.Point(7, 72);
            this.baudRate.Name = "baudRate";
            this.baudRate.Size = new System.Drawing.Size(119, 21);
            this.baudRate.TabIndex = 2;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(132, 70);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 3;
            this.openButton.Text = "&Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Serial Port";
            // 
            // serialPortName
            // 
            this.serialPortName.FormattingEnabled = true;
            this.serialPortName.Location = new System.Drawing.Point(7, 27);
            this.serialPortName.Name = "serialPortName";
            this.serialPortName.Size = new System.Drawing.Size(119, 21);
            this.serialPortName.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.viewInHex);
            this.panel2.Controls.Add(this.clearButton);
            this.panel2.Controls.Add(this.closeButton);
            this.panel2.Controls.Add(this.refreshButton);
            this.panel2.Controls.Add(this.outputText);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.serialPortName);
            this.panel2.Controls.Add(this.baudRate);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.openButton);
            this.panel2.Location = new System.Drawing.Point(0, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(391, 433);
            this.panel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(349, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Data received (assumes ASCII, special characters are replaced with a \'.\')";
            // 
            // viewInHex
            // 
            this.viewInHex.AutoSize = true;
            this.viewInHex.Location = new System.Drawing.Point(5, 405);
            this.viewInHex.Name = "viewInHex";
            this.viewInHex.Size = new System.Drawing.Size(153, 17);
            this.viewInHex.TabIndex = 6;
            this.viewInHex.Text = "View as hexadecimal string";
            this.viewInHex.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(313, 401);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "&Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // outputText
            // 
            this.outputText.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputText.Location = new System.Drawing.Point(6, 122);
            this.outputText.MaxLength = 1000000;
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.ReadOnly = true;
            this.outputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputText.Size = new System.Drawing.Size(382, 270);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeOutValue)).EndInit();
            this.endOfLine.ResumeLayout(false);
            this.endOfLine.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox endOfLine;
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
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown timeOutValue;
        private System.Windows.Forms.CheckBox timeOut;
    }
}

