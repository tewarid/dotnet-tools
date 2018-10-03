namespace SnifferTool
{
    public partial class MainForm
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
            this.interfaceSelector = new Common.InterfaceSelectorComboBox();
            this.output = new Common.ReceiveTextBox();
            this.bind = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.protocolType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // interfaceSelector
            // 
            this.interfaceSelector.IncludeIPAddressAny = false;
            this.interfaceSelector.Location = new System.Drawing.Point(20, 38);
            this.interfaceSelector.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.interfaceSelector.Name = "interfaceSelector";
            this.interfaceSelector.Size = new System.Drawing.Size(161, 26);
            this.interfaceSelector.TabIndex = 0;
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.Location = new System.Drawing.Point(16, 71);
            this.output.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.output.MinimumSize = new System.Drawing.Size(473, 117);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(747, 358);
            this.output.TabIndex = 1;
            // 
            // bind
            // 
            this.bind.Location = new System.Drawing.Point(368, 41);
            this.bind.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bind.Name = "bind";
            this.bind.Size = new System.Drawing.Size(100, 23);
            this.bind.TabIndex = 2;
            this.bind.Text = "Bind";
            this.bind.UseVisualStyleBackColor = true;
            this.bind.Click += new System.EventHandler(this.Bind_Click);
            // 
            // close
            // 
            this.close.Enabled = false;
            this.close.Location = new System.Drawing.Point(476, 41);
            this.close.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(100, 23);
            this.close.TabIndex = 3;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Network Interface";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Protocol Type";
            // 
            // protocolType
            // 
            this.protocolType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.protocolType.FormattingEnabled = true;
            this.protocolType.Location = new System.Drawing.Point(195, 38);
            this.protocolType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.protocolType.Name = "protocolType";
            this.protocolType.Size = new System.Drawing.Size(160, 24);
            this.protocolType.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 444);
            this.Controls.Add(this.protocolType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.bind);
            this.Controls.Add(this.output);
            this.Controls.Add(this.interfaceSelector);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sniffer Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.InterfaceSelectorComboBox interfaceSelector;
        private Common.ReceiveTextBox output;
        private System.Windows.Forms.Button bind;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox protocolType;
    }
}

