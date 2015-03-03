namespace NvnTest.Candidate {
    partial class WebFilesCtrl {
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
            this.tvWebFiles = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newHTMLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCSSFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newJavascriptFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newASPNETFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvWebFiles
            // 
            this.tvWebFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvWebFiles.LabelEdit = true;
            this.tvWebFiles.Location = new System.Drawing.Point(3, 3);
            this.tvWebFiles.Name = "tvWebFiles";
            this.tvWebFiles.Size = new System.Drawing.Size(185, 369);
            this.tvWebFiles.TabIndex = 0;
            this.tvWebFiles.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvWebFiles_AfterLabelEdit);
            this.tvWebFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvWebFiles_AfterSelect);
            this.tvWebFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvWebFiles_MouseDown);
            this.tvWebFiles.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvWebFiles_BeforeLabelEdit);
            this.tvWebFiles.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvWebFiles_BeforeSelect);
            this.tvWebFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvWebFiles_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFolderToolStripMenuItem,
            this.toolStripSeparator1,
            this.newHTMLFileToolStripMenuItem,
            this.newCSSFileToolStripMenuItem,
            this.newJavascriptFileToolStripMenuItem,
            this.newASPNETFileToolStripMenuItem,
            this.toolStripSeparator2,
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(178, 170);
            // 
            // newFolderToolStripMenuItem
            // 
            this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.newFolderToolStripMenuItem.Text = "New Folder";
            this.newFolderToolStripMenuItem.Click += new System.EventHandler(this.AddNewFolder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // newHTMLFileToolStripMenuItem
            // 
            this.newHTMLFileToolStripMenuItem.Name = "newHTMLFileToolStripMenuItem";
            this.newHTMLFileToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.newHTMLFileToolStripMenuItem.Text = "New HTML File";
            this.newHTMLFileToolStripMenuItem.Click += new System.EventHandler(this.AddNewHTMLFile_Click);
            // 
            // newCSSFileToolStripMenuItem
            // 
            this.newCSSFileToolStripMenuItem.Name = "newCSSFileToolStripMenuItem";
            this.newCSSFileToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.newCSSFileToolStripMenuItem.Text = "New CSS File";
            this.newCSSFileToolStripMenuItem.Click += new System.EventHandler(this.AddNewCSSFile_Click);
            // 
            // newJavascriptFileToolStripMenuItem
            // 
            this.newJavascriptFileToolStripMenuItem.Name = "newJavascriptFileToolStripMenuItem";
            this.newJavascriptFileToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.newJavascriptFileToolStripMenuItem.Text = "New Javascript File";
            this.newJavascriptFileToolStripMenuItem.Click += new System.EventHandler(this.AddNewJavascriptFile_Click);
            // 
            // newASPNETFileToolStripMenuItem
            // 
            this.newASPNETFileToolStripMenuItem.Name = "newASPNETFileToolStripMenuItem";
            this.newASPNETFileToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.newASPNETFileToolStripMenuItem.Text = "New ASP.NET File";
            this.newASPNETFileToolStripMenuItem.Click += new System.EventHandler(this.AddNewASPNETFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.RenameMenuNode_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteMenuNode_Click);
            // 
            // WebFilesCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvWebFiles);
            this.Name = "WebFilesCtrl";
            this.Size = new System.Drawing.Size(191, 375);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvWebFiles;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem newCSSFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newJavascriptFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newHTMLFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newASPNETFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}
