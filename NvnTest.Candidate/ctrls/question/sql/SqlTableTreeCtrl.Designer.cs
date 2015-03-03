namespace NvnTest.Candidate
{
    partial class SqlTableTreeCtrl
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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Database");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlTableTreeCtrl));
            this.tvTables = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblHelpName = new System.Windows.Forms.Label();
            this.lblHelpDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tvTables
            // 
            this.tvTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvTables.ImageIndex = 0;
            this.tvTables.ImageList = this.imageList1;
            this.tvTables.Location = new System.Drawing.Point(3, 3);
            this.tvTables.Name = "tvTables";
            treeNode2.Name = "DatabaseNode";
            treeNode2.Text = "Database";
            this.tvTables.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tvTables.SelectedImageIndex = 0;
            this.tvTables.Size = new System.Drawing.Size(216, 326);
            this.tvTables.TabIndex = 0;
            this.tvTables.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTables_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "database_16.png");
            this.imageList1.Images.SetKeyName(1, "table_16.png");
            this.imageList1.Images.SetKeyName(2, "column_32.png");
            // 
            // lblHelpName
            // 
            this.lblHelpName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHelpName.AutoSize = true;
            this.lblHelpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelpName.ForeColor = System.Drawing.Color.Purple;
            this.lblHelpName.Location = new System.Drawing.Point(3, 332);
            this.lblHelpName.Name = "lblHelpName";
            this.lblHelpName.Size = new System.Drawing.Size(39, 13);
            this.lblHelpName.TabIndex = 1;
            this.lblHelpName.Text = "Name";
            this.lblHelpName.Visible = false;
            // 
            // lblHelpDesc
            // 
            this.lblHelpDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHelpDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblHelpDesc.Location = new System.Drawing.Point(7, 350);
            this.lblHelpDesc.Name = "lblHelpDesc";
            this.lblHelpDesc.Size = new System.Drawing.Size(212, 40);
            this.lblHelpDesc.TabIndex = 2;
            this.lblHelpDesc.Text = "help description";
            this.lblHelpDesc.Visible = false;
            // 
            // SqlTableTreeCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblHelpDesc);
            this.Controls.Add(this.lblHelpName);
            this.Controls.Add(this.tvTables);
            this.Name = "SqlTableTreeCtrl";
            this.Size = new System.Drawing.Size(222, 390);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvTables;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblHelpName;
        private System.Windows.Forms.Label lblHelpDesc;
    }
}
