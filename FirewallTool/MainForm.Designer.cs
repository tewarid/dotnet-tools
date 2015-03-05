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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTCP = new System.Windows.Forms.RadioButton();
            this.rbUDP = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.txtAppPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnRemovePortAuth = new System.Windows.Forms.Button();
            this.btnGrantPortAuth = new System.Windows.Forms.Button();
            this.btnRemoveAppAuth = new System.Windows.Forms.Button();
            this.btnGrantAppAuth = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTCP);
            this.groupBox1.Controls.Add(this.rbUDP);
            this.groupBox1.Location = new System.Drawing.Point(86, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 36);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Protocol";
            // 
            // rbTCP
            // 
            this.rbTCP.AutoSize = true;
            this.rbTCP.Location = new System.Drawing.Point(74, 16);
            this.rbTCP.Name = "rbTCP";
            this.rbTCP.Size = new System.Drawing.Size(46, 17);
            this.rbTCP.TabIndex = 7;
            this.rbTCP.Text = "TCP";
            this.rbTCP.UseVisualStyleBackColor = true;
            // 
            // rbUDP
            // 
            this.rbUDP.AutoSize = true;
            this.rbUDP.Checked = true;
            this.rbUDP.Location = new System.Drawing.Point(9, 16);
            this.rbUDP.Name = "rbUDP";
            this.rbUDP.Size = new System.Drawing.Size(48, 17);
            this.rbUDP.TabIndex = 6;
            this.rbUDP.TabStop = true;
            this.rbUDP.Text = "UDP";
            this.rbUDP.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Application";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(254, 30);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnBrowser.TabIndex = 1;
            this.btnBrowser.Text = "Browse...";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // txtAppPath
            // 
            this.txtAppPath.Location = new System.Drawing.Point(15, 32);
            this.txtAppPath.Name = "txtAppPath";
            this.txtAppPath.Size = new System.Drawing.Size(233, 20);
            this.txtAppPath.TabIndex = 0;
            this.txtAppPath.TextChanged += new System.EventHandler(this.txtAppPath_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.Enabled = false;
            this.txtPort.Location = new System.Drawing.Point(15, 118);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(56, 20);
            this.txtPort.TabIndex = 4;
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // btnRemovePortAuth
            // 
            this.btnRemovePortAuth.Enabled = false;
            this.btnRemovePortAuth.Location = new System.Drawing.Point(178, 154);
            this.btnRemovePortAuth.Name = "btnRemovePortAuth";
            this.btnRemovePortAuth.Size = new System.Drawing.Size(151, 23);
            this.btnRemovePortAuth.TabIndex = 9;
            this.btnRemovePortAuth.Text = "Remove Port Authorization";
            this.btnRemovePortAuth.UseVisualStyleBackColor = true;
            this.btnRemovePortAuth.Click += new System.EventHandler(this.btnRemovePortAuth_Click);
            // 
            // btnGrantPortAuth
            // 
            this.btnGrantPortAuth.Enabled = false;
            this.btnGrantPortAuth.Location = new System.Drawing.Point(15, 154);
            this.btnGrantPortAuth.Name = "btnGrantPortAuth";
            this.btnGrantPortAuth.Size = new System.Drawing.Size(151, 23);
            this.btnGrantPortAuth.TabIndex = 8;
            this.btnGrantPortAuth.Text = "Grant Port Authorization";
            this.btnGrantPortAuth.UseVisualStyleBackColor = true;
            this.btnGrantPortAuth.Click += new System.EventHandler(this.btnGrantPortAuth_Click);
            // 
            // btnRemoveAppAuth
            // 
            this.btnRemoveAppAuth.Enabled = false;
            this.btnRemoveAppAuth.Location = new System.Drawing.Point(178, 68);
            this.btnRemoveAppAuth.Name = "btnRemoveAppAuth";
            this.btnRemoveAppAuth.Size = new System.Drawing.Size(151, 23);
            this.btnRemoveAppAuth.TabIndex = 3;
            this.btnRemoveAppAuth.Text = "Remove App Authorization";
            this.btnRemoveAppAuth.UseVisualStyleBackColor = true;
            this.btnRemoveAppAuth.Click += new System.EventHandler(this.btnRemoveAppAuth_Click);
            // 
            // btnGrantAppAuth
            // 
            this.btnGrantAppAuth.Enabled = false;
            this.btnGrantAppAuth.Location = new System.Drawing.Point(15, 68);
            this.btnGrantAppAuth.Name = "btnGrantAppAuth";
            this.btnGrantAppAuth.Size = new System.Drawing.Size(151, 23);
            this.btnGrantAppAuth.TabIndex = 2;
            this.btnGrantAppAuth.Text = "Grant App Authorization";
            this.btnGrantAppAuth.UseVisualStyleBackColor = true;
            this.btnGrantAppAuth.Click += new System.EventHandler(this.btnGrantAppAuth_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Executable|*.exe";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 194);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemovePortAuth);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.btnGrantAppAuth);
            this.Controls.Add(this.txtAppPath);
            this.Controls.Add(this.btnRemoveAppAuth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGrantPortAuth);
            this.Controls.Add(this.txtPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Firewall Tool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemovePortAuth;
        private System.Windows.Forms.Button btnGrantPortAuth;
        private System.Windows.Forms.Button btnRemoveAppAuth;
        private System.Windows.Forms.Button btnGrantAppAuth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TextBox txtAppPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTCP;
        private System.Windows.Forms.RadioButton rbUDP;
    }
}

