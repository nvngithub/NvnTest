namespace NvnTest.Employer {
    partial class SchedulesCtrl {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrTestSchedules = new System.Windows.Forms.DataGridView();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScheduleDateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpiryDateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViewResultCol = new System.Windows.Forms.DataGridViewLinkColumn();
            this.EditCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.DeleteCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblTestsAvailable = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUtcTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIndex = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkSubmitted = new System.Windows.Forms.CheckBox();
            this.chkTaken = new System.Windows.Forms.CheckBox();
            this.chkExpired = new System.Windows.Forms.CheckBox();
            this.chkScheduled = new System.Windows.Forms.CheckBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnBulkSchedule = new RibbonStyle.RibbonMenuButton();
            this.pbFirst = new System.Windows.Forms.PictureBox();
            this.pbPrevious = new System.Windows.Forms.PictureBox();
            this.pbNext = new System.Windows.Forms.PictureBox();
            this.pbLast = new System.Windows.Forms.PictureBox();
            this.btnRefreshTestsAvailable = new RibbonStyle.RibbonMenuButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAssignToYourself = new RibbonStyle.RibbonMenuButton();
            this.btnCreateTestSchedule = new RibbonStyle.RibbonMenuButton();
            this.chkDisqualified = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgrTestSchedules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrTestSchedules
            // 
            this.dgrTestSchedules.AllowUserToAddRows = false;
            this.dgrTestSchedules.AllowUserToDeleteRows = false;
            this.dgrTestSchedules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrTestSchedules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrTestSchedules.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrTestSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrTestSchedules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameCol,
            this.EmailCol,
            this.ScheduleDateCol,
            this.ExpiryDateCol,
            this.StatusCol,
            this.ViewResultCol,
            this.EditCol,
            this.DeleteCol});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrTestSchedules.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgrTestSchedules.Location = new System.Drawing.Point(3, 26);
            this.dgrTestSchedules.Name = "dgrTestSchedules";
            this.dgrTestSchedules.ReadOnly = true;
            this.dgrTestSchedules.RowHeadersVisible = false;
            this.dgrTestSchedules.Size = new System.Drawing.Size(1165, 339);
            this.dgrTestSchedules.TabIndex = 0;
            this.dgrTestSchedules.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrTestSchedules_CellDoubleClick);
            this.dgrTestSchedules.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrTestSchedules_CellContentClick);
            // 
            // NameCol
            // 
            this.NameCol.FillWeight = 19.12269F;
            this.NameCol.HeaderText = "Name";
            this.NameCol.Name = "NameCol";
            this.NameCol.ReadOnly = true;
            // 
            // EmailCol
            // 
            this.EmailCol.FillWeight = 19.12269F;
            this.EmailCol.HeaderText = "Email";
            this.EmailCol.Name = "EmailCol";
            this.EmailCol.ReadOnly = true;
            // 
            // ScheduleDateCol
            // 
            this.ScheduleDateCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ScheduleDateCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.ScheduleDateCol.FillWeight = 236.561F;
            this.ScheduleDateCol.HeaderText = "Test Schedule Date (UTC)";
            this.ScheduleDateCol.Name = "ScheduleDateCol";
            this.ScheduleDateCol.ReadOnly = true;
            this.ScheduleDateCol.Width = 200;
            // 
            // ExpiryDateCol
            // 
            this.ExpiryDateCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExpiryDateCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.ExpiryDateCol.HeaderText = "Test Expiry Date (UTC)";
            this.ExpiryDateCol.Name = "ExpiryDateCol";
            this.ExpiryDateCol.ReadOnly = true;
            this.ExpiryDateCol.Width = 150;
            // 
            // StatusCol
            // 
            this.StatusCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.StatusCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.StatusCol.HeaderText = "Status";
            this.StatusCol.Name = "StatusCol";
            this.StatusCol.ReadOnly = true;
            // 
            // ViewResultCol
            // 
            this.ViewResultCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ViewResultCol.DefaultCellStyle = dataGridViewCellStyle5;
            this.ViewResultCol.HeaderText = "View Result";
            this.ViewResultCol.Name = "ViewResultCol";
            this.ViewResultCol.ReadOnly = true;
            this.ViewResultCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ViewResultCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // EditCol
            // 
            this.EditCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EditCol.FillWeight = 170.068F;
            this.EditCol.HeaderText = "Edit";
            this.EditCol.Image = global::NvnTest.Employer.Properties.Resources.edit_16;
            this.EditCol.Name = "EditCol";
            this.EditCol.ReadOnly = true;
            this.EditCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EditCol.Width = 50;
            // 
            // DeleteCol
            // 
            this.DeleteCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DeleteCol.FillWeight = 82.48299F;
            this.DeleteCol.HeaderText = "Delete";
            this.DeleteCol.Image = global::NvnTest.Employer.Properties.Resources.delete_16;
            this.DeleteCol.Name = "DeleteCol";
            this.DeleteCol.ReadOnly = true;
            this.DeleteCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteCol.Width = 50;
            // 
            // lblTestsAvailable
            // 
            this.lblTestsAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTestsAvailable.AutoSize = true;
            this.lblTestsAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestsAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTestsAvailable.Location = new System.Drawing.Point(600, 381);
            this.lblTestsAvailable.Name = "lblTestsAvailable";
            this.lblTestsAvailable.Size = new System.Drawing.Size(14, 13);
            this.lblTestsAvailable.TabIndex = 2;
            this.lblTestsAvailable.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(954, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "UTC Time: ";
            // 
            // lblUtcTime
            // 
            this.lblUtcTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUtcTime.AutoSize = true;
            this.lblUtcTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUtcTime.ForeColor = System.Drawing.Color.Purple;
            this.lblUtcTime.Location = new System.Drawing.Point(1017, 380);
            this.lblUtcTime.Name = "lblUtcTime";
            this.lblUtcTime.Size = new System.Drawing.Size(151, 13);
            this.lblUtcTime.TabIndex = 57;
            this.lblUtcTime.Text = "dd-MMM-yyyy hh:mm:ss tt";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(988, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 10);
            this.label3.TabIndex = 59;
            this.label3.Text = "Based on your system time and time zone.";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(474, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Number of tests availbale: ";
            // 
            // lblIndex
            // 
            this.lblIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIndex.AutoSize = true;
            this.lblIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndex.ForeColor = System.Drawing.Color.Maroon;
            this.lblIndex.Location = new System.Drawing.Point(836, 380);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(14, 13);
            this.lblIndex.TabIndex = 66;
            this.lblIndex.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(712, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Filter";
            // 
            // chkAll
            // 
            this.chkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(753, 4);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(37, 17);
            this.chkAll.TabIndex = 68;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkSubmitted
            // 
            this.chkSubmitted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSubmitted.AutoSize = true;
            this.chkSubmitted.Checked = true;
            this.chkSubmitted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSubmitted.Location = new System.Drawing.Point(796, 4);
            this.chkSubmitted.Name = "chkSubmitted";
            this.chkSubmitted.Size = new System.Drawing.Size(73, 17);
            this.chkSubmitted.TabIndex = 69;
            this.chkSubmitted.Text = "Submitted";
            this.chkSubmitted.UseVisualStyleBackColor = true;
            this.chkSubmitted.CheckedChanged += new System.EventHandler(this.FilterOption_Checked);
            // 
            // chkTaken
            // 
            this.chkTaken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTaken.AutoSize = true;
            this.chkTaken.Checked = true;
            this.chkTaken.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTaken.Location = new System.Drawing.Point(875, 4);
            this.chkTaken.Name = "chkTaken";
            this.chkTaken.Size = new System.Drawing.Size(57, 17);
            this.chkTaken.TabIndex = 70;
            this.chkTaken.Text = "Taken";
            this.chkTaken.UseVisualStyleBackColor = true;
            this.chkTaken.CheckedChanged += new System.EventHandler(this.FilterOption_Checked);
            // 
            // chkExpired
            // 
            this.chkExpired.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkExpired.AutoSize = true;
            this.chkExpired.Location = new System.Drawing.Point(938, 4);
            this.chkExpired.Name = "chkExpired";
            this.chkExpired.Size = new System.Drawing.Size(61, 17);
            this.chkExpired.TabIndex = 71;
            this.chkExpired.Text = "Expired";
            this.chkExpired.UseVisualStyleBackColor = true;
            this.chkExpired.CheckedChanged += new System.EventHandler(this.FilterOption_Checked);
            // 
            // chkScheduled
            // 
            this.chkScheduled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkScheduled.AutoSize = true;
            this.chkScheduled.Location = new System.Drawing.Point(1005, 4);
            this.chkScheduled.Name = "chkScheduled";
            this.chkScheduled.Size = new System.Drawing.Size(77, 17);
            this.chkScheduled.TabIndex = 72;
            this.chkScheduled.Text = "Scheduled";
            this.chkScheduled.UseVisualStyleBackColor = true;
            this.chkScheduled.CheckedChanged += new System.EventHandler(this.FilterOption_Checked);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.FillWeight = 170.068F;
            this.dataGridViewImageColumn1.HeaderText = "Edit";
            this.dataGridViewImageColumn1.Image = global::NvnTest.Employer.Properties.Resources.edit_16;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn2.FillWeight = 82.48299F;
            this.dataGridViewImageColumn2.HeaderText = "Delete";
            this.dataGridViewImageColumn2.Image = global::NvnTest.Employer.Properties.Resources.delete_16;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.Width = 50;
            // 
            // btnBulkSchedule
            // 
            this.btnBulkSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBulkSchedule.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnBulkSchedule.BackColor = System.Drawing.Color.Transparent;
            this.btnBulkSchedule.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBulkSchedule.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnBulkSchedule.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnBulkSchedule.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnBulkSchedule.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnBulkSchedule.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnBulkSchedule.FadingSpeed = 0;
            this.btnBulkSchedule.FlatAppearance.BorderSize = 0;
            this.btnBulkSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBulkSchedule.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBulkSchedule.ForeColor = System.Drawing.Color.Black;
            this.btnBulkSchedule.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnBulkSchedule.Image = global::NvnTest.Employer.Properties.Resources.bulk;
            this.btnBulkSchedule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBulkSchedule.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnBulkSchedule.ImageOffset = 3;
            this.btnBulkSchedule.IsPressed = false;
            this.btnBulkSchedule.KeepPress = false;
            this.btnBulkSchedule.Location = new System.Drawing.Point(183, 371);
            this.btnBulkSchedule.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnBulkSchedule.MenuPos = new System.Drawing.Point(0, 0);
            this.btnBulkSchedule.Name = "btnBulkSchedule";
            this.btnBulkSchedule.Radius = 8;
            this.btnBulkSchedule.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnBulkSchedule.Size = new System.Drawing.Size(102, 30);
            this.btnBulkSchedule.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnBulkSchedule.SplitDistance = 0;
            this.btnBulkSchedule.TabIndex = 77;
            this.btnBulkSchedule.Text = "Bulk assign";
            this.btnBulkSchedule.Title = "";
            this.btnBulkSchedule.UseVisualStyleBackColor = true;
            this.btnBulkSchedule.Click += new System.EventHandler(this.btnBulkSchedule_Click);
            // 
            // pbFirst
            // 
            this.pbFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFirst.Image = global::NvnTest.Employer.Properties.Resources.first;
            this.pbFirst.Location = new System.Drawing.Point(774, 372);
            this.pbFirst.Name = "pbFirst";
            this.pbFirst.Size = new System.Drawing.Size(25, 25);
            this.pbFirst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFirst.TabIndex = 76;
            this.pbFirst.TabStop = false;
            this.pbFirst.Click += new System.EventHandler(this.pbFirst_Click);
            // 
            // pbPrevious
            // 
            this.pbPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPrevious.Image = global::NvnTest.Employer.Properties.Resources.prev;
            this.pbPrevious.Location = new System.Drawing.Point(805, 372);
            this.pbPrevious.Name = "pbPrevious";
            this.pbPrevious.Size = new System.Drawing.Size(25, 25);
            this.pbPrevious.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPrevious.TabIndex = 75;
            this.pbPrevious.TabStop = false;
            this.pbPrevious.Click += new System.EventHandler(this.pbPrevious_Click);
            // 
            // pbNext
            // 
            this.pbNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbNext.Image = global::NvnTest.Employer.Properties.Resources.next;
            this.pbNext.Location = new System.Drawing.Point(856, 372);
            this.pbNext.Name = "pbNext";
            this.pbNext.Size = new System.Drawing.Size(25, 25);
            this.pbNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNext.TabIndex = 74;
            this.pbNext.TabStop = false;
            this.pbNext.Click += new System.EventHandler(this.pbNext_Click);
            // 
            // pbLast
            // 
            this.pbLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLast.Image = global::NvnTest.Employer.Properties.Resources.last;
            this.pbLast.Location = new System.Drawing.Point(887, 372);
            this.pbLast.Name = "pbLast";
            this.pbLast.Size = new System.Drawing.Size(25, 25);
            this.pbLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLast.TabIndex = 73;
            this.pbLast.TabStop = false;
            this.pbLast.Click += new System.EventHandler(this.pbLast_Click);
            // 
            // btnRefreshTestsAvailable
            // 
            this.btnRefreshTestsAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshTestsAvailable.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnRefreshTestsAvailable.BackColor = System.Drawing.Color.Transparent;
            this.btnRefreshTestsAvailable.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRefreshTestsAvailable.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnRefreshTestsAvailable.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnRefreshTestsAvailable.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnRefreshTestsAvailable.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRefreshTestsAvailable.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRefreshTestsAvailable.FadingSpeed = 0;
            this.btnRefreshTestsAvailable.FlatAppearance.BorderSize = 0;
            this.btnRefreshTestsAvailable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshTestsAvailable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshTestsAvailable.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshTestsAvailable.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnRefreshTestsAvailable.Image = global::NvnTest.Employer.Properties.Resources.calculate;
            this.btnRefreshTestsAvailable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefreshTestsAvailable.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnRefreshTestsAvailable.ImageOffset = 3;
            this.btnRefreshTestsAvailable.IsPressed = false;
            this.btnRefreshTestsAvailable.KeepPress = false;
            this.btnRefreshTestsAvailable.Location = new System.Drawing.Point(656, 371);
            this.btnRefreshTestsAvailable.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnRefreshTestsAvailable.MenuPos = new System.Drawing.Point(0, 0);
            this.btnRefreshTestsAvailable.Name = "btnRefreshTestsAvailable";
            this.btnRefreshTestsAvailable.Radius = 8;
            this.btnRefreshTestsAvailable.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnRefreshTestsAvailable.Size = new System.Drawing.Size(31, 30);
            this.btnRefreshTestsAvailable.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnRefreshTestsAvailable.SplitDistance = 0;
            this.btnRefreshTestsAvailable.TabIndex = 61;
            this.btnRefreshTestsAvailable.Text = "Cancel";
            this.btnRefreshTestsAvailable.Title = "";
            this.btnRefreshTestsAvailable.UseVisualStyleBackColor = true;
            this.btnRefreshTestsAvailable.Click += new System.EventHandler(this.btnRefreshTestsAvailable_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::NvnTest.Employer.Properties.Resources.timer;
            this.pictureBox1.Location = new System.Drawing.Point(920, 371);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            // 
            // btnAssignToYourself
            // 
            this.btnAssignToYourself.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAssignToYourself.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnAssignToYourself.BackColor = System.Drawing.Color.Transparent;
            this.btnAssignToYourself.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAssignToYourself.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnAssignToYourself.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAssignToYourself.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAssignToYourself.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAssignToYourself.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAssignToYourself.FadingSpeed = 0;
            this.btnAssignToYourself.FlatAppearance.BorderSize = 0;
            this.btnAssignToYourself.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignToYourself.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignToYourself.ForeColor = System.Drawing.Color.Black;
            this.btnAssignToYourself.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnAssignToYourself.Image = global::NvnTest.Employer.Properties.Resources.assign_to_yourself;
            this.btnAssignToYourself.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssignToYourself.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnAssignToYourself.ImageOffset = 3;
            this.btnAssignToYourself.IsPressed = false;
            this.btnAssignToYourself.KeepPress = false;
            this.btnAssignToYourself.Location = new System.Drawing.Point(291, 371);
            this.btnAssignToYourself.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAssignToYourself.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAssignToYourself.Name = "btnAssignToYourself";
            this.btnAssignToYourself.Radius = 8;
            this.btnAssignToYourself.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnAssignToYourself.Size = new System.Drawing.Size(174, 30);
            this.btnAssignToYourself.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnAssignToYourself.SplitDistance = 0;
            this.btnAssignToYourself.TabIndex = 55;
            this.btnAssignToYourself.Text = "Assign a test to yourself";
            this.btnAssignToYourself.Title = "";
            this.btnAssignToYourself.UseVisualStyleBackColor = true;
            this.btnAssignToYourself.Click += new System.EventHandler(this.btnAssignToYourself_Click);
            // 
            // btnCreateTestSchedule
            // 
            this.btnCreateTestSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateTestSchedule.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnCreateTestSchedule.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateTestSchedule.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCreateTestSchedule.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnCreateTestSchedule.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnCreateTestSchedule.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnCreateTestSchedule.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCreateTestSchedule.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCreateTestSchedule.FadingSpeed = 0;
            this.btnCreateTestSchedule.FlatAppearance.BorderSize = 0;
            this.btnCreateTestSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTestSchedule.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateTestSchedule.ForeColor = System.Drawing.Color.Black;
            this.btnCreateTestSchedule.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnCreateTestSchedule.Image = global::NvnTest.Employer.Properties.Resources.add;
            this.btnCreateTestSchedule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateTestSchedule.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnCreateTestSchedule.ImageOffset = 3;
            this.btnCreateTestSchedule.IsPressed = false;
            this.btnCreateTestSchedule.KeepPress = false;
            this.btnCreateTestSchedule.Location = new System.Drawing.Point(3, 371);
            this.btnCreateTestSchedule.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnCreateTestSchedule.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCreateTestSchedule.Name = "btnCreateTestSchedule";
            this.btnCreateTestSchedule.Radius = 8;
            this.btnCreateTestSchedule.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnCreateTestSchedule.Size = new System.Drawing.Size(174, 30);
            this.btnCreateTestSchedule.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnCreateTestSchedule.SplitDistance = 0;
            this.btnCreateTestSchedule.TabIndex = 49;
            this.btnCreateTestSchedule.Text = "Add a new test schedule";
            this.btnCreateTestSchedule.Title = "";
            this.btnCreateTestSchedule.UseVisualStyleBackColor = true;
            this.btnCreateTestSchedule.Click += new System.EventHandler(this.btnCreateTestSchedule_Click);
            // 
            // chkDisqualified
            // 
            this.chkDisqualified.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDisqualified.AutoSize = true;
            this.chkDisqualified.Location = new System.Drawing.Point(1088, 4);
            this.chkDisqualified.Name = "chkDisqualified";
            this.chkDisqualified.Size = new System.Drawing.Size(80, 17);
            this.chkDisqualified.TabIndex = 78;
            this.chkDisqualified.Text = "Disqualified";
            this.chkDisqualified.UseVisualStyleBackColor = true;
            this.chkDisqualified.CheckedChanged += new System.EventHandler(this.FilterOption_Checked);
            // 
            // SchedulesCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkDisqualified);
            this.Controls.Add(this.btnBulkSchedule);
            this.Controls.Add(this.pbFirst);
            this.Controls.Add(this.pbPrevious);
            this.Controls.Add(this.pbNext);
            this.Controls.Add(this.pbLast);
            this.Controls.Add(this.chkScheduled);
            this.Controls.Add(this.chkExpired);
            this.Controls.Add(this.chkTaken);
            this.Controls.Add(this.chkSubmitted);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblIndex);
            this.Controls.Add(this.lblTestsAvailable);
            this.Controls.Add(this.btnRefreshTestsAvailable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblUtcTime);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAssignToYourself);
            this.Controls.Add(this.btnCreateTestSchedule);
            this.Controls.Add(this.dgrTestSchedules);
            this.Name = "SchedulesCtrl";
            this.Size = new System.Drawing.Size(1171, 404);
            ((System.ComponentModel.ISupportInitialize)(this.dgrTestSchedules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrTestSchedules;
        private System.Windows.Forms.Label lblTestsAvailable;
        private RibbonStyle.RibbonMenuButton btnCreateTestSchedule;
        private RibbonStyle.RibbonMenuButton btnAssignToYourself;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUtcTime;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScheduleDateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpiryDateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusCol;
        private System.Windows.Forms.DataGridViewLinkColumn ViewResultCol;
        private System.Windows.Forms.DataGridViewImageColumn EditCol;
        private System.Windows.Forms.DataGridViewImageColumn DeleteCol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private RibbonStyle.RibbonMenuButton btnRefreshTestsAvailable;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkSubmitted;
        private System.Windows.Forms.CheckBox chkTaken;
        private System.Windows.Forms.CheckBox chkExpired;
        private System.Windows.Forms.CheckBox chkScheduled;
        private System.Windows.Forms.PictureBox pbLast;
        private System.Windows.Forms.PictureBox pbNext;
        private System.Windows.Forms.PictureBox pbPrevious;
        private System.Windows.Forms.PictureBox pbFirst;
        private RibbonStyle.RibbonMenuButton btnBulkSchedule;
        private System.Windows.Forms.CheckBox chkDisqualified;
    }
}
