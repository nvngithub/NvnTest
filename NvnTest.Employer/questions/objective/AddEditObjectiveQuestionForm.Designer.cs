namespace NvnTest.Employer {
    partial class AddEditObjectiveQuestionForm {
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
            this.label2 = new System.Windows.Forms.Label();
            this.pnlOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new RibbonStyle.RibbonMenuButton();
            this.btnAddNewOption = new RibbonStyle.RibbonMenuButton();
            this.btnSave = new RibbonStyle.RibbonMenuButton();
            this.selectQuestionLevelCtrl1 = new NvnTest.Employer.SelectQuestionLevelCtrl();
            this.selectQuestionCategoryCtrl1 = new NvnTest.Employer.SelectQuestionCategoryCtrl();
            this.descriptionCtrl1 = new NvnTest.Employer.DescriptionCtrl();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Options";
            // 
            // pnlOptions
            // 
            this.pnlOptions.AutoScroll = true;
            this.pnlOptions.Location = new System.Drawing.Point(12, 152);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(579, 362);
            this.pnlOptions.TabIndex = 12;
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
            this.btnCancel.Image = global::NvnTest.Employer.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnCancel.ImageOffset = 3;
            this.btnCancel.IsPressed = false;
            this.btnCancel.KeepPress = false;
            this.btnCancel.Location = new System.Drawing.Point(773, 520);
            this.btnCancel.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnCancel.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 8;
            this.btnCancel.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnCancel.SplitDistance = 0;
            this.btnCancel.TabIndex = 52;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Title = "";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNewOption
            // 
            this.btnAddNewOption.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnAddNewOption.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewOption.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddNewOption.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnAddNewOption.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAddNewOption.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAddNewOption.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddNewOption.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAddNewOption.FadingSpeed = 0;
            this.btnAddNewOption.FlatAppearance.BorderSize = 0;
            this.btnAddNewOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewOption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewOption.ForeColor = System.Drawing.Color.Black;
            this.btnAddNewOption.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnAddNewOption.Image = global::NvnTest.Employer.Properties.Resources.add;
            this.btnAddNewOption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewOption.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnAddNewOption.ImageOffset = 3;
            this.btnAddNewOption.IsPressed = false;
            this.btnAddNewOption.KeepPress = false;
            this.btnAddNewOption.Location = new System.Drawing.Point(12, 520);
            this.btnAddNewOption.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAddNewOption.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAddNewOption.Name = "btnAddNewOption";
            this.btnAddNewOption.Radius = 8;
            this.btnAddNewOption.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnAddNewOption.Size = new System.Drawing.Size(134, 30);
            this.btnAddNewOption.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnAddNewOption.SplitDistance = 0;
            this.btnAddNewOption.TabIndex = 53;
            this.btnAddNewOption.Text = "Add new option";
            this.btnAddNewOption.Title = "";
            this.btnAddNewOption.UseVisualStyleBackColor = true;
            this.btnAddNewOption.Click += new System.EventHandler(this.btnAddNewOption_Click);
            // 
            // btnSave
            // 
            this.btnSave.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSave.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnSave.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnSave.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnSave.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSave.FadingSpeed = 0;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnSave.Image = global::NvnTest.Employer.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnSave.ImageOffset = 3;
            this.btnSave.IsPressed = false;
            this.btnSave.KeepPress = false;
            this.btnSave.Location = new System.Drawing.Point(667, 520);
            this.btnSave.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSave.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 8;
            this.btnSave.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnSave.SplitDistance = 0;
            this.btnSave.TabIndex = 51;
            this.btnSave.Text = "Save";
            this.btnSave.Title = "";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // selectQuestionLevelCtrl1
            // 
            this.selectQuestionLevelCtrl1.Location = new System.Drawing.Point(597, 31);
            this.selectQuestionLevelCtrl1.Name = "selectQuestionLevelCtrl1";
            this.selectQuestionLevelCtrl1.QuestionLevel = ((uint)(0u));
            this.selectQuestionLevelCtrl1.Size = new System.Drawing.Size(276, 40);
            this.selectQuestionLevelCtrl1.TabIndex = 55;
            // 
            // selectQuestionCategoryCtrl1
            // 
            this.selectQuestionCategoryCtrl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.selectQuestionCategoryCtrl1.Location = new System.Drawing.Point(600, 77);
            this.selectQuestionCategoryCtrl1.Name = "selectQuestionCategoryCtrl1";
            this.selectQuestionCategoryCtrl1.Size = new System.Drawing.Size(273, 437);
            this.selectQuestionCategoryCtrl1.TabIndex = 54;
            // 
            // descriptionCtrl1
            // 
            this.descriptionCtrl1.Description = "";
            this.descriptionCtrl1.Location = new System.Drawing.Point(12, 12);
            this.descriptionCtrl1.Name = "descriptionCtrl1";
            this.descriptionCtrl1.Size = new System.Drawing.Size(579, 121);
            this.descriptionCtrl1.TabIndex = 14;
            // 
            // AddEditObjectiveQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(885, 562);
            this.Controls.Add(this.selectQuestionLevelCtrl1);
            this.Controls.Add(this.selectQuestionCategoryCtrl1);
            this.Controls.Add(this.btnAddNewOption);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.descriptionCtrl1);
            this.Controls.Add(this.pnlOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddEditObjectiveQuestionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit objective question";
            this.Load += new System.EventHandler(this.AddEditObjectiveQuestionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel pnlOptions;
        private DescriptionCtrl descriptionCtrl1;
        private RibbonStyle.RibbonMenuButton btnCancel;
        private RibbonStyle.RibbonMenuButton btnSave;
        private RibbonStyle.RibbonMenuButton btnAddNewOption;
        private SelectQuestionCategoryCtrl selectQuestionCategoryCtrl1;
        private SelectQuestionLevelCtrl selectQuestionLevelCtrl1;
    }
}