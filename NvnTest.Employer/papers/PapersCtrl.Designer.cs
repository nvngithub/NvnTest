namespace NvnTest.Employer {
    partial class PapersCtrl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrPapers = new System.Windows.Forms.DataGridView();
            this.IndexCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaperTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.DeleteCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAddNewAutoPaper = new RibbonStyle.RibbonMenuButton();
            this.btnAddNewPaper = new RibbonStyle.RibbonMenuButton();
            this.chkShowAutoPapers = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgrPapers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrPapers
            // 
            this.dgrPapers.AllowUserToAddRows = false;
            this.dgrPapers.AllowUserToDeleteRows = false;
            this.dgrPapers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrPapers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrPapers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgrPapers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrPapers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IndexCol,
            this.NameCol,
            this.DescCol,
            this.PaperTypeColumn,
            this.EditCol,
            this.DeleteCol});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrPapers.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgrPapers.Location = new System.Drawing.Point(3, 3);
            this.dgrPapers.Name = "dgrPapers";
            this.dgrPapers.ReadOnly = true;
            this.dgrPapers.RowHeadersVisible = false;
            this.dgrPapers.Size = new System.Drawing.Size(911, 410);
            this.dgrPapers.TabIndex = 0;
            this.dgrPapers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrPapers_CellDoubleClick);
            this.dgrPapers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrPapers_CellContentClick);
            // 
            // IndexCol
            // 
            this.IndexCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IndexCol.FillWeight = 50.76142F;
            this.IndexCol.HeaderText = "Index";
            this.IndexCol.Name = "IndexCol";
            this.IndexCol.ReadOnly = true;
            this.IndexCol.Width = 50;
            // 
            // NameCol
            // 
            this.NameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.NameCol.DefaultCellStyle = dataGridViewCellStyle6;
            this.NameCol.FillWeight = 269.433F;
            this.NameCol.HeaderText = "Name";
            this.NameCol.Name = "NameCol";
            this.NameCol.ReadOnly = true;
            this.NameCol.Width = 200;
            // 
            // DescCol
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DescCol.DefaultCellStyle = dataGridViewCellStyle7;
            this.DescCol.HeaderText = "Description";
            this.DescCol.Name = "DescCol";
            this.DescCol.ReadOnly = true;
            // 
            // PaperTypeColumn
            // 
            this.PaperTypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PaperTypeColumn.HeaderText = "Type";
            this.PaperTypeColumn.Name = "PaperTypeColumn";
            this.PaperTypeColumn.ReadOnly = true;
            // 
            // EditCol
            // 
            this.EditCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EditCol.HeaderText = "Edit";
            this.EditCol.Image = global::NvnTest.Employer.Properties.Resources.edit_16;
            this.EditCol.Name = "EditCol";
            this.EditCol.ReadOnly = true;
            this.EditCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EditCol.Width = 50;
            // 
            // DeleteCol
            // 
            this.DeleteCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DeleteCol.FillWeight = 59.93518F;
            this.DeleteCol.HeaderText = "Delete";
            this.DeleteCol.Image = global::NvnTest.Employer.Properties.Resources.delete_16;
            this.DeleteCol.Name = "DeleteCol";
            this.DeleteCol.ReadOnly = true;
            this.DeleteCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteCol.Width = 50;
            // 
            // btnAddNewAutoPaper
            // 
            this.btnAddNewAutoPaper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddNewAutoPaper.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnAddNewAutoPaper.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewAutoPaper.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddNewAutoPaper.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnAddNewAutoPaper.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAddNewAutoPaper.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAddNewAutoPaper.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddNewAutoPaper.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAddNewAutoPaper.FadingSpeed = 0;
            this.btnAddNewAutoPaper.FlatAppearance.BorderSize = 0;
            this.btnAddNewAutoPaper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewAutoPaper.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewAutoPaper.ForeColor = System.Drawing.Color.Black;
            this.btnAddNewAutoPaper.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnAddNewAutoPaper.Image = global::NvnTest.Employer.Properties.Resources.add;
            this.btnAddNewAutoPaper.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewAutoPaper.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnAddNewAutoPaper.ImageOffset = 3;
            this.btnAddNewAutoPaper.IsPressed = false;
            this.btnAddNewAutoPaper.KeepPress = false;
            this.btnAddNewAutoPaper.Location = new System.Drawing.Point(151, 419);
            this.btnAddNewAutoPaper.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAddNewAutoPaper.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAddNewAutoPaper.Name = "btnAddNewAutoPaper";
            this.btnAddNewAutoPaper.Radius = 8;
            this.btnAddNewAutoPaper.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnAddNewAutoPaper.Size = new System.Drawing.Size(163, 30);
            this.btnAddNewAutoPaper.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnAddNewAutoPaper.SplitDistance = 0;
            this.btnAddNewAutoPaper.TabIndex = 49;
            this.btnAddNewAutoPaper.Text = "Add a new auto paper";
            this.btnAddNewAutoPaper.Title = "";
            this.btnAddNewAutoPaper.UseVisualStyleBackColor = true;
            this.btnAddNewAutoPaper.Click += new System.EventHandler(this.btnAddNewAutoPaper_Click);
            // 
            // btnAddNewPaper
            // 
            this.btnAddNewPaper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddNewPaper.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnAddNewPaper.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewPaper.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddNewPaper.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnAddNewPaper.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAddNewPaper.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAddNewPaper.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddNewPaper.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAddNewPaper.FadingSpeed = 0;
            this.btnAddNewPaper.FlatAppearance.BorderSize = 0;
            this.btnAddNewPaper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewPaper.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewPaper.ForeColor = System.Drawing.Color.Black;
            this.btnAddNewPaper.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnAddNewPaper.Image = global::NvnTest.Employer.Properties.Resources.add;
            this.btnAddNewPaper.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewPaper.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnAddNewPaper.ImageOffset = 3;
            this.btnAddNewPaper.IsPressed = false;
            this.btnAddNewPaper.KeepPress = false;
            this.btnAddNewPaper.Location = new System.Drawing.Point(3, 419);
            this.btnAddNewPaper.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAddNewPaper.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAddNewPaper.Name = "btnAddNewPaper";
            this.btnAddNewPaper.Radius = 8;
            this.btnAddNewPaper.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnAddNewPaper.Size = new System.Drawing.Size(142, 30);
            this.btnAddNewPaper.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnAddNewPaper.SplitDistance = 0;
            this.btnAddNewPaper.TabIndex = 48;
            this.btnAddNewPaper.Text = "Add a new paper";
            this.btnAddNewPaper.Title = "";
            this.btnAddNewPaper.UseVisualStyleBackColor = true;
            this.btnAddNewPaper.Click += new System.EventHandler(this.btnAddNewPaper_Click);
            // 
            // chkShowAutoPapers
            // 
            this.chkShowAutoPapers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowAutoPapers.AutoSize = true;
            this.chkShowAutoPapers.Location = new System.Drawing.Point(723, 427);
            this.chkShowAutoPapers.Name = "chkShowAutoPapers";
            this.chkShowAutoPapers.Size = new System.Drawing.Size(191, 17);
            this.chkShowAutoPapers.TabIndex = 50;
            this.chkShowAutoPapers.Text = "Show automatically created papers";
            this.chkShowAutoPapers.UseVisualStyleBackColor = true;
            this.chkShowAutoPapers.CheckedChanged += new System.EventHandler(this.chkShowAutoPapers_CheckedChanged);
            // 
            // PapersCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkShowAutoPapers);
            this.Controls.Add(this.btnAddNewAutoPaper);
            this.Controls.Add(this.btnAddNewPaper);
            this.Controls.Add(this.dgrPapers);
            this.Name = "PapersCtrl";
            this.Size = new System.Drawing.Size(917, 452);
            ((System.ComponentModel.ISupportInitialize)(this.dgrPapers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrPapers;
        private RibbonStyle.RibbonMenuButton btnAddNewPaper;
        private RibbonStyle.RibbonMenuButton btnAddNewAutoPaper;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndexCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaperTypeColumn;
        private System.Windows.Forms.DataGridViewImageColumn EditCol;
        private System.Windows.Forms.DataGridViewImageColumn DeleteCol;
        private System.Windows.Forms.CheckBox chkShowAutoPapers;
    }
}
