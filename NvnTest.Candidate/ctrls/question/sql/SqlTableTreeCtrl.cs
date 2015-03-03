using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;

namespace NvnTest.Candidate {
    public partial class SqlTableTreeCtrl : UserControl {
        public SqlTableTreeCtrl() {
            InitializeComponent();
        }

        public void LoadTables(TestService.SqlTable[] tables) {
            tvTables.Nodes[0].Nodes.Clear();

            foreach (TestService.SqlTable table in tables) {
                AddTable(tvTables.Nodes[0], table);
            }

            tvTables.Nodes[0].Expand();
        }

        private void AddTable(TreeNode rootNode, TestService.SqlTable table) {
            //TODO: table columns retrieved by executing sql query... check performance
            DbResult dbResult = DbManager.Instance.GetSqlResult("SELECT * FROM " + table.TableName);

            TreeNode node = rootNode.Nodes.Add(table.TableName);
            node.Tag = table.CreateTableSql;
            node.ImageIndex = node.SelectedImageIndex = 1;

            if (dbResult.Data.Columns != null) {
                foreach (DataColumn column in dbResult.Data.Columns) {
                    TreeNode colNode = node.Nodes.Add(column.ColumnName);
                    colNode.ImageIndex = colNode.SelectedImageIndex = 2;
                }
            }
        }

        private void tvTables_AfterSelect(object sender, TreeViewEventArgs e) {
            ShowInfo();
        }

        private void ShowInfo() {
            if (tvTables.SelectedNode == null) return;

            TreeNode selectedNode = tvTables.SelectedNode;
            string tableDefinition = string.Empty;
            if (selectedNode.Level == 1) {
                tableDefinition = (string)selectedNode.Tag;
            } else if (selectedNode.Level == 2) {
                tableDefinition = (string)selectedNode.Parent.Tag;
            }

            if (String.IsNullOrEmpty(tableDefinition) == false) {
                lblHelpName.Visible = lblHelpDesc.Visible = true;
                lblHelpName.Text = "Table definition";
                lblHelpDesc.Text = tableDefinition;
            } else {
                lblHelpName.Visible = lblHelpDesc.Visible = false;
            }
        }
    }
}