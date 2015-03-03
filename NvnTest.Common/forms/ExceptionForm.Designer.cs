namespace NvnTest.Common {
    partial class ExceptionForm {
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
            this.btnDontReport = new RibbonStyle.RibbonMenuButton();
            this.btnReport = new RibbonStyle.RibbonMenuButton();
            this.logoCtrl1 = new NvnTest.Common.LogoCtrl();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDontReport
            // 
            this.btnDontReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDontReport.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnDontReport.BackColor = System.Drawing.Color.Transparent;
            this.btnDontReport.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDontReport.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnDontReport.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnDontReport.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnDontReport.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDontReport.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDontReport.FadingSpeed = 0;
            this.btnDontReport.FlatAppearance.BorderSize = 0;
            this.btnDontReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDontReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDontReport.ForeColor = System.Drawing.Color.Black;
            this.btnDontReport.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnDontReport.Image = global::NvnTest.Common.Properties.Resources.cancel;
            this.btnDontReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDontReport.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnDontReport.ImageOffset = 3;
            this.btnDontReport.IsPressed = false;
            this.btnDontReport.KeepPress = false;
            this.btnDontReport.Location = new System.Drawing.Point(452, 95);
            this.btnDontReport.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnDontReport.MenuPos = new System.Drawing.Point(0, 0);
            this.btnDontReport.Name = "btnDontReport";
            this.btnDontReport.Radius = 8;
            this.btnDontReport.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnDontReport.Size = new System.Drawing.Size(110, 30);
            this.btnDontReport.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnDontReport.SplitDistance = 0;
            this.btnDontReport.TabIndex = 55;
            this.btnDontReport.Text = "Don\'t send";
            this.btnDontReport.Title = "";
            this.btnDontReport.UseVisualStyleBackColor = true;
            this.btnDontReport.Click += new System.EventHandler(this.btnDontReport_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnReport.BackColor = System.Drawing.Color.Transparent;
            this.btnReport.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReport.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnReport.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnReport.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnReport.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnReport.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnReport.FadingSpeed = 0;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.Black;
            this.btnReport.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnReport.Image = global::NvnTest.Common.Properties.Resources.select;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnReport.ImageOffset = 3;
            this.btnReport.IsPressed = false;
            this.btnReport.KeepPress = false;
            this.btnReport.Location = new System.Drawing.Point(310, 95);
            this.btnReport.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnReport.MenuPos = new System.Drawing.Point(0, 0);
            this.btnReport.Name = "btnReport";
            this.btnReport.Radius = 8;
            this.btnReport.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnReport.Size = new System.Drawing.Size(136, 30);
            this.btnReport.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnReport.SplitDistance = 0;
            this.btnReport.TabIndex = 54;
            this.btnReport.Text = "Send error report";
            this.btnReport.Title = "";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // logoCtrl1
            // 
            this.logoCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logoCtrl1.Location = new System.Drawing.Point(15, 79);
            this.logoCtrl1.Name = "logoCtrl1";
            this.logoCtrl1.Size = new System.Drawing.Size(149, 46);
            this.logoCtrl1.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 16);
            this.label1.TabIndex = 57;
            this.label1.Text = "Unexpected error occured !!!";
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(12, 36);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(550, 46);
            this.lblMessage.TabIndex = 58;
            this.lblMessage.Text = "Message";
            // 
            // ExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(574, 137);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logoCtrl1);
            this.Controls.Add(this.btnDontReport);
            this.Controls.Add(this.btnReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ExceptionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RibbonStyle.RibbonMenuButton btnReport;
        private RibbonStyle.RibbonMenuButton btnDontReport;
        private LogoCtrl logoCtrl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMessage;

    }
}