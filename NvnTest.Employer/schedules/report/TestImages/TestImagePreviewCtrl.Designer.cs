namespace NvnTest.Employer {
    partial class TestImagePreviewCtrl {
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
            this.pbTestImage = new System.Windows.Forms.PictureBox();
            this.lblTimeTaken = new System.Windows.Forms.Label();
            this.lnkView = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTestImage
            // 
            this.pbTestImage.Location = new System.Drawing.Point(3, 3);
            this.pbTestImage.Name = "pbTestImage";
            this.pbTestImage.Size = new System.Drawing.Size(178, 119);
            this.pbTestImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTestImage.TabIndex = 0;
            this.pbTestImage.TabStop = false;
            // 
            // lblTimeTaken
            // 
            this.lblTimeTaken.AutoSize = true;
            this.lblTimeTaken.Location = new System.Drawing.Point(3, 125);
            this.lblTimeTaken.Name = "lblTimeTaken";
            this.lblTimeTaken.Size = new System.Drawing.Size(49, 13);
            this.lblTimeTaken.TabIndex = 1;
            this.lblTimeTaken.Text = "00:00:00";
            // 
            // lnkView
            // 
            this.lnkView.AutoSize = true;
            this.lnkView.Location = new System.Drawing.Point(151, 125);
            this.lnkView.Name = "lnkView";
            this.lnkView.Size = new System.Drawing.Size(30, 13);
            this.lnkView.TabIndex = 2;
            this.lnkView.TabStop = true;
            this.lnkView.Text = "View";
            this.lnkView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkView_LinkClicked);
            // 
            // TestImagePreviewCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lnkView);
            this.Controls.Add(this.lblTimeTaken);
            this.Controls.Add(this.pbTestImage);
            this.Name = "TestImagePreviewCtrl";
            this.Size = new System.Drawing.Size(184, 138);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTestImage;
        private System.Windows.Forms.Label lblTimeTaken;
        private System.Windows.Forms.LinkLabel lnkView;
    }
}
