namespace Common
{
    partial class SendTextBox
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
            this.inputInHex = new System.Windows.Forms.CheckBox();
            this.inputTextLabel = new System.Windows.Forms.Label();
            this.endOfLine = new System.Windows.Forms.GroupBox();
            this.endOfLineUnix = new System.Windows.Forms.RadioButton();
            this.endOfLineDos = new System.Windows.Forms.RadioButton();
            this.endOfLineMac = new System.Windows.Forms.RadioButton();
            this.inputText = new System.Windows.Forms.TextBox();
            this.endOfLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputInHex
            // 
            this.inputInHex.AutoSize = true;
            this.inputInHex.Location = new System.Drawing.Point(3, 6);
            this.inputInHex.Name = "inputInHex";
            this.inputInHex.Size = new System.Drawing.Size(340, 17);
            this.inputInHex.TabIndex = 0;
            this.inputInHex.Text = "Send binary, text is hexadecimal ASCII (e.g. 0xDE 0xAD or DE AD)";
            this.inputInHex.UseVisualStyleBackColor = true;
            this.inputInHex.CheckedChanged += new System.EventHandler(this.inputInHex_CheckedChanged);
            // 
            // inputTextLabel
            // 
            this.inputTextLabel.AutoSize = true;
            this.inputTextLabel.Location = new System.Drawing.Point(0, 26);
            this.inputTextLabel.Name = "inputTextLabel";
            this.inputTextLabel.Size = new System.Drawing.Size(105, 13);
            this.inputTextLabel.TabIndex = 21;
            this.inputTextLabel.Text = "Text to send (UTF-8)";
            // 
            // endOfLine
            // 
            this.endOfLine.Controls.Add(this.endOfLineUnix);
            this.endOfLine.Controls.Add(this.endOfLineDos);
            this.endOfLine.Controls.Add(this.endOfLineMac);
            this.endOfLine.Location = new System.Drawing.Point(3, 376);
            this.endOfLine.Name = "endOfLine";
            this.endOfLine.Size = new System.Drawing.Size(247, 45);
            this.endOfLine.TabIndex = 2;
            this.endOfLine.TabStop = false;
            this.endOfLine.Text = "End of Line";
            // 
            // endOfLineUnix
            // 
            this.endOfLineUnix.AutoSize = true;
            this.endOfLineUnix.Location = new System.Drawing.Point(84, 19);
            this.endOfLineUnix.Name = "endOfLineUnix";
            this.endOfLineUnix.Size = new System.Drawing.Size(67, 17);
            this.endOfLineUnix.TabIndex = 2;
            this.endOfLineUnix.Text = "Unix (LF)";
            this.endOfLineUnix.UseVisualStyleBackColor = true;
            this.endOfLineUnix.CheckedChanged += new System.EventHandler(this.endOfLine_CheckedChanged);
            // 
            // endOfLineDos
            // 
            this.endOfLineDos.AutoSize = true;
            this.endOfLineDos.Location = new System.Drawing.Point(157, 19);
            this.endOfLineDos.Name = "endOfLineDos";
            this.endOfLineDos.Size = new System.Drawing.Size(87, 17);
            this.endOfLineDos.TabIndex = 2;
            this.endOfLineDos.Text = "DOS (CR-LF)";
            this.endOfLineDos.UseVisualStyleBackColor = true;
            this.endOfLineDos.CheckedChanged += new System.EventHandler(this.endOfLine_CheckedChanged);
            // 
            // endOfLineMac
            // 
            this.endOfLineMac.AutoSize = true;
            this.endOfLineMac.Checked = true;
            this.endOfLineMac.Location = new System.Drawing.Point(6, 19);
            this.endOfLineMac.Name = "endOfLineMac";
            this.endOfLineMac.Size = new System.Drawing.Size(72, 17);
            this.endOfLineMac.TabIndex = 2;
            this.endOfLineMac.TabStop = true;
            this.endOfLineMac.Text = "MAC (CR)";
            this.endOfLineMac.UseVisualStyleBackColor = true;
            this.endOfLineMac.CheckedChanged += new System.EventHandler(this.endOfLine_CheckedChanged);
            // 
            // inputText
            // 
            this.inputText.AcceptsReturn = true;
            this.inputText.AcceptsTab = true;
            this.inputText.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputText.HideSelection = false;
            this.inputText.Location = new System.Drawing.Point(3, 42);
            this.inputText.MaxLength = 1000000;
            this.inputText.Multiline = true;
            this.inputText.Name = "inputText";
            this.inputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputText.Size = new System.Drawing.Size(374, 328);
            this.inputText.TabIndex = 1;
            this.inputText.TextChanged += new System.EventHandler(this.inputText_TextChanged);
            this.inputText.Enter += new System.EventHandler(this.inputText_Enter);
            this.inputText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputText_KeyPress);
            this.inputText.Leave += new System.EventHandler(this.inputText_Leave);
            // 
            // SendTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inputInHex);
            this.Controls.Add(this.inputTextLabel);
            this.Controls.Add(this.endOfLine);
            this.Controls.Add(this.inputText);
            this.Name = "SendTextBox";
            this.Size = new System.Drawing.Size(379, 425);
            this.Resize += new System.EventHandler(this.SendTextBox_Resize);
            this.endOfLine.ResumeLayout(false);
            this.endOfLine.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox inputInHex;
        private System.Windows.Forms.Label inputTextLabel;
        private System.Windows.Forms.GroupBox endOfLine;
        private System.Windows.Forms.RadioButton endOfLineUnix;
        private System.Windows.Forms.RadioButton endOfLineDos;
        private System.Windows.Forms.RadioButton endOfLineMac;
        private System.Windows.Forms.TextBox inputText;
    }
}
