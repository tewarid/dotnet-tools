using System.Windows.Forms;

namespace HttpListenerTool
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
            this.uri = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.stop = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.certificateAuth = new System.Windows.Forms.CheckBox();
            this.log = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.responseStatusCode = new System.Windows.Forms.ComboBox();
            this.responseHeaders = new NetTools.Common.NameValueGrid();
            this.responseContentType = new NetTools.Common.ContentTypeSelector();
            this.responseContent = new Common.InputTextBox();
            this.SuspendLayout();
            // 
            // uri
            // 
            this.uri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uri.Location = new System.Drawing.Point(13, 93);
            this.uri.Name = "uri";
            this.uri.Size = new System.Drawing.Size(460, 20);
            this.uri.TabIndex = 5;
            this.uri.Text = "https://localhost:8443/";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Prefix URI";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(14, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(459, 49);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "For HTTPS, create and initialize X509 certificate as follows...";
            // 
            // stop
            // 
            this.stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stop.Enabled = false;
            this.stop.Location = new System.Drawing.Point(398, 320);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 24;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // start
            // 
            this.start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.start.Location = new System.Drawing.Point(317, 320);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 23;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // certificateAuth
            // 
            this.certificateAuth.AutoSize = true;
            this.certificateAuth.Location = new System.Drawing.Point(16, 119);
            this.certificateAuth.Name = "certificateAuth";
            this.certificateAuth.Size = new System.Drawing.Size(145, 17);
            this.certificateAuth.TabIndex = 10;
            this.certificateAuth.Text = "Request Client Certificate";
            this.certificateAuth.UseVisualStyleBackColor = true;
            // 
            // log
            // 
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log.Location = new System.Drawing.Point(10, 359);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.log.Size = new System.Drawing.Size(463, 130);
            this.log.TabIndex = 26;
            this.log.WordWrap = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 342);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Request Log";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 139);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Response Content Type";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 139);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Response Headers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Response Status Code";
            // 
            // responseStatusCode
            // 
            this.responseStatusCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.responseStatusCode.FormattingEnabled = true;
            this.responseStatusCode.Location = new System.Drawing.Point(16, 155);
            this.responseStatusCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.responseStatusCode.Name = "responseStatusCode";
            this.responseStatusCode.Size = new System.Drawing.Size(133, 21);
            this.responseStatusCode.TabIndex = 12;
            // 
            // responseHeaders
            // 
            this.responseHeaders.AllowUserToAddRows = true;
            this.responseHeaders.AllowUserToDeleteRows = true;
            this.responseHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.responseHeaders.Location = new System.Drawing.Point(293, 156);
            this.responseHeaders.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.responseHeaders.Name = "responseHeaders";
            this.responseHeaders.ReadOnly = false;
            this.responseHeaders.Size = new System.Drawing.Size(178, 159);
            this.responseHeaders.TabIndex = 18;
            // 
            // responseContentType
            // 
            this.responseContentType.AutoSize = true;
            this.responseContentType.Location = new System.Drawing.Point(154, 155);
            this.responseContentType.Name = "responseContentType";
            this.responseContentType.Size = new System.Drawing.Size(130, 21);
            this.responseContentType.TabIndex = 14;
            // 
            // responseContent
            // 
            this.responseContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.responseContent.Location = new System.Drawing.Point(10, 181);
            this.responseContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.responseContent.MinimumSize = new System.Drawing.Size(210, 106);
            this.responseContent.Name = "responseContent";
            this.responseContent.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.responseContent.Size = new System.Drawing.Size(274, 135);
            this.responseContent.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 498);
            this.Controls.Add(this.responseContent);
            this.Controls.Add(this.responseContentType);
            this.Controls.Add(this.responseStatusCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.responseHeaders);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.log);
            this.Controls.Add(this.certificateAuth);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Controls.Add(this.uri);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "HTTP Listener Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uri;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.CheckBox certificateAuth;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.Label label5;
        private NetTools.Common.NameValueGrid responseHeaders;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox responseStatusCode;
        private NetTools.Common.ContentTypeSelector responseContentType;
        private Common.InputTextBox responseContent;
    }
}

