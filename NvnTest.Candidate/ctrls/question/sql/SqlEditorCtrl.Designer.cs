namespace NvnTest.Candidate
{
    partial class SqlEditorCtrl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.codeEditorCtrl = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.SuspendLayout();
            // 
            // codeEditorCtrl
            // 
            this.codeEditorCtrl.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.codeEditorCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.codeEditorCtrl.AutoListPosition = null;
            this.codeEditorCtrl.AutoListSelectedText = "";
            this.codeEditorCtrl.AutoListVisible = false;
            this.codeEditorCtrl.BackColor = System.Drawing.Color.White;
            this.codeEditorCtrl.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.codeEditorCtrl.CopyAsRTF = false;
            this.codeEditorCtrl.Document = this.syntaxDocument1;
            this.codeEditorCtrl.FontName = "Courier new";
            this.codeEditorCtrl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.codeEditorCtrl.InfoTipCount = 1;
            this.codeEditorCtrl.InfoTipPosition = null;
            this.codeEditorCtrl.InfoTipSelectedIndex = 0;
            this.codeEditorCtrl.InfoTipVisible = false;
            this.codeEditorCtrl.Location = new System.Drawing.Point(3, 3);
            this.codeEditorCtrl.LockCursorUpdate = false;
            this.codeEditorCtrl.Name = "codeEditorCtrl";
            this.codeEditorCtrl.ShowScopeIndicator = false;
            this.codeEditorCtrl.Size = new System.Drawing.Size(486, 327);
            this.codeEditorCtrl.SmoothScroll = false;
            this.codeEditorCtrl.SplitviewH = -4;
            this.codeEditorCtrl.SplitviewV = -4;
            this.codeEditorCtrl.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.codeEditorCtrl.TabIndex = 0;
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
            // SqlEditorCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.codeEditorCtrl);
            this.Name = "SqlEditorCtrl";
            this.Size = new System.Drawing.Size(492, 333);
            this.ResumeLayout(false);

        }

        #endregion

        private Alsing.Windows.Forms.SyntaxBoxControl codeEditorCtrl;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;


    }
}
