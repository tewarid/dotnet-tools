namespace HttpRequestTool
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
            this.label1 = new System.Windows.Forms.Label();
            this.url = new System.Windows.Forms.TextBox();
            this.setClientCertificate = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.certificatePassword = new System.Windows.Forms.TextBox();
            this.clientCertificateFile = new System.Windows.Forms.TextBox();
            this.selectCertificateFile = new System.Windows.Forms.Button();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.go = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tlsVersion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.requestMethod = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.requestContentType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.requestHeaders = new NetTools.Common.NameValueGrid();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responseContent = new Common.ReceiveTextBox();
            this.responseHeaders = new NetTools.Common.NameValueGrid();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestContent = new Common.SendTextBox();
            this.queryParameters = new NetTools.Common.NameValueGrid();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Request URL";
            // 
            // url
            // 
            this.url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.url.Location = new System.Drawing.Point(9, 29);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(566, 22);
            this.url.TabIndex = 9;
            this.url.Text = "https://localhost:8443/";
            this.url.TextChanged += new System.EventHandler(this.url_TextChanged);
            // 
            // setClientCertificate
            // 
            this.setClientCertificate.AutoSize = true;
            this.setClientCertificate.Location = new System.Drawing.Point(12, 79);
            this.setClientCertificate.Name = "setClientCertificate";
            this.setClientCertificate.Size = new System.Drawing.Size(153, 21);
            this.setClientCertificate.TabIndex = 2;
            this.setClientCertificate.Text = "Set client certificate";
            this.setClientCertificate.UseVisualStyleBackColor = true;
            this.setClientCertificate.CheckedChanged += new System.EventHandler(this.setClientCertificate_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(578, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Certificate file";
            // 
            // certificatePassword
            // 
            this.certificatePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.certificatePassword.Enabled = false;
            this.certificatePassword.Location = new System.Drawing.Point(581, 79);
            this.certificatePassword.Name = "certificatePassword";
            this.certificatePassword.PasswordChar = '*';
            this.certificatePassword.Size = new System.Drawing.Size(134, 22);
            this.certificatePassword.TabIndex = 5;
            // 
            // clientCertificateFile
            // 
            this.clientCertificateFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientCertificateFile.Enabled = false;
            this.clientCertificateFile.Location = new System.Drawing.Point(174, 79);
            this.clientCertificateFile.Name = "clientCertificateFile";
            this.clientCertificateFile.Size = new System.Drawing.Size(312, 22);
            this.clientCertificateFile.TabIndex = 6;
            // 
            // selectCertificateFile
            // 
            this.selectCertificateFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectCertificateFile.Enabled = false;
            this.selectCertificateFile.Location = new System.Drawing.Point(492, 79);
            this.selectCertificateFile.Name = "selectCertificateFile";
            this.selectCertificateFile.Size = new System.Drawing.Size(75, 23);
            this.selectCertificateFile.TabIndex = 7;
            this.selectCertificateFile.Text = "Browse...";
            this.selectCertificateFile.UseVisualStyleBackColor = true;
            this.selectCertificateFile.Click += new System.EventHandler(this.selectCertificateFile_Click);
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "client.pfx";
            this.fileDialog.Filter = "PFX file (*.pfx)|*.pfx";
            // 
            // go
            // 
            this.go.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.go.Location = new System.Drawing.Point(640, 372);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(75, 23);
            this.go.TabIndex = 10;
            this.go.Text = "Go";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(578, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "SSL/TLS version";
            // 
            // tlsVersion
            // 
            this.tlsVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tlsVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tlsVersion.FormattingEnabled = true;
            this.tlsVersion.Location = new System.Drawing.Point(581, 29);
            this.tlsVersion.Name = "tlsVersion";
            this.tlsVersion.Size = new System.Drawing.Size(134, 24);
            this.tlsVersion.TabIndex = 12;
            this.tlsVersion.SelectedIndexChanged += new System.EventHandler(this.tlsVersion_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Request Headers";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(333, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Request Method";
            // 
            // requestMethod
            // 
            this.requestMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.requestMethod.FormattingEnabled = true;
            this.requestMethod.Location = new System.Drawing.Point(336, 125);
            this.requestMethod.Name = "requestMethod";
            this.requestMethod.Size = new System.Drawing.Size(146, 24);
            this.requestMethod.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(485, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Request Content Type";
            // 
            // requestContentType
            // 
            this.requestContentType.Enabled = false;
            this.requestContentType.FormattingEnabled = true;
            this.requestContentType.Location = new System.Drawing.Point(488, 125);
            this.requestContentType.Name = "requestContentType";
            this.requestContentType.Size = new System.Drawing.Size(210, 24);
            this.requestContentType.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 404);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Response Headers";
            // 
            // requestHeaders
            // 
            this.requestHeaders.Location = new System.Drawing.Point(9, 295);
            this.requestHeaders.Name = "requestHeaders";
            this.requestHeaders.Size = new System.Drawing.Size(318, 93);
            this.requestHeaders.TabIndex = 26;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // responseContent
            // 
            this.responseContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.responseContent.Location = new System.Drawing.Point(336, 404);
            this.responseContent.Margin = new System.Windows.Forms.Padding(4);
            this.responseContent.MinimumSize = new System.Drawing.Size(380, 117);
            this.responseContent.Name = "responseContent";
            this.responseContent.Size = new System.Drawing.Size(380, 259);
            this.responseContent.TabIndex = 25;
            // 
            // responseHeaders
            // 
            this.responseHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.responseHeaders.Location = new System.Drawing.Point(12, 425);
            this.responseHeaders.Name = "responseHeaders";
            this.responseHeaders.Size = new System.Drawing.Size(315, 238);
            this.responseHeaders.TabIndex = 24;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Value";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // requestContent
            // 
            this.requestContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.requestContent.Enabled = false;
            this.requestContent.Location = new System.Drawing.Point(334, 156);
            this.requestContent.Margin = new System.Windows.Forms.Padding(4);
            this.requestContent.MinimumSize = new System.Drawing.Size(373, 160);
            this.requestContent.Name = "requestContent";
            this.requestContent.Size = new System.Drawing.Size(382, 209);
            this.requestContent.TabIndex = 18;
            // 
            // queryParameters
            // 
            this.queryParameters.Location = new System.Drawing.Point(9, 127);
            this.queryParameters.Name = "queryParameters";
            this.queryParameters.Size = new System.Drawing.Size(318, 145);
            this.queryParameters.TabIndex = 27;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Name";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Value";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(181, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Request Query Parameters";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 675);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.queryParameters);
            this.Controls.Add(this.requestHeaders);
            this.Controls.Add(this.responseContent);
            this.Controls.Add(this.responseHeaders);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.requestContentType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.requestContent);
            this.Controls.Add(this.requestMethod);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tlsVersion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.go);
            this.Controls.Add(this.selectCertificateFile);
            this.Controls.Add(this.clientCertificateFile);
            this.Controls.Add(this.certificatePassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.setClientCertificate);
            this.Controls.Add(this.url);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "HTTP Request Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.CheckBox setClientCertificate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox certificatePassword;
        private System.Windows.Forms.TextBox clientCertificateFile;
        private System.Windows.Forms.Button selectCertificateFile;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Button go;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox tlsVersion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox requestMethod;
        private Common.SendTextBox requestContent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox requestContentType;
        private System.Windows.Forms.Label label8;
        private Common.ReceiveTextBox responseContent;
        private NetTools.Common.NameValueGrid requestHeaders;
        private NetTools.Common.NameValueGrid responseHeaders;
        private NetTools.Common.NameValueGrid queryParameters;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}

