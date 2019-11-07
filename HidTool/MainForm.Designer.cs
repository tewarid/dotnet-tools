namespace HidTool
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
            this.hidDevicesCombo = new System.Windows.Forms.ComboBox();
            this.refresh = new System.Windows.Forms.Button();
            this.open = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hidDevicesCombo
            // 
            this.hidDevicesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hidDevicesCombo.FormattingEnabled = true;
            this.hidDevicesCombo.Location = new System.Drawing.Point(13, 13);
            this.hidDevicesCombo.Name = "hidDevicesCombo";
            this.hidDevicesCombo.Size = new System.Drawing.Size(430, 21);
            this.hidDevicesCombo.TabIndex = 0;
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(449, 13);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(75, 23);
            this.refresh.TabIndex = 1;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(531, 13);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 23);
            this.open.TabIndex = 2;
            this.open.Text = "Open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.Open_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.open);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.hidDevicesCombo);
            this.Name = "MainForm";
            this.Text = "HID Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox hidDevicesCombo;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button open;
    }
}

