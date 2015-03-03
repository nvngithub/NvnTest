namespace NvnTest.Employer {
    partial class AutoPaperConfigItemCtrl {
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuestionsCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDifficultyLevel = new System.Windows.Forms.ComboBox();
            this.btnDelete = new RibbonStyle.RibbonMenuButton();
            this.cmbQuestionCategories = new System.Windows.Forms.ComboBox();
            this.rbMCQ = new System.Windows.Forms.RadioButton();
            this.rbProgramming = new System.Windows.Forms.RadioButton();
            this.rbWebProgramming = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of questions";
            // 
            // txtQuestionsCount
            // 
            this.txtQuestionsCount.Location = new System.Drawing.Point(113, 26);
            this.txtQuestionsCount.Name = "txtQuestionsCount";
            this.txtQuestionsCount.Size = new System.Drawing.Size(246, 20);
            this.txtQuestionsCount.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Question category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Difficulty level";
            // 
            // cmbDifficultyLevel
            // 
            this.cmbDifficultyLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDifficultyLevel.FormattingEnabled = true;
            this.cmbDifficultyLevel.Location = new System.Drawing.Point(113, 52);
            this.cmbDifficultyLevel.Name = "cmbDifficultyLevel";
            this.cmbDifficultyLevel.Size = new System.Drawing.Size(246, 21);
            this.cmbDifficultyLevel.TabIndex = 7;
            // 
            // btnDelete
            // 
            this.btnDelete.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDelete.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnDelete.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnDelete.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnDelete.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDelete.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDelete.FadingSpeed = 0;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnDelete.Image = global::NvnTest.Employer.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnDelete.ImageOffset = 3;
            this.btnDelete.IsPressed = false;
            this.btnDelete.KeepPress = false;
            this.btnDelete.Location = new System.Drawing.Point(380, 3);
            this.btnDelete.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnDelete.MenuPos = new System.Drawing.Point(0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Radius = 8;
            this.btnDelete.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnDelete.Size = new System.Drawing.Size(32, 30);
            this.btnDelete.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnDelete.SplitDistance = 0;
            this.btnDelete.TabIndex = 53;
            this.btnDelete.Title = "";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbQuestionCategories
            // 
            this.cmbQuestionCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestionCategories.FormattingEnabled = true;
            this.cmbQuestionCategories.Location = new System.Drawing.Point(113, 79);
            this.cmbQuestionCategories.Name = "cmbQuestionCategories";
            this.cmbQuestionCategories.Size = new System.Drawing.Size(246, 21);
            this.cmbQuestionCategories.TabIndex = 54;
            // 
            // rbMCQ
            // 
            this.rbMCQ.AutoSize = true;
            this.rbMCQ.Checked = true;
            this.rbMCQ.Location = new System.Drawing.Point(3, 3);
            this.rbMCQ.Name = "rbMCQ";
            this.rbMCQ.Size = new System.Drawing.Size(144, 17);
            this.rbMCQ.TabIndex = 55;
            this.rbMCQ.TabStop = true;
            this.rbMCQ.Text = "Multiple choice questions";
            this.rbMCQ.UseVisualStyleBackColor = true;
            // 
            // rbProgramming
            // 
            this.rbProgramming.AutoSize = true;
            this.rbProgramming.Location = new System.Drawing.Point(153, 3);
            this.rbProgramming.Name = "rbProgramming";
            this.rbProgramming.Size = new System.Drawing.Size(86, 17);
            this.rbProgramming.TabIndex = 56;
            this.rbProgramming.Text = "Programming";
            this.rbProgramming.UseVisualStyleBackColor = true;
            // 
            // rbWebProgramming
            // 
            this.rbWebProgramming.AutoSize = true;
            this.rbWebProgramming.Location = new System.Drawing.Point(245, 3);
            this.rbWebProgramming.Name = "rbWebProgramming";
            this.rbWebProgramming.Size = new System.Drawing.Size(111, 17);
            this.rbWebProgramming.TabIndex = 57;
            this.rbWebProgramming.Text = "Web programming";
            this.rbWebProgramming.UseVisualStyleBackColor = true;
            // 
            // AutoPaperConfigItemCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbWebProgramming);
            this.Controls.Add(this.rbProgramming);
            this.Controls.Add(this.rbMCQ);
            this.Controls.Add(this.cmbQuestionCategories);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cmbDifficultyLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuestionsCount);
            this.Controls.Add(this.label1);
            this.Name = "AutoPaperConfigItemCtrl";
            this.Size = new System.Drawing.Size(415, 112);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuestionsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDifficultyLevel;
        private RibbonStyle.RibbonMenuButton btnDelete;
        private System.Windows.Forms.ComboBox cmbQuestionCategories;
        private System.Windows.Forms.RadioButton rbMCQ;
        private System.Windows.Forms.RadioButton rbProgramming;
        private System.Windows.Forms.RadioButton rbWebProgramming;
    }
}
