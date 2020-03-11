using System.Windows.Forms;

namespace SerialTool
{
    public partial class MainForm : Form
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
            this.sendButton = new System.Windows.Forms.Button();
            this.input = new Common.InputTextBox();
            this.close = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.baudRate = new System.Windows.Forms.ComboBox();
            this.open = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.serialPortName = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.outputText = new Common.OutputTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeOutValue)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.panel1.Controls.Add(this.timeOutValue);
            this.panel1.Controls.Add(this.timeOut);
            this.panel1.Controls.Add(this.sendButton);
            this.panel1.Controls.Add(this.input);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 439);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 412);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "seconds";
            // 
            // timeOutValue
            // 
            this.timeOutValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timeOutValue.Enabled = false;
            this.timeOutValue.Location = new System.Drawing.Point(92, 407);
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
            this.timeOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timeOut.AutoSize = true;
            this.timeOut.Location = new System.Drawing.Point(8, 408);
            this.timeOut.Name = "timeOut";
            this.timeOut.Size = new System.Drawing.Size(78, 17);
            this.timeOut.TabIndex = 13;
            this.timeOut.Text = "Time out in";
            this.timeOut.UseVisualStyleBackColor = true;
            this.timeOut.CheckedChanged += new System.EventHandler(this.TimeOut_CheckedChanged);
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(308, 407);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 15;
            this.sendButton.Text = "&Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // input
            // 
            this.input.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input.BinaryChecked = false;
            this.input.ChangeEndOfLine = true;
            this.input.EndOfLine = Common.EndOfLine.Dos;
            this.input.Location = new System.Drawing.Point(3, 4);
            this.input.Margin = new System.Windows.Forms.Padding(4);
            this.input.MinimumSize = new System.Drawing.Size(280, 130);
            this.input.Name = "input";
            this.input.Padding = new System.Windows.Forms.Padding(3);
            this.input.SelectedTextValue = "";
            this.input.Size = new System.Drawing.Size(380, 398);
            this.input.TabIndex = 12;
            this.input.TextValue = "";
            // 
            // close
            // 
            this.close.Enabled = false;
            this.close.Location = new System.Drawing.Point(213, 72);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 8;
            this.close.Text = "&Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.Close_Click);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(132, 25);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(75, 23);
            this.refresh.TabIndex = 3;
            this.refresh.Text = "&Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.Refresh_Click);
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
            this.baudRate.TabIndex = 6;
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(132, 72);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 23);
            this.open.TabIndex = 7;
            this.open.Text = "&Open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.Open_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Serial Port";
            // 
            // serialPortName
            // 
            this.serialPortName.FormattingEnabled = true;
            this.serialPortName.Location = new System.Drawing.Point(7, 27);
            this.serialPortName.Name = "serialPortName";
            this.serialPortName.Size = new System.Drawing.Size(119, 21);
            this.serialPortName.TabIndex = 1;
            this.serialPortName.SelectedIndexChanged += new System.EventHandler(this.serialPortName_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.outputText);
            this.panel2.Controls.Add(this.close);
            this.panel2.Controls.Add(this.refresh);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.serialPortName);
            this.panel2.Controls.Add(this.baudRate);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.open);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(391, 439);
            this.panel2.TabIndex = 1;
            // 
            // outputText
            // 
            this.outputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputText.AppendBinaryChecked = false;
            this.outputText.Location = new System.Drawing.Point(6, 99);
            this.outputText.Margin = new System.Windows.Forms.Padding(4);
            this.outputText.MinimumSize = new System.Drawing.Size(355, 95);
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(382, 337);
            this.outputText.TabIndex = 10;
            this.outputText.TextValue = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.splitContainer1.SplitterDistance = 391;
            this.splitContainer1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeOutValue)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.ComboBox serialPortName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox baudRate;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown timeOutValue;
        private System.Windows.Forms.CheckBox timeOut;
        private Common.InputTextBox input;
        private Common.OutputTextBox outputText;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

