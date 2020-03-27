namespace Launcher
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.amqpClient = new System.Windows.Forms.Button();
            this.azureEventHubClient = new System.Windows.Forms.Button();
            this.bluetoothSerialClient = new System.Windows.Forms.Button();
            this.bluetoothSerialServer = new System.Windows.Forms.Button();
            this.encodingTool = new System.Windows.Forms.Button();
            this.firewallTool = new System.Windows.Forms.Button();
            this.fontTool = new System.Windows.Forms.Button();
            this.gitLabTool = new System.Windows.Forms.Button();
            this.gitTool = new System.Windows.Forms.Button();
            this.globalizationTool = new System.Windows.Forms.Button();
            this.usbHidTool = new System.Windows.Forms.Button();
            this.httpListener = new System.Windows.Forms.Button();
            this.httpRequestTool = new System.Windows.Forms.Button();
            this.icmpTool = new System.Windows.Forms.Button();
            this.kafkaClient = new System.Windows.Forms.Button();
            this.mqttClient = new System.Windows.Forms.Button();
            this.networkRouteTool = new System.Windows.Forms.Button();
            this.notificationTool = new System.Windows.Forms.Button();
            this.serialPortTool = new System.Windows.Forms.Button();
            this.smtpClient = new System.Windows.Forms.Button();
            this.smtpServer = new System.Windows.Forms.Button();
            this.networkSniffer = new System.Windows.Forms.Button();
            this.tcpClient = new System.Windows.Forms.Button();
            this.tcpListener = new System.Windows.Forms.Button();
            this.udpTool = new System.Windows.Forms.Button();
            this.webSocketClient = new System.Windows.Forms.Button();
            this.webSocketServer = new System.Windows.Forms.Button();
            this.wmiQueryTool = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.amqpClient);
            this.flowLayoutPanel1.Controls.Add(this.azureEventHubClient);
            this.flowLayoutPanel1.Controls.Add(this.bluetoothSerialClient);
            this.flowLayoutPanel1.Controls.Add(this.bluetoothSerialServer);
            this.flowLayoutPanel1.Controls.Add(this.encodingTool);
            this.flowLayoutPanel1.Controls.Add(this.firewallTool);
            this.flowLayoutPanel1.Controls.Add(this.fontTool);
            this.flowLayoutPanel1.Controls.Add(this.gitLabTool);
            this.flowLayoutPanel1.Controls.Add(this.gitTool);
            this.flowLayoutPanel1.Controls.Add(this.globalizationTool);
            this.flowLayoutPanel1.Controls.Add(this.usbHidTool);
            this.flowLayoutPanel1.Controls.Add(this.httpListener);
            this.flowLayoutPanel1.Controls.Add(this.httpRequestTool);
            this.flowLayoutPanel1.Controls.Add(this.icmpTool);
            this.flowLayoutPanel1.Controls.Add(this.kafkaClient);
            this.flowLayoutPanel1.Controls.Add(this.mqttClient);
            this.flowLayoutPanel1.Controls.Add(this.networkRouteTool);
            this.flowLayoutPanel1.Controls.Add(this.notificationTool);
            this.flowLayoutPanel1.Controls.Add(this.serialPortTool);
            this.flowLayoutPanel1.Controls.Add(this.smtpClient);
            this.flowLayoutPanel1.Controls.Add(this.smtpServer);
            this.flowLayoutPanel1.Controls.Add(this.networkSniffer);
            this.flowLayoutPanel1.Controls.Add(this.tcpClient);
            this.flowLayoutPanel1.Controls.Add(this.tcpListener);
            this.flowLayoutPanel1.Controls.Add(this.udpTool);
            this.flowLayoutPanel1.Controls.Add(this.webSocketClient);
            this.flowLayoutPanel1.Controls.Add(this.webSocketServer);
            this.flowLayoutPanel1.Controls.Add(this.wmiQueryTool);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(784, 441);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // amqpClient
            // 
            this.amqpClient.FlatAppearance.BorderSize = 0;
            this.amqpClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.amqpClient.Location = new System.Drawing.Point(3, 3);
            this.amqpClient.Name = "amqpClient";
            this.amqpClient.Size = new System.Drawing.Size(250, 30);
            this.amqpClient.TabIndex = 0;
            this.amqpClient.Text = "AMQP Client Tool";
            this.amqpClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.amqpClient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.amqpClient.UseVisualStyleBackColor = true;
            this.amqpClient.Click += new System.EventHandler(this.AmqpClient_Click);
            // 
            // azureEventHubClient
            // 
            this.azureEventHubClient.FlatAppearance.BorderSize = 0;
            this.azureEventHubClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.azureEventHubClient.Location = new System.Drawing.Point(259, 3);
            this.azureEventHubClient.Name = "azureEventHubClient";
            this.azureEventHubClient.Size = new System.Drawing.Size(250, 30);
            this.azureEventHubClient.TabIndex = 1;
            this.azureEventHubClient.Text = "Azure EventHub Client Tool";
            this.azureEventHubClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.azureEventHubClient.UseVisualStyleBackColor = true;
            this.azureEventHubClient.Click += new System.EventHandler(this.azureEventHubClient_Click);
            // 
            // bluetoothSerialClient
            // 
            this.bluetoothSerialClient.FlatAppearance.BorderSize = 0;
            this.bluetoothSerialClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bluetoothSerialClient.Location = new System.Drawing.Point(515, 3);
            this.bluetoothSerialClient.Name = "bluetoothSerialClient";
            this.bluetoothSerialClient.Size = new System.Drawing.Size(250, 30);
            this.bluetoothSerialClient.TabIndex = 2;
            this.bluetoothSerialClient.Text = "Bluetooth Serial Client Tool";
            this.bluetoothSerialClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bluetoothSerialClient.UseVisualStyleBackColor = true;
            this.bluetoothSerialClient.Click += new System.EventHandler(this.BluetoothSerialClient_Click);
            // 
            // bluetoothSerialServer
            // 
            this.bluetoothSerialServer.FlatAppearance.BorderSize = 0;
            this.bluetoothSerialServer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bluetoothSerialServer.Location = new System.Drawing.Point(3, 39);
            this.bluetoothSerialServer.Name = "bluetoothSerialServer";
            this.bluetoothSerialServer.Size = new System.Drawing.Size(250, 30);
            this.bluetoothSerialServer.TabIndex = 3;
            this.bluetoothSerialServer.Text = "Bluetooth Serial Server Tool";
            this.bluetoothSerialServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bluetoothSerialServer.UseVisualStyleBackColor = true;
            this.bluetoothSerialServer.Click += new System.EventHandler(this.BluetoothSerialServer_Click);
            // 
            // encodingTool
            // 
            this.encodingTool.FlatAppearance.BorderSize = 0;
            this.encodingTool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.encodingTool.Location = new System.Drawing.Point(259, 39);
            this.encodingTool.Name = "encodingTool";
            this.encodingTool.Size = new System.Drawing.Size(250, 30);
            this.encodingTool.TabIndex = 4;
            this.encodingTool.Text = "Encoding Tool";
            this.encodingTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.encodingTool.UseVisualStyleBackColor = true;
            this.encodingTool.Click += new System.EventHandler(this.EncodingTool_Click);
            // 
            // firewallTool
            // 
            this.firewallTool.FlatAppearance.BorderSize = 0;
            this.firewallTool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.firewallTool.Location = new System.Drawing.Point(515, 39);
            this.firewallTool.Name = "firewallTool";
            this.firewallTool.Size = new System.Drawing.Size(250, 30);
            this.firewallTool.TabIndex = 5;
            this.firewallTool.Text = "Firewall Tool";
            this.firewallTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.firewallTool.UseVisualStyleBackColor = true;
            this.firewallTool.Click += new System.EventHandler(this.FirewallTool_Click);
            // 
            // fontTool
            // 
            this.fontTool.FlatAppearance.BorderSize = 0;
            this.fontTool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fontTool.Location = new System.Drawing.Point(3, 75);
            this.fontTool.Name = "fontTool";
            this.fontTool.Size = new System.Drawing.Size(250, 30);
            this.fontTool.TabIndex = 6;
            this.fontTool.Text = "Font Tool";
            this.fontTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fontTool.UseVisualStyleBackColor = true;
            this.fontTool.Click += new System.EventHandler(this.FontTool_Click);
            // 
            // gitLabTool
            // 
            this.gitLabTool.FlatAppearance.BorderSize = 0;
            this.gitLabTool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gitLabTool.Location = new System.Drawing.Point(259, 75);
            this.gitLabTool.Name = "gitLabTool";
            this.gitLabTool.Size = new System.Drawing.Size(250, 30);
            this.gitLabTool.TabIndex = 7;
            this.gitLabTool.Text = "GitLab Tool";
            this.gitLabTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gitLabTool.UseVisualStyleBackColor = true;
            this.gitLabTool.Click += new System.EventHandler(this.GitLabTool_Click);
            // 
            // gitTool
            // 
            this.gitTool.FlatAppearance.BorderSize = 0;
            this.gitTool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gitTool.Location = new System.Drawing.Point(515, 75);
            this.gitTool.Name = "gitTool";
            this.gitTool.Size = new System.Drawing.Size(250, 30);
            this.gitTool.TabIndex = 8;
            this.gitTool.Text = "Git Tool";
            this.gitTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gitTool.UseVisualStyleBackColor = true;
            this.gitTool.Click += new System.EventHandler(this.GitTool_Click);
            // 
            // globalizationTool
            // 
            this.globalizationTool.FlatAppearance.BorderSize = 0;
            this.globalizationTool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.globalizationTool.Location = new System.Drawing.Point(3, 111);
            this.globalizationTool.Name = "globalizationTool";
            this.globalizationTool.Size = new System.Drawing.Size(250, 30);
            this.globalizationTool.TabIndex = 9;
            this.globalizationTool.Text = "Globalization Tool";
            this.globalizationTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.globalizationTool.UseVisualStyleBackColor = true;
            this.globalizationTool.Click += new System.EventHandler(this.GlobalizationTool_Click);
            // 
            // usbHidTool
            // 
            this.usbHidTool.FlatAppearance.BorderSize = 0;
            this.usbHidTool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.usbHidTool.Location = new System.Drawing.Point(259, 111);
            this.usbHidTool.Name = "usbHidTool";
            this.usbHidTool.Size = new System.Drawing.Size(250, 30);
            this.usbHidTool.TabIndex = 10;
            this.usbHidTool.Text = "USB HID Tool";
            this.usbHidTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.usbHidTool.UseVisualStyleBackColor = true;
            this.usbHidTool.Click += new System.EventHandler(this.UsbHidTool_Click);
            // 
            // httpListener
            // 
            this.httpListener.FlatAppearance.BorderSize = 0;
            this.httpListener.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.httpListener.Location = new System.Drawing.Point(515, 111);
            this.httpListener.Name = "httpListener";
            this.httpListener.Size = new System.Drawing.Size(250, 30);
            this.httpListener.TabIndex = 11;
            this.httpListener.Text = "HTTP Listener Tool";
            this.httpListener.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.httpListener.UseVisualStyleBackColor = true;
            this.httpListener.Click += new System.EventHandler(this.HttpListener_Click);
            // 
            // httpRequestTool
            // 
            this.httpRequestTool.FlatAppearance.BorderSize = 0;
            this.httpRequestTool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.httpRequestTool.Location = new System.Drawing.Point(3, 147);
            this.httpRequestTool.Name = "httpRequestTool";
            this.httpRequestTool.Size = new System.Drawing.Size(250, 30);
            this.httpRequestTool.TabIndex = 12;
            this.httpRequestTool.Text = "HTTP Request Tool";
            this.httpRequestTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.httpRequestTool.UseVisualStyleBackColor = true;
            this.httpRequestTool.Click += new System.EventHandler(this.HttpRequestTool_Click);
            // 
            // icmpTool
            // 
            this.icmpTool.FlatAppearance.BorderSize = 0;
            this.icmpTool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.icmpTool.Location = new System.Drawing.Point(259, 147);
            this.icmpTool.Name = "icmpTool";
            this.icmpTool.Size = new System.Drawing.Size(250, 30);
            this.icmpTool.TabIndex = 13;
            this.icmpTool.Text = "ICMP Tool";
            this.icmpTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icmpTool.UseVisualStyleBackColor = true;
            this.icmpTool.Click += new System.EventHandler(this.icmpTool_Click);
            // 
            // kafkaClient
            // 
            this.kafkaClient.FlatAppearance.BorderSize = 0;
            this.kafkaClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.kafkaClient.Location = new System.Drawing.Point(515, 147);
            this.kafkaClient.Name = "kafkaClient";
            this.kafkaClient.Size = new System.Drawing.Size(250, 30);
            this.kafkaClient.TabIndex = 14;
            this.kafkaClient.Text = "Kafka Client Tool";
            this.kafkaClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kafkaClient.UseVisualStyleBackColor = true;
            this.kafkaClient.Click += new System.EventHandler(this.KafkaClient_Click);
            // 
            // mqttClient
            // 
            this.mqttClient.FlatAppearance.BorderSize = 0;
            this.mqttClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mqttClient.Location = new System.Drawing.Point(3, 183);
            this.mqttClient.Name = "mqttClient";
            this.mqttClient.Size = new System.Drawing.Size(250, 30);
            this.mqttClient.TabIndex = 15;
            this.mqttClient.Text = "MQTT Client Tool";
            this.mqttClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mqttClient.UseVisualStyleBackColor = true;
            this.mqttClient.Click += new System.EventHandler(this.MqttClient_Click);
            // 
            // networkRouteTool
            // 
            this.networkRouteTool.FlatAppearance.BorderSize = 0;
            this.networkRouteTool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.networkRouteTool.Location = new System.Drawing.Point(259, 183);
            this.networkRouteTool.Name = "networkRouteTool";
            this.networkRouteTool.Size = new System.Drawing.Size(250, 30);
            this.networkRouteTool.TabIndex = 16;
            this.networkRouteTool.Text = "Network Route Tool";
            this.networkRouteTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.networkRouteTool.UseVisualStyleBackColor = true;
            this.networkRouteTool.Click += new System.EventHandler(this.NetworkRouteTool_Click);
            // 
            // notificationTool
            // 
            this.notificationTool.FlatAppearance.BorderSize = 0;
            this.notificationTool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.notificationTool.Location = new System.Drawing.Point(515, 183);
            this.notificationTool.Name = "notificationTool";
            this.notificationTool.Size = new System.Drawing.Size(250, 30);
            this.notificationTool.TabIndex = 17;
            this.notificationTool.Text = "Notification Tool";
            this.notificationTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.notificationTool.UseVisualStyleBackColor = true;
            this.notificationTool.Click += new System.EventHandler(this.NotificationTool_Click);
            // 
            // serialPortTool
            // 
            this.serialPortTool.FlatAppearance.BorderSize = 0;
            this.serialPortTool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.serialPortTool.Location = new System.Drawing.Point(3, 219);
            this.serialPortTool.Name = "serialPortTool";
            this.serialPortTool.Size = new System.Drawing.Size(250, 30);
            this.serialPortTool.TabIndex = 18;
            this.serialPortTool.Text = "Serial Port Tool";
            this.serialPortTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.serialPortTool.UseVisualStyleBackColor = true;
            this.serialPortTool.Click += new System.EventHandler(this.SerialPortTool_Click);
            // 
            // smtpClient
            // 
            this.smtpClient.FlatAppearance.BorderSize = 0;
            this.smtpClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.smtpClient.Location = new System.Drawing.Point(259, 219);
            this.smtpClient.Name = "smtpClient";
            this.smtpClient.Size = new System.Drawing.Size(250, 30);
            this.smtpClient.TabIndex = 19;
            this.smtpClient.Text = "SMTP Client Tool";
            this.smtpClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.smtpClient.UseVisualStyleBackColor = true;
            this.smtpClient.Click += new System.EventHandler(this.SmtpClient_Click);
            // 
            // smtpServer
            // 
            this.smtpServer.FlatAppearance.BorderSize = 0;
            this.smtpServer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.smtpServer.Location = new System.Drawing.Point(515, 219);
            this.smtpServer.Name = "smtpServer";
            this.smtpServer.Size = new System.Drawing.Size(250, 30);
            this.smtpServer.TabIndex = 20;
            this.smtpServer.Text = "SMTP Server Tool";
            this.smtpServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.smtpServer.UseVisualStyleBackColor = true;
            this.smtpServer.Click += new System.EventHandler(this.SmtpServer_Click);
            // 
            // networkSniffer
            // 
            this.networkSniffer.FlatAppearance.BorderSize = 0;
            this.networkSniffer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.networkSniffer.Location = new System.Drawing.Point(3, 255);
            this.networkSniffer.Name = "networkSniffer";
            this.networkSniffer.Size = new System.Drawing.Size(250, 30);
            this.networkSniffer.TabIndex = 21;
            this.networkSniffer.Text = "Network Sniffer Tool";
            this.networkSniffer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.networkSniffer.UseVisualStyleBackColor = true;
            this.networkSniffer.Click += new System.EventHandler(this.NetworkSniffer_Click);
            // 
            // tcpClient
            // 
            this.tcpClient.FlatAppearance.BorderSize = 0;
            this.tcpClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tcpClient.Location = new System.Drawing.Point(259, 255);
            this.tcpClient.Name = "tcpClient";
            this.tcpClient.Size = new System.Drawing.Size(250, 30);
            this.tcpClient.TabIndex = 22;
            this.tcpClient.Text = "TCP Client Tool";
            this.tcpClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tcpClient.UseVisualStyleBackColor = true;
            this.tcpClient.Click += new System.EventHandler(this.TcpClient_Click);
            // 
            // tcpListener
            // 
            this.tcpListener.FlatAppearance.BorderSize = 0;
            this.tcpListener.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tcpListener.Location = new System.Drawing.Point(515, 255);
            this.tcpListener.Name = "tcpListener";
            this.tcpListener.Size = new System.Drawing.Size(250, 30);
            this.tcpListener.TabIndex = 23;
            this.tcpListener.Text = "TCP Listener Tool";
            this.tcpListener.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tcpListener.UseVisualStyleBackColor = true;
            this.tcpListener.Click += new System.EventHandler(this.TcpListener_Click);
            // 
            // udpTool
            // 
            this.udpTool.FlatAppearance.BorderSize = 0;
            this.udpTool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.udpTool.Location = new System.Drawing.Point(3, 291);
            this.udpTool.Name = "udpTool";
            this.udpTool.Size = new System.Drawing.Size(250, 30);
            this.udpTool.TabIndex = 24;
            this.udpTool.Text = "UDP Tool";
            this.udpTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.udpTool.UseVisualStyleBackColor = true;
            this.udpTool.Click += new System.EventHandler(this.udpTool_Click);
            // 
            // webSocketClient
            // 
            this.webSocketClient.FlatAppearance.BorderSize = 0;
            this.webSocketClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.webSocketClient.Location = new System.Drawing.Point(259, 291);
            this.webSocketClient.Name = "webSocketClient";
            this.webSocketClient.Size = new System.Drawing.Size(250, 30);
            this.webSocketClient.TabIndex = 25;
            this.webSocketClient.Text = "WebSocket Client Tool";
            this.webSocketClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.webSocketClient.UseVisualStyleBackColor = true;
            this.webSocketClient.Click += new System.EventHandler(this.WebSocketClient_Click);
            // 
            // webSocketServer
            // 
            this.webSocketServer.FlatAppearance.BorderSize = 0;
            this.webSocketServer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.webSocketServer.Location = new System.Drawing.Point(515, 291);
            this.webSocketServer.Name = "webSocketServer";
            this.webSocketServer.Size = new System.Drawing.Size(250, 30);
            this.webSocketServer.TabIndex = 26;
            this.webSocketServer.Text = "WebSocket Server Tool";
            this.webSocketServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.webSocketServer.UseVisualStyleBackColor = true;
            this.webSocketServer.Click += new System.EventHandler(this.WebSocketServer_Click);
            // 
            // wmiQueryTool
            // 
            this.wmiQueryTool.FlatAppearance.BorderSize = 0;
            this.wmiQueryTool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.wmiQueryTool.Location = new System.Drawing.Point(3, 327);
            this.wmiQueryTool.Name = "wmiQueryTool";
            this.wmiQueryTool.Size = new System.Drawing.Size(250, 30);
            this.wmiQueryTool.TabIndex = 27;
            this.wmiQueryTool.Text = "WMI Query Tool";
            this.wmiQueryTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.wmiQueryTool.UseVisualStyleBackColor = true;
            this.wmiQueryTool.Click += new System.EventHandler(this.WmiQueryTool_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Tools for Windows Desktop";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button amqpClient;
        private System.Windows.Forms.Button azureEventHubClient;
        private System.Windows.Forms.Button bluetoothSerialClient;
        private System.Windows.Forms.Button bluetoothSerialServer;
        private System.Windows.Forms.Button encodingTool;
        private System.Windows.Forms.Button firewallTool;
        private System.Windows.Forms.Button fontTool;
        private System.Windows.Forms.Button gitLabTool;
        private System.Windows.Forms.Button gitTool;
        private System.Windows.Forms.Button globalizationTool;
        private System.Windows.Forms.Button usbHidTool;
        private System.Windows.Forms.Button httpListener;
        private System.Windows.Forms.Button httpRequestTool;
        private System.Windows.Forms.Button icmpTool;
        private System.Windows.Forms.Button kafkaClient;
        private System.Windows.Forms.Button mqttClient;
        private System.Windows.Forms.Button networkRouteTool;
        private System.Windows.Forms.Button notificationTool;
        private System.Windows.Forms.Button serialPortTool;
        private System.Windows.Forms.Button smtpClient;
        private System.Windows.Forms.Button smtpServer;
        private System.Windows.Forms.Button networkSniffer;
        private System.Windows.Forms.Button tcpClient;
        private System.Windows.Forms.Button tcpListener;
        private System.Windows.Forms.Button udpTool;
        private System.Windows.Forms.Button webSocketServer;
        private System.Windows.Forms.Button webSocketClient;
        private System.Windows.Forms.Button wmiQueryTool;
    }
}

