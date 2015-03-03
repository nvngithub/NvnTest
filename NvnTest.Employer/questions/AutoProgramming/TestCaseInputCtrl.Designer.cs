namespace NvnTest.Employer {
    partial class TestCaseInputCtrl {
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
            this.lblArgumentName = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblArgumentName
            // 
            this.lblArgumentName.AutoSize = true;
            this.lblArgumentName.Location = new System.Drawing.Point(3, 6);
            this.lblArgumentName.Name = "lblArgumentName";
            this.lblArgumentName.Size = new System.Drawing.Size(35, 13);
            this.lblArgumentName.TabIndex = 0;
            this.lblArgumentName.Text = "Name";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(69, 3);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(210, 20);
            this.txtInput.TabIndex = 1;
            // 
            // TestCaseInputCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblArgumentName);
            this.Name = "TestCaseInputCtrl";
            this.Size = new System.Drawing.Size(282, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblArgumentName;
        private System.Windows.Forms.TextBox txtInput;
    }
}
