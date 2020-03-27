namespace WmiQuery
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
            this.log = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.queryClass = new System.Windows.Forms.ComboBox();
            this.queryProperty = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.query = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(346, 10);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log.Size = new System.Drawing.Size(384, 273);
            this.log.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "WMI Class";
            // 
            // queryClass
            // 
            this.queryClass.FormattingEnabled = true;
            this.queryClass.Items.AddRange(new object[] {
            "Win32_BaseBoard",
            "Win32_BIOS",
            "Win32_OperatingSystem",
            "Win32_PnPEntity",
            "Win32_PnPSignedDriver",
            "Win32_Processor",
            "WIN32_SerialPort",
            "Win32_SystemDriver"});
            this.queryClass.Location = new System.Drawing.Point(119, 10);
            this.queryClass.Name = "queryClass";
            this.queryClass.Size = new System.Drawing.Size(212, 21);
            this.queryClass.TabIndex = 1;
            // 
            // queryProperty
            // 
            this.queryProperty.FormattingEnabled = true;
            this.queryProperty.Items.AddRange(new object[] {
            "Caption",
            "DeviceID",
            "IdentificationCode",
            "InfName",
            "Manufacturer",
            "MaxClockSpeed",
            "Model",
            "Name",
            "PNPDeviceID",
            "ProcessorId",
            "ReleaseDate",
            "SerialNumber",
            "Service",
            "SMBIOSBIOSVersion",
            "UniqueId",
            "Version"});
            this.queryProperty.Location = new System.Drawing.Point(119, 49);
            this.queryProperty.Name = "queryProperty";
            this.queryProperty.Size = new System.Drawing.Size(212, 21);
            this.queryProperty.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "WMI Property";
            // 
            // query
            // 
            this.query.Location = new System.Drawing.Point(255, 88);
            this.query.Name = "query";
            this.query.Size = new System.Drawing.Size(75, 23);
            this.query.TabIndex = 3;
            this.query.Text = "Query";
            this.query.UseVisualStyleBackColor = true;
            this.query.Click += new System.EventHandler(this.Query_Click);
            // 
            // WmiQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 291);
            this.Controls.Add(this.query);
            this.Controls.Add(this.queryProperty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.queryClass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.log);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WmiQueryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Query PC information using WMI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox queryClass;
        private System.Windows.Forms.ComboBox queryProperty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button query;
    }
}

