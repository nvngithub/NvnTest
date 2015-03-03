namespace NvnTest.Employer {
    partial class TestResultForm {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestResultForm));
            this.dgrResult = new System.Windows.Forms.DataGridView();
            this.DescCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExeCol = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnClose = new RibbonStyle.RibbonMenuButton();
            this.btnSaveAsRtf = new RibbonStyle.RibbonMenuButton();
            this.btnImagesCaptured = new RibbonStyle.RibbonMenuButton();
            this.btnWebReference = new RibbonStyle.RibbonMenuButton();
            this.btnExport = new RibbonStyle.RibbonMenuButton();
            this.btnPrint = new RibbonStyle.RibbonMenuButton();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnApplicationsIgnored = new RibbonStyle.RibbonMenuButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgrResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrResult
            // 
            this.dgrResult.AllowUserToAddRows = false;
            this.dgrResult.AllowUserToDeleteRows = false;
            this.dgrResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgrResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrResult.ColumnHeadersVisible = false;
            this.dgrResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DescCol,
            this.ExeCol});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrResult.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrResult.Location = new System.Drawing.Point(12, 12);
            this.dgrResult.MultiSelect = false;
            this.dgrResult.Name = "dgrResult";
            this.dgrResult.ReadOnly = true;
            this.dgrResult.RowHeadersVisible = false;
            this.dgrResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrResult.Size = new System.Drawing.Size(1041, 535);
            this.dgrResult.TabIndex = 2;
            this.dgrResult.SelectionChanged += new System.EventHandler(this.dgrResult_SelectionChanged);
            this.dgrResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrResult_CellContentClick);
            // 
            // DescCol
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DescCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.DescCol.HeaderText = "";
            this.DescCol.Name = "DescCol";
            this.DescCol.ReadOnly = true;
            // 
            // ExeCol
            // 
            this.ExeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ExeCol.HeaderText = "";
            this.ExeCol.Name = "ExeCol";
            this.ExeCol.ReadOnly = true;
            this.ExeCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnClose.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnClose.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnClose.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FadingSpeed = 0;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnClose.Image = global::NvnTest.Employer.Properties.Resources.cancel;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnClose.ImageOffset = 3;
            this.btnClose.IsPressed = false;
            this.btnClose.KeepPress = false;
            this.btnClose.Location = new System.Drawing.Point(953, 553);
            this.btnClose.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 8;
            this.btnClose.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnClose.SplitDistance = 0;
            this.btnClose.TabIndex = 50;
            this.btnClose.Text = "Close";
            this.btnClose.Title = "";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveAsRtf
            // 
            this.btnSaveAsRtf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAsRtf.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnSaveAsRtf.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveAsRtf.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSaveAsRtf.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnSaveAsRtf.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnSaveAsRtf.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnSaveAsRtf.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSaveAsRtf.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSaveAsRtf.FadingSpeed = 0;
            this.btnSaveAsRtf.FlatAppearance.BorderSize = 0;
            this.btnSaveAsRtf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAsRtf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAsRtf.ForeColor = System.Drawing.Color.Black;
            this.btnSaveAsRtf.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnSaveAsRtf.Image = global::NvnTest.Employer.Properties.Resources.save;
            this.btnSaveAsRtf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveAsRtf.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnSaveAsRtf.ImageOffset = 3;
            this.btnSaveAsRtf.IsPressed = false;
            this.btnSaveAsRtf.KeepPress = false;
            this.btnSaveAsRtf.Location = new System.Drawing.Point(847, 553);
            this.btnSaveAsRtf.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSaveAsRtf.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSaveAsRtf.Name = "btnSaveAsRtf";
            this.btnSaveAsRtf.Radius = 8;
            this.btnSaveAsRtf.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnSaveAsRtf.Size = new System.Drawing.Size(100, 30);
            this.btnSaveAsRtf.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnSaveAsRtf.SplitDistance = 0;
            this.btnSaveAsRtf.TabIndex = 54;
            this.btnSaveAsRtf.Text = "Save";
            this.btnSaveAsRtf.Title = "";
            this.btnSaveAsRtf.UseVisualStyleBackColor = true;
            this.btnSaveAsRtf.Click += new System.EventHandler(this.btnSaveAsRtf_Click);
            // 
            // btnImagesCaptured
            // 
            this.btnImagesCaptured.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImagesCaptured.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnImagesCaptured.BackColor = System.Drawing.Color.Transparent;
            this.btnImagesCaptured.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnImagesCaptured.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnImagesCaptured.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnImagesCaptured.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnImagesCaptured.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnImagesCaptured.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnImagesCaptured.FadingSpeed = 0;
            this.btnImagesCaptured.FlatAppearance.BorderSize = 0;
            this.btnImagesCaptured.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImagesCaptured.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImagesCaptured.ForeColor = System.Drawing.Color.Black;
            this.btnImagesCaptured.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnImagesCaptured.Image = global::NvnTest.Employer.Properties.Resources.image;
            this.btnImagesCaptured.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImagesCaptured.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnImagesCaptured.ImageOffset = 3;
            this.btnImagesCaptured.IsPressed = false;
            this.btnImagesCaptured.KeepPress = false;
            this.btnImagesCaptured.Location = new System.Drawing.Point(164, 553);
            this.btnImagesCaptured.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnImagesCaptured.MenuPos = new System.Drawing.Point(0, 0);
            this.btnImagesCaptured.Name = "btnImagesCaptured";
            this.btnImagesCaptured.Radius = 8;
            this.btnImagesCaptured.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnImagesCaptured.Size = new System.Drawing.Size(146, 30);
            this.btnImagesCaptured.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnImagesCaptured.SplitDistance = 0;
            this.btnImagesCaptured.TabIndex = 53;
            this.btnImagesCaptured.Text = "Images captured";
            this.btnImagesCaptured.Title = "";
            this.btnImagesCaptured.UseVisualStyleBackColor = true;
            this.btnImagesCaptured.Click += new System.EventHandler(this.btnImagesCaptured_Click);
            // 
            // btnWebReference
            // 
            this.btnWebReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWebReference.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnWebReference.BackColor = System.Drawing.Color.Transparent;
            this.btnWebReference.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWebReference.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnWebReference.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnWebReference.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnWebReference.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnWebReference.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnWebReference.FadingSpeed = 0;
            this.btnWebReference.FlatAppearance.BorderSize = 0;
            this.btnWebReference.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWebReference.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWebReference.ForeColor = System.Drawing.Color.Black;
            this.btnWebReference.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnWebReference.Image = global::NvnTest.Employer.Properties.Resources.internet;
            this.btnWebReference.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWebReference.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnWebReference.ImageOffset = 3;
            this.btnWebReference.IsPressed = false;
            this.btnWebReference.KeepPress = false;
            this.btnWebReference.Location = new System.Drawing.Point(12, 553);
            this.btnWebReference.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnWebReference.MenuPos = new System.Drawing.Point(0, 0);
            this.btnWebReference.Name = "btnWebReference";
            this.btnWebReference.Radius = 8;
            this.btnWebReference.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnWebReference.Size = new System.Drawing.Size(146, 30);
            this.btnWebReference.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnWebReference.SplitDistance = 0;
            this.btnWebReference.TabIndex = 52;
            this.btnWebReference.Text = "Websites visited";
            this.btnWebReference.Title = "";
            this.btnWebReference.UseVisualStyleBackColor = true;
            this.btnWebReference.Click += new System.EventHandler(this.btnWebReference_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExport.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnExport.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnExport.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnExport.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExport.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExport.FadingSpeed = 0;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.Black;
            this.btnExport.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnExport.Image = global::NvnTest.Employer.Properties.Resources.export;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnExport.ImageOffset = 3;
            this.btnExport.IsPressed = false;
            this.btnExport.KeepPress = false;
            this.btnExport.Location = new System.Drawing.Point(619, 553);
            this.btnExport.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnExport.MenuPos = new System.Drawing.Point(0, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Radius = 8;
            this.btnExport.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnExport.Size = new System.Drawing.Size(222, 30);
            this.btnExport.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnExport.SplitDistance = 0;
            this.btnExport.TabIndex = 51;
            this.btnExport.Text = "Export executables and web pages";
            this.btnExport.Title = "";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrint.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnPrint.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnPrint.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnPrint.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrint.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPrint.FadingSpeed = 0;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnPrint.Image = global::NvnTest.Employer.Properties.Resources.printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnPrint.ImageOffset = 3;
            this.btnPrint.IsPressed = false;
            this.btnPrint.KeepPress = false;
            this.btnPrint.Location = new System.Drawing.Point(513, 553);
            this.btnPrint.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnPrint.MenuPos = new System.Drawing.Point(0, 0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Radius = 8;
            this.btnPrint.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnPrint.Size = new System.Drawing.Size(100, 30);
            this.btnPrint.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnPrint.SplitDistance = 0;
            this.btnPrint.TabIndex = 49;
            this.btnPrint.Text = "Print";
            this.btnPrint.Title = "";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::NvnTest.Employer.Properties.Resources.console;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // btnApplicationsIgnored
            // 
            this.btnApplicationsIgnored.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApplicationsIgnored.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnApplicationsIgnored.BackColor = System.Drawing.Color.Transparent;
            this.btnApplicationsIgnored.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnApplicationsIgnored.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnApplicationsIgnored.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnApplicationsIgnored.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnApplicationsIgnored.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnApplicationsIgnored.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnApplicationsIgnored.FadingSpeed = 0;
            this.btnApplicationsIgnored.FlatAppearance.BorderSize = 0;
            this.btnApplicationsIgnored.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplicationsIgnored.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplicationsIgnored.ForeColor = System.Drawing.Color.Black;
            this.btnApplicationsIgnored.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnApplicationsIgnored.Image = global::NvnTest.Employer.Properties.Resources.console;
            this.btnApplicationsIgnored.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApplicationsIgnored.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnApplicationsIgnored.ImageOffset = 3;
            this.btnApplicationsIgnored.IsPressed = false;
            this.btnApplicationsIgnored.KeepPress = false;
            this.btnApplicationsIgnored.Location = new System.Drawing.Point(316, 553);
            this.btnApplicationsIgnored.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnApplicationsIgnored.MenuPos = new System.Drawing.Point(0, 0);
            this.btnApplicationsIgnored.Name = "btnApplicationsIgnored";
            this.btnApplicationsIgnored.Radius = 8;
            this.btnApplicationsIgnored.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnApplicationsIgnored.Size = new System.Drawing.Size(156, 30);
            this.btnApplicationsIgnored.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnApplicationsIgnored.SplitDistance = 0;
            this.btnApplicationsIgnored.TabIndex = 55;
            this.btnApplicationsIgnored.Text = "Applications Ignored";
            this.btnApplicationsIgnored.Title = "";
            this.btnApplicationsIgnored.UseVisualStyleBackColor = true;
            this.btnApplicationsIgnored.Click += new System.EventHandler(this.btnApplicationsIgnored_Click);
            // 
            // TestResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1065, 588);
            this.Controls.Add(this.btnApplicationsIgnored);
            this.Controls.Add(this.btnSaveAsRtf);
            this.Controls.Add(this.btnImagesCaptured);
            this.Controls.Add(this.btnWebReference);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgrResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NvnTest - Result";
            ((System.ComponentModel.ISupportInitialize)(this.dgrResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrResult;
        private RibbonStyle.RibbonMenuButton btnPrint;
        private RibbonStyle.RibbonMenuButton btnClose;
        private RibbonStyle.RibbonMenuButton btnExport;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescCol;
        private System.Windows.Forms.DataGridViewLinkColumn ExeCol;
        private RibbonStyle.RibbonMenuButton btnWebReference;
        private RibbonStyle.RibbonMenuButton btnImagesCaptured;
        private RibbonStyle.RibbonMenuButton btnSaveAsRtf;
        private RibbonStyle.RibbonMenuButton btnApplicationsIgnored;
    }
}