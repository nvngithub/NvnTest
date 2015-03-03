namespace NvnTest.Employer {
    partial class AddEditTestScheduleForm {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConfirmEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgrPapers = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtDuration = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new RibbonStyle.RibbonMenuButton();
            this.btnCancel = new RibbonStyle.RibbonMenuButton();
            this.numDaysLeft = new System.Windows.Forms.NumericUpDown();
            this.chkWebReference = new System.Windows.Forms.CheckBox();
            this.chkLiveImages = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PaperDescCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaperTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrPapers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDaysLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(129, 12);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(248, 20);
            this.txtFirstName.TabIndex = 3;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(129, 38);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(248, 20);
            this.txtLastName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last Name";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(129, 64);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(248, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Email Address";
            // 
            // txtConfirmEmail
            // 
            this.txtConfirmEmail.Location = new System.Drawing.Point(129, 90);
            this.txtConfirmEmail.Name = "txtConfirmEmail";
            this.txtConfirmEmail.Size = new System.Drawing.Size(248, 20);
            this.txtConfirmEmail.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Confirm Email Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Number of days left";
            // 
            // dgrPapers
            // 
            this.dgrPapers.AllowUserToAddRows = false;
            this.dgrPapers.AllowUserToDeleteRows = false;
            this.dgrPapers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrPapers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrPapers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrPapers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PaperDescCol,
            this.PaperTypeColumn});
            this.dgrPapers.Location = new System.Drawing.Point(12, 247);
            this.dgrPapers.Name = "dgrPapers";
            this.dgrPapers.ReadOnly = true;
            this.dgrPapers.RowHeadersVisible = false;
            this.dgrPapers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrPapers.Size = new System.Drawing.Size(365, 270);
            this.dgrPapers.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Select a paper from the following list";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Duration ( hour : minute )";
            // 
            // dtDuration
            // 
            this.dtDuration.CustomFormat = "HH:mm";
            this.dtDuration.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDuration.Location = new System.Drawing.Point(302, 116);
            this.dtDuration.Name = "dtDuration";
            this.dtDuration.ShowUpDown = true;
            this.dtDuration.Size = new System.Drawing.Size(59, 20);
            this.dtDuration.TabIndex = 21;
            this.dtDuration.Value = new System.DateTime(2011, 7, 13, 1, 0, 0, 0);
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
            this.btnSave.Location = new System.Drawing.Point(171, 523);
            this.btnSave.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSave.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 8;
            this.btnSave.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnSave.SplitDistance = 0;
            this.btnSave.TabIndex = 48;
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
            this.btnCancel.Location = new System.Drawing.Point(277, 523);
            this.btnCancel.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnCancel.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 8;
            this.btnCancel.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnCancel.SplitDistance = 0;
            this.btnCancel.TabIndex = 49;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Title = "";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // numDaysLeft
            // 
            this.numDaysLeft.Location = new System.Drawing.Point(129, 116);
            this.numDaysLeft.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numDaysLeft.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDaysLeft.Name = "numDaysLeft";
            this.numDaysLeft.Size = new System.Drawing.Size(38, 20);
            this.numDaysLeft.TabIndex = 10;
            this.numDaysLeft.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkWebReference
            // 
            this.chkWebReference.AutoSize = true;
            this.chkWebReference.Location = new System.Drawing.Point(129, 142);
            this.chkWebReference.Name = "chkWebReference";
            this.chkWebReference.Size = new System.Drawing.Size(126, 17);
            this.chkWebReference.TabIndex = 50;
            this.chkWebReference.Text = "Allow internet access";
            this.chkWebReference.UseVisualStyleBackColor = true;
            // 
            // chkLiveImages
            // 
            this.chkLiveImages.AutoSize = true;
            this.chkLiveImages.Location = new System.Drawing.Point(129, 165);
            this.chkLiveImages.Name = "chkLiveImages";
            this.chkLiveImages.Size = new System.Drawing.Size(116, 17);
            this.chkLiveImages.TabIndex = 51;
            this.chkLiveImages.Text = "Live image capture";
            this.chkLiveImages.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(126, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(251, 46);
            this.label8.TabIndex = 52;
            this.label8.Text = "Candidate is allowed to take test only if webcam is detected. We recommend you to" +
                " inform candidate about it explicitly.";
            // 
            // PaperDescCol
            // 
            this.PaperDescCol.HeaderText = "Paper Name";
            this.PaperDescCol.Name = "PaperDescCol";
            this.PaperDescCol.ReadOnly = true;
            // 
            // PaperTypeColumn
            // 
            this.PaperTypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PaperTypeColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.PaperTypeColumn.HeaderText = "Type";
            this.PaperTypeColumn.Name = "PaperTypeColumn";
            this.PaperTypeColumn.ReadOnly = true;
            // 
            // AddEditTestScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(390, 561);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkLiveImages);
            this.Controls.Add(this.chkWebReference);
            this.Controls.Add(this.numDaysLeft);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtDuration);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgrPapers);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtConfirmEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddEditTestScheduleForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Define test schedule";
            ((System.ComponentModel.ISupportInitialize)(this.dgrPapers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDaysLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConfirmEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgrPapers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtDuration;
        private RibbonStyle.RibbonMenuButton btnSave;
        private RibbonStyle.RibbonMenuButton btnCancel;
        private System.Windows.Forms.NumericUpDown numDaysLeft;
        private System.Windows.Forms.CheckBox chkWebReference;
        private System.Windows.Forms.CheckBox chkLiveImages;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaperDescCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaperTypeColumn;
    }
}