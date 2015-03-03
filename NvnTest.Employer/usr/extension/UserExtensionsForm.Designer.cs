namespace NvnTest.Employer {
    partial class UserExtensionsForm {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserExtensionsForm));
            this.dgrUserExtensions = new System.Windows.Forms.DataGridView();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchedulesPrivilegeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PapersPrivilegeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuestionsPrivilegeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditCol = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DeleteCol = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnAddNewUser = new RibbonStyle.RibbonMenuButton();
            this.btnCancel = new RibbonStyle.RibbonMenuButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgrUserExtensions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrUserExtensions
            // 
            this.dgrUserExtensions.AllowUserToAddRows = false;
            this.dgrUserExtensions.AllowUserToDeleteRows = false;
            this.dgrUserExtensions.AllowUserToOrderColumns = true;
            this.dgrUserExtensions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrUserExtensions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrUserExtensions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameCol,
            this.EmailCol,
            this.SchedulesPrivilegeCol,
            this.PapersPrivilegeCol,
            this.QuestionsPrivilegeCol,
            this.EditCol,
            this.DeleteCol});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrUserExtensions.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrUserExtensions.Location = new System.Drawing.Point(12, 12);
            this.dgrUserExtensions.MultiSelect = false;
            this.dgrUserExtensions.Name = "dgrUserExtensions";
            this.dgrUserExtensions.ReadOnly = true;
            this.dgrUserExtensions.RowHeadersVisible = false;
            this.dgrUserExtensions.Size = new System.Drawing.Size(848, 293);
            this.dgrUserExtensions.TabIndex = 0;
            this.dgrUserExtensions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrUserExtensions_CellContentClick);
            // 
            // NameCol
            // 
            this.NameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NameCol.HeaderText = "Name";
            this.NameCol.Name = "NameCol";
            this.NameCol.ReadOnly = true;
            this.NameCol.Width = 150;
            // 
            // EmailCol
            // 
            this.EmailCol.HeaderText = "Email";
            this.EmailCol.Name = "EmailCol";
            this.EmailCol.ReadOnly = true;
            // 
            // SchedulesPrivilegeCol
            // 
            this.SchedulesPrivilegeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SchedulesPrivilegeCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.SchedulesPrivilegeCol.HeaderText = "Schedules Privilege";
            this.SchedulesPrivilegeCol.Name = "SchedulesPrivilegeCol";
            this.SchedulesPrivilegeCol.ReadOnly = true;
            this.SchedulesPrivilegeCol.Width = 130;
            // 
            // PapersPrivilegeCol
            // 
            this.PapersPrivilegeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PapersPrivilegeCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.PapersPrivilegeCol.HeaderText = "Papers Privilege";
            this.PapersPrivilegeCol.Name = "PapersPrivilegeCol";
            this.PapersPrivilegeCol.ReadOnly = true;
            this.PapersPrivilegeCol.Width = 120;
            // 
            // QuestionsPrivilegeCol
            // 
            this.QuestionsPrivilegeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.QuestionsPrivilegeCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.QuestionsPrivilegeCol.HeaderText = "Questions Privilege";
            this.QuestionsPrivilegeCol.Name = "QuestionsPrivilegeCol";
            this.QuestionsPrivilegeCol.ReadOnly = true;
            this.QuestionsPrivilegeCol.Width = 120;
            // 
            // EditCol
            // 
            this.EditCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EditCol.HeaderText = "Edit";
            this.EditCol.Name = "EditCol";
            this.EditCol.ReadOnly = true;
            this.EditCol.Width = 50;
            // 
            // DeleteCol
            // 
            this.DeleteCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DeleteCol.HeaderText = "Delete";
            this.DeleteCol.Name = "DeleteCol";
            this.DeleteCol.ReadOnly = true;
            this.DeleteCol.Width = 50;
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddNewUser.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnAddNewUser.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewUser.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddNewUser.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnAddNewUser.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAddNewUser.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAddNewUser.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddNewUser.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAddNewUser.FadingSpeed = 0;
            this.btnAddNewUser.FlatAppearance.BorderSize = 0;
            this.btnAddNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewUser.ForeColor = System.Drawing.Color.Black;
            this.btnAddNewUser.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnAddNewUser.Image = global::NvnTest.Employer.Properties.Resources.add;
            this.btnAddNewUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewUser.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnAddNewUser.ImageOffset = 3;
            this.btnAddNewUser.IsPressed = false;
            this.btnAddNewUser.KeepPress = false;
            this.btnAddNewUser.Location = new System.Drawing.Point(12, 311);
            this.btnAddNewUser.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAddNewUser.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Radius = 8;
            this.btnAddNewUser.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnAddNewUser.Size = new System.Drawing.Size(142, 30);
            this.btnAddNewUser.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnAddNewUser.SplitDistance = 0;
            this.btnAddNewUser.TabIndex = 50;
            this.btnAddNewUser.Text = "Add a new user";
            this.btnAddNewUser.Title = "";
            this.btnAddNewUser.UseVisualStyleBackColor = true;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(760, 311);
            this.btnCancel.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnCancel.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 8;
            this.btnCancel.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnCancel.SplitDistance = 0;
            this.btnCancel.TabIndex = 49;
            this.btnCancel.Text = "Close";
            this.btnCancel.Title = "";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // UserExtensionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(872, 353);
            this.Controls.Add(this.btnAddNewUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgrUserExtensions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserExtensionsForm";
            this.Text = "Users";
            ((System.ComponentModel.ISupportInitialize)(this.dgrUserExtensions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrUserExtensions;
        private RibbonStyle.RibbonMenuButton btnCancel;
        private RibbonStyle.RibbonMenuButton btnAddNewUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchedulesPrivilegeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PapersPrivilegeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuestionsPrivilegeCol;
        private System.Windows.Forms.DataGridViewLinkColumn EditCol;
        private System.Windows.Forms.DataGridViewLinkColumn DeleteCol;
    }
}