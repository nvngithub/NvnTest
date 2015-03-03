namespace NvnTest.Candidate {
    partial class ObjectiveCtrl {
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.btnHome = new RibbonStyle.RibbonMenuButton();
            this.btnWebReference = new RibbonStyle.RibbonMenuButton();
            this.testInfoCtrl1 = new NvnTest.Candidate.TestInfoCtrl();
            this.btnSubmit = new RibbonStyle.RibbonMenuButton();
            this.objectiveQuestionCtrl1 = new NvnTest.Candidate.ObjectiveQuestionCtrl();
            this.pnlLogo = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::NvnTest.Candidate.Properties.Resources.timer;
            this.pictureBox1.Location = new System.Drawing.Point(869, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLeft.Location = new System.Drawing.Point(923, 18);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(57, 13);
            this.lblTimeLeft.TabIndex = 65;
            this.lblTimeLeft.Text = "00:00:00";
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
            this.btnHome.Location = new System.Drawing.Point(600, 9);
            this.btnHome.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnHome.MenuPos = new System.Drawing.Point(0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Radius = 8;
            this.btnHome.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnHome.Size = new System.Drawing.Size(112, 30);
            this.btnHome.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnHome.SplitDistance = 0;
            this.btnHome.TabIndex = 71;
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
            this.btnWebReference.Location = new System.Drawing.Point(469, 9);
            this.btnWebReference.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnWebReference.MenuPos = new System.Drawing.Point(0, 0);
            this.btnWebReference.Name = "btnWebReference";
            this.btnWebReference.Radius = 8;
            this.btnWebReference.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnWebReference.Size = new System.Drawing.Size(125, 30);
            this.btnWebReference.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnWebReference.SplitDistance = 0;
            this.btnWebReference.TabIndex = 70;
            this.btnWebReference.Text = "Web reference";
            this.btnWebReference.Title = "";
            this.btnWebReference.UseVisualStyleBackColor = true;
            this.btnWebReference.Click += new System.EventHandler(this.btnWebReference_Click);
            // 
            // testInfoCtrl1
            // 
            this.testInfoCtrl1.Location = new System.Drawing.Point(4, 1);
            this.testInfoCtrl1.Name = "testInfoCtrl1";
            this.testInfoCtrl1.Size = new System.Drawing.Size(270, 60);
            this.testInfoCtrl1.TabIndex = 69;
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
            this.btnSubmit.Location = new System.Drawing.Point(718, 9);
            this.btnSubmit.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSubmit.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Radius = 8;
            this.btnSubmit.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnSubmit.Size = new System.Drawing.Size(135, 30);
            this.btnSubmit.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnSubmit.SplitDistance = 0;
            this.btnSubmit.TabIndex = 68;
            this.btnSubmit.Text = "Submit preview";
            this.btnSubmit.Title = "";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // objectiveQuestionCtrl1
            // 
            this.objectiveQuestionCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.objectiveQuestionCtrl1.Location = new System.Drawing.Point(4, 95);
            this.objectiveQuestionCtrl1.Name = "objectiveQuestionCtrl1";
            this.objectiveQuestionCtrl1.Size = new System.Drawing.Size(980, 405);
            this.objectiveQuestionCtrl1.TabIndex = 72;
            // 
            // pnlLogo
            // 
            this.pnlLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLogo.Location = new System.Drawing.Point(4, 445);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(180, 55);
            this.pnlLogo.TabIndex = 73;
            // 
            // ObjectiveCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLogo);
            this.Controls.Add(this.objectiveQuestionCtrl1);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnWebReference);
            this.Controls.Add(this.testInfoCtrl1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTimeLeft);
            this.Name = "ObjectiveCtrl";
            this.Size = new System.Drawing.Size(987, 503);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RibbonStyle.RibbonMenuButton btnHome;
        private RibbonStyle.RibbonMenuButton btnWebReference;
        private TestInfoCtrl testInfoCtrl1;
        private RibbonStyle.RibbonMenuButton btnSubmit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTimeLeft;
        private ObjectiveQuestionCtrl objectiveQuestionCtrl1;
        private System.Windows.Forms.Panel pnlLogo;
    }
}
