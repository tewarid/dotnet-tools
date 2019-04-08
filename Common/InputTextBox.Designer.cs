using System.Windows.Forms;

namespace Common
{
    public partial class InputTextBox : UserControl
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
            this.inputText = new System.Windows.Forms.TextBox();
            this.changeEndOfLine = new System.Windows.Forms.CheckBox();
            this.endOfLine = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // inputInHex
            // 
            this.inputInHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inputInHex.AutoSize = true;
            this.inputInHex.Location = new System.Drawing.Point(0, 265);
            this.inputInHex.MinimumSize = new System.Drawing.Size(272, 17);
            this.inputInHex.Name = "inputInHex";
            this.inputInHex.Size = new System.Drawing.Size(272, 17);
            this.inputInHex.TabIndex = 1;
            this.inputInHex.Text = "Text is in hexadecimal (e.g. BE 0xad)";
            this.inputInHex.UseVisualStyleBackColor = true;
            this.inputInHex.CheckedChanged += new System.EventHandler(this.InputInHex_CheckedChanged);
            // 
            // inputTextLabel
            // 
            this.inputTextLabel.AutoSize = true;
            this.inputTextLabel.Location = new System.Drawing.Point(-3, 0);
            this.inputTextLabel.Name = "inputTextLabel";
            this.inputTextLabel.Size = new System.Drawing.Size(94, 13);
            this.inputTextLabel.TabIndex = 21;
            this.inputTextLabel.Text = "Input Text (UTF-8)";
            // 
            // inputText
            // 
            this.inputText.AcceptsReturn = true;
            this.inputText.AcceptsTab = true;
            this.inputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputText.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputText.HideSelection = false;
            this.inputText.Location = new System.Drawing.Point(0, 16);
            this.inputText.MaxLength = 1000000;
            this.inputText.Multiline = true;
            this.inputText.Name = "inputText";
            this.inputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputText.Size = new System.Drawing.Size(502, 243);
            this.inputText.TabIndex = 0;
            // 
            // changeEndOfLine
            // 
            this.changeEndOfLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.changeEndOfLine.AutoSize = true;
            this.changeEndOfLine.Checked = true;
            this.changeEndOfLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.changeEndOfLine.Location = new System.Drawing.Point(0, 288);
            this.changeEndOfLine.Name = "changeEndOfLine";
            this.changeEndOfLine.Size = new System.Drawing.Size(115, 17);
            this.changeEndOfLine.TabIndex = 22;
            this.changeEndOfLine.Text = "Change end of line";
            this.changeEndOfLine.UseVisualStyleBackColor = true;
            this.changeEndOfLine.CheckedChanged += new System.EventHandler(this.ChangeEndOfLine_CheckedChanged);
            // 
            // endOfLine
            // 
            this.endOfLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.endOfLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.endOfLine.FormattingEnabled = true;
            this.endOfLine.Location = new System.Drawing.Point(121, 286);
            this.endOfLine.Name = "endOfLine";
            this.endOfLine.Size = new System.Drawing.Size(180, 21);
            this.endOfLine.TabIndex = 23;
            // 
            // InputTextBox
            // 
            this.Controls.Add(this.endOfLine);
            this.Controls.Add(this.changeEndOfLine);
            this.Controls.Add(this.inputTextLabel);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.inputInHex);
            this.Name = "InputTextBox";
            this.Size = new System.Drawing.Size(502, 307);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox inputInHex;
        private System.Windows.Forms.Label inputTextLabel;
        private System.Windows.Forms.TextBox inputText;
        private CheckBox changeEndOfLine;
        private ComboBox endOfLine;
    }
}
