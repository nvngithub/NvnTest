namespace NvnTest.Candidate
{
    partial class SqlCtrl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.sqlCommandCtrl = new NvnTest.Candidate.SqlCommandCtrl();
            this.sqlEditorCtrl = new NvnTest.Candidate.SqlEditorCtrl();
            this.sqlResultCtrl = new NvnTest.Candidate.SqlResultCtrl();
            this.sqlResultMessageCtrl = new NvnTest.Candidate.SqlResultMessageCtrl();
            this.tablesTreeCtrl = new NvnTest.Candidate.SqlTableTreeCtrl();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tablesTreeCtrl);
            this.splitContainer1.Size = new System.Drawing.Size(886, 386);
            this.splitContainer1.SplitterDistance = 620;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.sqlCommandCtrl);
            this.splitContainer2.Panel1.Controls.Add(this.sqlEditorCtrl);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(620, 386);
            this.splitContainer2.SplitterDistance = 219;
            this.splitContainer2.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.sqlResultCtrl);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.sqlResultMessageCtrl);
            this.splitContainer3.Size = new System.Drawing.Size(620, 163);
            this.splitContainer3.SplitterDistance = 134;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.AutoScroll = true;
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer4.Size = new System.Drawing.Size(886, 515);
            this.splitContainer4.SplitterDistance = 125;
            this.splitContainer4.TabIndex = 1;
            // 
            // sqlCommandCtrl
            // 
            this.sqlCommandCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sqlCommandCtrl.Location = new System.Drawing.Point(3, 3);
            this.sqlCommandCtrl.Name = "sqlCommandCtrl";
            this.sqlCommandCtrl.Size = new System.Drawing.Size(614, 33);
            this.sqlCommandCtrl.TabIndex = 1;
            // 
            // sqlEditorCtrl
            // 
            this.sqlEditorCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sqlEditorCtrl.Location = new System.Drawing.Point(0, 42);
            this.sqlEditorCtrl.Name = "sqlEditorCtrl";
            this.sqlEditorCtrl.Query = "";
            this.sqlEditorCtrl.Size = new System.Drawing.Size(620, 175);
            this.sqlEditorCtrl.TabIndex = 0;
            // 
            // sqlResultCtrl
            // 
            this.sqlResultCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlResultCtrl.Location = new System.Drawing.Point(0, 0);
            this.sqlResultCtrl.Name = "sqlResultCtrl";
            this.sqlResultCtrl.Size = new System.Drawing.Size(620, 134);
            this.sqlResultCtrl.TabIndex = 0;
            // 
            // sqlResultMessageCtrl
            // 
            this.sqlResultMessageCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlResultMessageCtrl.Location = new System.Drawing.Point(0, 0);
            this.sqlResultMessageCtrl.Name = "sqlResultMessageCtrl";
            this.sqlResultMessageCtrl.Size = new System.Drawing.Size(620, 25);
            this.sqlResultMessageCtrl.TabIndex = 0;
            // 
            // tablesTreeCtrl
            // 
            this.tablesTreeCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tablesTreeCtrl.Location = new System.Drawing.Point(3, 42);
            this.tablesTreeCtrl.Name = "tablesTreeCtrl";
            this.tablesTreeCtrl.Size = new System.Drawing.Size(256, 315);
            this.tablesTreeCtrl.TabIndex = 0;
            // 
            // SqlCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer4);
            this.Name = "SqlCtrl";
            this.Size = new System.Drawing.Size(892, 521);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private SqlEditorCtrl sqlEditorCtrl;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private SqlResultCtrl sqlResultCtrl;
        private SqlResultMessageCtrl sqlResultMessageCtrl;
        private SqlTableTreeCtrl tablesTreeCtrl;
        private SqlCommandCtrl sqlCommandCtrl;
        private System.Windows.Forms.SplitContainer splitContainer4;

    }
}
