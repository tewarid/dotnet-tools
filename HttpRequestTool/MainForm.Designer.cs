using System.Windows.Forms;

namespace HttpRequestTool
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
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.requestContentType = new NetTools.Common.ContentTypeSelector();
            this.queryParameters = new NetTools.Common.NameValueGrid();
            this.requestHeaders = new NetTools.Common.NameValueGrid();
            this.responseContent = new Common.ReceiveTextBox();
            this.responseHeaders = new NetTools.Common.NameValueGrid();
            this.requestContent = new Common.SendTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Request URL";
            // 
            // url
            // 
            this.url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.url.Location = new System.Drawing.Point(7, 24);
            this.url.Margin = new System.Windows.Forms.Padding(2);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(512, 20);
            this.url.TabIndex = 9;
            this.url.Text = "https://localhost:8443/";
            this.url.TextChanged += new System.EventHandler(this.Url_TextChanged);
            // 
            // setClientCertificate
            // 
            this.setClientCertificate.AutoSize = true;
            this.setClientCertificate.Location = new System.Drawing.Point(9, 68);
            this.setClientCertificate.Margin = new System.Windows.Forms.Padding(2);
            this.setClientCertificate.Name = "setClientCertificate";
            this.setClientCertificate.Size = new System.Drawing.Size(119, 17);
            this.setClientCertificate.TabIndex = 2;
            this.setClientCertificate.Text = "Set client certificate";
            this.setClientCertificate.UseVisualStyleBackColor = true;
            this.setClientCertificate.CheckedChanged += new System.EventHandler(this.SetClientCertificate_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(529, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Certificate file";
            // 
            // certificatePassword
            // 
            this.certificatePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.certificatePassword.Enabled = false;
            this.certificatePassword.Location = new System.Drawing.Point(529, 66);
            this.certificatePassword.Margin = new System.Windows.Forms.Padding(2);
            this.certificatePassword.Name = "certificatePassword";
            this.certificatePassword.PasswordChar = '*';
            this.certificatePassword.Size = new System.Drawing.Size(102, 20);
            this.certificatePassword.TabIndex = 5;
            // 
            // clientCertificateFile
            // 
            this.clientCertificateFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientCertificateFile.Enabled = false;
            this.clientCertificateFile.Location = new System.Drawing.Point(166, 67);
            this.clientCertificateFile.Margin = new System.Windows.Forms.Padding(2);
            this.clientCertificateFile.Name = "clientCertificateFile";
            this.clientCertificateFile.Size = new System.Drawing.Size(274, 20);
            this.clientCertificateFile.TabIndex = 6;
            // 
            // selectCertificateFile
            // 
            this.selectCertificateFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectCertificateFile.Enabled = false;
            this.selectCertificateFile.Location = new System.Drawing.Point(444, 66);
            this.selectCertificateFile.Margin = new System.Windows.Forms.Padding(2);
            this.selectCertificateFile.Name = "selectCertificateFile";
            this.selectCertificateFile.Size = new System.Drawing.Size(75, 23);
            this.selectCertificateFile.TabIndex = 7;
            this.selectCertificateFile.Text = "Browse...";
            this.selectCertificateFile.UseVisualStyleBackColor = true;
            this.selectCertificateFile.Click += new System.EventHandler(this.SelectCertificateFile_Click);
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "client.pfx";
            this.fileDialog.Filter = "PFX file (*.pfx)|*.pfx";
            // 
            // go
            // 
            this.go.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.go.Location = new System.Drawing.Point(559, 309);
            this.go.Margin = new System.Windows.Forms.Padding(2);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(75, 23);
            this.go.TabIndex = 10;
            this.go.Text = "Go";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.Go_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(529, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "SSL/TLS version";
            // 
            // tlsVersion
            // 
            this.tlsVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tlsVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tlsVersion.FormattingEnabled = true;
            this.tlsVersion.Location = new System.Drawing.Point(529, 24);
            this.tlsVersion.Margin = new System.Windows.Forms.Padding(2);
            this.tlsVersion.Name = "tlsVersion";
            this.tlsVersion.Size = new System.Drawing.Size(102, 21);
            this.tlsVersion.TabIndex = 12;
            this.tlsVersion.SelectedIndexChanged += new System.EventHandler(this.TlsVersion_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 230);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Request Headers";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 91);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Request Method";
            // 
            // requestMethod
            // 
            this.requestMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.requestMethod.FormattingEnabled = true;
            this.requestMethod.Location = new System.Drawing.Point(252, 110);
            this.requestMethod.Margin = new System.Windows.Forms.Padding(2);
            this.requestMethod.Name = "requestMethod";
            this.requestMethod.Size = new System.Drawing.Size(129, 21);
            this.requestMethod.TabIndex = 15;
            this.requestMethod.SelectedIndexChanged += new System.EventHandler(this.RequestMethod_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(393, 91);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Request Content Type";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 328);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Response Headers";
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
            this.label9.Location = new System.Drawing.Point(7, 91);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Request Query Parameters";
            // 
            // requestContentType
            // 
            this.requestContentType.AutoSize = true;
            this.requestContentType.Location = new System.Drawing.Point(396, 110);
            this.requestContentType.Name = "requestContentType";
            this.requestContentType.Size = new System.Drawing.Size(150, 21);
            this.requestContentType.TabIndex = 17;
            // 
            // queryParameters
            // 
            this.queryParameters.AllowUserToAddRows = false;
            this.queryParameters.AllowUserToDeleteRows = false;
            this.queryParameters.Location = new System.Drawing.Point(7, 110);
            this.queryParameters.Margin = new System.Windows.Forms.Padding(2);
            this.queryParameters.Name = "queryParameters";
            this.queryParameters.ReadOnly = true;
            this.queryParameters.Size = new System.Drawing.Size(238, 118);
            this.queryParameters.TabIndex = 27;
            // 
            // requestHeaders
            // 
            this.requestHeaders.AllowUserToAddRows = true;
            this.requestHeaders.AllowUserToDeleteRows = true;
            this.requestHeaders.Location = new System.Drawing.Point(7, 249);
            this.requestHeaders.Margin = new System.Windows.Forms.Padding(2);
            this.requestHeaders.Name = "requestHeaders";
            this.requestHeaders.ReadOnly = false;
            this.requestHeaders.Size = new System.Drawing.Size(238, 76);
            this.requestHeaders.TabIndex = 26;
            // 
            // responseContent
            // 
            this.responseContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.responseContent.Location = new System.Drawing.Point(252, 328);
            this.responseContent.Margin = new System.Windows.Forms.Padding(4);
            this.responseContent.MinimumSize = new System.Drawing.Size(285, 95);
            this.responseContent.Name = "responseContent";
            this.responseContent.Size = new System.Drawing.Size(383, 275);
            this.responseContent.TabIndex = 25;
            // 
            // responseHeaders
            // 
            this.responseHeaders.AllowUserToAddRows = false;
            this.responseHeaders.AllowUserToDeleteRows = false;
            this.responseHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.responseHeaders.Location = new System.Drawing.Point(9, 345);
            this.responseHeaders.Margin = new System.Windows.Forms.Padding(2);
            this.responseHeaders.Name = "responseHeaders";
            this.responseHeaders.ReadOnly = true;
            this.responseHeaders.Size = new System.Drawing.Size(236, 258);
            this.responseHeaders.TabIndex = 24;
            // 
            // requestContent
            // 
            this.requestContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.requestContent.Enabled = false;
            this.requestContent.Location = new System.Drawing.Point(250, 139);
            this.requestContent.MinimumSize = new System.Drawing.Size(280, 130);
            this.requestContent.Name = "requestContent";
            this.requestContent.Size = new System.Drawing.Size(384, 165);
            this.requestContent.TabIndex = 18;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(642, 613);
            this.Controls.Add(this.requestContentType);
            this.Controls.Add(this.go);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.queryParameters);
            this.Controls.Add(this.requestHeaders);
            this.Controls.Add(this.responseContent);
            this.Controls.Add(this.responseHeaders);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.requestContent);
            this.Controls.Add(this.requestMethod);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tlsVersion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.selectCertificateFile);
            this.Controls.Add(this.clientCertificateFile);
            this.Controls.Add(this.certificatePassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.setClientCertificate);
            this.Controls.Add(this.url);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private NetTools.Common.ContentTypeSelector requestContentType;
    }
}

