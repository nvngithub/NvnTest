namespace NvnTest.Employer {
    partial class WebsitesVisitedForm {
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
            this.txtUrls = new System.Windows.Forms.TextBox();
            this.btnClose = new RibbonStyle.RibbonMenuButton();
            this.SuspendLayout();
            // 
            // txtUrls
            // 
            this.txtUrls.Location = new System.Drawing.Point(12, 12);
            this.txtUrls.Multiline = true;
            this.txtUrls.Name = "txtUrls";
            this.txtUrls.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtUrls.Size = new System.Drawing.Size(586, 312);
            this.txtUrls.TabIndex = 0;
            this.txtUrls.WordWrap = false;
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
            this.btnClose.Location = new System.Drawing.Point(498, 330);
            this.btnClose.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 8;
            this.btnClose.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnClose.SplitDistance = 0;
            this.btnClose.TabIndex = 50;
            this.btnClose.Text = "Close";
            this.btnClose.Title = "";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // WebsitesVisitedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 372);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtUrls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WebsitesVisitedForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List of websites visited";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrls;
        private RibbonStyle.RibbonMenuButton btnClose;
    }
}