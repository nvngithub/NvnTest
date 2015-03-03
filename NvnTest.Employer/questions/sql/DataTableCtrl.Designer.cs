namespace NvnTest.Employer {
    partial class DataTableCtrl {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrTestData = new System.Windows.Forms.DataGridView();
            this.dgrTableName = new System.Windows.Forms.DataGridView();
            this.TableNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new RibbonStyle.RibbonMenuButton();
            this.btnDelete = new RibbonStyle.RibbonMenuButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgrTestData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrTableName)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrTestData
            // 
            this.dgrTestData.AllowUserToAddRows = false;
            this.dgrTestData.AllowUserToDeleteRows = false;
            this.dgrTestData.AllowUserToResizeRows = false;
            this.dgrTestData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrTestData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrTestData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrTestData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrTestData.Location = new System.Drawing.Point(3, 50);
            this.dgrTestData.Name = "dgrTestData";
            this.dgrTestData.ReadOnly = true;
            this.dgrTestData.RowHeadersVisible = false;
            this.dgrTestData.Size = new System.Drawing.Size(170, 125);
            this.dgrTestData.TabIndex = 1;
            // 
            // dgrTableName
            // 
            this.dgrTableName.AllowUserToAddRows = false;
            this.dgrTableName.AllowUserToDeleteRows = false;
            this.dgrTableName.AllowUserToResizeColumns = false;
            this.dgrTableName.AllowUserToResizeRows = false;
            this.dgrTableName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrTableName.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrTableName.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrTableName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrTableName.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TableNameCol});
            this.dgrTableName.Location = new System.Drawing.Point(3, 30);
            this.dgrTableName.Name = "dgrTableName";
            this.dgrTableName.RowHeadersVisible = false;
            this.dgrTableName.Size = new System.Drawing.Size(170, 20);
            this.dgrTableName.TabIndex = 4;
            // 
            // TableNameCol
            // 
            this.TableNameCol.HeaderText = "Table Name";
            this.TableNameCol.Name = "TableNameCol";
            this.TableNameCol.ReadOnly = true;
            this.TableNameCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEdit.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnEdit.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnEdit.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnEdit.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEdit.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnEdit.FadingSpeed = 0;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnEdit.Image = global::NvnTest.Employer.Properties.Resources.edit;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnEdit.ImageOffset = 3;
            this.btnEdit.IsPressed = false;
            this.btnEdit.KeepPress = false;
            this.btnEdit.Location = new System.Drawing.Point(149, 3);
            this.btnEdit.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnEdit.MenuPos = new System.Drawing.Point(0, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Radius = 8;
            this.btnEdit.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnEdit.Size = new System.Drawing.Size(24, 24);
            this.btnEdit.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnEdit.SplitDistance = 0;
            this.btnEdit.TabIndex = 55;
            this.btnEdit.Title = "";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDelete.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnDelete.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnDelete.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnDelete.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDelete.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDelete.FadingSpeed = 0;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnDelete.Image = global::NvnTest.Employer.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnDelete.ImageOffset = 3;
            this.btnDelete.IsPressed = false;
            this.btnDelete.KeepPress = false;
            this.btnDelete.Location = new System.Drawing.Point(119, 3);
            this.btnDelete.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnDelete.MenuPos = new System.Drawing.Point(0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Radius = 8;
            this.btnDelete.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnDelete.Size = new System.Drawing.Size(24, 24);
            this.btnDelete.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnDelete.SplitDistance = 0;
            this.btnDelete.TabIndex = 54;
            this.btnDelete.Title = "";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // DataTableCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgrTableName);
            this.Controls.Add(this.dgrTestData);
            this.Name = "DataTableCtrl";
            this.Size = new System.Drawing.Size(176, 178);
            ((System.ComponentModel.ISupportInitialize)(this.dgrTestData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrTableName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrTestData;
        private System.Windows.Forms.DataGridView dgrTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableNameCol;
        private RibbonStyle.RibbonMenuButton btnDelete;
        private RibbonStyle.RibbonMenuButton btnEdit;
    }
}
