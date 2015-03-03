namespace NvnTest.Employer {
    partial class AddEditSqlQuestionForm {
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
            this.pnlTables = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddNewTable = new RibbonStyle.RibbonMenuButton();
            this.btnCancel = new RibbonStyle.RibbonMenuButton();
            this.btnSave = new RibbonStyle.RibbonMenuButton();
            this.descriptionCtrl1 = new NvnTest.Employer.DescriptionCtrl();
            this.SuspendLayout();
            // 
            // pnlTables
            // 
            this.pnlTables.AutoScroll = true;
            this.pnlTables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTables.Location = new System.Drawing.Point(15, 150);
            this.pnlTables.Name = "pnlTables";
            this.pnlTables.Size = new System.Drawing.Size(631, 192);
            this.pnlTables.TabIndex = 13;
            this.pnlTables.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlTables_ControlAdded);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tables and test data";
            // 
            // btnAddNewTable
            // 
            this.btnAddNewTable.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnAddNewTable.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewTable.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddNewTable.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnAddNewTable.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAddNewTable.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAddNewTable.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddNewTable.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAddNewTable.FadingSpeed = 0;
            this.btnAddNewTable.FlatAppearance.BorderSize = 0;
            this.btnAddNewTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewTable.ForeColor = System.Drawing.Color.Black;
            this.btnAddNewTable.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnAddNewTable.Image = global::NvnTest.Employer.Properties.Resources.add;
            this.btnAddNewTable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewTable.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnAddNewTable.ImageOffset = 3;
            this.btnAddNewTable.IsPressed = false;
            this.btnAddNewTable.KeepPress = false;
            this.btnAddNewTable.Location = new System.Drawing.Point(15, 354);
            this.btnAddNewTable.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAddNewTable.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAddNewTable.Name = "btnAddNewTable";
            this.btnAddNewTable.Radius = 8;
            this.btnAddNewTable.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnAddNewTable.Size = new System.Drawing.Size(127, 30);
            this.btnAddNewTable.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnAddNewTable.SplitDistance = 0;
            this.btnAddNewTable.TabIndex = 57;
            this.btnAddNewTable.Text = "Add new table";
            this.btnAddNewTable.Title = "";
            this.btnAddNewTable.UseVisualStyleBackColor = true;
            this.btnAddNewTable.Click += new System.EventHandler(this.btnAddNewTable_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnCancel.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnCancel.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnCancel.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCancel.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FadingSpeed = 0;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnCancel.Image = global::NvnTest.Employer.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnCancel.ImageOffset = 3;
            this.btnCancel.IsPressed = false;
            this.btnCancel.KeepPress = false;
            this.btnCancel.Location = new System.Drawing.Point(546, 354);
            this.btnCancel.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnCancel.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 8;
            this.btnCancel.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnCancel.SplitDistance = 0;
            this.btnCancel.TabIndex = 56;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Title = "";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSave.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnSave.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnSave.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnSave.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSave.FadingSpeed = 0;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnSave.Image = global::NvnTest.Employer.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnSave.ImageOffset = 3;
            this.btnSave.IsPressed = false;
            this.btnSave.KeepPress = false;
            this.btnSave.Location = new System.Drawing.Point(440, 354);
            this.btnSave.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSave.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 8;
            this.btnSave.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnSave.SplitDistance = 0;
            this.btnSave.TabIndex = 55;
            this.btnSave.Text = "Save";
            this.btnSave.Title = "";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // descriptionCtrl1
            // 
            this.descriptionCtrl1.Description = "";
            this.descriptionCtrl1.Location = new System.Drawing.Point(15, 12);
            this.descriptionCtrl1.Name = "descriptionCtrl1";
            this.descriptionCtrl1.Size = new System.Drawing.Size(631, 119);
            this.descriptionCtrl1.TabIndex = 18;
            // 
            // AddEditSqlQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(661, 394);
            this.Controls.Add(this.btnAddNewTable);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.descriptionCtrl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlTables);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddEditSqlQuestionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit SQL question";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlTables;
        private System.Windows.Forms.Label label2;
        private DescriptionCtrl descriptionCtrl1;
        private RibbonStyle.RibbonMenuButton btnCancel;
        private RibbonStyle.RibbonMenuButton btnSave;
        private RibbonStyle.RibbonMenuButton btnAddNewTable;
    }
}