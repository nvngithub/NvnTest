namespace NvnTest.Candidate {
    partial class SubmitPreviewCtrl {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubmitPreviewCtrl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrQuestions = new System.Windows.Forms.DataGridView();
            this.IndexCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.DescCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuestionTypeCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.btnHome = new RibbonStyle.RibbonMenuButton();
            this.btnWebReference = new RibbonStyle.RibbonMenuButton();
            this.testInfoCtrl1 = new NvnTest.Candidate.TestInfoCtrl();
            this.ribbonMenuButton1 = new RibbonStyle.RibbonMenuButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgrQuestions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrQuestions
            // 
            this.dgrQuestions.AllowUserToAddRows = false;
            this.dgrQuestions.AllowUserToDeleteRows = false;
            this.dgrQuestions.AllowUserToResizeColumns = false;
            this.dgrQuestions.AllowUserToResizeRows = false;
            this.dgrQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrQuestions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrQuestions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrQuestions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgrQuestions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgrQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrQuestions.ColumnHeadersVisible = false;
            this.dgrQuestions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IndexCol,
            this.EditCol,
            this.DescCol,
            this.QuestionTypeCol});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrQuestions.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgrQuestions.Location = new System.Drawing.Point(3, 89);
            this.dgrQuestions.Name = "dgrQuestions";
            this.dgrQuestions.ReadOnly = true;
            this.dgrQuestions.RowHeadersVisible = false;
            this.dgrQuestions.Size = new System.Drawing.Size(833, 326);
            this.dgrQuestions.TabIndex = 2;
            this.dgrQuestions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrQuestions_CellContentClick);
            // 
            // IndexCol
            // 
            this.IndexCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.IndexCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.IndexCol.HeaderText = "Index";
            this.IndexCol.Name = "IndexCol";
            this.IndexCol.ReadOnly = true;
            this.IndexCol.Width = 40;
            // 
            // EditCol
            // 
            this.EditCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle2.NullValue")));
            this.EditCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.EditCol.HeaderText = "Edit";
            this.EditCol.Image = global::NvnTest.Candidate.Properties.Resources.Plain;
            this.EditCol.Name = "EditCol";
            this.EditCol.ReadOnly = true;
            this.EditCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EditCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DescCol
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.DescCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.DescCol.HeaderText = "Description";
            this.DescCol.Name = "DescCol";
            this.DescCol.ReadOnly = true;
            // 
            // QuestionTypeCol
            // 
            this.QuestionTypeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle4.NullValue")));
            this.QuestionTypeCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.QuestionTypeCol.HeaderText = "";
            this.QuestionTypeCol.Image = global::NvnTest.Candidate.Properties.Resources.Plain;
            this.QuestionTypeCol.Name = "QuestionTypeCol";
            this.QuestionTypeCol.ReadOnly = true;
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLeft.Location = new System.Drawing.Point(779, 18);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(57, 13);
            this.lblTimeLeft.TabIndex = 4;
            this.lblTimeLeft.Text = "00:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(3, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 61;
            this.label1.Text = "Submit preview";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle6.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle6.NullValue")));
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewImageColumn1.HeaderText = "Edit";
            this.dataGridViewImageColumn1.Image = global::NvnTest.Candidate.Properties.Resources.edit;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle7.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle7.NullValue")));
            this.dataGridViewImageColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::NvnTest.Candidate.Properties.Resources.Plain;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::NvnTest.Candidate.Properties.Resources.timer;
            this.pictureBox1.Location = new System.Drawing.Point(725, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pnlLogo
            // 
            this.pnlLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLogo.Location = new System.Drawing.Point(3, 421);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(180, 55);
            this.pnlLogo.TabIndex = 81;
            // 
            // btnHome
            // 
            this.btnHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHome.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHome.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnHome.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnHome.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnHome.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnHome.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnHome.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHome.FadingSpeed = 0;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.Black;
            this.btnHome.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnHome.Image = global::NvnTest.Candidate.Properties.Resources.home;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnHome.ImageOffset = 3;
            this.btnHome.IsPressed = false;
            this.btnHome.KeepPress = false;
            this.btnHome.Location = new System.Drawing.Point(463, 9);
            this.btnHome.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnHome.MenuPos = new System.Drawing.Point(0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Radius = 8;
            this.btnHome.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnHome.Size = new System.Drawing.Size(112, 30);
            this.btnHome.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnHome.SplitDistance = 0;
            this.btnHome.TabIndex = 72;
            this.btnHome.Text = "Home";
            this.btnHome.Title = "";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnWebReference
            // 
            this.btnWebReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWebReference.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnWebReference.BackColor = System.Drawing.Color.Transparent;
            this.btnWebReference.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWebReference.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnWebReference.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnWebReference.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnWebReference.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnWebReference.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnWebReference.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnWebReference.FadingSpeed = 0;
            this.btnWebReference.FlatAppearance.BorderSize = 0;
            this.btnWebReference.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWebReference.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWebReference.ForeColor = System.Drawing.Color.Black;
            this.btnWebReference.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnWebReference.Image = global::NvnTest.Candidate.Properties.Resources.browser;
            this.btnWebReference.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWebReference.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnWebReference.ImageOffset = 3;
            this.btnWebReference.IsPressed = false;
            this.btnWebReference.KeepPress = false;
            this.btnWebReference.Location = new System.Drawing.Point(332, 9);
            this.btnWebReference.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnWebReference.MenuPos = new System.Drawing.Point(0, 0);
            this.btnWebReference.Name = "btnWebReference";
            this.btnWebReference.Radius = 8;
            this.btnWebReference.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnWebReference.Size = new System.Drawing.Size(125, 30);
            this.btnWebReference.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnWebReference.SplitDistance = 0;
            this.btnWebReference.TabIndex = 62;
            this.btnWebReference.Text = "Web reference";
            this.btnWebReference.Title = "";
            this.btnWebReference.UseVisualStyleBackColor = true;
            this.btnWebReference.Click += new System.EventHandler(this.btnWebReference_Click);
            // 
            // testInfoCtrl1
            // 
            this.testInfoCtrl1.Location = new System.Drawing.Point(3, 3);
            this.testInfoCtrl1.Name = "testInfoCtrl1";
            this.testInfoCtrl1.Size = new System.Drawing.Size(270, 60);
            this.testInfoCtrl1.TabIndex = 60;
            // 
            // ribbonMenuButton1
            // 
            this.ribbonMenuButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ribbonMenuButton1.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.ribbonMenuButton1.BackColor = System.Drawing.Color.Transparent;
            this.ribbonMenuButton1.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ribbonMenuButton1.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ribbonMenuButton1.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.ribbonMenuButton1.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.ribbonMenuButton1.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ribbonMenuButton1.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ribbonMenuButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ribbonMenuButton1.FadingSpeed = 0;
            this.ribbonMenuButton1.FlatAppearance.BorderSize = 0;
            this.ribbonMenuButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ribbonMenuButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonMenuButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ribbonMenuButton1.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.ribbonMenuButton1.Image = global::NvnTest.Candidate.Properties.Resources.select;
            this.ribbonMenuButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ribbonMenuButton1.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.ribbonMenuButton1.ImageOffset = 3;
            this.ribbonMenuButton1.IsPressed = false;
            this.ribbonMenuButton1.KeepPress = false;
            this.ribbonMenuButton1.Location = new System.Drawing.Point(581, 9);
            this.ribbonMenuButton1.MaxImageSize = new System.Drawing.Point(0, 0);
            this.ribbonMenuButton1.MenuPos = new System.Drawing.Point(0, 0);
            this.ribbonMenuButton1.Name = "ribbonMenuButton1";
            this.ribbonMenuButton1.Radius = 8;
            this.ribbonMenuButton1.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.ribbonMenuButton1.Size = new System.Drawing.Size(116, 30);
            this.ribbonMenuButton1.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.ribbonMenuButton1.SplitDistance = 0;
            this.ribbonMenuButton1.TabIndex = 58;
            this.ribbonMenuButton1.Text = "Submit test";
            this.ribbonMenuButton1.Title = "";
            this.ribbonMenuButton1.UseVisualStyleBackColor = true;
            this.ribbonMenuButton1.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // SubmitPreviewCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLogo);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnWebReference);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.testInfoCtrl1);
            this.Controls.Add(this.ribbonMenuButton1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTimeLeft);
            this.Controls.Add(this.dgrQuestions);
            this.Name = "SubmitPreviewCtrl";
            this.Size = new System.Drawing.Size(839, 479);
            ((System.ComponentModel.ISupportInitialize)(this.dgrQuestions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrQuestions;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.PictureBox pictureBox1;
        private RibbonStyle.RibbonMenuButton ribbonMenuButton1;
        private TestInfoCtrl testInfoCtrl1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndexCol;
        private System.Windows.Forms.DataGridViewImageColumn EditCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescCol;
        private System.Windows.Forms.DataGridViewImageColumn QuestionTypeCol;
        private RibbonStyle.RibbonMenuButton btnWebReference;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private RibbonStyle.RibbonMenuButton btnHome;
        private System.Windows.Forms.Panel pnlLogo;
    }
}
