using System.Windows.Forms;

namespace AmqpClientTool
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.close = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.open = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.receive = new System.Windows.Forms.Button();
            this.output = new Common.OutputTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.senderLinkAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.send = new System.Windows.Forms.Button();
            this.input = new Common.InputTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.receiverLinkName = new System.Windows.Forms.TextBox();
            this.receiverLinkAddress = new System.Windows.Forms.TextBox();
            this.subject = new System.Windows.Forms.TextBox();
            this.senderLinkName = new System.Windows.Forms.TextBox();
            this.host = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.TextBox();
            this.useTls = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(324, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Password";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Username";
            // 
            // password
            // 
            this.password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.password.Location = new System.Drawing.Point(327, 61);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(165, 20);
            this.password.TabIndex = 28;
            this.password.Text = "guest";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(43, 17);
            this.status.Text = "Closed";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 36;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close.Location = new System.Drawing.Point(587, 59);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 34;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.Close_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Host or URL";
            // 
            // open
            // 
            this.open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.open.Location = new System.Drawing.Point(506, 59);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 23);
            this.open.TabIndex = 33;
            this.open.Text = "Open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.Open_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 87);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.receiverLinkName);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.receiverLinkAddress);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.receive);
            this.splitContainer1.Panel1.Controls.Add(this.output);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.subject);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.senderLinkName);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.senderLinkAddress);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.send);
            this.splitContainer1.Panel2.Controls.Add(this.input);
            this.splitContainer1.Size = new System.Drawing.Size(795, 337);
            this.splitContainer1.SplitterDistance = 392;
            this.splitContainer1.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Receiver link name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(197, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Queue address to receive message from";
            // 
            // receive
            // 
            this.receive.Location = new System.Drawing.Point(308, 87);
            this.receive.Name = "receive";
            this.receive.Size = new System.Drawing.Size(75, 23);
            this.receive.TabIndex = 24;
            this.receive.Text = "Receive";
            this.receive.UseVisualStyleBackColor = true;
            this.receive.Click += new System.EventHandler(this.Receive_Click);
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.AppendBinaryChecked = false;
            this.output.Location = new System.Drawing.Point(2, 117);
            this.output.Margin = new System.Windows.Forms.Padding(4);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(385, 215);
            this.output.TabIndex = 27;
            this.output.TextValue = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Sender link name";
            // 
            // senderLinkAddress
            // 
            this.senderLinkAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.senderLinkAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AmqpClientTool.Properties.Settings.Default, "senderLinkAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.senderLinkAddress.Location = new System.Drawing.Point(9, 59);
            this.senderLinkAddress.Name = "senderLinkAddress";
            this.senderLinkAddress.Size = new System.Drawing.Size(384, 20);
            this.senderLinkAddress.TabIndex = 30;
            this.senderLinkAddress.Text = global::AmqpClientTool.Properties.Settings.Default.senderLinkAddress;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Queue address to send message to";
            // 
            // send
            // 
            this.send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.send.Location = new System.Drawing.Point(318, 307);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(75, 23);
            this.send.TabIndex = 34;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.Send_Click);
            // 
            // input
            // 
            this.input.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input.BinaryChecked = false;
            this.input.ChangeEndOfLine = true;
            this.input.EndOfLine = Common.EndOfLine.Dos;
            this.input.Location = new System.Drawing.Point(2, 124);
            this.input.Name = "input";
            this.input.Padding = new System.Windows.Forms.Padding(4);
            this.input.SelectedTextValue = "test";
            this.input.Size = new System.Drawing.Size(394, 177);
            this.input.TabIndex = 33;
            this.input.TextValue = "test";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Subject";
            // 
            // receiverLinkName
            // 
            this.receiverLinkName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.receiverLinkName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AmqpClientTool.Properties.Settings.Default, "receiverLinkName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.receiverLinkName.Location = new System.Drawing.Point(10, 21);
            this.receiverLinkName.Name = "receiverLinkName";
            this.receiverLinkName.Size = new System.Drawing.Size(373, 20);
            this.receiverLinkName.TabIndex = 22;
            this.receiverLinkName.Text = global::AmqpClientTool.Properties.Settings.Default.receiverLinkName;
            // 
            // receiverLinkAddress
            // 
            this.receiverLinkAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.receiverLinkAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AmqpClientTool.Properties.Settings.Default, "receiverLinkAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.receiverLinkAddress.Location = new System.Drawing.Point(10, 61);
            this.receiverLinkAddress.Name = "receiverLinkAddress";
            this.receiverLinkAddress.Size = new System.Drawing.Size(373, 20);
            this.receiverLinkAddress.TabIndex = 23;
            this.receiverLinkAddress.Text = global::AmqpClientTool.Properties.Settings.Default.receiverLinkAddress;
            // 
            // subject
            // 
            this.subject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subject.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AmqpClientTool.Properties.Settings.Default, "subject", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.subject.Location = new System.Drawing.Point(9, 98);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(384, 20);
            this.subject.TabIndex = 32;
            this.subject.Text = global::AmqpClientTool.Properties.Settings.Default.subject;
            // 
            // senderLinkName
            // 
            this.senderLinkName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.senderLinkName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AmqpClientTool.Properties.Settings.Default, "senderLinkName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.senderLinkName.Location = new System.Drawing.Point(10, 21);
            this.senderLinkName.Name = "senderLinkName";
            this.senderLinkName.Size = new System.Drawing.Size(383, 20);
            this.senderLinkName.TabIndex = 29;
            this.senderLinkName.Text = global::AmqpClientTool.Properties.Settings.Default.senderLinkName;
            // 
            // host
            // 
            this.host.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.host.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AmqpClientTool.Properties.Settings.Default, "host", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.host.Location = new System.Drawing.Point(5, 22);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(316, 20);
            this.host.TabIndex = 24;
            this.host.Text = global::AmqpClientTool.Properties.Settings.Default.host;
            // 
            // username
            // 
            this.username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.username.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AmqpClientTool.Properties.Settings.Default, "username", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.username.Location = new System.Drawing.Point(5, 61);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(316, 20);
            this.username.TabIndex = 27;
            this.username.Text = global::AmqpClientTool.Properties.Settings.Default.username;
            // 
            // port
            // 
            this.port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.port.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AmqpClientTool.Properties.Settings.Default, "port", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.port.Location = new System.Drawing.Point(327, 20);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(61, 20);
            this.port.TabIndex = 26;
            this.port.Text = global::AmqpClientTool.Properties.Settings.Default.port;
            // 
            // useTls
            // 
            this.useTls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.useTls.AutoSize = true;
            this.useTls.Checked = global::AmqpClientTool.Properties.Settings.Default.useTls;
            this.useTls.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AmqpClientTool.Properties.Settings.Default, "useTls", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.useTls.Location = new System.Drawing.Point(506, 24);
            this.useTls.Name = "useTls";
            this.useTls.Size = new System.Drawing.Size(68, 17);
            this.useTls.TabIndex = 31;
            this.useTls.Text = "Use TLS";
            this.useTls.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.host);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.port);
            this.Controls.Add(this.useTls);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.open);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "AMQP 1.0 Client Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label6;
        private Label label5;
        private TextBox host;
        private TextBox password;
        private TextBox username;
        private TextBox port;
        private CheckBox useTls;
        private ToolStripStatusLabel status;
        private StatusStrip statusStrip1;
        private Button close;
        private Label label2;
        private Label label1;
        private Button open;
        private SplitContainer splitContainer1;
        private TextBox receiverLinkAddress;
        private Label label10;
        private Button receive;
        private Common.OutputTextBox output;
        private TextBox senderLinkAddress;
        private Label label3;
        private Button send;
        private Common.InputTextBox input;
        private TextBox receiverLinkName;
        private Label label7;
        private TextBox senderLinkName;
        private Label label8;
        private TextBox subject;
        private Label label4;
    }
}

