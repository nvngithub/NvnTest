namespace NvnTest.Candidate {
    partial class QuestionsListCtrl {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrQuestions = new System.Windows.Forms.DataGridView();
            this.IndexCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuestionTypeCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHome = new RibbonStyle.RibbonMenuButton();
            this.btnWebReference = new RibbonStyle.RibbonMenuButton();
            this.testInfoCtrl1 = new NvnTest.Candidate.TestInfoCtrl();
            this.btnSubmit = new RibbonStyle.RibbonMenuButton();
            this.btnViewSelectedQuestion = new RibbonStyle.RibbonMenuButton();
            this.pnlLogo = new System.Windows.Forms.Panel();
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
            this.dgrQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrQuestions.ColumnHeadersVisible = false;
            this.dgrQuestions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IndexCol,
            this.DescCol,
            this.QuestionTypeCol});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrQuestions.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrQuestions.Location = new System.Drawing.Point(3, 86);
            this.dgrQuestions.MultiSelect = false;
            this.dgrQuestions.Name = "dgrQuestions";
            this.dgrQuestions.ReadOnly = true;
            this.dgrQuestions.RowHeadersVisible = false;
            this.dgrQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrQuestions.Size = new System.Drawing.Size(976, 321);
            this.dgrQuestions.TabIndex = 0;
            this.dgrQuestions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // IndexCol
            // 
            this.IndexCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IndexCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.IndexCol.HeaderText = "Index";
            this.IndexCol.Name = "IndexCol";
            this.IndexCol.ReadOnly = true;
            this.IndexCol.Width = 40;
            // 
            // DescCol
            // 
            this.DescCol.HeaderText = "Description";
            this.DescCol.Name = "DescCol";
            this.DescCol.ReadOnly = true;
            // 
            // QuestionTypeCol
            // 
            this.QuestionTypeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.QuestionTypeCol.HeaderText = "Question Type";
            this.QuestionTypeCol.Name = "QuestionTypeCol";
            this.QuestionTypeCol.ReadOnly = true;
            this.QuestionTypeCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.QuestionTypeCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLeft.Location = new System.Drawing.Point(922, 17);
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
            this.label1.Location = new System.Drawing.Point(3, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 20);
            this.label1.TabIndex = 62;
            this.label1.Text = "List of programming questions";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::NvnTest.Candidate.Properties.Resources.timer;
            this.pictureBox1.Location = new System.Drawing.Point(868, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
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
            this.btnHome.Location = new System.Drawing.Point(426, 8);
            this.btnHome.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnHome.MenuPos = new System.Drawing.Point(0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Radius = 8;
            this.btnHome.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnHome.Size = new System.Drawing.Size(112, 30);
            this.btnHome.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnHome.SplitDistance = 0;
            this.btnHome.TabIndex = 64;
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
            this.btnWebReference.Location = new System.Drawing.Point(295, 8);
            this.btnWebReference.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnWebReference.MenuPos = new System.Drawing.Point(0, 0);
            this.btnWebReference.Name = "btnWebReference";
            this.btnWebReference.Radius = 8;
            this.btnWebReference.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnWebReference.Size = new System.Drawing.Size(125, 30);
            this.btnWebReference.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnWebReference.SplitDistance = 0;
            this.btnWebReference.TabIndex = 63;
            this.btnWebReference.Text = "Web reference";
            this.btnWebReference.Title = "";
            this.btnWebReference.UseVisualStyleBackColor = true;
            this.btnWebReference.Click += new System.EventHandler(this.btnWebReference_Click);
            // 
            // testInfoCtrl1
            // 
            this.testInfoCtrl1.Location = new System.Drawing.Point(3, 0);
            this.testInfoCtrl1.Name = "testInfoCtrl1";
            this.testInfoCtrl1.Size = new System.Drawing.Size(270, 60);
            this.testInfoCtrl1.TabIndex = 53;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSubmit.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnSubmit.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnSubmit.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnSubmit.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSubmit.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSubmit.FadingSpeed = 0;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.Black;
            this.btnSubmit.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnSubmit.Image = global::NvnTest.Candidate.Properties.Resources.select;
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubmit.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnSubmit.ImageOffset = 3;
            this.btnSubmit.IsPressed = false;
            this.btnSubmit.KeepPress = false;
            this.btnSubmit.Location = new System.Drawing.Point(717, 8);
            this.btnSubmit.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSubmit.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Radius = 8;
            this.btnSubmit.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnSubmit.Size = new System.Drawing.Size(135, 30);
            this.btnSubmit.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnSubmit.SplitDistance = 0;
            this.btnSubmit.TabIndex = 51;
            this.btnSubmit.Text = "Submit preview";
            this.btnSubmit.Title = "";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnViewSelectedQuestion
            // 
            this.btnViewSelectedQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewSelectedQuestion.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnViewSelectedQuestion.BackColor = System.Drawing.Color.Transparent;
            this.btnViewSelectedQuestion.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnViewSelectedQuestion.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnViewSelectedQuestion.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnViewSelectedQuestion.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnViewSelectedQuestion.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnViewSelectedQuestion.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnViewSelectedQuestion.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnViewSelectedQuestion.FadingSpeed = 0;
            this.btnViewSelectedQuestion.FlatAppearance.BorderSize = 0;
            this.btnViewSelectedQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewSelectedQuestion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSelectedQuestion.ForeColor = System.Drawing.Color.Black;
            this.btnViewSelectedQuestion.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnViewSelectedQuestion.Image = global::NvnTest.Candidate.Properties.Resources.view;
            this.btnViewSelectedQuestion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewSelectedQuestion.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnViewSelectedQuestion.ImageOffset = 3;
            this.btnViewSelectedQuestion.IsPressed = false;
            this.btnViewSelectedQuestion.KeepPress = false;
            this.btnViewSelectedQuestion.Location = new System.Drawing.Point(544, 8);
            this.btnViewSelectedQuestion.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnViewSelectedQuestion.MenuPos = new System.Drawing.Point(0, 0);
            this.btnViewSelectedQuestion.Name = "btnViewSelectedQuestion";
            this.btnViewSelectedQuestion.Radius = 8;
            this.btnViewSelectedQuestion.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnViewSelectedQuestion.Size = new System.Drawing.Size(167, 30);
            this.btnViewSelectedQuestion.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnViewSelectedQuestion.SplitDistance = 0;
            this.btnViewSelectedQuestion.TabIndex = 50;
            this.btnViewSelectedQuestion.Text = "View selected question";
            this.btnViewSelectedQuestion.Title = "";
            this.btnViewSelectedQuestion.UseVisualStyleBackColor = true;
            this.btnViewSelectedQuestion.Click += new System.EventHandler(this.btnViewSelectedQuestion_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLogo.Location = new System.Drawing.Point(3, 413);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(180, 55);
            this.pnlLogo.TabIndex = 68;
            // 
            // QuestionsListCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLogo);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnWebReference);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.testInfoCtrl1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnViewSelectedQuestion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTimeLeft);
            this.Controls.Add(this.dgrQuestions);
            this.Name = "QuestionsListCtrl";
            this.Size = new System.Drawing.Size(982, 471);
            ((System.ComponentModel.ISupportInitialize)(this.dgrQuestions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrQuestions;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.PictureBox pictureBox1;
        private RibbonStyle.RibbonMenuButton btnViewSelectedQuestion;
        private RibbonStyle.RibbonMenuButton btnSubmit;
        private TestInfoCtrl testInfoCtrl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndexCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescCol;
        private System.Windows.Forms.DataGridViewImageColumn QuestionTypeCol;
        private System.Windows.Forms.Label label1;
        private RibbonStyle.RibbonMenuButton btnWebReference;
        private RibbonStyle.RibbonMenuButton btnHome;
        private System.Windows.Forms.Panel pnlLogo;
    }
}
