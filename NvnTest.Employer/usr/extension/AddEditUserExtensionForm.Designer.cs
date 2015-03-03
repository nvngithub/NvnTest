namespace NvnTest.Employer {
    partial class AddEditUserExtensionForm {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSchedulePrivilegeViewOnly = new System.Windows.Forms.RadioButton();
            this.rbSchedulePrivilegeNone = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbPapersPrivilegeAddEdit = new System.Windows.Forms.RadioButton();
            this.rbPapersPrivilegeViewOnly = new System.Windows.Forms.RadioButton();
            this.rbPapersPrivilegeNone = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbQuestionsPrivilegeAddEdit = new System.Windows.Forms.RadioButton();
            this.rbQuestionsPrivilegeViewOnly = new System.Windows.Forms.RadioButton();
            this.rbQuestionsPrivilegeNone = new System.Windows.Forms.RadioButton();
            this.btnSetPassword = new RibbonStyle.RibbonMenuButton();
            this.btnSave = new RibbonStyle.RibbonMenuButton();
            this.btnCancel = new RibbonStyle.RibbonMenuButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Note";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Email Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Password";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(82, 12);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(133, 20);
            this.txtFirstName.TabIndex = 56;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(82, 38);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(353, 38);
            this.txtNote.TabIndex = 57;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(82, 82);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(353, 20);
            this.txtEmail.TabIndex = 58;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(82, 114);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(229, 20);
            this.txtPassword.TabIndex = 59;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSchedulePrivilegeViewOnly);
            this.groupBox1.Controls.Add(this.rbSchedulePrivilegeNone);
            this.groupBox1.Location = new System.Drawing.Point(82, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 50);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test schedule privilege";
            // 
            // rbSchedulePrivilegeViewOnly
            // 
            this.rbSchedulePrivilegeViewOnly.AutoSize = true;
            this.rbSchedulePrivilegeViewOnly.Location = new System.Drawing.Point(102, 19);
            this.rbSchedulePrivilegeViewOnly.Name = "rbSchedulePrivilegeViewOnly";
            this.rbSchedulePrivilegeViewOnly.Size = new System.Drawing.Size(70, 17);
            this.rbSchedulePrivilegeViewOnly.TabIndex = 1;
            this.rbSchedulePrivilegeViewOnly.Text = "View only";
            this.rbSchedulePrivilegeViewOnly.UseVisualStyleBackColor = true;
            // 
            // rbSchedulePrivilegeNone
            // 
            this.rbSchedulePrivilegeNone.AutoSize = true;
            this.rbSchedulePrivilegeNone.Checked = true;
            this.rbSchedulePrivilegeNone.Location = new System.Drawing.Point(6, 19);
            this.rbSchedulePrivilegeNone.Name = "rbSchedulePrivilegeNone";
            this.rbSchedulePrivilegeNone.Size = new System.Drawing.Size(51, 17);
            this.rbSchedulePrivilegeNone.TabIndex = 0;
            this.rbSchedulePrivilegeNone.TabStop = true;
            this.rbSchedulePrivilegeNone.Text = "None";
            this.rbSchedulePrivilegeNone.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbPapersPrivilegeAddEdit);
            this.groupBox2.Controls.Add(this.rbPapersPrivilegeViewOnly);
            this.groupBox2.Controls.Add(this.rbPapersPrivilegeNone);
            this.groupBox2.Location = new System.Drawing.Point(82, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 50);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Papers privilege";
            // 
            // rbPapersPrivilegeAddEdit
            // 
            this.rbPapersPrivilegeAddEdit.AutoSize = true;
            this.rbPapersPrivilegeAddEdit.Location = new System.Drawing.Point(198, 17);
            this.rbPapersPrivilegeAddEdit.Name = "rbPapersPrivilegeAddEdit";
            this.rbPapersPrivilegeAddEdit.Size = new System.Drawing.Size(149, 17);
            this.rbPapersPrivilegeAddEdit.TabIndex = 5;
            this.rbPapersPrivilegeAddEdit.Text = "View / Add / Edit / Delete";
            this.rbPapersPrivilegeAddEdit.UseVisualStyleBackColor = true;
            // 
            // rbPapersPrivilegeViewOnly
            // 
            this.rbPapersPrivilegeViewOnly.AutoSize = true;
            this.rbPapersPrivilegeViewOnly.Location = new System.Drawing.Point(102, 17);
            this.rbPapersPrivilegeViewOnly.Name = "rbPapersPrivilegeViewOnly";
            this.rbPapersPrivilegeViewOnly.Size = new System.Drawing.Size(70, 17);
            this.rbPapersPrivilegeViewOnly.TabIndex = 4;
            this.rbPapersPrivilegeViewOnly.Text = "View only";
            this.rbPapersPrivilegeViewOnly.UseVisualStyleBackColor = true;
            // 
            // rbPapersPrivilegeNone
            // 
            this.rbPapersPrivilegeNone.AutoSize = true;
            this.rbPapersPrivilegeNone.Checked = true;
            this.rbPapersPrivilegeNone.Location = new System.Drawing.Point(6, 17);
            this.rbPapersPrivilegeNone.Name = "rbPapersPrivilegeNone";
            this.rbPapersPrivilegeNone.Size = new System.Drawing.Size(51, 17);
            this.rbPapersPrivilegeNone.TabIndex = 3;
            this.rbPapersPrivilegeNone.TabStop = true;
            this.rbPapersPrivilegeNone.Text = "None";
            this.rbPapersPrivilegeNone.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbQuestionsPrivilegeAddEdit);
            this.groupBox3.Controls.Add(this.rbQuestionsPrivilegeViewOnly);
            this.groupBox3.Controls.Add(this.rbQuestionsPrivilegeNone);
            this.groupBox3.Location = new System.Drawing.Point(82, 252);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(353, 50);
            this.groupBox3.TabIndex = 62;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Questions privilege";
            // 
            // rbQuestionsPrivilegeAddEdit
            // 
            this.rbQuestionsPrivilegeAddEdit.AutoSize = true;
            this.rbQuestionsPrivilegeAddEdit.Location = new System.Drawing.Point(198, 17);
            this.rbQuestionsPrivilegeAddEdit.Name = "rbQuestionsPrivilegeAddEdit";
            this.rbQuestionsPrivilegeAddEdit.Size = new System.Drawing.Size(149, 17);
            this.rbQuestionsPrivilegeAddEdit.TabIndex = 5;
            this.rbQuestionsPrivilegeAddEdit.Text = "View / Add / Edit / Delete";
            this.rbQuestionsPrivilegeAddEdit.UseVisualStyleBackColor = true;
            // 
            // rbQuestionsPrivilegeViewOnly
            // 
            this.rbQuestionsPrivilegeViewOnly.AutoSize = true;
            this.rbQuestionsPrivilegeViewOnly.Location = new System.Drawing.Point(102, 17);
            this.rbQuestionsPrivilegeViewOnly.Name = "rbQuestionsPrivilegeViewOnly";
            this.rbQuestionsPrivilegeViewOnly.Size = new System.Drawing.Size(70, 17);
            this.rbQuestionsPrivilegeViewOnly.TabIndex = 4;
            this.rbQuestionsPrivilegeViewOnly.Text = "View only";
            this.rbQuestionsPrivilegeViewOnly.UseVisualStyleBackColor = true;
            // 
            // rbQuestionsPrivilegeNone
            // 
            this.rbQuestionsPrivilegeNone.AutoSize = true;
            this.rbQuestionsPrivilegeNone.Checked = true;
            this.rbQuestionsPrivilegeNone.Location = new System.Drawing.Point(6, 17);
            this.rbQuestionsPrivilegeNone.Name = "rbQuestionsPrivilegeNone";
            this.rbQuestionsPrivilegeNone.Size = new System.Drawing.Size(51, 17);
            this.rbQuestionsPrivilegeNone.TabIndex = 3;
            this.rbQuestionsPrivilegeNone.TabStop = true;
            this.rbQuestionsPrivilegeNone.Text = "None";
            this.rbQuestionsPrivilegeNone.UseVisualStyleBackColor = true;
            // 
            // btnSetPassword
            // 
            this.btnSetPassword.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnSetPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnSetPassword.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSetPassword.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnSetPassword.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnSetPassword.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnSetPassword.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSetPassword.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSetPassword.FadingSpeed = 0;
            this.btnSetPassword.FlatAppearance.BorderSize = 0;
            this.btnSetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetPassword.ForeColor = System.Drawing.Color.Black;
            this.btnSetPassword.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnSetPassword.Image = global::NvnTest.Employer.Properties.Resources.login;
            this.btnSetPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetPassword.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnSetPassword.ImageOffset = 3;
            this.btnSetPassword.IsPressed = false;
            this.btnSetPassword.KeepPress = false;
            this.btnSetPassword.Location = new System.Drawing.Point(317, 108);
            this.btnSetPassword.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSetPassword.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSetPassword.Name = "btnSetPassword";
            this.btnSetPassword.Radius = 8;
            this.btnSetPassword.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnSetPassword.Size = new System.Drawing.Size(118, 30);
            this.btnSetPassword.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnSetPassword.SplitDistance = 0;
            this.btnSetPassword.TabIndex = 60;
            this.btnSetPassword.Text = "Set password";
            this.btnSetPassword.Title = "";
            this.btnSetPassword.UseVisualStyleBackColor = true;
            this.btnSetPassword.Click += new System.EventHandler(this.btnSetPassword_Click);
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
            this.btnSave.Location = new System.Drawing.Point(235, 314);
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
            this.btnCancel.Location = new System.Drawing.Point(341, 314);
            this.btnCancel.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnCancel.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 8;
            this.btnCancel.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnCancel.SplitDistance = 0;
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Title = "";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(285, 12);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(150, 20);
            this.txtLastName.TabIndex = 64;
            // 
            // AddEditUserExtensionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(453, 356);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSetPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddEditUserExtensionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit User";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RibbonStyle.RibbonMenuButton btnCancel;
        private RibbonStyle.RibbonMenuButton btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private RibbonStyle.RibbonMenuButton btnSetPassword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSchedulePrivilegeViewOnly;
        private System.Windows.Forms.RadioButton rbSchedulePrivilegeNone;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbPapersPrivilegeAddEdit;
        private System.Windows.Forms.RadioButton rbPapersPrivilegeViewOnly;
        private System.Windows.Forms.RadioButton rbPapersPrivilegeNone;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbQuestionsPrivilegeAddEdit;
        private System.Windows.Forms.RadioButton rbQuestionsPrivilegeViewOnly;
        private System.Windows.Forms.RadioButton rbQuestionsPrivilegeNone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLastName;
    }
}