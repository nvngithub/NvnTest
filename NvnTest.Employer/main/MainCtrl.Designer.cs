namespace NvnTest.Employer {
    partial class MainCtrl {
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
            this.tbPapers = new System.Windows.Forms.TabPage();
            this.lnkLogout = new System.Windows.Forms.LinkLabel();
            this.tbSchedules = new System.Windows.Forms.TabPage();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tbQuestions = new System.Windows.Forms.TabPage();
            this.lnkSettings = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkTerms = new System.Windows.Forms.LinkLabel();
            this.pbLogout = new System.Windows.Forms.PictureBox();
            this.pbSettings = new System.Windows.Forms.PictureBox();
            this.pbRefresh = new System.Windows.Forms.PictureBox();
            this.lnkRefresh = new System.Windows.Forms.LinkLabel();
            this.pbUserExtensions = new System.Windows.Forms.PictureBox();
            this.lnkUserExtensions = new System.Windows.Forms.LinkLabel();
            this.logoCtrl1 = new NvnTest.Common.LogoCtrl();
            this.schedulesCtrl1 = new NvnTest.Employer.SchedulesCtrl();
            this.papersCtrl1 = new NvnTest.Employer.PapersCtrl();
            this.questionsCtrl1 = new NvnTest.Employer.QuestionsCtrl();
            this.tbPapers.SuspendLayout();
            this.tbSchedules.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.tbQuestions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserExtensions)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPapers
            // 
            this.tbPapers.Controls.Add(this.papersCtrl1);
            this.tbPapers.Location = new System.Drawing.Point(4, 24);
            this.tbPapers.Name = "tbPapers";
            this.tbPapers.Padding = new System.Windows.Forms.Padding(3);
            this.tbPapers.Size = new System.Drawing.Size(1134, 502);
            this.tbPapers.TabIndex = 0;
            this.tbPapers.Text = "Papers";
            this.tbPapers.UseVisualStyleBackColor = true;
            // 
            // lnkLogout
            // 
            this.lnkLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkLogout.AutoSize = true;
            this.lnkLogout.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkLogout.Location = new System.Drawing.Point(1101, 556);
            this.lnkLogout.Name = "lnkLogout";
            this.lnkLogout.Size = new System.Drawing.Size(40, 13);
            this.lnkLogout.TabIndex = 5;
            this.lnkLogout.TabStop = true;
            this.lnkLogout.Text = "Logout";
            this.lnkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogout_LinkClicked);
            // 
            // tbSchedules
            // 
            this.tbSchedules.Controls.Add(this.schedulesCtrl1);
            this.tbSchedules.Location = new System.Drawing.Point(4, 24);
            this.tbSchedules.Name = "tbSchedules";
            this.tbSchedules.Padding = new System.Windows.Forms.Padding(3);
            this.tbSchedules.Size = new System.Drawing.Size(1134, 502);
            this.tbSchedules.TabIndex = 1;
            this.tbSchedules.Text = "Schedules";
            this.tbSchedules.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(541, 563);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 9;
            // 
            // tbMain
            // 
            this.tbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMain.Controls.Add(this.tbSchedules);
            this.tbMain.Controls.Add(this.tbPapers);
            this.tbMain.Controls.Add(this.tbQuestions);
            this.tbMain.ItemSize = new System.Drawing.Size(150, 20);
            this.tbMain.Location = new System.Drawing.Point(3, 3);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(1142, 530);
            this.tbMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbMain.TabIndex = 7;
            // 
            // tbQuestions
            // 
            this.tbQuestions.Controls.Add(this.questionsCtrl1);
            this.tbQuestions.Location = new System.Drawing.Point(4, 24);
            this.tbQuestions.Name = "tbQuestions";
            this.tbQuestions.Size = new System.Drawing.Size(1134, 502);
            this.tbQuestions.TabIndex = 2;
            this.tbQuestions.Text = "Questions";
            this.tbQuestions.UseVisualStyleBackColor = true;
            // 
            // lnkSettings
            // 
            this.lnkSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkSettings.AutoSize = true;
            this.lnkSettings.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkSettings.Location = new System.Drawing.Point(1016, 556);
            this.lnkSettings.Name = "lnkSettings";
            this.lnkSettings.Size = new System.Drawing.Size(45, 13);
            this.lnkSettings.TabIndex = 6;
            this.lnkSettings.TabStop = true;
            this.lnkSettings.Text = "Settings";
            this.lnkSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSettings_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(427, 556);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Copyright © Coderlabz. All rights reserved";
            // 
            // lnkTerms
            // 
            this.lnkTerms.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lnkTerms.AutoSize = true;
            this.lnkTerms.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkTerms.Location = new System.Drawing.Point(629, 556);
            this.lnkTerms.Name = "lnkTerms";
            this.lnkTerms.Size = new System.Drawing.Size(85, 13);
            this.lnkTerms.TabIndex = 13;
            this.lnkTerms.TabStop = true;
            this.lnkTerms.Text = "Terms of service";
            this.lnkTerms.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTerms_LinkClicked);
            // 
            // pbLogout
            // 
            this.pbLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLogout.Image = global::NvnTest.Employer.Properties.Resources.logout;
            this.pbLogout.Location = new System.Drawing.Point(1067, 546);
            this.pbLogout.Name = "pbLogout";
            this.pbLogout.Size = new System.Drawing.Size(32, 32);
            this.pbLogout.TabIndex = 11;
            this.pbLogout.TabStop = false;
            this.pbLogout.Click += new System.EventHandler(this.pbLogout_Click);
            // 
            // pbSettings
            // 
            this.pbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSettings.Image = global::NvnTest.Employer.Properties.Resources.settings;
            this.pbSettings.Location = new System.Drawing.Point(978, 546);
            this.pbSettings.Name = "pbSettings";
            this.pbSettings.Size = new System.Drawing.Size(32, 32);
            this.pbSettings.TabIndex = 10;
            this.pbSettings.TabStop = false;
            this.pbSettings.Click += new System.EventHandler(this.pbSettings_Click);
            // 
            // pbRefresh
            // 
            this.pbRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbRefresh.Image = global::NvnTest.Employer.Properties.Resources.refresh;
            this.pbRefresh.Location = new System.Drawing.Point(769, 546);
            this.pbRefresh.Name = "pbRefresh";
            this.pbRefresh.Size = new System.Drawing.Size(32, 32);
            this.pbRefresh.TabIndex = 16;
            this.pbRefresh.TabStop = false;
            this.pbRefresh.Click += new System.EventHandler(this.pbRefresh_Click);
            // 
            // lnkRefresh
            // 
            this.lnkRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkRefresh.AutoSize = true;
            this.lnkRefresh.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkRefresh.Location = new System.Drawing.Point(807, 556);
            this.lnkRefresh.Name = "lnkRefresh";
            this.lnkRefresh.Size = new System.Drawing.Size(44, 13);
            this.lnkRefresh.TabIndex = 15;
            this.lnkRefresh.TabStop = true;
            this.lnkRefresh.Text = "Refresh";
            this.lnkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRefresh_LinkClicked);
            // 
            // pbUserExtensions
            // 
            this.pbUserExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbUserExtensions.Image = global::NvnTest.Employer.Properties.Resources.add_user;
            this.pbUserExtensions.Location = new System.Drawing.Point(857, 546);
            this.pbUserExtensions.Name = "pbUserExtensions";
            this.pbUserExtensions.Size = new System.Drawing.Size(32, 32);
            this.pbUserExtensions.TabIndex = 18;
            this.pbUserExtensions.TabStop = false;
            this.pbUserExtensions.Click += new System.EventHandler(this.pbUserExtensions_Click);
            // 
            // lnkUserExtensions
            // 
            this.lnkUserExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkUserExtensions.AutoSize = true;
            this.lnkUserExtensions.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkUserExtensions.Location = new System.Drawing.Point(895, 556);
            this.lnkUserExtensions.Name = "lnkUserExtensions";
            this.lnkUserExtensions.Size = new System.Drawing.Size(77, 13);
            this.lnkUserExtensions.TabIndex = 17;
            this.lnkUserExtensions.TabStop = true;
            this.lnkUserExtensions.Text = "User extension";
            this.lnkUserExtensions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUserExtensions_LinkClicked);
            // 
            // logoCtrl1
            // 
            this.logoCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logoCtrl1.Location = new System.Drawing.Point(3, 532);
            this.logoCtrl1.Name = "logoCtrl1";
            this.logoCtrl1.Size = new System.Drawing.Size(150, 51);
            this.logoCtrl1.TabIndex = 19;
            // 
            // schedulesCtrl1
            // 
            this.schedulesCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulesCtrl1.Location = new System.Drawing.Point(3, 3);
            this.schedulesCtrl1.Name = "schedulesCtrl1";
            this.schedulesCtrl1.Size = new System.Drawing.Size(1128, 496);
            this.schedulesCtrl1.TabIndex = 0;
            // 
            // papersCtrl1
            // 
            this.papersCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.papersCtrl1.Location = new System.Drawing.Point(3, 3);
            this.papersCtrl1.Name = "papersCtrl1";
            this.papersCtrl1.Size = new System.Drawing.Size(1128, 496);
            this.papersCtrl1.TabIndex = 0;
            // 
            // questionsCtrl1
            // 
            this.questionsCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionsCtrl1.Location = new System.Drawing.Point(0, 0);
            this.questionsCtrl1.Name = "questionsCtrl1";
            this.questionsCtrl1.Size = new System.Drawing.Size(1134, 502);
            this.questionsCtrl1.TabIndex = 0;
            // 
            // MainCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.logoCtrl1);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.pbUserExtensions);
            this.Controls.Add(this.lnkUserExtensions);
            this.Controls.Add(this.pbRefresh);
            this.Controls.Add(this.lnkRefresh);
            this.Controls.Add(this.lnkTerms);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbLogout);
            this.Controls.Add(this.pbSettings);
            this.Controls.Add(this.lnkLogout);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lnkSettings);
            this.Name = "MainCtrl";
            this.Size = new System.Drawing.Size(1149, 583);
            this.tbPapers.ResumeLayout(false);
            this.tbSchedules.ResumeLayout(false);
            this.tbMain.ResumeLayout(false);
            this.tbQuestions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserExtensions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tbPapers;
        private PapersCtrl papersCtrl1;
        private System.Windows.Forms.LinkLabel lnkLogout;
        private System.Windows.Forms.TabPage tbSchedules;
        private QuestionsCtrl questionsCtrl1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage tbQuestions;
        private System.Windows.Forms.LinkLabel lnkSettings;
        private SchedulesCtrl schedulesCtrl1;
        private System.Windows.Forms.PictureBox pbSettings;
        private System.Windows.Forms.PictureBox pbLogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkTerms;
        private System.Windows.Forms.PictureBox pbRefresh;
        private System.Windows.Forms.LinkLabel lnkRefresh;
        private System.Windows.Forms.PictureBox pbUserExtensions;
        private System.Windows.Forms.LinkLabel lnkUserExtensions;
        private NvnTest.Common.LogoCtrl logoCtrl1;

    }
}
