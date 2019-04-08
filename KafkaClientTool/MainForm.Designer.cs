namespace KafkaClientTool
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.subscribe = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.produce = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.reset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.securityProtocol = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.saslMechanism = new System.Windows.Forms.ComboBox();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.clientGroupId = new System.Windows.Forms.TextBox();
            this.subscribeToTopic = new System.Windows.Forms.TextBox();
            this.output = new Common.OutputTextBox();
            this.produceToTopic = new System.Windows.Forms.TextBox();
            this.input = new Common.InputTextBox();
            this.bootstrapServers = new System.Windows.Forms.TextBox();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 17);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Comma separated list of bootstrap servers";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 95);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.subscribe);
            this.splitContainer1.Panel1.Controls.Add(this.clientGroupId);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.subscribeToTopic);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.output);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.produce);
            this.splitContainer1.Panel2.Controls.Add(this.produceToTopic);
            this.splitContainer1.Panel2.Controls.Add(this.input);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Size = new System.Drawing.Size(788, 330);
            this.splitContainer1.SplitterDistance = 384;
            this.splitContainer1.TabIndex = 3;
            // 
            // subscribe
            // 
            this.subscribe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.subscribe.Location = new System.Drawing.Point(305, 82);
            this.subscribe.Name = "subscribe";
            this.subscribe.Size = new System.Drawing.Size(75, 23);
            this.subscribe.TabIndex = 5;
            this.subscribe.Text = "Subscribe";
            this.subscribe.UseVisualStyleBackColor = true;
            this.subscribe.Click += new System.EventHandler(this.Subscribe_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Client Group ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Comma separated list of subscription topics or regex";
            // 
            // produce
            // 
            this.produce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.produce.Location = new System.Drawing.Point(319, 303);
            this.produce.Name = "produce";
            this.produce.Size = new System.Drawing.Size(75, 23);
            this.produce.TabIndex = 3;
            this.produce.Text = "Produce";
            this.produce.UseVisualStyleBackColor = true;
            this.produce.Click += new System.EventHandler(this.Produce_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Produce to topic";
            // 
            // reset
            // 
            this.reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reset.Location = new System.Drawing.Point(713, 22);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 4;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(387, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Username";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(577, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Password";
            // 
            // securityProtocol
            // 
            this.securityProtocol.DataBindings.Add(new System.Windows.Forms.Binding("Tag", global::KafkaClientTool.Properties.Settings.Default, "securityProtocol", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.securityProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.securityProtocol.FormattingEnabled = true;
            this.securityProtocol.Location = new System.Drawing.Point(10, 64);
            this.securityProtocol.Name = "securityProtocol";
            this.securityProtocol.Size = new System.Drawing.Size(184, 21);
            this.securityProtocol.TabIndex = 9;
            this.securityProtocol.Tag = global::KafkaClientTool.Properties.Settings.Default.securityProtocol;
            this.securityProtocol.SelectedIndexChanged += new System.EventHandler(this.securityProtocol_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Security Protocol";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(197, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "SASL Mechanism";
            // 
            // saslMechanism
            // 
            this.saslMechanism.DataBindings.Add(new System.Windows.Forms.Binding("Tag", global::KafkaClientTool.Properties.Settings.Default, "saslMechanism", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.saslMechanism.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.saslMechanism.FormattingEnabled = true;
            this.saslMechanism.Location = new System.Drawing.Point(200, 64);
            this.saslMechanism.Name = "saslMechanism";
            this.saslMechanism.Size = new System.Drawing.Size(184, 21);
            this.saslMechanism.TabIndex = 11;
            this.saslMechanism.Tag = global::KafkaClientTool.Properties.Settings.Default.saslMechanism;
            this.saslMechanism.SelectedIndexChanged += new System.EventHandler(this.saslMechanism_SelectedIndexChanged);
            // 
            // password
            // 
            this.password.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::KafkaClientTool.Properties.Settings.Default, "password", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.password.Location = new System.Drawing.Point(580, 64);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(208, 20);
            this.password.TabIndex = 8;
            this.password.Text = global::KafkaClientTool.Properties.Settings.Default.password;
            // 
            // username
            // 
            this.username.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::KafkaClientTool.Properties.Settings.Default, "username", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.username.Location = new System.Drawing.Point(390, 64);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(184, 20);
            this.username.TabIndex = 6;
            this.username.Text = global::KafkaClientTool.Properties.Settings.Default.username;
            // 
            // clientGroupId
            // 
            this.clientGroupId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientGroupId.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::KafkaClientTool.Properties.Settings.Default, "clientGroupId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.clientGroupId.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientGroupId.Location = new System.Drawing.Point(3, 26);
            this.clientGroupId.Name = "clientGroupId";
            this.clientGroupId.Size = new System.Drawing.Size(296, 20);
            this.clientGroupId.TabIndex = 4;
            this.clientGroupId.Text = global::KafkaClientTool.Properties.Settings.Default.clientGroupId;
            // 
            // subscribeToTopic
            // 
            this.subscribeToTopic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subscribeToTopic.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::KafkaClientTool.Properties.Settings.Default, "subscribeToTopic", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.subscribeToTopic.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subscribeToTopic.Location = new System.Drawing.Point(3, 65);
            this.subscribeToTopic.Multiline = true;
            this.subscribeToTopic.Name = "subscribeToTopic";
            this.subscribeToTopic.Size = new System.Drawing.Size(296, 40);
            this.subscribeToTopic.TabIndex = 2;
            this.subscribeToTopic.Text = global::KafkaClientTool.Properties.Settings.Default.subscribeToTopic;
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.AppendBinaryChecked = false;
            this.output.DataBindings.Add(new System.Windows.Forms.Binding("TextValue", global::KafkaClientTool.Properties.Settings.Default, "output", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.output.Location = new System.Drawing.Point(4, 112);
            this.output.Margin = new System.Windows.Forms.Padding(4);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(376, 214);
            this.output.TabIndex = 0;
            this.output.TextValue = global::KafkaClientTool.Properties.Settings.Default.output;
            // 
            // produceToTopic
            // 
            this.produceToTopic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.produceToTopic.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::KafkaClientTool.Properties.Settings.Default, "produceToTopic", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.produceToTopic.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produceToTopic.Location = new System.Drawing.Point(6, 26);
            this.produceToTopic.Name = "produceToTopic";
            this.produceToTopic.Size = new System.Drawing.Size(388, 20);
            this.produceToTopic.TabIndex = 2;
            this.produceToTopic.Text = global::KafkaClientTool.Properties.Settings.Default.produceToTopic;
            // 
            // input
            // 
            this.input.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input.BinaryChecked = false;
            this.input.ChangeEndOfLine = true;
            this.input.DataBindings.Add(new System.Windows.Forms.Binding("TextValue", global::KafkaClientTool.Properties.Settings.Default, "input", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.input.EndOfLine = Common.EndOfLine.Dos;
            this.input.Location = new System.Drawing.Point(3, 52);
            this.input.Name = "input";
            this.input.Padding = new System.Windows.Forms.Padding(4);
            this.input.SelectedTextValue = "";
            this.input.Size = new System.Drawing.Size(391, 245);
            this.input.TabIndex = 1;
            this.input.TextValue = global::KafkaClientTool.Properties.Settings.Default.input;
            // 
            // bootstrapServers
            // 
            this.bootstrapServers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bootstrapServers.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::KafkaClientTool.Properties.Settings.Default, "bootstrapServers", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.bootstrapServers.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bootstrapServers.Location = new System.Drawing.Point(9, 25);
            this.bootstrapServers.Name = "bootstrapServers";
            this.bootstrapServers.Size = new System.Drawing.Size(698, 20);
            this.bootstrapServers.TabIndex = 2;
            this.bootstrapServers.Text = global::KafkaClientTool.Properties.Settings.Default.bootstrapServers;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.saslMechanism);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.securityProtocol);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.bootstrapServers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Kafka Client Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
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

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox bootstrapServers;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox subscribeToTopic;
        private System.Windows.Forms.Label label2;
        private Common.OutputTextBox output;
        private System.Windows.Forms.Button subscribe;
        private System.Windows.Forms.TextBox clientGroupId;
        private System.Windows.Forms.Label label3;
        private Common.InputTextBox input;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox produceToTopic;
        private System.Windows.Forms.Button produce;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox securityProtocol;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox saslMechanism;
    }
}

