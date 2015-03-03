namespace NvnTest.Employer {
    partial class TestImagesPreviewForm {
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
            this.pnlImagePreview = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new RibbonStyle.RibbonMenuButton();
            this.SuspendLayout();
            // 
            // pnlImagePreview
            // 
            this.pnlImagePreview.AutoScroll = true;
            this.pnlImagePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlImagePreview.Location = new System.Drawing.Point(12, 12);
            this.pnlImagePreview.Name = "pnlImagePreview";
            this.pnlImagePreview.Size = new System.Drawing.Size(784, 311);
            this.pnlImagePreview.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnClose.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnClose.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnClose.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FadingSpeed = 0;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnClose.Image = global::NvnTest.Employer.Properties.Resources.cancel;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnClose.ImageOffset = 3;
            this.btnClose.IsPressed = false;
            this.btnClose.KeepPress = false;
            this.btnClose.Location = new System.Drawing.Point(696, 329);
            this.btnClose.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 8;
            this.btnClose.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnClose.SplitDistance = 0;
            this.btnClose.TabIndex = 54;
            this.btnClose.Text = "Close";
            this.btnClose.Title = "";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TestImagesPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 371);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlImagePreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TestImagesPreviewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Images captured...";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlImagePreview;
        private RibbonStyle.RibbonMenuButton btnClose;
    }
}