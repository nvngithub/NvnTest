using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate {
    public partial class SqlEditorCtrl : UserControl {
        public SqlEditorCtrl() {
            InitializeComponent();

            syntaxDocument1.SyntaxFile = Globals.AppPath + "Syntax\\MySQL_SQL.syn";
        }

        public string Query {
            get {
                if (String.IsNullOrEmpty(codeEditorCtrl.Selection.Text)) {
                    return codeEditorCtrl.Document.Text;
                } else {
                    return codeEditorCtrl.Selection.Text;
                }
            }
            set {
                if (String.IsNullOrEmpty(codeEditorCtrl.Selection.Text)) {
                    codeEditorCtrl.Document.Text += String.IsNullOrEmpty(value) ? "" : value;
                } else {
                    codeEditorCtrl.Selection.Text = value; ;
                }
            }
        }
    }
}