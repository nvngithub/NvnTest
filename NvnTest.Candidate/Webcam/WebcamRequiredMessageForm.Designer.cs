namespace NvnTest.Candidate {
    partial class WebcamRequiredMessageForm {
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
            this.lnkSkipWebcamDetection = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new RibbonStyle.RibbonMenuButton();
            this.SuspendLayout();
            // 
            // lnkSkipWebcamDetection
            // 
            this.lnkSkipWebcamDetection.AutoSize = true;
            this.lnkSkipWebcamDetection.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkSkipWebcamDetection.Location = new System.Drawing.Point(12, 75);
            this.lnkSkipWebcamDetection.Name = "lnkSkipWebcamDetection";
            this.lnkSkipWebcamDetection.Size = new System.Drawing.Size(288, 13);
            this.lnkSkipWebcamDetection.TabIndex = 5;
            this.lnkSkipWebcamDetection.TabStop = true;
            this.lnkSkipWebcamDetection.Text = "Do not show this window again [Demo user only]";
            this.lnkSkipWebcamDetection.Visible = false;
            this.lnkSkipWebcamDetection.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSkipWebcamDetection_LinkClicked);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(425, 34);
            this.label2.TabIndex = 7;
            this.label2.Text = "You are required to connect webcam to your computer in order to continue with thi" +
                "s test.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(98, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Webcam not detected!";
            // 
            // btnExit
            // 
            this.btnExit.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExit.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnExit.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnExit.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnExit.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExit.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FadingSpeed = 0;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnExit.Image = global::NvnTest.Candidate.Properties.Resources.cancel;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnExit.ImageOffset = 3;
            this.btnExit.IsPressed = false;
            this.btnExit.KeepPress = false;
            this.btnExit.Location = new System.Drawing.Point(337, 66);
            this.btnExit.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnExit.MenuPos = new System.Drawing.Point(0, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Radius = 8;
            this.btnExit.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnExit.Size = new System.Drawing.Size(100, 30);
            this.btnExit.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnExit.SplitDistance = 0;
            this.btnExit.TabIndex = 57;
            this.btnExit.Text = "Exit";
            this.btnExit.Title = "";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // WebcamRequiredMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 108);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lnkSkipWebcamDetection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WebcamRequiredMessageForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WebcamRequiredMessageForm";
            this.Load += new System.EventHandler(this.WebcamRequiredMessageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkSkipWebcamDetection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private RibbonStyle.RibbonMenuButton btnExit;
    }
}