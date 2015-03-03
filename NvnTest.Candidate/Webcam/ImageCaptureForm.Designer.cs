namespace NvnTest.Candidate {
    partial class ImageCaptureForm {
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
            this.pbLiveImages = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLiveImages)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLiveImages
            // 
            this.pbLiveImages.Location = new System.Drawing.Point(0, 0);
            this.pbLiveImages.Name = "pbLiveImages";
            this.pbLiveImages.Size = new System.Drawing.Size(50, 50);
            this.pbLiveImages.TabIndex = 0;
            this.pbLiveImages.TabStop = false;
            // 
            // ImageCaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(50, 50);
            this.Controls.Add(this.pbLiveImages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImageCaptureForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ImageCaptureForm";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pbLiveImages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLiveImages;
    }
}