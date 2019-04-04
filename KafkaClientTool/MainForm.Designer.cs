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
            this.clientGroupId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.subscribeToTopic = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.output = new Common.OutputTextBox();
            this.produce = new System.Windows.Forms.Button();
            this.produceToTopic = new System.Windows.Forms.TextBox();
            this.input = new Common.InputTextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.label1.Location = new System.Drawing.Point(13, 13);
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
            this.splitContainer1.Location = new System.Drawing.Point(12, 56);
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
            this.splitContainer1.Size = new System.Drawing.Size(776, 369);
            this.splitContainer1.SplitterDistance = 379;
            this.splitContainer1.TabIndex = 3;
            // 
            // subscribe
            // 
            this.subscribe.Location = new System.Drawing.Point(256, 63);
            this.subscribe.Name = "subscribe";
            this.subscribe.Size = new System.Drawing.Size(75, 23);
            this.subscribe.TabIndex = 5;
            this.subscribe.Text = "Subscribe";
            this.subscribe.UseVisualStyleBackColor = true;
            this.subscribe.Click += new System.EventHandler(this.Subscribe_Click);
            // 
            // clientGroupId
            // 
            this.clientGroupId.Location = new System.Drawing.Point(10, 26);
            this.clientGroupId.Name = "clientGroupId";
            this.clientGroupId.Size = new System.Drawing.Size(240, 20);
            this.clientGroupId.TabIndex = 4;
            this.clientGroupId.Text = "test-group";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Client Group ID";
            // 
            // subscribeToTopic
            // 
            this.subscribeToTopic.Location = new System.Drawing.Point(10, 65);
            this.subscribeToTopic.Name = "subscribeToTopic";
            this.subscribeToTopic.Size = new System.Drawing.Size(240, 20);
            this.subscribeToTopic.TabIndex = 2;
            this.subscribeToTopic.Text = "test";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subscription topic or regex";
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.AppendBinaryChecked = false;
            this.output.Location = new System.Drawing.Point(4, 99);
            this.output.Margin = new System.Windows.Forms.Padding(4);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(371, 266);
            this.output.TabIndex = 0;
            this.output.TextValue = "";
            // 
            // produce
            // 
            this.produce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.produce.Location = new System.Drawing.Point(315, 343);
            this.produce.Name = "produce";
            this.produce.Size = new System.Drawing.Size(75, 23);
            this.produce.TabIndex = 3;
            this.produce.Text = "Produce";
            this.produce.UseVisualStyleBackColor = true;
            this.produce.Click += new System.EventHandler(this.Produce_Click);
            // 
            // produceToTopic
            // 
            this.produceToTopic.Location = new System.Drawing.Point(6, 26);
            this.produceToTopic.Name = "produceToTopic";
            this.produceToTopic.Size = new System.Drawing.Size(240, 20);
            this.produceToTopic.TabIndex = 2;
            this.produceToTopic.Text = "test";
            // 
            // input
            // 
            this.input.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input.BinaryChecked = false;
            this.input.ChangeEndOfLine = true;
            this.input.EndOfLine = Common.EndOfLine.Dos;
            this.input.Location = new System.Drawing.Point(3, 52);
            this.input.Name = "input";
            this.input.Padding = new System.Windows.Forms.Padding(4);
            this.input.SelectedTextValue = "";
            this.input.Size = new System.Drawing.Size(384, 293);
            this.input.TabIndex = 1;
            this.input.TextValue = "";
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
            // bootstrapServers
            // 
            this.bootstrapServers.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::KafkaClientTool.Properties.Settings.Default, "bootstrapServers", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.bootstrapServers.Location = new System.Drawing.Point(16, 30);
            this.bootstrapServers.Name = "bootstrapServers";
            this.bootstrapServers.Size = new System.Drawing.Size(232, 20);
            this.bootstrapServers.TabIndex = 2;
            this.bootstrapServers.Text = global::KafkaClientTool.Properties.Settings.Default.bootstrapServers;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.bootstrapServers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Kafka Client Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
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
    }
}

