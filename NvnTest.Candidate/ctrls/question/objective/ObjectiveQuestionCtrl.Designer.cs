namespace NvnTest.Candidate {
    partial class ObjectiveQuestionCtrl {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectiveQuestionCtrl));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pnlAnswered = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlUnanswered = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlCurrent = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.navigationCtrl = new NvnTest.Candidate.ObjectiveQuestionsNavigationCtrl();
            this.questionsStatusCtrl = new NvnTest.Candidate.ObjectiveQuestionsStatusCtrl();
            this.objectiveOptionsCtrl1 = new NvnTest.Candidate.ObjectiveOptionsCtrl();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel1.Controls.Add(this.lblDescription);
            this.flowLayoutPanel1.Controls.Add(this.objectiveOptionsCtrl1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(22, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(870, 367);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(3, 0);
            this.lblDescription.MaximumSize = new System.Drawing.Size(800, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(799, 0);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = resources.GetString("lblDescription.Text");
            // 
            // pnlAnswered
            // 
            this.pnlAnswered.Location = new System.Drawing.Point(252, 519);
            this.pnlAnswered.Name = "pnlAnswered";
            this.pnlAnswered.Size = new System.Drawing.Size(20, 20);
            this.pnlAnswered.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 523);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Answered";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 523);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Unanswered";
            // 
            // pnlUnanswered
            // 
            this.pnlUnanswered.Location = new System.Drawing.Point(353, 519);
            this.pnlUnanswered.Name = "pnlUnanswered";
            this.pnlUnanswered.Size = new System.Drawing.Size(20, 20);
            this.pnlUnanswered.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(490, 523);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Flagged";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(576, 523);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Current";
            // 
            // pnlCurrent
            // 
            this.pnlCurrent.Location = new System.Drawing.Point(550, 519);
            this.pnlCurrent.Name = "pnlCurrent";
            this.pnlCurrent.Size = new System.Drawing.Size(20, 20);
            this.pnlCurrent.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NvnTest.Candidate.Properties.Resources.flag;
            this.pictureBox1.Location = new System.Drawing.Point(464, 519);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // navigationCtrl
            // 
            this.navigationCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.navigationCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.navigationCtrl.Location = new System.Drawing.Point(3, 376);
            this.navigationCtrl.Name = "navigationCtrl";
            this.navigationCtrl.Size = new System.Drawing.Size(909, 43);
            this.navigationCtrl.TabIndex = 7;
            // 
            // questionsStatusCtrl
            // 
            this.questionsStatusCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.questionsStatusCtrl.AutoScroll = true;
            this.questionsStatusCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.questionsStatusCtrl.Location = new System.Drawing.Point(3, 425);
            this.questionsStatusCtrl.Name = "questionsStatusCtrl";
            this.questionsStatusCtrl.Size = new System.Drawing.Size(909, 88);
            this.questionsStatusCtrl.TabIndex = 6;
            // 
            // objectiveOptionsCtrl1
            // 
            this.objectiveOptionsCtrl1.Location = new System.Drawing.Point(808, 20);
            this.objectiveOptionsCtrl1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.objectiveOptionsCtrl1.Name = "objectiveOptionsCtrl1";
            this.objectiveOptionsCtrl1.Size = new System.Drawing.Size(793, 280);
            this.objectiveOptionsCtrl1.TabIndex = 1;
            // 
            // ObjectiveQuestionCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigationCtrl);
            this.Controls.Add(this.questionsStatusCtrl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnlCurrent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlUnanswered);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlAnswered);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ObjectiveQuestionCtrl";
            this.Size = new System.Drawing.Size(915, 557);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlAnswered;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlUnanswered;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlCurrent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ObjectiveQuestionsStatusCtrl questionsStatusCtrl;
        private ObjectiveQuestionsNavigationCtrl navigationCtrl;
        private System.Windows.Forms.Label lblDescription;
        private ObjectiveOptionsCtrl objectiveOptionsCtrl1;
    }
}
