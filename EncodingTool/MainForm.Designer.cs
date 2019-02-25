using System.Windows.Forms;

namespace EncodingTool
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
            this.input = new Common.InputTextBox();
            this.output = new Common.OutputTextBox();
            this.convertTo = new System.Windows.Forms.ComboBox();
            this.saveToClipboard = new System.Windows.Forms.CheckBox();
            this.convert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input.Location = new System.Drawing.Point(10, 11);
            this.input.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.input.Name = "input";
            this.input.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.input.Size = new System.Drawing.Size(581, 171);
            this.input.TabIndex = 0;
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.Location = new System.Drawing.Point(10, 210);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(580, 145);
            this.output.TabIndex = 1;
            // 
            // convertTo
            // 
            this.convertTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.convertTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.convertTo.FormattingEnabled = true;
            this.convertTo.Location = new System.Drawing.Point(10, 187);
            this.convertTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.convertTo.Name = "convertTo";
            this.convertTo.Size = new System.Drawing.Size(386, 21);
            this.convertTo.TabIndex = 2;
            // 
            // saveToClipboard
            // 
            this.saveToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveToClipboard.AutoSize = true;
            this.saveToClipboard.Location = new System.Drawing.Point(400, 188);
            this.saveToClipboard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveToClipboard.Name = "saveToClipboard";
            this.saveToClipboard.Size = new System.Drawing.Size(110, 17);
            this.saveToClipboard.TabIndex = 3;
            this.saveToClipboard.Text = "Save to Clipboard";
            this.saveToClipboard.UseVisualStyleBackColor = true;
            // 
            // convert
            // 
            this.convert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.convert.Location = new System.Drawing.Point(514, 184);
            this.convert.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.convert.Name = "convert";
            this.convert.Size = new System.Drawing.Size(75, 23);
            this.convert.TabIndex = 4;
            this.convert.Text = "Convert";
            this.convert.UseVisualStyleBackColor = true;
            this.convert.Click += new System.EventHandler(this.Convert);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.convert);
            this.Controls.Add(this.saveToClipboard);
            this.Controls.Add(this.convertTo);
            this.Controls.Add(this.output);
            this.Controls.Add(this.input);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encoding Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.InputTextBox input;
        private Common.OutputTextBox output;
        private System.Windows.Forms.ComboBox convertTo;
        private System.Windows.Forms.CheckBox saveToClipboard;
        private System.Windows.Forms.Button convert;
    }
}

