namespace NvnTest.Employer {
    partial class FunctionSignatureCtrl {
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
            this.lblSignaturePreview = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbReturnType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFunctionName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlArgs = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddArgument = new RibbonStyle.RibbonMenuButton();
            this.SuspendLayout();
            // 
            // lblSignaturePreview
            // 
            this.lblSignaturePreview.AutoSize = true;
            this.lblSignaturePreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignaturePreview.Location = new System.Drawing.Point(3, 0);
            this.lblSignaturePreview.Name = "lblSignaturePreview";
            this.lblSignaturePreview.Size = new System.Drawing.Size(172, 13);
            this.lblSignaturePreview.TabIndex = 0;
            this.lblSignaturePreview.Text = "Function signature undefined";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Return Type";
            // 
            // cmbReturnType
            // 
            this.cmbReturnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReturnType.FormattingEnabled = true;
            this.cmbReturnType.Location = new System.Drawing.Point(88, 26);
            this.cmbReturnType.Name = "cmbReturnType";
            this.cmbReturnType.Size = new System.Drawing.Size(212, 21);
            this.cmbReturnType.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Function Name";
            // 
            // txtFunctionName
            // 
            this.txtFunctionName.Location = new System.Drawing.Point(88, 53);
            this.txtFunctionName.Name = "txtFunctionName";
            this.txtFunctionName.Size = new System.Drawing.Size(212, 20);
            this.txtFunctionName.TabIndex = 4;
            this.txtFunctionName.TextChanged += new System.EventHandler(this.txtFunctionName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Arguments";
            // 
            // pnlArgs
            // 
            this.pnlArgs.AutoScroll = true;
            this.pnlArgs.Location = new System.Drawing.Point(6, 115);
            this.pnlArgs.Name = "pnlArgs";
            this.pnlArgs.Size = new System.Drawing.Size(294, 175);
            this.pnlArgs.TabIndex = 6;
            // 
            // btnAddArgument
            // 
            this.btnAddArgument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddArgument.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnAddArgument.BackColor = System.Drawing.Color.Transparent;
            this.btnAddArgument.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddArgument.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnAddArgument.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAddArgument.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAddArgument.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddArgument.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAddArgument.FadingSpeed = 0;
            this.btnAddArgument.FlatAppearance.BorderSize = 0;
            this.btnAddArgument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddArgument.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddArgument.ForeColor = System.Drawing.Color.Black;
            this.btnAddArgument.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnAddArgument.Image = global::NvnTest.Employer.Properties.Resources.add;
            this.btnAddArgument.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddArgument.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnAddArgument.ImageOffset = 3;
            this.btnAddArgument.IsPressed = false;
            this.btnAddArgument.KeepPress = false;
            this.btnAddArgument.Location = new System.Drawing.Point(176, 79);
            this.btnAddArgument.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAddArgument.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAddArgument.Name = "btnAddArgument";
            this.btnAddArgument.Radius = 8;
            this.btnAddArgument.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnAddArgument.Size = new System.Drawing.Size(124, 30);
            this.btnAddArgument.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnAddArgument.SplitDistance = 0;
            this.btnAddArgument.TabIndex = 53;
            this.btnAddArgument.Text = "Add argument";
            this.btnAddArgument.Title = "";
            this.btnAddArgument.UseVisualStyleBackColor = true;
            this.btnAddArgument.Click += new System.EventHandler(this.btnAddArgument_Click);
            // 
            // FunctionSignatureCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddArgument);
            this.Controls.Add(this.pnlArgs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFunctionName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbReturnType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSignaturePreview);
            this.Name = "FunctionSignatureCtrl";
            this.Size = new System.Drawing.Size(303, 293);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSignaturePreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbReturnType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFunctionName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel pnlArgs;
        private RibbonStyle.RibbonMenuButton btnAddArgument;
    }
}
