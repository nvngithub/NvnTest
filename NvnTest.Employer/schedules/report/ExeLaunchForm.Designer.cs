namespace NvnTest.Employer {
    partial class ExeLaunchForm {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExeLaunchForm));
            this.codeEditorCtrl = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new RibbonStyle.RibbonMenuButton();
            this.btnRun = new RibbonStyle.RibbonMenuButton();
            this.SuspendLayout();
            // 
            // codeEditorCtrl
            // 
            this.codeEditorCtrl.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.codeEditorCtrl.AutoListPosition = null;
            this.codeEditorCtrl.AutoListSelectedText = "a123";
            this.codeEditorCtrl.AutoListVisible = false;
            this.codeEditorCtrl.BackColor = System.Drawing.Color.White;
            this.codeEditorCtrl.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.codeEditorCtrl.CopyAsRTF = false;
            this.codeEditorCtrl.Document = this.syntaxDocument1;
            this.codeEditorCtrl.FontName = "Courier new";
            this.codeEditorCtrl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.codeEditorCtrl.InfoTipCount = 1;
            this.codeEditorCtrl.InfoTipPosition = null;
            this.codeEditorCtrl.InfoTipSelectedIndex = 1;
            this.codeEditorCtrl.InfoTipVisible = false;
            this.codeEditorCtrl.Location = new System.Drawing.Point(12, 12);
            this.codeEditorCtrl.LockCursorUpdate = false;
            this.codeEditorCtrl.Name = "codeEditorCtrl";
            this.codeEditorCtrl.ShowScopeIndicator = false;
            this.codeEditorCtrl.Size = new System.Drawing.Size(608, 354);
            this.codeEditorCtrl.SmoothScroll = false;
            this.codeEditorCtrl.SplitviewH = -4;
            this.codeEditorCtrl.SplitviewV = -4;
            this.codeEditorCtrl.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.codeEditorCtrl.TabIndex = 2;
            this.codeEditorCtrl.Text = "syntaxBoxControl1";
            this.codeEditorCtrl.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(9, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(611, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = resources.GetString("label1.Text");
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
            this.btnClose.Location = new System.Drawing.Point(520, 399);
            this.btnClose.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 8;
            this.btnClose.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnClose.SplitDistance = 0;
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "Close";
            this.btnClose.Title = "";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRun
            // 
            this.btnRun.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnRun.BackColor = System.Drawing.Color.Transparent;
            this.btnRun.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRun.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnRun.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnRun.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnRun.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRun.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRun.FadingSpeed = 0;
            this.btnRun.FlatAppearance.BorderSize = 0;
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.ForeColor = System.Drawing.Color.Black;
            this.btnRun.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnRun.Image = global::NvnTest.Employer.Properties.Resources.console;
            this.btnRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnRun.ImageOffset = 3;
            this.btnRun.IsPressed = false;
            this.btnRun.KeepPress = false;
            this.btnRun.Location = new System.Drawing.Point(367, 399);
            this.btnRun.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnRun.MenuPos = new System.Drawing.Point(0, 0);
            this.btnRun.Name = "btnRun";
            this.btnRun.Radius = 8;
            this.btnRun.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnRun.Size = new System.Drawing.Size(147, 30);
            this.btnRun.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnRun.SplitDistance = 0;
            this.btnRun.TabIndex = 52;
            this.btnRun.Text = "Execute application";
            this.btnRun.Title = "";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // ExeLaunchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(632, 441);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.codeEditorCtrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ExeLaunchForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Execute application";
            this.ResumeLayout(false);

        }

        #endregion

        private Alsing.Windows.Forms.SyntaxBoxControl codeEditorCtrl;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
        private System.Windows.Forms.Label label1;
        private RibbonStyle.RibbonMenuButton btnClose;
        private RibbonStyle.RibbonMenuButton btnRun;
    }
}