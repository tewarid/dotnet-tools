using System.Windows.Forms;

namespace GitTool
{
    public partial class RemoteBrowser : Form
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
            this.gitLab = new System.Windows.Forms.RadioButton();
            this.gitHub = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.host = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.https = new System.Windows.Forms.RadioButton();
            this.ssh = new System.Windows.Forms.RadioButton();
            this.repositories = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.query = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.clipboard = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gitLab);
            this.groupBox1.Controls.Add(this.gitHub);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Git Hosting Provider";
            // 
            // gitLab
            // 
            this.gitLab.AutoSize = true;
            this.gitLab.Location = new System.Drawing.Point(98, 20);
            this.gitLab.Name = "gitLab";
            this.gitLab.Size = new System.Drawing.Size(56, 17);
            this.gitLab.TabIndex = 1;
            this.gitLab.Text = "GitLab";
            this.gitLab.UseVisualStyleBackColor = true;
            this.gitLab.CheckedChanged += new System.EventHandler(this.gitLab_CheckedChanged);
            // 
            // gitHub
            // 
            this.gitHub.AutoSize = true;
            this.gitHub.Checked = true;
            this.gitHub.Location = new System.Drawing.Point(7, 20);
            this.gitHub.Name = "gitHub";
            this.gitHub.Size = new System.Drawing.Size(58, 17);
            this.gitHub.TabIndex = 0;
            this.gitHub.TabStop = true;
            this.gitHub.Text = "GitHub";
            this.gitHub.UseVisualStyleBackColor = true;
            this.gitHub.CheckedChanged += new System.EventHandler(this.gitHub_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Host";
            // 
            // host
            // 
            this.host.Location = new System.Drawing.Point(13, 84);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(171, 20);
            this.host.TabIndex = 2;
            this.host.Text = "https://github.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(13, 128);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(171, 20);
            this.username.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password or access token";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(13, 172);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(171, 20);
            this.password.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.https);
            this.groupBox2.Controls.Add(this.ssh);
            this.groupBox2.Location = new System.Drawing.Point(12, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 47);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Access Git using";
            // 
            // https
            // 
            this.https.AutoSize = true;
            this.https.Location = new System.Drawing.Point(98, 20);
            this.https.Name = "https";
            this.https.Size = new System.Drawing.Size(61, 17);
            this.https.TabIndex = 1;
            this.https.Text = "HTTPS";
            this.https.UseVisualStyleBackColor = true;
            // 
            // ssh
            // 
            this.ssh.AutoSize = true;
            this.ssh.Checked = true;
            this.ssh.Location = new System.Drawing.Point(7, 20);
            this.ssh.Name = "ssh";
            this.ssh.Size = new System.Drawing.Size(47, 17);
            this.ssh.TabIndex = 0;
            this.ssh.TabStop = true;
            this.ssh.Text = "SSH";
            this.ssh.UseVisualStyleBackColor = true;
            // 
            // repositories
            // 
            this.repositories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.repositories.FormattingEnabled = true;
            this.repositories.Location = new System.Drawing.Point(190, 30);
            this.repositories.Name = "repositories";
            this.repositories.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.repositories.Size = new System.Drawing.Size(325, 212);
            this.repositories.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Select repositories";
            // 
            // query
            // 
            this.query.Location = new System.Drawing.Point(107, 252);
            this.query.Name = "query";
            this.query.Size = new System.Drawing.Size(75, 23);
            this.query.TabIndex = 9;
            this.query.Text = "Query";
            this.query.UseVisualStyleBackColor = true;
            this.query.Click += new System.EventHandler(this.query_Click);
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.Location = new System.Drawing.Point(359, 251);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 10;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(440, 251);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 11;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // clipboard
            // 
            this.clipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clipboard.Location = new System.Drawing.Point(190, 251);
            this.clipboard.Name = "clipboard";
            this.clipboard.Size = new System.Drawing.Size(125, 23);
            this.clipboard.TabIndex = 12;
            this.clipboard.Text = "Copy to Clipboard";
            this.clipboard.UseVisualStyleBackColor = true;
            this.clipboard.Click += new System.EventHandler(this.clipboard_Click);
            // 
            // RemoteBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(527, 282);
            this.Controls.Add(this.clipboard);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.query);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.repositories);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.host);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "RemoteBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Browse Remote Repositories";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton gitLab;
        private System.Windows.Forms.RadioButton gitHub;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox host;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton https;
        private System.Windows.Forms.RadioButton ssh;
        private System.Windows.Forms.ListBox repositories;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button query;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button clipboard;
    }
}