using System.Windows.Forms;

namespace MqttClientTool
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.unsubscribe = new System.Windows.Forms.Button();
            this.subscribe = new System.Windows.Forms.Button();
            this.subscriptions = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.output = new Common.ReceiveTextBox();
            this.topic = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.send = new System.Windows.Forms.Button();
            this.input = new Common.SendTextBox();
            this.useWebSocket = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.useTls = new System.Windows.Forms.CheckBox();
            this.port = new System.Windows.Forms.TextBox();
            this.host = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Host or URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(612, 25);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 11;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.Start_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(693, 25);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 12;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 54);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.unsubscribe);
            this.splitContainer1.Panel1.Controls.Add(this.subscribe);
            this.splitContainer1.Panel1.Controls.Add(this.subscriptions);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.output);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.topic);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.send);
            this.splitContainer1.Panel2.Controls.Add(this.input);
            this.splitContainer1.Size = new System.Drawing.Size(795, 375);
            this.splitContainer1.SplitterDistance = 392;
            this.splitContainer1.TabIndex = 17;
            // 
            // unsubscribe
            // 
            this.unsubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unsubscribe.Location = new System.Drawing.Point(312, 67);
            this.unsubscribe.Name = "unsubscribe";
            this.unsubscribe.Size = new System.Drawing.Size(75, 23);
            this.unsubscribe.TabIndex = 21;
            this.unsubscribe.Text = "Remove";
            this.unsubscribe.UseVisualStyleBackColor = true;
            this.unsubscribe.Click += new System.EventHandler(this.Unsubscribe_Click);
            // 
            // subscribe
            // 
            this.subscribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.subscribe.Location = new System.Drawing.Point(312, 38);
            this.subscribe.Name = "subscribe";
            this.subscribe.Size = new System.Drawing.Size(75, 23);
            this.subscribe.TabIndex = 20;
            this.subscribe.Text = "Add...";
            this.subscribe.UseVisualStyleBackColor = true;
            this.subscribe.Click += new System.EventHandler(this.Subscribe_Click);
            // 
            // subscriptions
            // 
            this.subscriptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subscriptions.FormattingEnabled = true;
            this.subscriptions.IntegralHeight = false;
            this.subscriptions.Location = new System.Drawing.Point(5, 21);
            this.subscriptions.Name = "subscriptions";
            this.subscriptions.Size = new System.Drawing.Size(301, 69);
            this.subscriptions.Sorted = true;
            this.subscriptions.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Subscribed topics";
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.Location = new System.Drawing.Point(2, 97);
            this.output.Margin = new System.Windows.Forms.Padding(4);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(385, 273);
            this.output.TabIndex = 22;
            // 
            // topic
            // 
            this.topic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topic.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MqttClientTool.Properties.Settings.Default, "topic", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.topic.Location = new System.Drawing.Point(2, 20);
            this.topic.Name = "topic";
            this.topic.Size = new System.Drawing.Size(391, 20);
            this.topic.TabIndex = 23;
            this.topic.Text = global::MqttClientTool.Properties.Settings.Default.topic;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Topic to send message to";
            // 
            // send
            // 
            this.send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.send.Location = new System.Drawing.Point(321, 342);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(75, 23);
            this.send.TabIndex = 25;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.Send_Click);
            // 
            // input
            // 
            this.input.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input.Location = new System.Drawing.Point(2, 46);
            this.input.Name = "input";
            this.input.Padding = new System.Windows.Forms.Padding(4);
            this.input.Size = new System.Drawing.Size(394, 324);
            this.input.TabIndex = 24;
            // 
            // useWebSocket
            // 
            this.useWebSocket.AutoSize = true;
            this.useWebSocket.Checked = global::MqttClientTool.Properties.Settings.Default.useWebSocket;
            this.useWebSocket.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MqttClientTool.Properties.Settings.Default, "useWebSocket", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.useWebSocket.Location = new System.Drawing.Point(427, 29);
            this.useWebSocket.Name = "useWebSocket";
            this.useWebSocket.Size = new System.Drawing.Size(105, 17);
            this.useWebSocket.TabIndex = 9;
            this.useWebSocket.Text = "Use WebSocket";
            this.useWebSocket.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(79, 17);
            this.status.Text = "Disconnected";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Username";
            // 
            // username
            // 
            this.username.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MqttClientTool.Properties.Settings.Default, "username", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.username.Location = new System.Drawing.Point(227, 26);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(94, 20);
            this.username.TabIndex = 7;
            this.username.Text = global::MqttClientTool.Properties.Settings.Default.username;
            // 
            // useTls
            // 
            this.useTls.AutoSize = true;
            this.useTls.Checked = global::MqttClientTool.Properties.Settings.Default.useTls;
            this.useTls.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MqttClientTool.Properties.Settings.Default, "useTls", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.useTls.Location = new System.Drawing.Point(538, 28);
            this.useTls.Name = "useTls";
            this.useTls.Size = new System.Drawing.Size(68, 17);
            this.useTls.TabIndex = 10;
            this.useTls.Text = "Use TLS";
            this.useTls.UseVisualStyleBackColor = true;
            // 
            // port
            // 
            this.port.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MqttClientTool.Properties.Settings.Default, "port", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.port.Location = new System.Drawing.Point(160, 26);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(61, 20);
            this.port.TabIndex = 6;
            this.port.Text = global::MqttClientTool.Properties.Settings.Default.port;
            // 
            // host
            // 
            this.host.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MqttClientTool.Properties.Settings.Default, "host", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.host.Location = new System.Drawing.Point(5, 26);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(149, 20);
            this.host.TabIndex = 4;
            this.host.Text = global::MqttClientTool.Properties.Settings.Default.host;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(327, 26);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(94, 20);
            this.password.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(324, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Password";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.host);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.port);
            this.Controls.Add(this.useWebSocket);
            this.Controls.Add(this.useTls);
            this.Controls.Add(this.start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "MQTT 3.1.1 Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox host;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.CheckBox useTls;
        private System.Windows.Forms.CheckBox useWebSocket;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button unsubscribe;
        private System.Windows.Forms.Button subscribe;
        private System.Windows.Forms.ListBox subscriptions;
        private System.Windows.Forms.Label label4;
        private Common.ReceiveTextBox output;
        private System.Windows.Forms.TextBox topic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button send;
        private Common.SendTextBox input;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel status;
        private TextBox username;
        private Label label5;
        private TextBox password;
        private Label label6;
    }
}

