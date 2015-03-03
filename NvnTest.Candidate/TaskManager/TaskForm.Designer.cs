namespace NvnTest.Candidate {
    partial class TaskForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskForm));
            this.pnlTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.lnkSkipTaskManager = new System.Windows.Forms.LinkLabel();
            this.lblTimeLimitLabel = new System.Windows.Forms.Label();
            this.lblSecondsLeft = new System.Windows.Forms.Label();
            this.lblSecondsLabel = new System.Windows.Forms.Label();
            this.lblAttemptsLeft = new System.Windows.Forms.Label();
            this.lblAttemptsRemainingLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTasks
            // 
            this.pnlTasks.AutoScroll = true;
            this.pnlTasks.Location = new System.Drawing.Point(12, 78);
            this.pnlTasks.Name = "pnlTasks";
            this.pnlTasks.Size = new System.Drawing.Size(354, 201);
            this.pnlTasks.TabIndex = 1;
            // 
            // lblInstruction
            // 
            this.lblInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.ForeColor = System.Drawing.Color.Purple;
            this.lblInstruction.Location = new System.Drawing.Point(12, 9);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(354, 42);
            this.lblInstruction.TabIndex = 2;
            this.lblInstruction.Text = "Following applications need to be closed to continue with your test. You will be " +
                "disqualified from the test if listed applications are not closed in the given ti" +
                "me frame.";
            // 
            // lnkSkipTaskManager
            // 
            this.lnkSkipTaskManager.AutoSize = true;
            this.lnkSkipTaskManager.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkSkipTaskManager.Location = new System.Drawing.Point(151, 362);
            this.lnkSkipTaskManager.Name = "lnkSkipTaskManager";
            this.lnkSkipTaskManager.Size = new System.Drawing.Size(215, 16);
            this.lnkSkipTaskManager.TabIndex = 3;
            this.lnkSkipTaskManager.TabStop = true;
            this.lnkSkipTaskManager.Text = "Demo user: Skip this window";
            this.lnkSkipTaskManager.Visible = false;
            this.lnkSkipTaskManager.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSkipTaskManager_LinkClicked);
            // 
            // lblTimeLimitLabel
            // 
            this.lblTimeLimitLabel.AutoSize = true;
            this.lblTimeLimitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLimitLabel.Location = new System.Drawing.Point(12, 61);
            this.lblTimeLimitLabel.Name = "lblTimeLimitLabel";
            this.lblTimeLimitLabel.Size = new System.Drawing.Size(68, 13);
            this.lblTimeLimitLabel.TabIndex = 4;
            this.lblTimeLimitLabel.Text = "Time limit: ";
            // 
            // lblSecondsLeft
            // 
            this.lblSecondsLeft.AutoSize = true;
            this.lblSecondsLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecondsLeft.ForeColor = System.Drawing.Color.Red;
            this.lblSecondsLeft.Location = new System.Drawing.Point(73, 62);
            this.lblSecondsLeft.Name = "lblSecondsLeft";
            this.lblSecondsLeft.Size = new System.Drawing.Size(21, 13);
            this.lblSecondsLeft.TabIndex = 5;
            this.lblSecondsLeft.Text = "00";
            // 
            // lblSecondsLabel
            // 
            this.lblSecondsLabel.AutoSize = true;
            this.lblSecondsLabel.Location = new System.Drawing.Point(91, 61);
            this.lblSecondsLabel.Name = "lblSecondsLabel";
            this.lblSecondsLabel.Size = new System.Drawing.Size(47, 13);
            this.lblSecondsLabel.TabIndex = 6;
            this.lblSecondsLabel.Text = "seconds";
            // 
            // lblAttemptsLeft
            // 
            this.lblAttemptsLeft.AutoSize = true;
            this.lblAttemptsLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttemptsLeft.ForeColor = System.Drawing.Color.Red;
            this.lblAttemptsLeft.Location = new System.Drawing.Point(302, 63);
            this.lblAttemptsLeft.Name = "lblAttemptsLeft";
            this.lblAttemptsLeft.Size = new System.Drawing.Size(14, 13);
            this.lblAttemptsLeft.TabIndex = 8;
            this.lblAttemptsLeft.Text = "0";
            // 
            // lblAttemptsRemainingLabel
            // 
            this.lblAttemptsRemainingLabel.AutoSize = true;
            this.lblAttemptsRemainingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttemptsRemainingLabel.Location = new System.Drawing.Point(187, 61);
            this.lblAttemptsRemainingLabel.Name = "lblAttemptsRemainingLabel";
            this.lblAttemptsRemainingLabel.Size = new System.Drawing.Size(122, 13);
            this.lblAttemptsRemainingLabel.TabIndex = 7;
            this.lblAttemptsRemainingLabel.Text = "Attempts remaining: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NvnTest.Candidate.Properties.Resources.select;
            this.pictureBox1.Location = new System.Drawing.Point(12, 292);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(50, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 68);
            this.label1.TabIndex = 10;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(378, 387);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblAttemptsLeft);
            this.Controls.Add(this.lblAttemptsRemainingLabel);
            this.Controls.Add(this.lblSecondsLabel);
            this.Controls.Add(this.lblSecondsLeft);
            this.Controls.Add(this.lblTimeLimitLabel);
            this.Controls.Add(this.lnkSkipTaskManager);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.pnlTasks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TaskForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Task Form";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlTasks;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.LinkLabel lnkSkipTaskManager;
        private System.Windows.Forms.Label lblTimeLimitLabel;
        private System.Windows.Forms.Label lblSecondsLeft;
        private System.Windows.Forms.Label lblSecondsLabel;
        private System.Windows.Forms.Label lblAttemptsLeft;
        private System.Windows.Forms.Label lblAttemptsRemainingLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}