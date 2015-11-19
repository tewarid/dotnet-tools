namespace WebSocketTool
{
    partial class HeaderForm
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
            this.headers = new System.Windows.Forms.DataGridView();
            this.done = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.headerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headerValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.headers)).BeginInit();
            this.SuspendLayout();
            // 
            // headers
            // 
            this.headers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.headers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.headerName,
            this.headerValue});
            this.headers.Location = new System.Drawing.Point(2, 1);
            this.headers.MultiSelect = false;
            this.headers.Name = "headers";
            this.headers.Size = new System.Drawing.Size(394, 218);
            this.headers.TabIndex = 0;
            // 
            // done
            // 
            this.done.Location = new System.Drawing.Point(317, 226);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(75, 23);
            this.done.TabIndex = 2;
            this.done.Text = "Done";
            this.done.UseVisualStyleBackColor = true;
            this.done.Click += new System.EventHandler(this.done_Click);
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(236, 226);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(75, 23);
            this.remove.TabIndex = 1;
            this.remove.Text = "Remove";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // headerName
            // 
            this.headerName.HeaderText = "Name";
            this.headerName.Name = "headerName";
            // 
            // headerValue
            // 
            this.headerValue.HeaderText = "Value";
            this.headerValue.Name = "headerValue";
            this.headerValue.Width = 200;
            // 
            // HeaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 254);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.done);
            this.Controls.Add(this.headers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HeaderForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Request Headers";
            this.Load += new System.EventHandler(this.HeaderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView headers;
        private System.Windows.Forms.Button done;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.DataGridViewTextBoxColumn headerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn headerValue;
    }
}