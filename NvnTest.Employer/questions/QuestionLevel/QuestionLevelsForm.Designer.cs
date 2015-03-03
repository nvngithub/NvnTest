namespace NvnTest.Employer {
    partial class QuestionLevelsForm {
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionLevelsForm));
            this.btnCancel = new RibbonStyle.RibbonMenuButton();
            this.btnAddNewCategory = new RibbonStyle.RibbonMenuButton();
            this.dgrQuestionLevels = new System.Windows.Forms.DataGridView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrQuestionLevels)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
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
            this.btnCancel.Image = global::NvnTest.Employer.Properties.Resources.select;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnCancel.ImageOffset = 3;
            this.btnCancel.IsPressed = false;
            this.btnCancel.KeepPress = false;
            this.btnCancel.Location = new System.Drawing.Point(453, 269);
            this.btnCancel.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnCancel.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 8;
            this.btnCancel.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnCancel.Size = new System.Drawing.Size(92, 30);
            this.btnCancel.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnCancel.SplitDistance = 0;
            this.btnCancel.TabIndex = 60;
            this.btnCancel.Text = "OK";
            this.btnCancel.Title = "";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddNewCategory
            // 
            this.btnAddNewCategory.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnAddNewCategory.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewCategory.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddNewCategory.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnAddNewCategory.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAddNewCategory.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAddNewCategory.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddNewCategory.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAddNewCategory.FadingSpeed = 0;
            this.btnAddNewCategory.FlatAppearance.BorderSize = 0;
            this.btnAddNewCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewCategory.ForeColor = System.Drawing.Color.Black;
            this.btnAddNewCategory.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnAddNewCategory.Image = global::NvnTest.Employer.Properties.Resources.add;
            this.btnAddNewCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewCategory.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnAddNewCategory.ImageOffset = 3;
            this.btnAddNewCategory.IsPressed = false;
            this.btnAddNewCategory.KeepPress = false;
            this.btnAddNewCategory.Location = new System.Drawing.Point(12, 269);
            this.btnAddNewCategory.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAddNewCategory.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAddNewCategory.Name = "btnAddNewCategory";
            this.btnAddNewCategory.Radius = 8;
            this.btnAddNewCategory.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnAddNewCategory.Size = new System.Drawing.Size(122, 30);
            this.btnAddNewCategory.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnAddNewCategory.SplitDistance = 0;
            this.btnAddNewCategory.TabIndex = 59;
            this.btnAddNewCategory.Text = "Add new level";
            this.btnAddNewCategory.Title = "";
            this.btnAddNewCategory.UseVisualStyleBackColor = true;
            this.btnAddNewCategory.Click += new System.EventHandler(this.btnAddNewLevel_Click);
            // 
            // dgrQuestionLevels
            // 
            this.dgrQuestionLevels.AllowUserToAddRows = false;
            this.dgrQuestionLevels.AllowUserToDeleteRows = false;
            this.dgrQuestionLevels.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrQuestionLevels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrQuestionLevels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DescriptionColumn,
            this.EditColumn,
            this.DeleteColumn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrQuestionLevels.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrQuestionLevels.Location = new System.Drawing.Point(12, 12);
            this.dgrQuestionLevels.Name = "dgrQuestionLevels";
            this.dgrQuestionLevels.RowHeadersVisible = false;
            this.dgrQuestionLevels.Size = new System.Drawing.Size(533, 251);
            this.dgrQuestionLevels.TabIndex = 58;
            this.dgrQuestionLevels.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrQuestionLevels_CellClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "edit-16.png");
            this.imageList.Images.SetKeyName(1, "delete-16.png");
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.HeaderText = "Description";
            this.DescriptionColumn.Name = "DescriptionColumn";
            // 
            // EditColumn
            // 
            this.EditColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EditColumn.HeaderText = "Edit";
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.Width = 50;
            // 
            // DeleteColumn
            // 
            this.DeleteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DeleteColumn.HeaderText = "Delete";
            this.DeleteColumn.Name = "DeleteColumn";
            this.DeleteColumn.Width = 50;
            // 
            // QuestionLevelsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(556, 305);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddNewCategory);
            this.Controls.Add(this.dgrQuestionLevels);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuestionLevelsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Question levels";
            ((System.ComponentModel.ISupportInitialize)(this.dgrQuestionLevels)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RibbonStyle.RibbonMenuButton btnCancel;
        private RibbonStyle.RibbonMenuButton btnAddNewCategory;
        private System.Windows.Forms.DataGridView dgrQuestionLevels;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
        private System.Windows.Forms.DataGridViewImageColumn EditColumn;
        private System.Windows.Forms.DataGridViewImageColumn DeleteColumn;
    }
}