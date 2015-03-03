namespace NvnTest.Employer {
    partial class ObjectiveQuestionItemCtrl {
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
            this.chkCorrectAnswer = new System.Windows.Forms.CheckBox();
            this.txtOptionText = new System.Windows.Forms.TextBox();
            this.lblOptionIndex = new System.Windows.Forms.Label();
            this.txtMarks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new RibbonStyle.RibbonMenuButton();
            this.btnDeleteOption = new RibbonStyle.RibbonMenuButton();
            this.SuspendLayout();
            // 
            // chkCorrectAnswer
            // 
            this.chkCorrectAnswer.AutoSize = true;
            this.chkCorrectAnswer.Location = new System.Drawing.Point(53, 87);
            this.chkCorrectAnswer.Name = "chkCorrectAnswer";
            this.chkCorrectAnswer.Size = new System.Drawing.Size(156, 17);
            this.chkCorrectAnswer.TabIndex = 9;
            this.chkCorrectAnswer.Text = "This is the correct answer ?";
            this.chkCorrectAnswer.UseVisualStyleBackColor = true;
            this.chkCorrectAnswer.CheckedChanged += new System.EventHandler(this.chkCorrectAnswer_CheckedChanged);
            // 
            // txtOptionText
            // 
            this.txtOptionText.Location = new System.Drawing.Point(53, 9);
            this.txtOptionText.Multiline = true;
            this.txtOptionText.Name = "txtOptionText";
            this.txtOptionText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOptionText.Size = new System.Drawing.Size(261, 72);
            this.txtOptionText.TabIndex = 6;
            // 
            // lblOptionIndex
            // 
            this.lblOptionIndex.AutoSize = true;
            this.lblOptionIndex.Location = new System.Drawing.Point(9, 11);
            this.lblOptionIndex.Name = "lblOptionIndex";
            this.lblOptionIndex.Size = new System.Drawing.Size(38, 13);
            this.lblOptionIndex.TabIndex = 5;
            this.lblOptionIndex.Text = "Option";
            // 
            // txtMarks
            // 
            this.txtMarks.Location = new System.Drawing.Point(259, 87);
            this.txtMarks.Name = "txtMarks";
            this.txtMarks.Size = new System.Drawing.Size(55, 20);
            this.txtMarks.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Marks";
            // 
            // btnClear
            // 
            this.btnClear.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClear.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnClear.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnClear.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnClear.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClear.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnClear.FadingSpeed = 0;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnClear.Image = global::NvnTest.Employer.Properties.Resources.clear;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnClear.ImageOffset = 3;
            this.btnClear.IsPressed = false;
            this.btnClear.KeepPress = false;
            this.btnClear.Location = new System.Drawing.Point(320, 3);
            this.btnClear.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClear.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Radius = 8;
            this.btnClear.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnClear.SplitDistance = 0;
            this.btnClear.TabIndex = 51;
            this.btnClear.Text = "Clear";
            this.btnClear.Title = "";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDeleteOption
            // 
            this.btnDeleteOption.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnDeleteOption.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteOption.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDeleteOption.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnDeleteOption.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnDeleteOption.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnDeleteOption.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDeleteOption.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDeleteOption.FadingSpeed = 0;
            this.btnDeleteOption.FlatAppearance.BorderSize = 0;
            this.btnDeleteOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteOption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteOption.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteOption.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnDeleteOption.Image = global::NvnTest.Employer.Properties.Resources.delete;
            this.btnDeleteOption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteOption.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnDeleteOption.ImageOffset = 3;
            this.btnDeleteOption.IsPressed = false;
            this.btnDeleteOption.KeepPress = false;
            this.btnDeleteOption.Location = new System.Drawing.Point(426, 3);
            this.btnDeleteOption.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnDeleteOption.MenuPos = new System.Drawing.Point(0, 0);
            this.btnDeleteOption.Name = "btnDeleteOption";
            this.btnDeleteOption.Radius = 8;
            this.btnDeleteOption.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnDeleteOption.Size = new System.Drawing.Size(118, 30);
            this.btnDeleteOption.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnDeleteOption.SplitDistance = 0;
            this.btnDeleteOption.TabIndex = 52;
            this.btnDeleteOption.Text = "Delete option";
            this.btnDeleteOption.Title = "";
            this.btnDeleteOption.UseVisualStyleBackColor = true;
            this.btnDeleteOption.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ObjectiveQuestionItemCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteOption);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtMarks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkCorrectAnswer);
            this.Controls.Add(this.txtOptionText);
            this.Controls.Add(this.lblOptionIndex);
            this.Name = "ObjectiveQuestionItemCtrl";
            this.Size = new System.Drawing.Size(547, 110);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCorrectAnswer;
        private System.Windows.Forms.TextBox txtOptionText;
        private System.Windows.Forms.Label lblOptionIndex;
        private System.Windows.Forms.TextBox txtMarks;
        private System.Windows.Forms.Label label2;
        private RibbonStyle.RibbonMenuButton btnClear;
        private RibbonStyle.RibbonMenuButton btnDeleteOption;

    }
}
