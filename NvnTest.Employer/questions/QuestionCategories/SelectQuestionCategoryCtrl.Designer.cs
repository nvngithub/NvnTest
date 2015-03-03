namespace NvnTest.Employer {
    partial class SelectQuestionCategoryCtrl {
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
            this.cmbQuestionCategories = new System.Windows.Forms.ComboBox();
            this.btnAdd = new RibbonStyle.RibbonMenuButton();
            this.pnlCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // cmbQuestionCategories
            // 
            this.cmbQuestionCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbQuestionCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestionCategories.FormattingEnabled = true;
            this.cmbQuestionCategories.Location = new System.Drawing.Point(3, 9);
            this.cmbQuestionCategories.Name = "cmbQuestionCategories";
            this.cmbQuestionCategories.Size = new System.Drawing.Size(210, 21);
            this.cmbQuestionCategories.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAdd.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnAdd.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAdd.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAdd.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAdd.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAdd.FadingSpeed = 0;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnAdd.Image = global::NvnTest.Employer.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnAdd.ImageOffset = 3;
            this.btnAdd.IsPressed = false;
            this.btnAdd.KeepPress = false;
            this.btnAdd.Location = new System.Drawing.Point(222, 3);
            this.btnAdd.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAdd.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Radius = 8;
            this.btnAdd.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnAdd.Size = new System.Drawing.Size(29, 30);
            this.btnAdd.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnAdd.SplitDistance = 0;
            this.btnAdd.TabIndex = 52;
            this.btnAdd.Text = "Add";
            this.btnAdd.Title = "";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlCategories
            // 
            this.pnlCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCategories.AutoScroll = true;
            this.pnlCategories.Location = new System.Drawing.Point(3, 39);
            this.pnlCategories.Name = "pnlCategories";
            this.pnlCategories.Size = new System.Drawing.Size(248, 285);
            this.pnlCategories.TabIndex = 53;
            // 
            // SelectQuestionCategoryCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCategories);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbQuestionCategories);
            this.Name = "SelectQuestionCategoryCtrl";
            this.Size = new System.Drawing.Size(254, 327);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbQuestionCategories;
        private RibbonStyle.RibbonMenuButton btnAdd;
        private System.Windows.Forms.FlowLayoutPanel pnlCategories;
    }
}
