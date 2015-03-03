namespace NvnTest.Employer {
    partial class SettingsForm {
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
            this.updateUserInfoCtrl = new NvnTest.Employer.UpdateUserInfoCtrlcs();
            this.SuspendLayout();
            // 
            // updateUserInfoCtrl
            // 
            this.updateUserInfoCtrl.Location = new System.Drawing.Point(2, 2);
            this.updateUserInfoCtrl.Name = "updateUserInfoCtrl";
            this.updateUserInfoCtrl.Size = new System.Drawing.Size(360, 176);
            this.updateUserInfoCtrl.TabIndex = 0;
            this.updateUserInfoCtrl.UserInfo = null;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(364, 178);
            this.Controls.Add(this.updateUserInfoCtrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings...";
            this.ResumeLayout(false);

        }

        #endregion

        private UpdateUserInfoCtrlcs updateUserInfoCtrl;
    }
}