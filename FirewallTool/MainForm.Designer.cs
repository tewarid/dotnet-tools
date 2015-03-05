namespace FirewallTool
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.txtAppPath = new System.Windows.Forms.TextBox();
            this.rbTCP = new System.Windows.Forms.RadioButton();
            this.rbUDP = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnRemovePortAuth = new System.Windows.Forms.Button();
            this.btnGrantPortAuth = new System.Windows.Forms.Button();
            this.btnRemoveAppAuth = new System.Windows.Forms.Button();
            this.btnGrantAppAuth = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnBrowser);
            this.groupBox2.Controls.Add(this.txtAppPath);
            this.groupBox2.Controls.Add(this.rbTCP);
            this.groupBox2.Controls.Add(this.rbUDP);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtPort);
            this.groupBox2.Controls.Add(this.btnRemovePortAuth);
            this.groupBox2.Controls.Add(this.btnGrantPortAuth);
            this.groupBox2.Controls.Add(this.btnRemoveAppAuth);
            this.groupBox2.Controls.Add(this.btnGrantAppAuth);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 212);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Firewall Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Select application";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(333, 44);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnBrowser.TabIndex = 14;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // txtAppPath
            // 
            this.txtAppPath.Location = new System.Drawing.Point(12, 45);
            this.txtAppPath.Name = "txtAppPath";
            this.txtAppPath.Size = new System.Drawing.Size(314, 20);
            this.txtAppPath.TabIndex = 13;
            this.txtAppPath.TextChanged += new System.EventHandler(this.txtAppPath_TextChanged);
            // 
            // rbTCP
            // 
            this.rbTCP.AutoSize = true;
            this.rbTCP.Location = new System.Drawing.Point(189, 131);
            this.rbTCP.Name = "rbTCP";
            this.rbTCP.Size = new System.Drawing.Size(46, 17);
            this.rbTCP.TabIndex = 12;
            this.rbTCP.Text = "TCP";
            this.rbTCP.UseVisualStyleBackColor = true;
            // 
            // rbUDP
            // 
            this.rbUDP.AutoSize = true;
            this.rbUDP.Checked = true;
            this.rbUDP.Location = new System.Drawing.Point(135, 131);
            this.rbUDP.Name = "rbUDP";
            this.rbUDP.Size = new System.Drawing.Size(48, 17);
            this.rbUDP.TabIndex = 11;
            this.rbUDP.TabStop = true;
            this.rbUDP.Text = "UDP";
            this.rbUDP.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.Enabled = false;
            this.txtPort.Location = new System.Drawing.Point(45, 129);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(75, 20);
            this.txtPort.TabIndex = 9;
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // btnRemovePortAuth
            // 
            this.btnRemovePortAuth.Enabled = false;
            this.btnRemovePortAuth.Location = new System.Drawing.Point(175, 167);
            this.btnRemovePortAuth.Name = "btnRemovePortAuth";
            this.btnRemovePortAuth.Size = new System.Drawing.Size(151, 23);
            this.btnRemovePortAuth.TabIndex = 3;
            this.btnRemovePortAuth.Text = "Remove Port Authorization";
            this.btnRemovePortAuth.UseVisualStyleBackColor = true;
            this.btnRemovePortAuth.Click += new System.EventHandler(this.btnRemovePortAuth_Click);
            // 
            // btnGrantPortAuth
            // 
            this.btnGrantPortAuth.Enabled = false;
            this.btnGrantPortAuth.Location = new System.Drawing.Point(12, 167);
            this.btnGrantPortAuth.Name = "btnGrantPortAuth";
            this.btnGrantPortAuth.Size = new System.Drawing.Size(151, 23);
            this.btnGrantPortAuth.TabIndex = 2;
            this.btnGrantPortAuth.Text = "Grant Port Authorization";
            this.btnGrantPortAuth.UseVisualStyleBackColor = true;
            this.btnGrantPortAuth.Click += new System.EventHandler(this.btnGrantPortAuth_Click);
            // 
            // btnRemoveAppAuth
            // 
            this.btnRemoveAppAuth.Enabled = false;
            this.btnRemoveAppAuth.Location = new System.Drawing.Point(175, 81);
            this.btnRemoveAppAuth.Name = "btnRemoveAppAuth";
            this.btnRemoveAppAuth.Size = new System.Drawing.Size(151, 23);
            this.btnRemoveAppAuth.TabIndex = 1;
            this.btnRemoveAppAuth.Text = "Remove App Authorization";
            this.btnRemoveAppAuth.UseVisualStyleBackColor = true;
            this.btnRemoveAppAuth.Click += new System.EventHandler(this.btnRemoveAppAuth_Click);
            // 
            // btnGrantAppAuth
            // 
            this.btnGrantAppAuth.Enabled = false;
            this.btnGrantAppAuth.Location = new System.Drawing.Point(12, 81);
            this.btnGrantAppAuth.Name = "btnGrantAppAuth";
            this.btnGrantAppAuth.Size = new System.Drawing.Size(151, 23);
            this.btnGrantAppAuth.TabIndex = 0;
            this.btnGrantAppAuth.Text = "Grant App Authorization";
            this.btnGrantAppAuth.UseVisualStyleBackColor = true;
            this.btnGrantAppAuth.Click += new System.EventHandler(this.btnGrantAppAuth_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 248);
            this.Controls.Add(this.groupBox2);
            this.Name = "MainForm";
            this.Text = "Firewall Tool";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemovePortAuth;
        private System.Windows.Forms.Button btnGrantPortAuth;
        private System.Windows.Forms.Button btnRemoveAppAuth;
        private System.Windows.Forms.Button btnGrantAppAuth;
        private System.Windows.Forms.RadioButton rbTCP;
        private System.Windows.Forms.RadioButton rbUDP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TextBox txtAppPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

