using System.Windows.Forms;

namespace WebSocketServerTool
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
            this.start = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.subjectName = new System.Windows.Forms.TextBox();
            this.url = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.stop = new System.Windows.Forms.Button();
            this.useWcf = new System.Windows.Forms.CheckBox();
            this.certificateAuth = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(416, 446);
            this.start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(100, 23);
            this.start.TabIndex = 9;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(489, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "For wss:// scheme, create and initialize service\'s X509 certificate as follows..." +
    "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 36);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(607, 221);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 278);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Subject Name in X509 Certificate";
            // 
            // subjectName
            // 
            this.subjectName.Location = new System.Drawing.Point(16, 299);
            this.subjectName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.subjectName.Name = "subjectName";
            this.subjectName.Size = new System.Drawing.Size(608, 22);
            this.subjectName.TabIndex = 5;
            this.subjectName.Text = "mycompany.com";
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(16, 348);
            this.url.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(608, 22);
            this.url.TabIndex = 7;
            this.url.Text = "wss://localhost:8088";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 327);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Service URL";
            // 
            // stop
            // 
            this.stop.Enabled = false;
            this.stop.Location = new System.Drawing.Point(524, 446);
            this.stop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(100, 23);
            this.stop.TabIndex = 10;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // useWcf
            // 
            this.useWcf.AutoSize = true;
            this.useWcf.Location = new System.Drawing.Point(20, 382);
            this.useWcf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.useWcf.Name = "useWcf";
            this.useWcf.Size = new System.Drawing.Size(449, 21);
            this.useWcf.TabIndex = 8;
            this.useWcf.Text = "Use self-hosted WCF service (defaults to System.Net.HttpListener)";
            this.useWcf.UseVisualStyleBackColor = true;
            // 
            // certificateAuth
            // 
            this.certificateAuth.AutoSize = true;
            this.certificateAuth.Location = new System.Drawing.Point(20, 410);
            this.certificateAuth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.certificateAuth.Name = "certificateAuth";
            this.certificateAuth.Size = new System.Drawing.Size(189, 21);
            this.certificateAuth.TabIndex = 9;
            this.certificateAuth.Text = "Request Client Certificate";
            this.certificateAuth.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AcceptButton = this.start;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 482);
            this.Controls.Add(this.certificateAuth);
            this.Controls.Add(this.useWcf);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.url);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.subjectName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "WebSocket Server Tool (Requires Windows 8 or better)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox subjectName;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.CheckBox useWcf;
        private System.Windows.Forms.CheckBox certificateAuth;
    }
}

