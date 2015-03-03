using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;

namespace NvnTest.Candidate
{
    public partial class SqlResultMessageCtrl : UserControl
    {
        public SqlResultMessageCtrl()
        {
            InitializeComponent();
        }

        internal void SetMessage(DbResult result)
        {
            lblMessage.Text = result.Message;
            if (result.ResultStatus == DbResultStatus.Error) {
                lblMessage.ForeColor = Color.Red;
            } else {
                lblMessage.ForeColor = Color.Green;
            }
        }
    }
}
