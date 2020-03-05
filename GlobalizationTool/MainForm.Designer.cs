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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.culturesGrid = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.unicodeGrid = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.sort = new System.Windows.Forms.Button();
            this.removeDiacritics = new System.Windows.Forms.Button();
            this.lowerCase = new System.Windows.Forms.Button();
            this.upperCase = new System.Windows.Forms.Button();
            this.text = new System.Windows.Forms.TextBox();
            this.tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.culturesGrid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unicodeGrid)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Controls.Add(this.tabPage2);
            this.tab.Controls.Add(this.tabPage3);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(784, 561);
            this.tab.TabIndex = 2;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.culturesGrid.DefaultCellStyle = dataGridViewCellStyle1;
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.sort);
            this.tabPage3.Controls.Add(this.removeDiacritics);
            this.tabPage3.Controls.Add(this.lowerCase);
            this.tabPage3.Controls.Add(this.upperCase);
            this.tabPage3.Controls.Add(this.text);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(776, 535);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Conversions";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // sort
            // 
            this.sort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sort.Location = new System.Drawing.Point(697, 504);
            this.sort.Name = "sort";
            this.sort.Size = new System.Drawing.Size(75, 23);
            this.sort.TabIndex = 4;
            this.sort.Text = "Sort Words";
            this.sort.UseVisualStyleBackColor = true;
            this.sort.Click += new System.EventHandler(this.Sort_Click);
            // 
            // removeDiacritics
            // 
            this.removeDiacritics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeDiacritics.Location = new System.Drawing.Point(578, 504);
            this.removeDiacritics.Name = "removeDiacritics";
            this.removeDiacritics.Size = new System.Drawing.Size(113, 23);
            this.removeDiacritics.TabIndex = 3;
            this.removeDiacritics.Text = "Remove Diacritics";
            this.removeDiacritics.UseVisualStyleBackColor = true;
            this.removeDiacritics.Click += new System.EventHandler(this.RemoveDiacritics_Click);
            // 
            // lowerCase
            // 
            this.lowerCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lowerCase.Location = new System.Drawing.Point(497, 504);
            this.lowerCase.Name = "lowerCase";
            this.lowerCase.Size = new System.Drawing.Size(75, 23);
            this.lowerCase.TabIndex = 2;
            this.lowerCase.Text = "Lower Case";
            this.lowerCase.UseVisualStyleBackColor = true;
            this.lowerCase.Click += new System.EventHandler(this.LowerCase_Click);
            // 
            // upperCase
            // 
            this.upperCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.upperCase.Location = new System.Drawing.Point(416, 504);
            this.upperCase.Name = "upperCase";
            this.upperCase.Size = new System.Drawing.Size(75, 23);
            this.upperCase.TabIndex = 1;
            this.upperCase.Text = "Upper Case";
            this.upperCase.UseVisualStyleBackColor = true;
            this.upperCase.Click += new System.EventHandler(this.UpperCase_Click);
            // 
            // text
            // 
            this.text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text.Location = new System.Drawing.Point(4, 4);
            this.text.Multiline = true;
            this.text.Name = "text";
            this.text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text.Size = new System.Drawing.Size(769, 494);
            this.text.TabIndex = 0;
            this.text.Text = "αάβγδεέζηήθιίϊκλμνξςοόπρστυύϋφχψωώ ΑΆΒΓΔΕΈΖΗΉΘΙΊΚΛΜΝΞΟΌΠΡΣΤΥΎΦΧΨΩΏ 0123456789";
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
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView culturesGrid;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView unicodeGrid;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button removeDiacritics;
        private System.Windows.Forms.Button lowerCase;
        private System.Windows.Forms.Button upperCase;
        private System.Windows.Forms.TextBox text;
        private System.Windows.Forms.Button sort;
    }
}

