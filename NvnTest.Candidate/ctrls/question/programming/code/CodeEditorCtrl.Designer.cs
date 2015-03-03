namespace NvnTest.Candidate
{
    partial class CodeEditorCtrl
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
            this.editorCtrl = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.SuspendLayout();
            // 
            // editorCtrl
            // 
            this.editorCtrl.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.editorCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.editorCtrl.AutoListPosition = null;
            this.editorCtrl.AutoListSelectedText = "a123";
            this.editorCtrl.AutoListVisible = false;
            this.editorCtrl.BackColor = System.Drawing.Color.White;
            this.editorCtrl.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.editorCtrl.CopyAsRTF = false;
            this.editorCtrl.Document = this.syntaxDocument1;
            this.editorCtrl.FontName = "Courier new";
            this.editorCtrl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.editorCtrl.InfoTipCount = 1;
            this.editorCtrl.InfoTipPosition = null;
            this.editorCtrl.InfoTipSelectedIndex = 1;
            this.editorCtrl.InfoTipVisible = false;
            this.editorCtrl.Location = new System.Drawing.Point(3, 3);
            this.editorCtrl.LockCursorUpdate = false;
            this.editorCtrl.Name = "editorCtrl";
            this.editorCtrl.ShowScopeIndicator = false;
            this.editorCtrl.Size = new System.Drawing.Size(498, 325);
            this.editorCtrl.SmoothScroll = false;
            this.editorCtrl.SplitviewH = -4;
            this.editorCtrl.SplitviewV = -4;
            this.editorCtrl.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.editorCtrl.TabIndex = 0;
            this.editorCtrl.Text = "syntaxBoxControl1";
            this.editorCtrl.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            this.editorCtrl.TextChanged += new System.EventHandler(this.editorCtrl_TextChanged);
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // CodeEditorCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editorCtrl);
            this.Name = "CodeEditorCtrl";
            this.Size = new System.Drawing.Size(504, 331);
            this.ResumeLayout(false);

        }

        #endregion

        private Alsing.Windows.Forms.SyntaxBoxControl editorCtrl;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
    }
}
