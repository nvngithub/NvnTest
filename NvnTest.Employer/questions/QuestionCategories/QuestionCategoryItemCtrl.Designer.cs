namespace NvnTest.Employer {
    partial class QuestionCategoryItemCtrl {
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
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.btnUnselectCategory = new RibbonStyle.RibbonMenuButton();
            this.SuspendLayout();
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryName.Location = new System.Drawing.Point(3, 8);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(57, 13);
            this.lblCategoryName.TabIndex = 0;
            this.lblCategoryName.Text = "Category";
            // 
            // btnUnselectCategory
            // 
            this.btnUnselectCategory.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnUnselectCategory.BackColor = System.Drawing.Color.Transparent;
            this.btnUnselectCategory.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUnselectCategory.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnUnselectCategory.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnUnselectCategory.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnUnselectCategory.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnUnselectCategory.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnUnselectCategory.FadingSpeed = 0;
            this.btnUnselectCategory.FlatAppearance.BorderSize = 0;
            this.btnUnselectCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnselectCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnselectCategory.ForeColor = System.Drawing.Color.Black;
            this.btnUnselectCategory.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnUnselectCategory.Image = global::NvnTest.Employer.Properties.Resources.delete_16;
            this.btnUnselectCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnselectCategory.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnUnselectCategory.ImageOffset = 3;
            this.btnUnselectCategory.IsPressed = false;
            this.btnUnselectCategory.KeepPress = false;
            this.btnUnselectCategory.Location = new System.Drawing.Point(210, 3);
            this.btnUnselectCategory.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnUnselectCategory.MenuPos = new System.Drawing.Point(0, 0);
            this.btnUnselectCategory.Name = "btnUnselectCategory";
            this.btnUnselectCategory.Radius = 8;
            this.btnUnselectCategory.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnUnselectCategory.Size = new System.Drawing.Size(22, 22);
            this.btnUnselectCategory.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnUnselectCategory.SplitDistance = 0;
            this.btnUnselectCategory.TabIndex = 53;
            this.btnUnselectCategory.Text = "Add";
            this.btnUnselectCategory.Title = "";
            this.btnUnselectCategory.UseVisualStyleBackColor = true;
            this.btnUnselectCategory.Click += new System.EventHandler(this.btnUnselectCategory_Click);
            // 
            // QuestionCategoryItemCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUnselectCategory);
            this.Controls.Add(this.lblCategoryName);
            this.Name = "QuestionCategoryItemCtrl";
            this.Size = new System.Drawing.Size(235, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategoryName;
        private RibbonStyle.RibbonMenuButton btnUnselectCategory;
    }
}
