using System.Windows.Forms;

namespace FirewallTool
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tcpOption = new System.Windows.Forms.RadioButton();
            this.udpOption = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.browse = new System.Windows.Forms.Button();
            this.appPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.TextBox();
            this.removePortAuth = new System.Windows.Forms.Button();
            this.grantPortAuth = new System.Windows.Forms.Button();
            this.removeAppAuth = new System.Windows.Forms.Button();
            this.grantAppAuth = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tcpOption);
            this.groupBox1.Controls.Add(this.udpOption);
            this.groupBox1.Location = new System.Drawing.Point(86, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 36);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Protocol";
            // 
            // tcpOption
            // 
            this.tcpOption.AutoSize = true;
            this.tcpOption.Location = new System.Drawing.Point(74, 16);
            this.tcpOption.Name = "tcpOption";
            this.tcpOption.Size = new System.Drawing.Size(46, 17);
            this.tcpOption.TabIndex = 7;
            this.tcpOption.Text = "TCP";
            this.tcpOption.UseVisualStyleBackColor = true;
            // 
            // udpOption
            // 
            this.udpOption.AutoSize = true;
            this.udpOption.Checked = true;
            this.udpOption.Location = new System.Drawing.Point(9, 16);
            this.udpOption.Name = "udpOption";
            this.udpOption.Size = new System.Drawing.Size(48, 17);
            this.udpOption.TabIndex = 6;
            this.udpOption.TabStop = true;
            this.udpOption.Text = "UDP";
            this.udpOption.UseVisualStyleBackColor = true;
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
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(254, 30);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 1;
            this.browse.Text = "Browse...";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // appPath
            // 
            this.appPath.Location = new System.Drawing.Point(15, 32);
            this.appPath.Name = "appPath";
            this.appPath.Size = new System.Drawing.Size(233, 20);
            this.appPath.TabIndex = 0;
            this.appPath.TextChanged += new System.EventHandler(this.AppPath_TextChanged);
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
            // port
            // 
            this.port.Enabled = false;
            this.port.Location = new System.Drawing.Point(15, 118);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(56, 20);
            this.port.TabIndex = 4;
            this.port.TextChanged += new System.EventHandler(this.Port_TextChanged);
            // 
            // removePortAuth
            // 
            this.removePortAuth.Enabled = false;
            this.removePortAuth.Location = new System.Drawing.Point(178, 154);
            this.removePortAuth.Name = "removePortAuth";
            this.removePortAuth.Size = new System.Drawing.Size(151, 23);
            this.removePortAuth.TabIndex = 9;
            this.removePortAuth.Text = "Remove Port Authorization";
            this.removePortAuth.UseVisualStyleBackColor = true;
            this.removePortAuth.Click += new System.EventHandler(this.RemovePortAuth_Click);
            // 
            // grantPortAuth
            // 
            this.grantPortAuth.Enabled = false;
            this.grantPortAuth.Location = new System.Drawing.Point(15, 154);
            this.grantPortAuth.Name = "grantPortAuth";
            this.grantPortAuth.Size = new System.Drawing.Size(151, 23);
            this.grantPortAuth.TabIndex = 8;
            this.grantPortAuth.Text = "Grant Port Authorization";
            this.grantPortAuth.UseVisualStyleBackColor = true;
            this.grantPortAuth.Click += new System.EventHandler(this.GrantPortAuth_Click);
            // 
            // removeAppAuth
            // 
            this.removeAppAuth.Enabled = false;
            this.removeAppAuth.Location = new System.Drawing.Point(178, 68);
            this.removeAppAuth.Name = "removeAppAuth";
            this.removeAppAuth.Size = new System.Drawing.Size(151, 23);
            this.removeAppAuth.TabIndex = 3;
            this.removeAppAuth.Text = "Remove App Authorization";
            this.removeAppAuth.UseVisualStyleBackColor = true;
            this.removeAppAuth.Click += new System.EventHandler(this.RemoveAppAuth_Click);
            // 
            // grantAppAuth
            // 
            this.grantAppAuth.Enabled = false;
            this.grantAppAuth.Location = new System.Drawing.Point(15, 68);
            this.grantAppAuth.Name = "grantAppAuth";
            this.grantAppAuth.Size = new System.Drawing.Size(151, 23);
            this.grantAppAuth.TabIndex = 2;
            this.grantAppAuth.Text = "Grant App Authorization";
            this.grantAppAuth.UseVisualStyleBackColor = true;
            this.grantAppAuth.Click += new System.EventHandler(this.GrantAppAuth_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Executable|*.exe";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 194);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.removePortAuth);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.grantAppAuth);
            this.Controls.Add(this.appPath);
            this.Controls.Add(this.removeAppAuth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grantPortAuth);
            this.Controls.Add(this.port);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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

        private System.Windows.Forms.Button removePortAuth;
        private System.Windows.Forms.Button grantPortAuth;
        private System.Windows.Forms.Button removeAppAuth;
        private System.Windows.Forms.Button grantAppAuth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox appPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton tcpOption;
        private System.Windows.Forms.RadioButton udpOption;
    }
}

