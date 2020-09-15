using System.Windows.Forms;

namespace ServiceBrowserTool
{
    partial class MainForm : Form
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
            this.domainText = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.serviceType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.networkProtocol = new System.Windows.Forms.ComboBox();
            this.startWatcher = new System.Windows.Forms.Button();
            this.stopWatcher = new System.Windows.Forms.Button();
            this.output = new Common.OutputTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Domain";
            // 
            // domainText
            // 
            this.domainText.Items.AddRange(new object[] {
            "local",
            "apple.com"});
            this.domainText.Location = new System.Drawing.Point(12, 28);
            this.domainText.Margin = new System.Windows.Forms.Padding(2);
            this.domainText.Name = "domainText";
            this.domainText.Size = new System.Drawing.Size(118, 21);
            this.domainText.TabIndex = 1;
            this.domainText.Text = "local";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "DNS-SD Service Type";
            // 
            // serviceType
            // 
            this.serviceType.Items.AddRange(new object[] {
            "_airplay",
            "_daap",
            "_googlecast",
            "_homekit",
            "_mediaremotetv",
            "_raop"});
            this.serviceType.Location = new System.Drawing.Point(12, 66);
            this.serviceType.Margin = new System.Windows.Forms.Padding(2);
            this.serviceType.Name = "serviceType";
            this.serviceType.Size = new System.Drawing.Size(118, 21);
            this.serviceType.TabIndex = 3;
            this.serviceType.Text = "_googlecast";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Network Protocol";
            // 
            // networkProtocol
            // 
            this.networkProtocol.Items.AddRange(new object[] {
            "_tcp"});
            this.networkProtocol.Location = new System.Drawing.Point(12, 104);
            this.networkProtocol.Margin = new System.Windows.Forms.Padding(2);
            this.networkProtocol.Name = "networkProtocol";
            this.networkProtocol.Size = new System.Drawing.Size(118, 21);
            this.networkProtocol.TabIndex = 5;
            this.networkProtocol.Text = "_tcp";
            // 
            // startWatcher
            // 
            this.startWatcher.Location = new System.Drawing.Point(12, 136);
            this.startWatcher.Margin = new System.Windows.Forms.Padding(2);
            this.startWatcher.Name = "startWatcher";
            this.startWatcher.Size = new System.Drawing.Size(56, 23);
            this.startWatcher.TabIndex = 6;
            this.startWatcher.Text = "Start";
            this.startWatcher.UseVisualStyleBackColor = true;
            this.startWatcher.Click += new System.EventHandler(this.StartWatcher_Click);
            // 
            // stopWatcher
            // 
            this.stopWatcher.Enabled = false;
            this.stopWatcher.Location = new System.Drawing.Point(73, 136);
            this.stopWatcher.Margin = new System.Windows.Forms.Padding(2);
            this.stopWatcher.Name = "stopWatcher";
            this.stopWatcher.Size = new System.Drawing.Size(56, 23);
            this.stopWatcher.TabIndex = 7;
            this.stopWatcher.Text = "Stop";
            this.stopWatcher.UseVisualStyleBackColor = true;
            this.stopWatcher.Click += new System.EventHandler(this.StopWatcher_Click);
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.AppendBinaryChecked = false;
            this.output.Location = new System.Drawing.Point(148, 11);
            this.output.Margin = new System.Windows.Forms.Padding(2);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(442, 345);
            this.output.TabIndex = 8;
            this.output.TextValue = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 171);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 96);
            this.label4.TabIndex = 9;
            this.label4.Text = "Use Wireshark to view mDNS/DNS-SD queries sent to devices and their reponses. Use" +
    " protocol filter mdns.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.output);
            this.Controls.Add(this.stopWatcher);
            this.Controls.Add(this.startWatcher);
            this.Controls.Add(this.networkProtocol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.serviceType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.domainText);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Service Discovery Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox domainText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox serviceType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox networkProtocol;
        private System.Windows.Forms.Button startWatcher;
        private System.Windows.Forms.Button stopWatcher;
        private Common.OutputTextBox output;
        private System.Windows.Forms.Label label4;
    }
}

