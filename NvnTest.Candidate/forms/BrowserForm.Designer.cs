namespace NvnTest.Candidate {
    partial class BrowserForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserForm));
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentUrl = new System.Windows.Forms.Label();
            this.btnGo = new RibbonStyle.RibbonMenuButton();
            this.btnForward = new RibbonStyle.RibbonMenuButton();
            this.btnBack = new RibbonStyle.RibbonMenuButton();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser.Location = new System.Drawing.Point(12, 38);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(899, 495);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.WebBrowserShortcutsEnabled = false;
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser_Navigated);
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(145, 10);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(701, 22);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Address";
            // 
            // lblCurrentUrl
            // 
            this.lblCurrentUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurrentUrl.AutoSize = true;
            this.lblCurrentUrl.ForeColor = System.Drawing.Color.Gray;
            this.lblCurrentUrl.Location = new System.Drawing.Point(12, 536);
            this.lblCurrentUrl.Name = "lblCurrentUrl";
            this.lblCurrentUrl.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentUrl.TabIndex = 67;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnGo.BackColor = System.Drawing.Color.Transparent;
            this.btnGo.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGo.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnGo.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnGo.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnGo.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnGo.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnGo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGo.FadingSpeed = 0;
            this.btnGo.FlatAppearance.BorderSize = 0;
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.ForeColor = System.Drawing.Color.Black;
            this.btnGo.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnGo.Image = global::NvnTest.Candidate.Properties.Resources.internet;
            this.btnGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGo.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnGo.ImageOffset = 3;
            this.btnGo.IsPressed = false;
            this.btnGo.KeepPress = false;
            this.btnGo.Location = new System.Drawing.Point(852, 6);
            this.btnGo.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnGo.MenuPos = new System.Drawing.Point(0, 0);
            this.btnGo.Name = "btnGo";
            this.btnGo.Radius = 8;
            this.btnGo.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnGo.Size = new System.Drawing.Size(59, 30);
            this.btnGo.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnGo.SplitDistance = 0;
            this.btnGo.TabIndex = 66;
            this.btnGo.Text = "Go";
            this.btnGo.Title = "";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnForward
            // 
            this.btnForward.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnForward.BackColor = System.Drawing.Color.Transparent;
            this.btnForward.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnForward.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnForward.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnForward.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnForward.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnForward.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnForward.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnForward.FadingSpeed = 0;
            this.btnForward.FlatAppearance.BorderSize = 0;
            this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForward.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForward.ForeColor = System.Drawing.Color.Black;
            this.btnForward.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnForward.Image = global::NvnTest.Candidate.Properties.Resources.browser_forward;
            this.btnForward.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnForward.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnForward.ImageOffset = 3;
            this.btnForward.IsPressed = false;
            this.btnForward.KeepPress = false;
            this.btnForward.Location = new System.Drawing.Point(48, 6);
            this.btnForward.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnForward.MenuPos = new System.Drawing.Point(0, 0);
            this.btnForward.Name = "btnForward";
            this.btnForward.Radius = 8;
            this.btnForward.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnForward.Size = new System.Drawing.Size(30, 30);
            this.btnForward.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnForward.SplitDistance = 0;
            this.btnForward.TabIndex = 65;
            this.btnForward.Title = "";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBack
            // 
            this.btnBack.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBack.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnBack.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnBack.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnBack.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnBack.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.FadingSpeed = 0;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.btnBack.Image = global::NvnTest.Candidate.Properties.Resources.browser_back;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
            this.btnBack.ImageOffset = 3;
            this.btnBack.IsPressed = false;
            this.btnBack.KeepPress = false;
            this.btnBack.Location = new System.Drawing.Point(12, 6);
            this.btnBack.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnBack.MenuPos = new System.Drawing.Point(0, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Radius = 8;
            this.btnBack.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.btnBack.Size = new System.Drawing.Size(30, 30);
            this.btnBack.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.btnBack.SplitDistance = 0;
            this.btnBack.TabIndex = 64;
            this.btnBack.Title = "";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(923, 551);
            this.Controls.Add(this.lblCurrentUrl);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.webBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BrowserForm";
            this.ShowInTaskbar = false;
            this.Text = "Web Reference";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrowserForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label1;
        private RibbonStyle.RibbonMenuButton btnBack;
        private RibbonStyle.RibbonMenuButton btnForward;
        private RibbonStyle.RibbonMenuButton btnGo;
        private System.Windows.Forms.Label lblCurrentUrl;
    }
}