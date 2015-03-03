namespace NvnTest.Employer {
    partial class QuestionsCtrl {
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionsCtrl));
            this.dgrQuestions = new System.Windows.Forms.DataGridView();
            this.SelectedQuestionCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IndexCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateModifiedCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuestionTypeCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.EditCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.DeleteCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripAddQuestions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAddObjective = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddProgramming = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddAutoProgramming = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddWebProgramming = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pbFirst = new System.Windows.Forms.PictureBox();
            this.pbPrevious = new System.Windows.Forms.PictureBox();
            this.pbNext = new System.Windows.Forms.PictureBox();
            this.pbLast = new System.Windows.Forms.PictureBox();
            this.lblIndex = new System.Windows.Forms.Label();
            this.btnQuestionLevels = new RibbonStyle.RibbonMenuButton();
            this.btnQuestionCategories = new RibbonStyle.RibbonMenuButton();
            this.btnAddQuestions = new RibbonStyle.RibbonMenuButton();
            this.btnImportQuestions = new RibbonStyle.RibbonMenuButton();
            this.btnExportQuestions = new RibbonStyle.RibbonMenuButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgrQuestions)).BeginInit();
            this.contextMenuStripAddQuestions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrQuestions
            // 
            this.dgrQuestions.AllowUserToAddRows = false;
            this.dgrQuestions.AllowUserToDeleteRows = false;
            this.dgrQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrQuestions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrQuestions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dgrQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrQuestions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectedQuestionCol,
            this.IndexCol,
            this.DescCol,
            this.DateModifiedCol,
            this.QuestionTypeCol,
            this.EditCol,
            this.DeleteCol});
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrQuestions.DefaultCellStyle = dataGridViewCellStyle28;
            this.dgrQuestions.Location = new System.Drawing.Point(3, 3);
            this.dgrQuestions.Name = "dgrQuestions";
            this.dgrQuestions.RowHeadersVisible = false;
            this.dgrQuestions.RowTemplate.Height = 24;
            this.dgrQuestions.Size = new System.Drawing.Size(1435, 450);
            this.dgrQuestions.TabIndex = 0;
            this.dgrQuestions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrQuestions_CellDoubleClick);
            this.dgrQuestions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrQuestions_CellClick);
            // 
            // SelectedQuestionCol
            // 
            this.SelectedQuestionCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SelectedQuestionCol.HeaderText = "";
            this.SelectedQuestionCol.Name = "SelectedQuestionCol";
            this.SelectedQuestionCol.Width = 30;
            // 
            // IndexCol
            // 
            this.IndexCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IndexCol.DefaultCellStyle = dataGridViewCellStyle26;
            this.IndexCol.FillWeight = 87.98186F;
            this.IndexCol.HeaderText = "Index";
            this.IndexCol.Name = "IndexCol";
            this.IndexCol.ReadOnly = true;
            this.IndexCol.Width = 50;
            // 
            // DescCol
            // 
            this.DescCol.FillWeight = 18.71954F;
            this.DescCol.HeaderText = "Description";
            this.DescCol.Name = "DescCol";
            this.DescCol.ReadOnly = true;
            // 
            // DateModifiedCol
            // 
            this.DateModifiedCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DateModifiedCol.DefaultCellStyle = dataGridViewCellStyle27;
            this.DateModifiedCol.HeaderText = "Date Modified";
            this.DateModifiedCol.Name = "DateModifiedCol";
            this.DateModifiedCol.ReadOnly = true;
            // 
            // QuestionTypeCol
            // 
            this.QuestionTypeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.QuestionTypeCol.FillWeight = 157.2442F;
            this.QuestionTypeCol.HeaderText = "Question Type";
            this.QuestionTypeCol.Name = "QuestionTypeCol";
            this.QuestionTypeCol.ReadOnly = true;
            this.QuestionTypeCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.QuestionTypeCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // EditCol
            // 
            this.EditCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
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
            this.DeleteCol.FillWeight = 136.0544F;
            this.DeleteCol.HeaderText = "Delete";
            this.DeleteCol.Image = global::NvnTest.Employer.Properties.Resources.delete_16;
            this.DeleteCol.Name = "DeleteCol";
            this.DeleteCol.ReadOnly = true;
            this.DeleteCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteCol.Width = 50;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "objective_16.png");
            this.imageList.Images.SetKeyName(1, "database-16.png");
            this.imageList.Images.SetKeyName(2, "algo-16.png");
            this.imageList.Images.SetKeyName(3, "algo-16.png");
            this.imageList.Images.SetKeyName(4, "internet_16.png");
            // 
            // contextMenuStripAddQuestions
            // 
            this.contextMenuStripAddQuestions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAddObjective,
            this.toolStripMenuItemAddProgramming,
            this.toolStripMenuItemAddAutoProgramming,
            this.toolStripMenuItemAddWebProgramming,
            this.toolStripMenuItemAddSQL});
            this.contextMenuStripAddQuestions.Name = "contextMenuStrip1";
            this.contextMenuStripAddQuestions.Size = new System.Drawing.Size(320, 114);
            // 
            // toolStripMenuItemAddObjective
            // 
            this.toolStripMenuItemAddObjective.Image = global::NvnTest.Employer.Properties.Resources.objective;
            this.toolStripMenuItemAddObjective.Name = "toolStripMenuItemAddObjective";
            this.toolStripMenuItemAddObjective.Size = new System.Drawing.Size(319, 22);
            this.toolStripMenuItemAddObjective.Text = "Add Multiple Choice Question";
            this.toolStripMenuItemAddObjective.Click += new System.EventHandler(this.btnAddNewObjectiveQuestion_Click);
            // 
            // toolStripMenuItemAddProgramming
            // 
            this.toolStripMenuItemAddProgramming.Image = global::NvnTest.Employer.Properties.Resources.algo;
            this.toolStripMenuItemAddProgramming.Name = "toolStripMenuItemAddProgramming";
            this.toolStripMenuItemAddProgramming.Size = new System.Drawing.Size(319, 22);
            this.toolStripMenuItemAddProgramming.Text = "Add Programming Question";
            this.toolStripMenuItemAddProgramming.Click += new System.EventHandler(this.btnAddNewProgrammingQuestion_Click);
            // 
            // toolStripMenuItemAddAutoProgramming
            // 
            this.toolStripMenuItemAddAutoProgramming.Image = global::NvnTest.Employer.Properties.Resources.algo;
            this.toolStripMenuItemAddAutoProgramming.Name = "toolStripMenuItemAddAutoProgramming";
            this.toolStripMenuItemAddAutoProgramming.Size = new System.Drawing.Size(319, 22);
            this.toolStripMenuItemAddAutoProgramming.Text = "Add Programming Question (Auto evaluation)";
            this.toolStripMenuItemAddAutoProgramming.Click += new System.EventHandler(this.btnAddNewAutoProgrammingQuestion_Click);
            // 
            // toolStripMenuItemAddWebProgramming
            // 
            this.toolStripMenuItemAddWebProgramming.Image = global::NvnTest.Employer.Properties.Resources.internet;
            this.toolStripMenuItemAddWebProgramming.Name = "toolStripMenuItemAddWebProgramming";
            this.toolStripMenuItemAddWebProgramming.Size = new System.Drawing.Size(319, 22);
            this.toolStripMenuItemAddWebProgramming.Text = "Add Web Programming Question";
            this.toolStripMenuItemAddWebProgramming.Click += new System.EventHandler(this.btnAddNewWebProgrammingQuestion_Click);
            // 
            // toolStripMenuItemAddSQL
            // 
            this.toolStripMenuItemAddSQL.Image = global::NvnTest.Employer.Properties.Resources.database;
            this.toolStripMenuItemAddSQL.Name = "toolStripMenuItemAddSQL";
            this.toolStripMenuItemAddSQL.Size = new System.Drawing.Size(319, 22);
            this.toolStripMenuItemAddSQL.Text = "Add SQL Question";
            this.toolStripMenuItemAddSQL.Visible = false;
            this.toolStripMenuItemAddSQL.Click += new System.EventHandler(this.btnAddNewSqlQuestion_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.FillWeight = 136.0544F;
            this.dataGridViewImageColumn1.HeaderText = "Remove";
            this.dataGridViewImageColumn1.Image = global::NvnTest.Employer.Properties.Resources.delete_16;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn2.FillWeight = 136.0544F;
            this.dataGridViewImageColumn2.HeaderText = "Remove";
            this.dataGridViewImageColumn2.Image = global::NvnTest.Employer.Properties.Resources.delete_16;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.Width = 50;
            // 
            // pbFirst
            // 
            this.pbFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFirst.Image = global::NvnTest.Employer.Properties.Resources.first;
            this.pbFirst.Location = new System.Drawing.Point(749, 464);
            this.pbFirst.Name = "pbFirst";
            this.pbFirst.Size = new System.Drawing.Size(25, 25);
            this.pbFirst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFirst.TabIndex = 81;
            this.pbFirst.TabStop = false;
            this.pbFirst.Click += new System.EventHandler(this.pbFirst_Click);
            // 
            // pbPrevious
            // 
            this.pbPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPrevious.Image = global::NvnTest.Employer.Properties.Resources.prev;
            this.pbPrevious.Location = new System.Drawing.Point(780, 464);
            this.pbPrevious.Name = "pbPrevious";
            this.pbPrevious.Size = new System.Drawing.Size(25, 25);
            this.pbPrevious.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPrevious.TabIndex = 80;
            this.pbPrevious.TabStop = false;
            this.pbPrevious.Click += new System.EventHandler(this.pbPrevious_Click);
            // 
            // pbNext
            // 
            this.pbNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbNext.Image = global::NvnTest.Employer.Properties.Resources.next;
            this.pbNext.Location = new System.Drawing.Point(831, 464);
            this.pbNext.Name = "pbNext";
            this.pbNext.Size = new System.Drawing.Size(25, 25);
            this.pbNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNext.TabIndex = 79;
            this.pbNext.TabStop = false;
            this.pbNext.Click += new System.EventHandler(this.pbNext_Click);
            // 
            // pbLast
            // 
            this.pbLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLast.Image = global::NvnTest.Employer.Properties.Resources.last;
            this.pbLast.Location = new System.Drawing.Point(862, 464);
            this.pbLast.Name = "pbLast";
            this.pbLast.Size = new System.Drawing.Size(25, 25);
            this.pbLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLast.TabIndex = 78;
            this.pbLast.TabStop = false;
            this.pbLast.Click += new System.EventHandler(this.pbLast_Click);
            // 
            // lblIndex
            // 
            this.lblIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIndex.AutoSize = true;
            this.lblIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndex.ForeColor = System.Drawing.Color.Maroon;
            this.lblIndex.Location = new System.Drawing.Point(811, 472);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(14, 13);
            this.lblIndex.TabIndex = 77;
            this.lblIndex.Text = "0";
            // 
            // btnQuestionLevels
            // 
            this.btnQuestionLevels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuestionLevels.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnQuestionLevels.BackColor = System.Drawing.Color.Transparent;
            this.btnQuestionLevels.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnQuestionLevels.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnQuestionLevels.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnQuestionLevels.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnQuestionLevels.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnQuestionLevels.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnQuestionLevels.FadingSpeed = 0;
            this.btnQuestionLevels.FlatAppearance.BorderSize = 0;
            this.btnQuestionLevels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuestionLevels.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuestionLevels.ForeColor = System.Drawing.Color.Black;
            this.btnQuestionLevels.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnQuestionLevels.Image = global::NvnTest.Employer.Properties.Resources.levels;
            this.btnQuestionLevels.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuestionLevels.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnQuestionLevels.ImageOffset = 3;
            this.btnQuestionLevels.IsPressed = false;
            this.btnQuestionLevels.KeepPress = false;
            this.btnQuestionLevels.Location = new System.Drawing.Point(1043, 459);
            this.btnQuestionLevels.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnQuestionLevels.MenuPos = new System.Drawing.Point(0, 0);
            this.btnQuestionLevels.Name = "btnQuestionLevels";
            this.btnQuestionLevels.Radius = 8;
            this.btnQuestionLevels.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnQuestionLevels.Size = new System.Drawing.Size(123, 30);
            this.btnQuestionLevels.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnQuestionLevels.SplitDistance = 0;
            this.btnQuestionLevels.TabIndex = 61;
            this.btnQuestionLevels.Text = "Define levels";
            this.btnQuestionLevels.Title = "";
            this.btnQuestionLevels.UseVisualStyleBackColor = true;
            this.btnQuestionLevels.Click += new System.EventHandler(this.btnQuestionLevels_Click);
            // 
            // btnQuestionCategories
            // 
            this.btnQuestionCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuestionCategories.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnQuestionCategories.BackColor = System.Drawing.Color.Transparent;
            this.btnQuestionCategories.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnQuestionCategories.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnQuestionCategories.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnQuestionCategories.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnQuestionCategories.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnQuestionCategories.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnQuestionCategories.FadingSpeed = 0;
            this.btnQuestionCategories.FlatAppearance.BorderSize = 0;
            this.btnQuestionCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuestionCategories.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuestionCategories.ForeColor = System.Drawing.Color.Black;
            this.btnQuestionCategories.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnQuestionCategories.Image = global::NvnTest.Employer.Properties.Resources.chart;
            this.btnQuestionCategories.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuestionCategories.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnQuestionCategories.ImageOffset = 3;
            this.btnQuestionCategories.IsPressed = false;
            this.btnQuestionCategories.KeepPress = false;
            this.btnQuestionCategories.Location = new System.Drawing.Point(893, 459);
            this.btnQuestionCategories.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnQuestionCategories.MenuPos = new System.Drawing.Point(0, 0);
            this.btnQuestionCategories.Name = "btnQuestionCategories";
            this.btnQuestionCategories.Radius = 8;
            this.btnQuestionCategories.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnQuestionCategories.Size = new System.Drawing.Size(144, 30);
            this.btnQuestionCategories.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnQuestionCategories.SplitDistance = 0;
            this.btnQuestionCategories.TabIndex = 60;
            this.btnQuestionCategories.Text = "Define categories";
            this.btnQuestionCategories.Title = "";
            this.btnQuestionCategories.UseVisualStyleBackColor = true;
            this.btnQuestionCategories.Click += new System.EventHandler(this.btnQuestionCategories_Click);
            // 
            // btnAddQuestions
            // 
            this.btnAddQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddQuestions.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.ToRight;
            this.btnAddQuestions.BackColor = System.Drawing.Color.Transparent;
            this.btnAddQuestions.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddQuestions.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnAddQuestions.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAddQuestions.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAddQuestions.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddQuestions.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAddQuestions.ContextMenuStrip = this.contextMenuStripAddQuestions;
            this.btnAddQuestions.FadingSpeed = 0;
            this.btnAddQuestions.FlatAppearance.BorderSize = 0;
            this.btnAddQuestions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddQuestions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddQuestions.ForeColor = System.Drawing.Color.Black;
            this.btnAddQuestions.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnAddQuestions.Image = global::NvnTest.Employer.Properties.Resources.add;
            this.btnAddQuestions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddQuestions.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnAddQuestions.ImageOffset = 3;
            this.btnAddQuestions.IsPressed = false;
            this.btnAddQuestions.KeepPress = false;
            this.btnAddQuestions.Location = new System.Drawing.Point(3, 459);
            this.btnAddQuestions.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAddQuestions.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAddQuestions.Name = "btnAddQuestions";
            this.btnAddQuestions.Radius = 8;
            this.btnAddQuestions.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnAddQuestions.Size = new System.Drawing.Size(146, 30);
            this.btnAddQuestions.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.Yes;
            this.btnAddQuestions.SplitDistance = 20;
            this.btnAddQuestions.TabIndex = 63;
            this.btnAddQuestions.Text = "Add questions";
            this.btnAddQuestions.Title = "";
            this.btnAddQuestions.UseVisualStyleBackColor = true;
            // 
            // btnImportQuestions
            // 
            this.btnImportQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportQuestions.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnImportQuestions.BackColor = System.Drawing.Color.Transparent;
            this.btnImportQuestions.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnImportQuestions.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnImportQuestions.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnImportQuestions.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnImportQuestions.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnImportQuestions.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnImportQuestions.FadingSpeed = 0;
            this.btnImportQuestions.FlatAppearance.BorderSize = 0;
            this.btnImportQuestions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportQuestions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportQuestions.ForeColor = System.Drawing.Color.Black;
            this.btnImportQuestions.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnImportQuestions.Image = global::NvnTest.Employer.Properties.Resources.import;
            this.btnImportQuestions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportQuestions.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnImportQuestions.ImageOffset = 3;
            this.btnImportQuestions.IsPressed = false;
            this.btnImportQuestions.KeepPress = false;
            this.btnImportQuestions.Location = new System.Drawing.Point(1308, 459);
            this.btnImportQuestions.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnImportQuestions.MenuPos = new System.Drawing.Point(0, 0);
            this.btnImportQuestions.Name = "btnImportQuestions";
            this.btnImportQuestions.Radius = 8;
            this.btnImportQuestions.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnImportQuestions.Size = new System.Drawing.Size(130, 30);
            this.btnImportQuestions.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnImportQuestions.SplitDistance = 0;
            this.btnImportQuestions.TabIndex = 59;
            this.btnImportQuestions.Text = "Import questions";
            this.btnImportQuestions.Title = "";
            this.btnImportQuestions.UseVisualStyleBackColor = true;
            this.btnImportQuestions.Click += new System.EventHandler(this.btnImportQuestions_Click);
            // 
            // btnExportQuestions
            // 
            this.btnExportQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportQuestions.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnExportQuestions.BackColor = System.Drawing.Color.Transparent;
            this.btnExportQuestions.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExportQuestions.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnExportQuestions.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnExportQuestions.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnExportQuestions.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExportQuestions.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExportQuestions.FadingSpeed = 0;
            this.btnExportQuestions.FlatAppearance.BorderSize = 0;
            this.btnExportQuestions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportQuestions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportQuestions.ForeColor = System.Drawing.Color.Black;
            this.btnExportQuestions.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnExportQuestions.Image = global::NvnTest.Employer.Properties.Resources.export;
            this.btnExportQuestions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportQuestions.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnExportQuestions.ImageOffset = 3;
            this.btnExportQuestions.IsPressed = false;
            this.btnExportQuestions.KeepPress = false;
            this.btnExportQuestions.Location = new System.Drawing.Point(1172, 459);
            this.btnExportQuestions.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnExportQuestions.MenuPos = new System.Drawing.Point(0, 0);
            this.btnExportQuestions.Name = "btnExportQuestions";
            this.btnExportQuestions.Radius = 8;
            this.btnExportQuestions.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnExportQuestions.Size = new System.Drawing.Size(130, 30);
            this.btnExportQuestions.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnExportQuestions.SplitDistance = 0;
            this.btnExportQuestions.TabIndex = 58;
            this.btnExportQuestions.Text = "Export questions";
            this.btnExportQuestions.Title = "";
            this.btnExportQuestions.UseVisualStyleBackColor = true;
            this.btnExportQuestions.Click += new System.EventHandler(this.btnExportQuestions_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(430, 468);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "Filter Questions";
            // 
            // cmbFilter
            // 
            this.cmbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(515, 465);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(218, 21);
            this.cmbFilter.TabIndex = 83;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // QuestionsCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbFirst);
            this.Controls.Add(this.pbPrevious);
            this.Controls.Add(this.pbNext);
            this.Controls.Add(this.pbLast);
            this.Controls.Add(this.lblIndex);
            this.Controls.Add(this.btnQuestionLevels);
            this.Controls.Add(this.btnQuestionCategories);
            this.Controls.Add(this.btnAddQuestions);
            this.Controls.Add(this.btnImportQuestions);
            this.Controls.Add(this.btnExportQuestions);
            this.Controls.Add(this.dgrQuestions);
            this.Name = "QuestionsCtrl";
            this.Size = new System.Drawing.Size(1441, 500);
            ((System.ComponentModel.ISupportInitialize)(this.dgrQuestions)).EndInit();
            this.contextMenuStripAddQuestions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrQuestions;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.ImageList imageList;
        private RibbonStyle.RibbonMenuButton btnExportQuestions;
        private RibbonStyle.RibbonMenuButton btnImportQuestions;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectedQuestionCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndexCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateModifiedCol;
        private System.Windows.Forms.DataGridViewImageColumn QuestionTypeCol;
        private System.Windows.Forms.DataGridViewImageColumn EditCol;
        private System.Windows.Forms.DataGridViewImageColumn DeleteCol;
        private RibbonStyle.RibbonMenuButton btnQuestionCategories;
        private RibbonStyle.RibbonMenuButton btnQuestionLevels;
        private RibbonStyle.RibbonMenuButton btnAddQuestions;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAddQuestions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddObjective;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddProgramming;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddAutoProgramming;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddWebProgramming;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddSQL;
        private System.Windows.Forms.PictureBox pbFirst;
        private System.Windows.Forms.PictureBox pbPrevious;
        private System.Windows.Forms.PictureBox pbNext;
        private System.Windows.Forms.PictureBox pbLast;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFilter;
    }
}
