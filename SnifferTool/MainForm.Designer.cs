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
            this.output = new Common.OutputTextBox();
            this.bind = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.protocolType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // interfaceSelector
            // 
            this.interfaceSelector.Location = new System.Drawing.Point(15, 31);
            this.interfaceSelector.Name = "interfaceSelector";
            this.interfaceSelector.Size = new System.Drawing.Size(121, 21);
            this.interfaceSelector.TabIndex = 0;
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.Location = new System.Drawing.Point(12, 58);
            this.output.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.output.MinimumSize = new System.Drawing.Size(355, 95);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(560, 291);
            this.output.TabIndex = 1;
            // 
            // bind
            // 
            this.bind.Location = new System.Drawing.Point(273, 29);
            this.bind.Name = "bind";
            this.bind.Size = new System.Drawing.Size(75, 23);
            this.bind.TabIndex = 2;
            this.bind.Text = "Bind";
            this.bind.UseVisualStyleBackColor = true;
            this.bind.Click += new System.EventHandler(this.Bind_Click);
            // 
            // close
            // 
            this.close.Enabled = false;
            this.close.Location = new System.Drawing.Point(354, 29);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 3;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Network Interface";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Protocol Type";
            // 
            // protocolType
            // 
            this.protocolType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.protocolType.FormattingEnabled = true;
            this.protocolType.Location = new System.Drawing.Point(146, 31);
            this.protocolType.Name = "protocolType";
            this.protocolType.Size = new System.Drawing.Size(121, 21);
            this.protocolType.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.protocolType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.bind);
            this.Controls.Add(this.output);
            this.Controls.Add(this.interfaceSelector);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sniffer Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.InterfaceSelectorComboBox interfaceSelector;
        private Common.OutputTextBox output;
        private System.Windows.Forms.Button bind;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox protocolType;
    }
}

