namespace NvnTest.Candidate {
    partial class WebCtrl {
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.webEditorCtrl1 = new NvnTest.Candidate.WebEditorCtrl();
            this.webCmdCtrl = new NvnTest.Candidate.WebCmdCtrl();
            this.webFilesCtrl = new NvnTest.Candidate.WebFilesCtrl();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.webEditorCtrl1);
            this.splitContainer1.Panel1.Controls.Add(this.webCmdCtrl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webFilesCtrl);
            this.splitContainer1.Size = new System.Drawing.Size(743, 350);
            this.splitContainer1.SplitterDistance = 514;
            this.splitContainer1.TabIndex = 0;
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
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.AutoScroll = true;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainerMain.Size = new System.Drawing.Size(743, 479);
            this.splitContainerMain.SplitterDistance = 125;
            this.splitContainerMain.TabIndex = 1;
            // 
            // webEditorCtrl1
            // 
            this.webEditorCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webEditorCtrl1.Location = new System.Drawing.Point(3, 39);
            this.webEditorCtrl1.Name = "webEditorCtrl1";
            this.webEditorCtrl1.Size = new System.Drawing.Size(508, 308);
            this.webEditorCtrl1.Source = "";
            this.webEditorCtrl1.TabIndex = 1;
            this.webEditorCtrl1.Type = NvnTest.Candidate.TestService.WebNodeType.Directory;
            // 
            // webCmdCtrl
            // 
            this.webCmdCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webCmdCtrl.Location = new System.Drawing.Point(3, 3);
            this.webCmdCtrl.Name = "webCmdCtrl";
            this.webCmdCtrl.Size = new System.Drawing.Size(508, 33);
            this.webCmdCtrl.TabIndex = 0;
            // 
            // webFilesCtrl
            // 
            this.webFilesCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webFilesCtrl.Location = new System.Drawing.Point(3, 39);
            this.webFilesCtrl.Name = "webFilesCtrl";
            this.webFilesCtrl.Size = new System.Drawing.Size(219, 308);
            this.webFilesCtrl.TabIndex = 0;
            // 
            // WebCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Name = "WebCtrl";
            this.Size = new System.Drawing.Size(749, 485);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private WebEditorCtrl webEditorCtrl1;
        private WebCmdCtrl webCmdCtrl;
        private WebFilesCtrl webFilesCtrl;
        private System.Windows.Forms.SplitContainer splitContainerMain;
    }
}