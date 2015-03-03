using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using NvnTest.Candidate.TestService;

namespace NvnTest.Candidate {
    public partial class WebFilesCtrl : UserControl {
        public event EventHandler WebFileSelectionChanging;
        public event EventHandler WebFileSelectionChanged;
        private ImageList webFileImages = new ImageList();

        public WebFilesCtrl() {
            InitializeComponent();

            webFileImages.Images.Add(Properties.Resources.folder_16);
            webFileImages.Images.Add(Properties.Resources.html_16);
            webFileImages.Images.Add(Properties.Resources.css_16);
            webFileImages.Images.Add(Properties.Resources.js_16);
            webFileImages.Images.Add(Properties.Resources.aspx_16);

            tvWebFiles.ImageList = webFileImages;
        }

        public WebNode SelectedNode {
            get {
                WebNode webNode = null;
                if (tvWebFiles.SelectedNode != null) {
                    webNode = (WebNode)tvWebFiles.SelectedNode.Tag;
                }
                return webNode;
            }
        }

        public void LoadControl() {
            // Create root node
            tvWebFiles.Nodes.Clear();

            TreeNode rootNode = tvWebFiles.Nodes.Add("/");
            rootNode.ImageIndex = rootNode.SelectedImageIndex = 0;
            rootNode.Tag = CreateWebNode(WebNodeType.Directory, rootNode.Text);
        }

        public void LoadWebNodeHierarchy(TestService.WebNode webNode) {
            if (webNode == null) return;

            LoadWebNode(tvWebFiles.Nodes[0], webNode);
            tvWebFiles.ExpandAll();
        }

        private void LoadWebNode(TreeNode rootNode, TestService.WebNode webNode) {
            foreach (TestService.WebNode node in webNode.Nodes) {
                TreeNode nodeAdded = AddExistingFile(rootNode, node);

                if (node.Type == WebNodeType.Directory) {
                    LoadWebNode(nodeAdded, node);
                }
            }
        }

        public WebNode GetWebNodeHierarchy() {
            WebNode webNode = (WebNode)tvWebFiles.Nodes[0].Tag;

            GenerateWebNodes(tvWebFiles.Nodes[0], webNode);

            return webNode;
        }

        private void GenerateWebNodes(TreeNode rootNode, WebNode rootWebNode) {
            List<WebNode> webNodes = new List<WebNode>();
            foreach (TreeNode node in rootNode.Nodes) {
                WebNode webNode = (WebNode)node.Tag;
                webNodes.Add(webNode);

                if (webNode.Type == WebNodeType.Directory) {
                    GenerateWebNodes(node, webNode);
                }
            }

            rootWebNode.Nodes = webNodes.ToArray();
        }

        #region Web file tree event handlers
        private void tvWebFiles_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
            if (WebFileSelectionChanging != null) {
                WebFileSelectionChanging(this, null);
            }
        }

        private void tvWebFiles_AfterSelect(object sender, TreeViewEventArgs e) {
            if (WebFileSelectionChanged != null) {
                WebFileSelectionChanged(this, null);
            }
        }

        private void tvWebFiles_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                tvWebFiles.SelectedNode = tvWebFiles.GetNodeAt(e.X, e.Y);
                if (tvWebFiles.SelectedNode != null) {
                    contextMenuStrip1.Show(tvWebFiles, e.Location);
                }
            }

        }

        private void tvWebFiles_KeyDown(object sender, KeyEventArgs e) {
            if (tvWebFiles.SelectedNode != null) {
                if (e.KeyCode == Keys.F2) {
                    tvWebFiles.SelectedNode.BeginEdit();
                }
            }
        }

        private void tvWebFiles_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e) {
            if (e.Node.Level == 0) {
                e.CancelEdit = true;
            }
        }

        private void tvWebFiles_AfterLabelEdit(object sender, NodeLabelEditEventArgs e) {
            if (String.IsNullOrEmpty(e.Label) == false) {
                if (IsInvalidCharExists(e.Label)) e.CancelEdit = true;

                // check whether file with same name exists
                if (tvWebFiles.SelectedNode.Parent != null) {
                    bool exists = false;
                    foreach (TreeNode node in tvWebFiles.SelectedNode.Parent.Nodes) {
                        if (node.Text.Equals(e.Label, StringComparison.OrdinalIgnoreCase)) {
                            exists = true;
                            break;
                        }
                    }

                    if (exists) {
                        e.CancelEdit = true;
                    }
                }

                WebNode webfile = (WebNode)tvWebFiles.SelectedNode.Tag;
                if (webfile.Type == WebNodeType.Directory) {
                    if (e.Label.Contains(".")) e.CancelEdit = true;
                } else {
                    if (IsEtensionExists(e.Label) == false) e.CancelEdit = true;
                }

                if (e.CancelEdit == false) {
                    WebNode webNode = (WebNode)e.Node.Tag;
                    webNode.Name = e.Label;
                }
            } else {
                e.CancelEdit = true;
            }
        }
        #endregion

        #region Context menu event handlers
        private void AddNewFolder_Click(object sender, EventArgs e) {
            AddNewFile(WebNodeType.Directory);
        }

        private void AddNewHTMLFile_Click(object sender, EventArgs e) {
            AddNewFile(WebNodeType.HTML);
        }

        private void AddNewCSSFile_Click(object sender, EventArgs e) {
            AddNewFile(WebNodeType.CSS);
        }

        private void AddNewJavascriptFile_Click(object sender, EventArgs e) {
            AddNewFile(WebNodeType.JavaScript);
        }

        private void AddNewASPNETFile_Click(object sender, EventArgs e) {
            AddNewFile(WebNodeType.ASP_DOT_NET);
        }
        #endregion

        #region Private functions
        private void AddNewFile(WebNodeType type) {
            if (tvWebFiles.SelectedNode != null) {
                WebNode selectedNode = (WebNode)tvWebFiles.SelectedNode.Tag;
                if (selectedNode.Type == WebNodeType.Directory) {
                    string newFileName = GetNewFileName(type);
                    TreeNode newNode = tvWebFiles.SelectedNode.Nodes.Add(newFileName);

                    SetImageIndex(newNode, type);

                    newNode.Tag = CreateWebNode(type, newNode.Text);

                    tvWebFiles.SelectedNode.Expand();
                }
            }
        }

        private TreeNode AddExistingFile(TreeNode parentNode, WebNode webNode) {
            TreeNode addedNode = parentNode.Nodes.Add(webNode.Name);
            addedNode.Tag = webNode;
            SetImageIndex(addedNode, webNode.Type);

            return addedNode;
        }

        private WebNode CreateWebNode(WebNodeType type, string name) {
            WebNode webFile = new WebNode();
            webFile.Type = type;
            webFile.Name = name;

            return webFile;
        }

        private void SetImageIndex(TreeNode node, TestService.WebNodeType type) {
            switch (type) {
                case WebNodeType.Directory: node.ImageIndex = node.SelectedImageIndex = 0; break;
                case WebNodeType.HTML: node.ImageIndex = node.SelectedImageIndex = 1; break;
                case WebNodeType.CSS: node.ImageIndex = node.SelectedImageIndex = 2; break;
                case WebNodeType.JavaScript: node.ImageIndex = node.SelectedImageIndex = 3; break;
                case WebNodeType.ASP_DOT_NET: node.ImageIndex = node.SelectedImageIndex = 4; break;
            }
        }

        private string GetNewFileName(WebNodeType type) {
            string newFileName = string.Empty;
            string prefix = string.Empty;
            string extension = string.Empty;
            switch (type) {
                case WebNodeType.Directory: prefix = "NewFolder"; break;
                case WebNodeType.CSS: prefix = "Style"; extension = "css"; break;
                case WebNodeType.JavaScript: prefix = "Script"; extension = "js"; break;
                case WebNodeType.HTML: prefix = "Page"; extension = "html"; break;
                case WebNodeType.ASP_DOT_NET: prefix = "Page"; extension = "aspx"; break;
            }

            bool found = false;
            for (int i = 0; found == false; i++) {
                newFileName = prefix + (i == 0 ? "" : i.ToString()) + (type != WebNodeType.Directory ? "." + extension : "");
                bool exists = false;
                foreach (TreeNode childNode in tvWebFiles.SelectedNode.Nodes) {
                    if (childNode.Text.Equals(newFileName, StringComparison.OrdinalIgnoreCase)) {
                        exists = true;
                        break;
                    }
                }

                if (exists == false) {
                    found = true;
                }
            }

            return newFileName;
        }

        private void RenameMenuNode_Click(object sender, EventArgs e) {
            if (tvWebFiles.SelectedNode != null) {
                tvWebFiles.SelectedNode.BeginEdit();
            }
        }

        private void DeleteMenuNode_Click(object sender, EventArgs e) {
            if (tvWebFiles.SelectedNode != null) {
                if (tvWebFiles.SelectedNode.Nodes.Count > 0) {
                    if (MessageBox.Show(String.Format("Are you sure you want to delete directory {0} and all files under it ?", tvWebFiles.SelectedNode.Text), "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                        tvWebFiles.SelectedNode.Remove();
                    }
                } else {
                    tvWebFiles.SelectedNode.Remove();
                }
            }
        }

        private bool IsInvalidCharExists(string filename) {
            MatchCollection matches = Regex.Matches(filename, @"[\w\.]+");

            if (matches.Count == 1) {
                if (matches[0].Value == filename) {
                    return false;
                }
            }

            return true;
        }

        private bool IsEtensionExists(string filename) {
            MatchCollection matches = Regex.Matches(filename, @"[\w]+\.[\w]+");

            if (matches.Count == 1) {
                if (matches[0].Value == filename) {
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}