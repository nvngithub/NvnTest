using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate
{
    public partial class SqlResultCtrl : UserControl
    {
        public SqlResultCtrl()
        {
            InitializeComponent();
        }

        public void LoadResult(DataTable result)
        {
            // clear already shown data
            dgrResult.DataSource = null;
            // Set datasource
            dgrResult.DataSource = result;
        }
    }
}
