using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

#if Admin
using TestService = NvnTest.Employer.TestService;
using AppResouces = NvnTest.Employer.Properties.Resources;
#elif Client
using TestService = NvnTest.Candidate.TestService;
using AppResouces = NvnTest.Candidate.Properties.Resources;
#endif

namespace NvnTest.Common {
    public partial class WebViewerForm : Form {
        private TestService.WebNode rootNode;
        private ImageList webFileImages = new ImageList();

        public WebViewerForm() {
            InitializeComponent();

            webFileImages.Images.Add(AppResouces.folder_16);
            webFileImages.Images.Add(AppResouces.html_16);
            webFileImages.Images.Add(AppResouces.css_16);
            webFileImages.Images.Add(AppResouces.js_16);
            webFileImages.Images.Add(AppResouces.aspx_16);

            tvFiles.ImageList = webFileImages;
        }

        public TestService.WebNode RootNode {
            get { return rootNode; }
            set { rootNode = value; }
        }

        public void LoadForm() {
            tvFiles.Nodes.Clear();

            TreeNode node = tvFiles.Nodes.Add(rootNode.Name);
            node.Tag = rootNode;

            AddWebNodeToTree(node, rootNode);

            tvFiles.ExpandAll();
        }

        private void AddWebNodeToTree(TreeNode rootNode, TestService.WebNode rootWebNode) {
            foreach (TestService.WebNode webNode in rootWebNode.Nodes) {
                TreeNode node = rootNode.Nodes.Add(webNode.Name);
                switch (webNode.Type) {
                    case TestService.WebNodeType.Directory: node.ImageIndex = node.SelectedImageIndex = 0; break;
                    case TestService.WebNodeType.HTML: node.ImageIndex = node.SelectedImageIndex = 1; break;
                    case TestService.WebNodeType.CSS: node.ImageIndex = node.SelectedImageIndex = 2; break;
                    case TestService.WebNodeType.JavaScript: node.ImageIndex = node.SelectedImageIndex = 3; break;
                    case TestService.WebNodeType.ASP_DOT_NET: node.ImageIndex = node.SelectedImageIndex = 4; break;
                }
                
                node.Tag = webNode;

                if (webNode.Type == TestService.WebNodeType.Directory) {
                    AddWebNodeToTree(node, webNode);
                }
            }
        }

        private void tvFiles_AfterSelect(object sender, TreeViewEventArgs e) {
            if (tvFiles.SelectedNode != null) {
                TestService.WebNode webNode = (TestService.WebNode)tvFiles.SelectedNode.Tag;
                if (webNode.Type != TestService.WebNodeType.Directory) {
#if LIVE
                    string path = String.Format("http://webprogramming.coderlabz.com/{0}", Common.UniqueId);
#else
                    string path = String.Format(@"C:\Inetpub\subdomains\WebProgramming\{0}\", Common.UniqueId);
#endif
                    path += GetNodePath(tvFiles.SelectedNode);

                    webBrowser.Navigate(path);
                }
            }
        }

        private string GetNodePath(TreeNode treeNode) {
            string path = string.Empty;
            if (treeNode.Parent != null) {
                path = GetNodePath(treeNode.Parent) + "/" + treeNode.Text;
            }
            return path;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            webBrowser.Refresh(WebBrowserRefreshOption.Completely);
        }

        private void WebViewerForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.Close();
            }
        }
    }
}