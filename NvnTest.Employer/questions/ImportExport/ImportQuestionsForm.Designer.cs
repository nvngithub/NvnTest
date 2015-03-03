namespace NvnTest.Employer {
    partial class ImportQuestionsForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new RibbonStyle.RibbonMenuButton();
            this.btnImport = new RibbonStyle.RibbonMenuButton();
            this.dgrQuestions = new System.Windows.Forms.DataGridView();
            this.SelectQuestionCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DescCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuestionTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrQuestions)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnCancel.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnCancel.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnCancel.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCancel.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FadingSpeed = 0;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnCancel.Image = global::NvnTest.Employer.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnCancel.ImageOffset = 3;
            this.btnCancel.IsPressed = false;
            this.btnCancel.KeepPress = false;
            this.btnCancel.Location = new System.Drawing.Point(636, 376);
            this.btnCancel.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnCancel.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 8;
            this.btnCancel.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnCancel.SplitDistance = 0;
            this.btnCancel.TabIndex = 60;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Title = "";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnImport.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnImport.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnImport.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnImport.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnImport.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnImport.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnImport.FadingSpeed = 0;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.Black;
            this.btnImport.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnImport.Image = global::NvnTest.Employer.Properties.Resources.save;
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnImport.ImageOffset = 3;
            this.btnImport.IsPressed = false;
            this.btnImport.KeepPress = false;
            this.btnImport.Location = new System.Drawing.Point(530, 376);
            this.btnImport.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnImport.MenuPos = new System.Drawing.Point(0, 0);
            this.btnImport.Name = "btnImport";
            this.btnImport.Radius = 8;
            this.btnImport.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnImport.Size = new System.Drawing.Size(100, 30);
            this.btnImport.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnImport.SplitDistance = 0;
            this.btnImport.TabIndex = 59;
            this.btnImport.Text = "Import";
            this.btnImport.Title = "";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dgrQuestions
            // 
            this.dgrQuestions.AllowUserToAddRows = false;
            this.dgrQuestions.AllowUserToDeleteRows = false;
            this.dgrQuestions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrQuestions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrQuestions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectQuestionCol,
            this.DescCol,
            this.QuestionTypeCol});
            this.dgrQuestions.Location = new System.Drawing.Point(12, 12);
            this.dgrQuestions.MultiSelect = false;
            this.dgrQuestions.Name = "dgrQuestions";
            this.dgrQuestions.RowHeadersVisible = false;
            this.dgrQuestions.Size = new System.Drawing.Size(724, 358);
            this.dgrQuestions.TabIndex = 61;
            // 
            // SelectQuestionCol
            // 
            this.SelectQuestionCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SelectQuestionCol.HeaderText = "";
            this.SelectQuestionCol.Name = "SelectQuestionCol";
            this.SelectQuestionCol.Width = 30;
            // 
            // DescCol
            // 
            this.DescCol.HeaderText = "Description";
            this.DescCol.Name = "DescCol";
            this.DescCol.ReadOnly = true;
            // 
            // QuestionTypeCol
            // 
            this.QuestionTypeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.QuestionTypeCol.HeaderText = "Type";
            this.QuestionTypeCol.Name = "QuestionTypeCol";
            this.QuestionTypeCol.ReadOnly = true;
            this.QuestionTypeCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.QuestionTypeCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QuestionTypeCol.Width = 150;
            // 
            // ImportQuestionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(748, 418);
            this.Controls.Add(this.dgrQuestions);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ImportQuestionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import questions";
            ((System.ComponentModel.ISupportInitialize)(this.dgrQuestions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RibbonStyle.RibbonMenuButton btnCancel;
        private RibbonStyle.RibbonMenuButton btnImport;
        private System.Windows.Forms.DataGridView dgrQuestions;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectQuestionCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuestionTypeCol;
    }
}