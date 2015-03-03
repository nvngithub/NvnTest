namespace NvnTest.Candidate {
    partial class AlgoCtrl {
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
            this.components = new System.ComponentModel.Container();
            this.algoText = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // algoText
            // 
            this.algoText.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.algoText.AutoListPosition = null;
            this.algoText.AutoListSelectedText = "a123";
            this.algoText.AutoListVisible = false;
            this.algoText.BackColor = System.Drawing.Color.White;
            this.algoText.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.algoText.CopyAsRTF = false;
            this.algoText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.algoText.Document = this.syntaxDocument1;
            this.algoText.FontName = "Courier new";
            this.algoText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.algoText.InfoTipCount = 1;
            this.algoText.InfoTipPosition = null;
            this.algoText.InfoTipSelectedIndex = 1;
            this.algoText.InfoTipVisible = false;
            this.algoText.Location = new System.Drawing.Point(0, 0);
            this.algoText.LockCursorUpdate = false;
            this.algoText.Name = "algoText";
            this.algoText.ShowScopeIndicator = false;
            this.algoText.Size = new System.Drawing.Size(407, 216);
            this.algoText.SmoothScroll = false;
            this.algoText.SplitviewH = -4;
            this.algoText.SplitviewV = -4;
            this.algoText.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.algoText.TabIndex = 0;
            this.algoText.Text = "syntaxBoxControl1";
            this.algoText.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            this.algoText.TextChanged += new System.EventHandler(this.algoText_TextChanged);
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.Location = new System.Drawing.Point(3, 3);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.algoText);
            this.splitContainerMain.Size = new System.Drawing.Size(407, 303);
            this.splitContainerMain.SplitterDistance = 83;
            this.splitContainerMain.TabIndex = 1;
            // 
            // AlgoCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Name = "AlgoCtrl";
            this.Size = new System.Drawing.Size(413, 309);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Alsing.Windows.Forms.SyntaxBoxControl algoText;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
        private System.Windows.Forms.SplitContainer splitContainerMain;

    }
}
