namespace NvnTest.Candidate {
    partial class VideoPreviewForm {
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
            this.pbLive = new System.Windows.Forms.PictureBox();
            this.btnContinue = new RibbonStyle.RibbonMenuButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new RibbonStyle.RibbonMenuButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbLive)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLive
            // 
            this.pbLive.Location = new System.Drawing.Point(12, 12);
            this.pbLive.Name = "pbLive";
            this.pbLive.Size = new System.Drawing.Size(370, 370);
            this.pbLive.TabIndex = 5;
            this.pbLive.TabStop = false;
            // 
            // btnContinue
            // 
            this.btnContinue.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnContinue.BackColor = System.Drawing.Color.Transparent;
            this.btnContinue.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnContinue.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnContinue.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnContinue.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnContinue.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnContinue.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnContinue.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnContinue.FadingSpeed = 0;
            this.btnContinue.FlatAppearance.BorderSize = 0;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.ForeColor = System.Drawing.Color.Black;
            this.btnContinue.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnContinue.Image = global::NvnTest.Candidate.Properties.Resources.select;
            this.btnContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContinue.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnContinue.ImageOffset = 3;
            this.btnContinue.IsPressed = false;
            this.btnContinue.KeepPress = false;
            this.btnContinue.Location = new System.Drawing.Point(163, 438);
            this.btnContinue.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnContinue.MenuPos = new System.Drawing.Point(0, 0);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Radius = 8;
            this.btnContinue.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnContinue.Size = new System.Drawing.Size(113, 30);
            this.btnContinue.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnContinue.SplitDistance = 0;
            this.btnContinue.TabIndex = 58;
            this.btnContinue.Text = "Continue";
            this.btnContinue.Title = "";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(10, 389);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 15);
            this.label1.TabIndex = 59;
            this.label1.Text = "NvnTest successfully detected webcam connected to your computer.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Location = new System.Drawing.Point(12, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(371, 15);
            this.label2.TabIndex = 60;
            this.label2.Text = "Please position webcam properly so that your face is correctly visible.";
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
            this.btnExit.Location = new System.Drawing.Point(282, 438);
            this.btnExit.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnExit.MenuPos = new System.Drawing.Point(0, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Radius = 8;
            this.btnExit.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnExit.Size = new System.Drawing.Size(100, 30);
            this.btnExit.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnExit.SplitDistance = 0;
            this.btnExit.TabIndex = 61;
            this.btnExit.Text = "Exit";
            this.btnExit.Title = "";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // VideoStreamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(394, 480);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.pbLive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VideoStreamForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VideoStreamForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbLive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RibbonStyle.RibbonMenuButton btnContinue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbLive;
        private RibbonStyle.RibbonMenuButton btnExit;
    }
}