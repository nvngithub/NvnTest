namespace NvnTest.Employer {
    partial class TestCaseCtrl {
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddNewTestCase = new RibbonStyle.RibbonMenuButton();
            this.pnlTestCases = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Test cases";
            // 
            // btnAddNewTestCase
            // 
            this.btnAddNewTestCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewTestCase.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnAddNewTestCase.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewTestCase.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddNewTestCase.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnAddNewTestCase.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAddNewTestCase.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAddNewTestCase.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddNewTestCase.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAddNewTestCase.FadingSpeed = 0;
            this.btnAddNewTestCase.FlatAppearance.BorderSize = 0;
            this.btnAddNewTestCase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewTestCase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewTestCase.ForeColor = System.Drawing.Color.Black;
            this.btnAddNewTestCase.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnAddNewTestCase.Image = global::NvnTest.Employer.Properties.Resources.add;
            this.btnAddNewTestCase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewTestCase.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnAddNewTestCase.ImageOffset = 3;
            this.btnAddNewTestCase.IsPressed = false;
            this.btnAddNewTestCase.KeepPress = false;
            this.btnAddNewTestCase.Location = new System.Drawing.Point(205, 3);
            this.btnAddNewTestCase.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAddNewTestCase.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAddNewTestCase.Name = "btnAddNewTestCase";
            this.btnAddNewTestCase.Radius = 8;
            this.btnAddNewTestCase.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnAddNewTestCase.Size = new System.Drawing.Size(136, 30);
            this.btnAddNewTestCase.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnAddNewTestCase.SplitDistance = 0;
            this.btnAddNewTestCase.TabIndex = 55;
            this.btnAddNewTestCase.Text = "Add new test case";
            this.btnAddNewTestCase.Title = "";
            this.btnAddNewTestCase.UseVisualStyleBackColor = true;
            this.btnAddNewTestCase.Click += new System.EventHandler(this.btnAddNewTestCase_Click);
            // 
            // pnlTestCases
            // 
            this.pnlTestCases.AutoScroll = true;
            this.pnlTestCases.Location = new System.Drawing.Point(6, 39);
            this.pnlTestCases.Name = "pnlTestCases";
            this.pnlTestCases.Size = new System.Drawing.Size(335, 198);
            this.pnlTestCases.TabIndex = 56;
            // 
            // TestCaseCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTestCases);
            this.Controls.Add(this.btnAddNewTestCase);
            this.Controls.Add(this.label3);
            this.Name = "TestCaseCtrl";
            this.Size = new System.Drawing.Size(344, 240);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RibbonStyle.RibbonMenuButton btnAddNewTestCase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel pnlTestCases;
    }
}
