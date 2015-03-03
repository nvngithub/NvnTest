namespace NvnTest.Candidate {
    partial class ObjectiveQuestionsStatusItemCtrl {
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
            this.pbFlagged = new System.Windows.Forms.PictureBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblIndex = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlagged)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFlagged
            // 
            this.pbFlagged.Image = global::NvnTest.Candidate.Properties.Resources.flag;
            this.pbFlagged.Location = new System.Drawing.Point(7, 0);
            this.pbFlagged.Name = "pbFlagged";
            this.pbFlagged.Size = new System.Drawing.Size(20, 20);
            this.pbFlagged.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFlagged.TabIndex = 2;
            this.pbFlagged.TabStop = false;
            // 
            // pnlStatus
            // 
            this.pnlStatus.Location = new System.Drawing.Point(7, 19);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(20, 20);
            this.pnlStatus.TabIndex = 3;
            // 
            // lblIndex
            // 
            this.lblIndex.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndex.Location = new System.Drawing.Point(4, 40);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(27, 20);
            this.lblIndex.TabIndex = 4;
            this.lblIndex.TabStop = true;
            this.lblIndex.Text = "10";
            this.lblIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIndex.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblIndex_LinkClicked);
            // 
            // ObjectiveQuestionsStatusItemCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblIndex);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pbFlagged);
            this.Name = "ObjectiveQuestionsStatusItemCtrl";
            this.Size = new System.Drawing.Size(35, 62);
            ((System.ComponentModel.ISupportInitialize)(this.pbFlagged)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFlagged;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.LinkLabel lblIndex;
    }
}
