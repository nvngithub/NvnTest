using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnTest.Candidate.TestService;
using System.IO;

namespace NvnTest.Candidate {
    public partial class WebEditorCtrl : UserControl {
        private WebNodeType type;

        public WebEditorCtrl() {
            InitializeComponent();
        }

        public WebNodeType Type {
            get { return type; }
            set { type = value; }
        }

        public string Source {
            get { return editorCtrl.Document.Text; }
            set { editorCtrl.Document.Text = value; }
        }

        public void LoadControl() {
            editorCtrl.Enabled = (type != WebNodeType.Directory);
            if (type == WebNodeType.Directory) {
                return;
            }

            // Set systax file
            switch (type) {
                case WebNodeType.HTML: syntaxDocument1.SyntaxFile = Globals.AppPath + "syntax\\XML.syn"; break;
                case WebNodeType.CSS: syntaxDocument1.SyntaxFile = Globals.AppPath + "syntax\\CSS.syn"; break;
                case WebNodeType.JavaScript: syntaxDocument1.SyntaxFile = Globals.AppPath + "syntax\\JavaScript.syn"; break;
                case WebNodeType.ASP_DOT_NET: syntaxDocument1.SyntaxFile = Globals.AppPath + "syntax\\ASP.syn"; break;
            }

            // Template
            if (String.IsNullOrEmpty(editorCtrl.Document.Text)) {
                switch (type) {
                    case WebNodeType.ASP_DOT_NET: editorCtrl.Document.Text = GetTemplateCode("template\\aspdotnet.txt"); break;
                    case WebNodeType.CSS: editorCtrl.Document.Text = GetTemplateCode("template\\css.txt"); break;
                    case WebNodeType.HTML: editorCtrl.Document.Text = GetTemplateCode("template\\html.txt"); break;
                    case WebNodeType.JavaScript: editorCtrl.Document.Text = GetTemplateCode("template\\javascript.txt"); break;
                }
            }
        }

        private string GetTemplateCode(string filename) {
            string template = string.Empty;
            using (StreamReader tr = new StreamReader(filename)) {
                template = tr.ReadToEnd();
            }
            return template;
        }
    }
}