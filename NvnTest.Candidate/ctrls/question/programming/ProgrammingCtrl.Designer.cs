namespace NvnTest.Candidate {
    partial class ProgrammingCtrl {
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAnswerType = new System.Windows.Forms.ComboBox();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.btnSave = new RibbonStyle.RibbonMenuButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose how you like to answer this question";
            // 
            // cmbAnswerType
            // 
            this.cmbAnswerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAnswerType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbAnswerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnswerType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAnswerType.FormattingEnabled = true;
            this.cmbAnswerType.ItemHeight = 21;
            this.cmbAnswerType.Items.AddRange(new object[] {
            "Write C program",
            "Write C++ program",
            "Write C# program",
            "Write VB.NET program",
            "Write Java program",
            "Give algorithmic answer",
            "Give descriptive answer"});
            this.cmbAnswerType.Location = new System.Drawing.Point(306, 6);
            this.cmbAnswerType.Name = "cmbAnswerType";
            this.cmbAnswerType.Size = new System.Drawing.Size(314, 27);
            this.cmbAnswerType.TabIndex = 1;
            this.cmbAnswerType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbAnswerType_DrawItem);
            this.cmbAnswerType.SelectedIndexChanged += new System.EventHandler(this.cmbAnswerType_SelectedIndexChanged);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.Location = new System.Drawing.Point(3, 39);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(734, 442);
            this.pnlContainer.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSave.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnSave.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnSave.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnSave.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.FadingSpeed = 0;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnSave.Image = global::NvnTest.Candidate.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnSave.ImageOffset = 3;
            this.btnSave.IsPressed = false;
            this.btnSave.KeepPress = false;
            this.btnSave.Location = new System.Drawing.Point(626, 3);
            this.btnSave.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSave.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 8;
            this.btnSave.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnSave.Size = new System.Drawing.Size(111, 30);
            this.btnSave.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnSave.SplitDistance = 0;
            this.btnSave.TabIndex = 57;
            this.btnSave.Text = "Save answer";
            this.btnSave.Title = "";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ProgrammingCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.cmbAnswerType);
            this.Controls.Add(this.label1);
            this.Name = "ProgrammingCtrl";
            this.Size = new System.Drawing.Size(740, 484);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAnswerType;
        private System.Windows.Forms.Panel pnlContainer;
        private RibbonStyle.RibbonMenuButton btnSave;
    }
}
