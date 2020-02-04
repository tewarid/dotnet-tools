namespace GlobalizationTool
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.culturesGrid = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.unicodeGrid = new System.Windows.Forms.DataGridView();
            this.tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.culturesGrid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unicodeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Controls.Add(this.tabPage2);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(784, 561);
            this.tab.TabIndex = 2;
            this.tab.SelectedIndexChanged += new System.EventHandler(this.Tab_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.culturesGrid);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 535);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cultures";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // culturesGrid
            // 
            this.culturesGrid.AllowUserToAddRows = false;
            this.culturesGrid.AllowUserToDeleteRows = false;
            this.culturesGrid.AllowUserToResizeRows = false;
            this.culturesGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.culturesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.culturesGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.culturesGrid.Location = new System.Drawing.Point(3, 3);
            this.culturesGrid.Name = "culturesGrid";
            this.culturesGrid.ReadOnly = true;
            this.culturesGrid.RowHeadersVisible = false;
            this.culturesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.culturesGrid.Size = new System.Drawing.Size(770, 529);
            this.culturesGrid.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.unicodeGrid);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 535);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Unicode";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // unicodeGrid
            // 
            this.unicodeGrid.AllowUserToAddRows = false;
            this.unicodeGrid.AllowUserToDeleteRows = false;
            this.unicodeGrid.AllowUserToResizeRows = false;
            this.unicodeGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unicodeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.unicodeGrid.Location = new System.Drawing.Point(4, 4);
            this.unicodeGrid.Name = "unicodeGrid";
            this.unicodeGrid.ReadOnly = true;
            this.unicodeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.unicodeGrid.Size = new System.Drawing.Size(769, 528);
            this.unicodeGrid.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tab);
            this.Name = "MainForm";
            this.Text = "Globalization Tool";
            this.tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.culturesGrid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.unicodeGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView culturesGrid;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView unicodeGrid;
    }
}

