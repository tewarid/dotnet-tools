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
            this.SuspendLayout();
            // 
            // hidDevicesCombo
            // 
            this.hidDevicesCombo.FormattingEnabled = true;
            this.hidDevicesCombo.Location = new System.Drawing.Point(13, 13);
            this.hidDevicesCombo.Name = "hidDevicesCombo";
            this.hidDevicesCombo.Size = new System.Drawing.Size(121, 21);
            this.hidDevicesCombo.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hidDevicesCombo);
            this.Name = "MainForm";
            this.Text = "HID Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox hidDevicesCombo;
    }
}

