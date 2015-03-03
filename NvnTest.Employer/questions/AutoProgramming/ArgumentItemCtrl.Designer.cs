namespace NvnTest.Employer {
    partial class ArgumentItemCtrl {
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
            this.cmbValueType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnDeleteArgument = new RibbonStyle.RibbonMenuButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Type";
            // 
            // cmbValueType
            // 
            this.cmbValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbValueType.FormattingEnabled = true;
            this.cmbValueType.Location = new System.Drawing.Point(52, 4);
            this.cmbValueType.Name = "cmbValueType";
            this.cmbValueType.Size = new System.Drawing.Size(176, 21);
            this.cmbValueType.TabIndex = 56;
            this.cmbValueType.SelectedValueChanged += new System.EventHandler(this.cmbValueType_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(52, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(176, 20);
            this.txtName.TabIndex = 58;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // btnDeleteArgument
            // 
            this.btnDeleteArgument.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnDeleteArgument.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteArgument.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDeleteArgument.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnDeleteArgument.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnDeleteArgument.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnDeleteArgument.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDeleteArgument.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDeleteArgument.FadingSpeed = 0;
            this.btnDeleteArgument.FlatAppearance.BorderSize = 0;
            this.btnDeleteArgument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteArgument.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteArgument.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteArgument.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnDeleteArgument.Image = global::NvnTest.Employer.Properties.Resources.delete;
            this.btnDeleteArgument.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteArgument.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnDeleteArgument.ImageOffset = 3;
            this.btnDeleteArgument.IsPressed = false;
            this.btnDeleteArgument.KeepPress = false;
            this.btnDeleteArgument.Location = new System.Drawing.Point(234, 12);
            this.btnDeleteArgument.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnDeleteArgument.MenuPos = new System.Drawing.Point(0, 0);
            this.btnDeleteArgument.Name = "btnDeleteArgument";
            this.btnDeleteArgument.Radius = 8;
            this.btnDeleteArgument.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnDeleteArgument.Size = new System.Drawing.Size(29, 30);
            this.btnDeleteArgument.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnDeleteArgument.SplitDistance = 0;
            this.btnDeleteArgument.TabIndex = 59;
            this.btnDeleteArgument.Text = "Add argument";
            this.btnDeleteArgument.Title = "";
            this.btnDeleteArgument.UseVisualStyleBackColor = true;
            this.btnDeleteArgument.Click += new System.EventHandler(this.btnDeleteArgument_Click);
            // 
            // ArgumentItemCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteArgument);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbValueType);
            this.Controls.Add(this.label1);
            this.Name = "ArgumentItemCtrl";
            this.Size = new System.Drawing.Size(268, 55);
            this.Load += new System.EventHandler(this.ArgumentItemCtrl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbValueType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private RibbonStyle.RibbonMenuButton btnDeleteArgument;
    }
}
