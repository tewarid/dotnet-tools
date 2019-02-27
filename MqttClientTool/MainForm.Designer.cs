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
            this.topicSubscribe = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.qosSubscribe = new System.Windows.Forms.ComboBox();
            this.unsubscribe = new System.Windows.Forms.Button();
            this.subscribe = new System.Windows.Forms.Button();
            this.subscriptions = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.output = new Common.OutputTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.qosPublish = new System.Windows.Forms.ComboBox();
            this.retain = new System.Windows.Forms.CheckBox();
            this.topicPublish = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.publish = new System.Windows.Forms.Button();
            this.input = new Common.InputTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cleanSession = new System.Windows.Forms.CheckBox();
            this.clientId = new System.Windows.Forms.TextBox();
            this.host = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.TextBox();
            this.useWebSocket = new System.Windows.Forms.CheckBox();
            this.useTls = new System.Windows.Forms.CheckBox();
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
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port";
            // 
            // start
            // 
            this.start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.start.Location = new System.Drawing.Point(510, 101);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 13;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.Start_Click);
            // 
            // stop
            // 
            this.stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stop.Location = new System.Drawing.Point(591, 101);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 14;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 130);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.topicSubscribe);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.qosSubscribe);
            this.splitContainer1.Panel1.Controls.Add(this.unsubscribe);
            this.splitContainer1.Panel1.Controls.Add(this.subscribe);
            this.splitContainer1.Panel1.Controls.Add(this.subscriptions);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.output);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.qosPublish);
            this.splitContainer1.Panel2.Controls.Add(this.retain);
            this.splitContainer1.Panel2.Controls.Add(this.topicPublish);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.publish);
            this.splitContainer1.Panel2.Controls.Add(this.input);
            this.splitContainer1.Size = new System.Drawing.Size(795, 299);
            this.splitContainer1.SplitterDistance = 392;
            this.splitContainer1.TabIndex = 17;
            // 
            // topicSubscribe
            // 
            this.topicSubscribe.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MqttClientTool.Properties.Settings.Default, "topicSubscribe", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.topicSubscribe.Location = new System.Drawing.Point(10, 61);
            this.topicSubscribe.Name = "topicSubscribe";
            this.topicSubscribe.Size = new System.Drawing.Size(164, 20);
            this.topicSubscribe.TabIndex = 23;
            this.topicSubscribe.Text = global::MqttClientTool.Properties.Settings.Default.topicSubscribe;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Topic";
            // 
            // qosSubscribe
            // 
            this.qosSubscribe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qosSubscribe.FormattingEnabled = true;
            this.qosSubscribe.Items.AddRange(new object[] {
            "QoS 0 (at most once)",
            "QoS 1 (at least once)",
            "QoS 2 (exactly once)"});
            this.qosSubscribe.Location = new System.Drawing.Point(10, 21);
            this.qosSubscribe.Name = "qosSubscribe";
            this.qosSubscribe.Size = new System.Drawing.Size(164, 21);
            this.qosSubscribe.TabIndex = 22;
            // 
            // unsubscribe
            // 
            this.unsubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unsubscribe.Location = new System.Drawing.Point(311, 87);
            this.unsubscribe.Name = "unsubscribe";
            this.unsubscribe.Size = new System.Drawing.Size(75, 23);
            this.unsubscribe.TabIndex = 26;
            this.unsubscribe.Text = "Remove";
            this.unsubscribe.UseVisualStyleBackColor = true;
            this.unsubscribe.Click += new System.EventHandler(this.Unsubscribe_Click);
            // 
            // subscribe
            // 
            this.subscribe.Location = new System.Drawing.Point(99, 87);
            this.subscribe.Name = "subscribe";
            this.subscribe.Size = new System.Drawing.Size(75, 23);
            this.subscribe.TabIndex = 24;
            this.subscribe.Text = "Subscribe";
            this.subscribe.UseVisualStyleBackColor = true;
            this.subscribe.Click += new System.EventHandler(this.Subscribe_Click);
            // 
            // subscriptions
            // 
            this.subscriptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subscriptions.FormattingEnabled = true;
            this.subscriptions.IntegralHeight = false;
            this.subscriptions.Location = new System.Drawing.Point(183, 21);
            this.subscriptions.Name = "subscriptions";
            this.subscriptions.Size = new System.Drawing.Size(203, 60);
            this.subscriptions.Sorted = true;
            this.subscriptions.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 5);
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
            this.output.AppendBinaryChecked = false;
            this.output.DataBindings.Add(new System.Windows.Forms.Binding("TextValue", global::MqttClientTool.Properties.Settings.Default, "outputText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.output.Location = new System.Drawing.Point(2, 117);
            this.output.Margin = new System.Windows.Forms.Padding(4);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(385, 177);
            this.output.TabIndex = 27;
            this.output.TextValue = global::MqttClientTool.Properties.Settings.Default.outputText;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Quality of Service Level";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Quality of Service Level";
            // 
            // qosPublish
            // 
            this.qosPublish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.qosPublish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qosPublish.FormattingEnabled = true;
            this.qosPublish.Items.AddRange(new object[] {
            "QoS 0 (at most once)",
            "QoS 1 (at least once)",
            "QoS 2 (exactly once)"});
            this.qosPublish.Location = new System.Drawing.Point(6, 269);
            this.qosPublish.Name = "qosPublish";
            this.qosPublish.Size = new System.Drawing.Size(164, 21);
            this.qosPublish.TabIndex = 32;
            // 
            // retain
            // 
            this.retain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.retain.AutoSize = true;
            this.retain.Location = new System.Drawing.Point(176, 273);
            this.retain.Name = "retain";
            this.retain.Size = new System.Drawing.Size(99, 17);
            this.retain.TabIndex = 33;
            this.retain.Text = "Set Retain Flag";
            this.retain.UseVisualStyleBackColor = true;
            // 
            // topicPublish
            // 
            this.topicPublish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topicPublish.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MqttClientTool.Properties.Settings.Default, "topicPublish", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.topicPublish.Location = new System.Drawing.Point(9, 20);
            this.topicPublish.Name = "topicPublish";
            this.topicPublish.Size = new System.Drawing.Size(384, 20);
            this.topicPublish.TabIndex = 30;
            this.topicPublish.Text = global::MqttClientTool.Properties.Settings.Default.topicPublish;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Topic to send message to";
            // 
            // publish
            // 
            this.publish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.publish.Location = new System.Drawing.Point(318, 269);
            this.publish.Name = "publish";
            this.publish.Size = new System.Drawing.Size(75, 23);
            this.publish.TabIndex = 34;
            this.publish.Text = "Publish";
            this.publish.UseVisualStyleBackColor = true;
            this.publish.Click += new System.EventHandler(this.Publish_Click);
            // 
            // input
            // 
            this.input.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input.BinaryChecked = false;
            this.input.ChangeEndOfLine = true;
            this.input.DataBindings.Add(new System.Windows.Forms.Binding("TextValue", global::MqttClientTool.Properties.Settings.Default, "inputText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.input.EndOfLine = Common.EndOfLine.Dos;
            this.input.Location = new System.Drawing.Point(2, 46);
            this.input.Name = "input";
            this.input.Padding = new System.Windows.Forms.Padding(4);
            this.input.SelectedTextValue = "";
            this.input.Size = new System.Drawing.Size(394, 204);
            this.input.TabIndex = 31;
            this.input.TextValue = global::MqttClientTool.Properties.Settings.Default.inputText;
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
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Username";
            // 
            // password
            // 
            this.password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.password.Location = new System.Drawing.Point(327, 65);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(165, 20);
            this.password.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(324, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Password";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Client ID";
            // 
            // cleanSession
            // 
            this.cleanSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cleanSession.AutoSize = true;
            this.cleanSession.Checked = global::MqttClientTool.Properties.Settings.Default.cleanSession;
            this.cleanSession.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cleanSession.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MqttClientTool.Properties.Settings.Default, "cleanSession", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cleanSession.Location = new System.Drawing.Point(510, 24);
            this.cleanSession.Name = "cleanSession";
            this.cleanSession.Size = new System.Drawing.Size(93, 17);
            this.cleanSession.TabIndex = 10;
            this.cleanSession.Text = "Clean Session";
            this.cleanSession.UseVisualStyleBackColor = true;
            // 
            // clientId
            // 
            this.clientId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientId.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MqttClientTool.Properties.Settings.Default, "clientId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.clientId.Location = new System.Drawing.Point(5, 104);
            this.clientId.Name = "clientId";
            this.clientId.Size = new System.Drawing.Size(316, 20);
            this.clientId.TabIndex = 9;
            this.clientId.Text = global::MqttClientTool.Properties.Settings.Default.clientId;
            // 
            // host
            // 
            this.host.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.host.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MqttClientTool.Properties.Settings.Default, "host", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.host.Location = new System.Drawing.Point(5, 26);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(316, 20);
            this.host.TabIndex = 4;
            this.host.Text = global::MqttClientTool.Properties.Settings.Default.host;
            // 
            // username
            // 
            this.username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.username.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MqttClientTool.Properties.Settings.Default, "username", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.username.Location = new System.Drawing.Point(5, 65);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(316, 20);
            this.username.TabIndex = 7;
            this.username.Text = global::MqttClientTool.Properties.Settings.Default.username;
            // 
            // port
            // 
            this.port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.port.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MqttClientTool.Properties.Settings.Default, "port", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.port.Location = new System.Drawing.Point(327, 24);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(61, 20);
            this.port.TabIndex = 6;
            this.port.Text = global::MqttClientTool.Properties.Settings.Default.port;
            // 
            // useWebSocket
            // 
            this.useWebSocket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.useWebSocket.AutoSize = true;
            this.useWebSocket.Checked = global::MqttClientTool.Properties.Settings.Default.useWebSocket;
            this.useWebSocket.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MqttClientTool.Properties.Settings.Default, "useWebSocket", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.useWebSocket.Location = new System.Drawing.Point(510, 70);
            this.useWebSocket.Name = "useWebSocket";
            this.useWebSocket.Size = new System.Drawing.Size(105, 17);
            this.useWebSocket.TabIndex = 12;
            this.useWebSocket.Text = "Use WebSocket";
            this.useWebSocket.UseVisualStyleBackColor = true;
            this.useWebSocket.CheckedChanged += new System.EventHandler(this.UseWebSocket_CheckedChanged);
            // 
            // useTls
            // 
            this.useTls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.useTls.AutoSize = true;
            this.useTls.Checked = global::MqttClientTool.Properties.Settings.Default.useTls;
            this.useTls.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MqttClientTool.Properties.Settings.Default, "useTls", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.useTls.Location = new System.Drawing.Point(510, 47);
            this.useTls.Name = "useTls";
            this.useTls.Size = new System.Drawing.Size(68, 17);
            this.useTls.TabIndex = 11;
            this.useTls.Text = "Use TLS";
            this.useTls.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cleanSession);
            this.Controls.Add(this.clientId);
            this.Controls.Add(this.label9);
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
            this.Shown += new System.EventHandler(this.MainForm_Shown);
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
        private Common.OutputTextBox output;
        private System.Windows.Forms.TextBox topicPublish;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button publish;
        private Common.InputTextBox input;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel status;
        private TextBox username;
        private Label label5;
        private TextBox password;
        private Label label6;
        private CheckBox retain;
        private Label label7;
        private ComboBox qosPublish;
        private Label label8;
        private ComboBox qosSubscribe;
        private Label label9;
        private TextBox clientId;
        private TextBox topicSubscribe;
        private Label label10;
        private CheckBox cleanSession;
    }
}

