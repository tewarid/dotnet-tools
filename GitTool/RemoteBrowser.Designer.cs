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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.query = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.https = new System.Windows.Forms.RadioButton();
            this.ssh = new System.Windows.Forms.RadioButton();
            this.password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.host = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gitLab = new System.Windows.Forms.RadioButton();
            this.gitHub = new System.Windows.Forms.RadioButton();
            this.clipboard = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.repositories = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.query);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.password);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.username);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.host);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.clipboard);
            this.splitContainer1.Panel2.Controls.Add(this.cancel);
            this.splitContainer1.Panel2.Controls.Add(this.ok);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.repositories);
            this.splitContainer1.Size = new System.Drawing.Size(567, 282);
            this.splitContainer1.SplitterDistance = 194;
            this.splitContainer1.TabIndex = 13;
            // 
            // query
            // 
            this.query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.query.Location = new System.Drawing.Point(111, 242);
            this.query.Name = "query";
            this.query.Size = new System.Drawing.Size(75, 23);
            this.query.TabIndex = 18;
            this.query.Text = "Query";
            this.query.UseVisualStyleBackColor = true;
            this.query.Click += new System.EventHandler(this.query_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.https);
            this.groupBox2.Controls.Add(this.ssh);
            this.groupBox2.Location = new System.Drawing.Point(4, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 47);
            this.groupBox2.TabIndex = 12;
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
            // password
            // 
            this.password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.password.Location = new System.Drawing.Point(5, 163);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(181, 20);
            this.password.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Password or access token";
            // 
            // username
            // 
            this.username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.username.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GitTool.Properties.Settings.Default, "username", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.username.Location = new System.Drawing.Point(5, 119);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(181, 20);
            this.username.TabIndex = 15;
            this.username.Text = global::GitTool.Properties.Settings.Default.username;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Username";
            // 
            // host
            // 
            this.host.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.host.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GitTool.Properties.Settings.Default, "gitHost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.host.Location = new System.Drawing.Point(5, 75);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(181, 20);
            this.host.TabIndex = 13;
            this.host.Text = global::GitTool.Properties.Settings.Default.gitHost;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Host";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gitLab);
            this.groupBox1.Controls.Add(this.gitHub);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 47);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Git Hosting Provider";
            // 
            // gitLab
            // 
            this.gitLab.AutoSize = true;
            this.gitLab.Checked = global::GitTool.Properties.Settings.Default.gitlab;
            this.gitLab.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::GitTool.Properties.Settings.Default, "gitlab", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gitLab.Location = new System.Drawing.Point(98, 20);
            this.gitLab.Name = "gitLab";
            this.gitLab.Size = new System.Drawing.Size(56, 17);
            this.gitLab.TabIndex = 1;
            this.gitLab.Text = "GitLab";
            this.gitLab.UseVisualStyleBackColor = true;
            // 
            // gitHub
            // 
            this.gitHub.AutoSize = true;
            this.gitHub.Checked = global::GitTool.Properties.Settings.Default.github;
            this.gitHub.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::GitTool.Properties.Settings.Default, "github", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gitHub.Location = new System.Drawing.Point(7, 20);
            this.gitHub.Name = "gitHub";
            this.gitHub.Size = new System.Drawing.Size(58, 17);
            this.gitHub.TabIndex = 0;
            this.gitHub.Text = "GitHub";
            this.gitHub.UseVisualStyleBackColor = true;
            // 
            // clipboard
            // 
            this.clipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clipboard.Location = new System.Drawing.Point(3, 249);
            this.clipboard.Name = "clipboard";
            this.clipboard.Size = new System.Drawing.Size(125, 23);
            this.clipboard.TabIndex = 17;
            this.clipboard.Text = "Copy to Clipboard";
            this.clipboard.UseVisualStyleBackColor = true;
            this.clipboard.Click += new System.EventHandler(this.clipboard_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(282, 249);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 16;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.Location = new System.Drawing.Point(201, 249);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 15;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Select repositories";
            // 
            // repositories
            // 
            this.repositories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.repositories.FormattingEnabled = true;
            this.repositories.IntegralHeight = false;
            this.repositories.Location = new System.Drawing.Point(1, 24);
            this.repositories.Name = "repositories";
            this.repositories.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.repositories.Size = new System.Drawing.Size(356, 217);
            this.repositories.Sorted = true;
            this.repositories.TabIndex = 13;
            // 
            // RemoteBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(567, 282);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "RemoteBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Browse Remote Repositories";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RemoteBrowser_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private Button query;
        private GroupBox groupBox2;
        private RadioButton https;
        private RadioButton ssh;
        private TextBox password;
        private Label label3;
        private TextBox username;
        private Label label2;
        private TextBox host;
        private Label label1;
        private GroupBox groupBox1;
        private RadioButton gitLab;
        private RadioButton gitHub;
        private Button clipboard;
        private Button cancel;
        private Button ok;
        private Label label4;
        private ListBox repositories;
    }
}