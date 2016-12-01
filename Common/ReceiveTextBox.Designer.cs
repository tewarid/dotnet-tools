namespace Common
{
    partial class ReceiveTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.outputText = new System.Windows.Forms.TextBox();
            this.viewInHex = new System.Windows.Forms.CheckBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(0, 1);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(352, 13);
            this.label.TabIndex = 13;
            this.label.Text = "Data received (assumes UTF-8, special characters are replaced with a \'.\')";
            // 
            // outputText
            // 
            this.outputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputText.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputText.Location = new System.Drawing.Point(0, 17);
            this.outputText.MaxLength = 1000000;
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.ReadOnly = true;
            this.outputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputText.Size = new System.Drawing.Size(390, 230);
            this.outputText.TabIndex = 0;
            this.outputText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.outputText_KeyPress);
            // 
            // viewInHex
            // 
            this.viewInHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewInHex.AutoSize = true;
            this.viewInHex.Location = new System.Drawing.Point(3, 261);
            this.viewInHex.Name = "viewInHex";
            this.viewInHex.Size = new System.Drawing.Size(228, 17);
            this.viewInHex.TabIndex = 2;
            this.viewInHex.Text = "Display as hexadecimal ASCII (e.g. BE AD)";
            this.viewInHex.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(315, 253);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 30);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "&Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // ReceiveTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label);
            this.Controls.Add(this.viewInHex);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.clearButton);
            this.MinimumSize = new System.Drawing.Size(355, 95);
            this.Name = "ReceiveTextBox";
            this.Size = new System.Drawing.Size(392, 285);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.CheckBox viewInHex;
        private System.Windows.Forms.Button clearButton;
    }
}
