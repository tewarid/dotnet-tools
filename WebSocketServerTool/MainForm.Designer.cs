namespace WebSocketServerTool
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
            this.start = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.subjectName = new System.Windows.Forms.TextBox();
            this.url = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.stop = new System.Windows.Forms.Button();
            this.useWcf = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(313, 332);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 9;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(371, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "For wss:// scheme, create and initialize service\'s X509 certificate as follows..." +
    "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 29);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(456, 180);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Subject Name in X509 Certificate";
            // 
            // subjectName
            // 
            this.subjectName.Location = new System.Drawing.Point(12, 243);
            this.subjectName.Name = "subjectName";
            this.subjectName.Size = new System.Drawing.Size(457, 20);
            this.subjectName.TabIndex = 5;
            this.subjectName.Text = "mycompany.com";
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(12, 283);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(457, 20);
            this.url.TabIndex = 7;
            this.url.Text = "wss://localhost:8088";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Service URL";
            // 
            // stop
            // 
            this.stop.Enabled = false;
            this.stop.Location = new System.Drawing.Point(394, 332);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 10;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // useWcf
            // 
            this.useWcf.AutoSize = true;
            this.useWcf.Location = new System.Drawing.Point(15, 310);
            this.useWcf.Name = "useWcf";
            this.useWcf.Size = new System.Drawing.Size(338, 17);
            this.useWcf.TabIndex = 8;
            this.useWcf.Text = "Use self-hosted WCF service (defaults to System.Net.HttpListener)";
            this.useWcf.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AcceptButton = this.start;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 367);
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
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "WebSocket Server Tool (Requires Windows 8 or better)";
            this.Load += new System.EventHandler(this.MainForm_Load);
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
    }
}

