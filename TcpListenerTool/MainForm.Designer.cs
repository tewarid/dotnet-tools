using System;

namespace TcpListenerTool
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
            this.stopListener = new System.Windows.Forms.Button();
            this.useSSLListener = new System.Windows.Forms.CheckBox();
            this.browseForPfx = new System.Windows.Forms.Button();
            this.pfxPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sourcePort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sourceIPAddress = new Common.InterfaceSelectorComboBox();
            this.listen = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.reuseAddress = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pfxPassphrase = new System.Windows.Forms.TextBox();
            this.requestClientCertificate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // stopListener
            // 
            this.stopListener.Enabled = false;
            this.stopListener.Location = new System.Drawing.Point(307, 171);
            this.stopListener.Name = "stopListener";
            this.stopListener.Size = new System.Drawing.Size(75, 23);
            this.stopListener.TabIndex = 28;
            this.stopListener.Text = "Stop";
            this.stopListener.UseVisualStyleBackColor = true;
            this.stopListener.Click += new System.EventHandler(this.stopListener_Click);
            // 
            // useSSLListener
            // 
            this.useSSLListener.AutoSize = true;
            this.useSSLListener.Location = new System.Drawing.Point(12, 45);
            this.useSSLListener.Name = "useSSLListener";
            this.useSSLListener.Size = new System.Drawing.Size(86, 17);
            this.useSSLListener.TabIndex = 18;
            this.useSSLListener.Text = "Use TLS 1.2";
            this.useSSLListener.UseVisualStyleBackColor = true;
            this.useSSLListener.CheckedChanged += new System.EventHandler(this.useSSLListener_CheckedChanged);
            // 
            // browseForPfx
            // 
            this.browseForPfx.Enabled = false;
            this.browseForPfx.Location = new System.Drawing.Point(307, 79);
            this.browseForPfx.Name = "browseForPfx";
            this.browseForPfx.Size = new System.Drawing.Size(75, 23);
            this.browseForPfx.TabIndex = 20;
            this.browseForPfx.Text = "Browse...";
            this.browseForPfx.UseVisualStyleBackColor = true;
            this.browseForPfx.Click += new System.EventHandler(this.browseForPfx_Click);
            // 
            // pfxPath
            // 
            this.pfxPath.Enabled = false;
            this.pfxPath.Location = new System.Drawing.Point(12, 81);
            this.pfxPath.Name = "pfxPath";
            this.pfxPath.ReadOnly = true;
            this.pfxPath.Size = new System.Drawing.Size(287, 20);
            this.pfxPath.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "PFX file path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Interface";
            // 
            // sourcePort
            // 
            this.sourcePort.Location = new System.Drawing.Point(150, 18);
            this.sourcePort.Name = "sourcePort";
            this.sourcePort.Size = new System.Drawing.Size(82, 20);
            this.sourcePort.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Port";
            // 
            // sourceIPAddress
            // 
            this.sourceIPAddress.IncludeIPAddressAny = true;
            this.sourceIPAddress.Location = new System.Drawing.Point(12, 18);
            this.sourceIPAddress.Name = "sourceIPAddress";
            this.sourceIPAddress.Size = new System.Drawing.Size(132, 21);
            this.sourceIPAddress.TabIndex = 16;
            // 
            // listen
            // 
            this.listen.Location = new System.Drawing.Point(224, 171);
            this.listen.Name = "listen";
            this.listen.Size = new System.Drawing.Size(75, 23);
            this.listen.TabIndex = 26;
            this.listen.Text = "Listen";
            this.listen.UseVisualStyleBackColor = true;
            this.listen.Click += new System.EventHandler(this.listen_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "pfx";
            this.openFileDialog.Filter = "PFX files|*.pfx";
            this.openFileDialog.Title = "Pick PFX file";
            // 
            // reuseAddress
            // 
            this.reuseAddress.AutoSize = true;
            this.reuseAddress.Location = new System.Drawing.Point(238, 21);
            this.reuseAddress.Name = "reuseAddress";
            this.reuseAddress.Size = new System.Drawing.Size(98, 17);
            this.reuseAddress.TabIndex = 26;
            this.reuseAddress.Text = "Reuse Address";
            this.reuseAddress.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "PFX passphrase";
            // 
            // pfxPassphrase
            // 
            this.pfxPassphrase.Enabled = false;
            this.pfxPassphrase.Location = new System.Drawing.Point(12, 120);
            this.pfxPassphrase.Name = "pfxPassphrase";
            this.pfxPassphrase.PasswordChar = '*';
            this.pfxPassphrase.Size = new System.Drawing.Size(115, 20);
            this.pfxPassphrase.TabIndex = 22;
            this.pfxPassphrase.Text = "abcd";
            // 
            // requestClientCertificate
            // 
            this.requestClientCertificate.AutoSize = true;
            this.requestClientCertificate.Location = new System.Drawing.Point(13, 147);
            this.requestClientCertificate.Name = "requestClientCertificate";
            this.requestClientCertificate.Size = new System.Drawing.Size(145, 17);
            this.requestClientCertificate.TabIndex = 224;
            this.requestClientCertificate.Text = "Request Client Certificate";
            this.requestClientCertificate.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 206);
            this.Controls.Add(this.requestClientCertificate);
            this.Controls.Add(this.pfxPassphrase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reuseAddress);
            this.Controls.Add(this.stopListener);
            this.Controls.Add(this.useSSLListener);
            this.Controls.Add(this.browseForPfx);
            this.Controls.Add(this.pfxPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sourcePort);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sourceIPAddress);
            this.Controls.Add(this.listen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP Listener Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button stopListener;
        private System.Windows.Forms.CheckBox useSSLListener;
        private System.Windows.Forms.Button browseForPfx;
        private System.Windows.Forms.TextBox pfxPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sourcePort;
        private System.Windows.Forms.Label label5;
        private Common.InterfaceSelectorComboBox sourceIPAddress;
        private System.Windows.Forms.Button listen;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox reuseAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pfxPassphrase;
        private System.Windows.Forms.CheckBox requestClientCertificate;
    }
}

