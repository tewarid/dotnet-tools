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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chunked = new System.Windows.Forms.CheckBox();
            this.responseContent = new Common.InputTextBox();
            this.responseContentType = new NetTools.Common.ContentTypeSelector();
            this.responseStatusCode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.responseHeaders = new NetTools.Common.NameValueGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uri
            // 
            this.uri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uri.Location = new System.Drawing.Point(13, 93);
            this.uri.Name = "uri";
            this.uri.Size = new System.Drawing.Size(490, 20);
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
            this.textBox1.Size = new System.Drawing.Size(489, 49);
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
            this.stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.stop.Enabled = false;
            this.stop.Location = new System.Drawing.Point(428, 320);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 24;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // start
            // 
            this.start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.start.Location = new System.Drawing.Point(347, 320);
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
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log.Location = new System.Drawing.Point(13, 359);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.log.Size = new System.Drawing.Size(490, 104);
            this.log.TabIndex = 26;
            this.log.WordWrap = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Request Log";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(14, 142);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chunked);
            this.splitContainer1.Panel1.Controls.Add(this.responseContent);
            this.splitContainer1.Panel1.Controls.Add(this.responseContentType);
            this.splitContainer1.Panel1.Controls.Add(this.responseStatusCode);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.responseHeaders);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(491, 172);
            this.splitContainer1.SplitterDistance = 305;
            this.splitContainer1.TabIndex = 11;
            // 
            // chunked
            // 
            this.chunked.AutoSize = true;
            this.chunked.Location = new System.Drawing.Point(2, 44);
            this.chunked.Name = "chunked";
            this.chunked.Size = new System.Drawing.Size(175, 17);
            this.chunked.TabIndex = 36;
            this.chunked.Text = "Use chunked transfer encoding";
            this.chunked.UseVisualStyleBackColor = true;
            // 
            // responseContent
            // 
            this.responseContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.responseContent.BinaryChecked = false;
            this.responseContent.ChangeEndOfLine = true;
            this.responseContent.EndOfLine = Common.EndOfLine.Dos;
            this.responseContent.Location = new System.Drawing.Point(2, 63);
            this.responseContent.MinimumSize = new System.Drawing.Size(210, 106);
            this.responseContent.Name = "responseContent";
            this.responseContent.SelectedTextValue = "";
            this.responseContent.Size = new System.Drawing.Size(300, 106);
            this.responseContent.TabIndex = 37;
            this.responseContent.TextValue = "";
            // 
            // responseContentType
            // 
            this.responseContentType.AutoSize = true;
            this.responseContentType.Location = new System.Drawing.Point(139, 17);
            this.responseContentType.Name = "responseContentType";
            this.responseContentType.Size = new System.Drawing.Size(130, 21);
            this.responseContentType.TabIndex = 35;
            // 
            // responseStatusCode
            // 
            this.responseStatusCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.responseStatusCode.FormattingEnabled = true;
            this.responseStatusCode.Location = new System.Drawing.Point(1, 17);
            this.responseStatusCode.Margin = new System.Windows.Forms.Padding(2);
            this.responseStatusCode.Name = "responseStatusCode";
            this.responseStatusCode.Size = new System.Drawing.Size(133, 21);
            this.responseStatusCode.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 2);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Response Status Code";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(136, 2);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Response Content Type";
            // 
            // responseHeaders
            // 
            this.responseHeaders.AllowUserToAddRows = true;
            this.responseHeaders.AllowUserToDeleteRows = true;
            this.responseHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.responseHeaders.Location = new System.Drawing.Point(3, 18);
            this.responseHeaders.Margin = new System.Windows.Forms.Padding(2);
            this.responseHeaders.Name = "responseHeaders";
            this.responseHeaders.ReadOnly = false;
            this.responseHeaders.Size = new System.Drawing.Size(177, 152);
            this.responseHeaders.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Response Headers";
            // 
            // clear
            // 
            this.clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clear.Location = new System.Drawing.Point(430, 469);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 35;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 498);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.splitContainer1);
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
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private SplitContainer splitContainer1;
        private Common.InputTextBox responseContent;
        private NetTools.Common.ContentTypeSelector responseContentType;
        private ComboBox responseStatusCode;
        private Label label3;
        private Label label7;
        private NetTools.Common.NameValueGrid responseHeaders;
        private Label label1;
        private Button clear;
        private CheckBox chunked;
    }
}

