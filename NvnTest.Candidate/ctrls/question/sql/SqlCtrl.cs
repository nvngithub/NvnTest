using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;

namespace NvnTest.Candidate {
    public partial class SqlCtrl : UserControl, INvnTestControl {
        private TestService.SqlQuestion sqlQuestion;

        public SqlCtrl() {
            InitializeComponent();

            sqlCommandCtrl.RunClicked += new EventHandler(SqlCommand_RunClicked);
            sqlCommandCtrl.PauseClicked += new EventHandler(SqlCommand_PauseClicked);
            sqlCommandCtrl.HistoryClicked += new EventHandler(SqlCommand_HistoryClicked);
            sqlCommandCtrl.SqlQuerySaved += new EventHandler(sqlCommandCtrl_SqlQuerySaved);
        }

        public TestService.SqlQuestion SqlQuestion {
            get { return sqlQuestion; }
            set { sqlQuestion = value; }
        }

        public void LoadControl() {
            // Load Question
            TextCtrl ctrl = new TextCtrl();
            ctrl.Text = sqlQuestion.Desc;
            ctrl.Font = new Font(ctrl.Font, FontStyle.Bold);
            ctrl.Width = splitContainer4.Panel1.Width - 30;
            ctrl.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            ctrl.Location = new Point(10, 10);
            ctrl.ScrollBars = RichTextBoxScrollBars.Both;
            ctrl.ResizeControl();

            splitContainer4.Panel1.Controls.Add(ctrl);

            // splitter distance
            splitContainer4.SplitterDistance = ctrl.Height > 150 ? 150 : (ctrl.Height);
            ctrl.Height = ctrl.Height > 150 ? 150 : ctrl.Height;

            //Load controls and database
            DbManager.Instance.CreateTable(sqlQuestion.Tables);
            tablesTreeCtrl.LoadTables(sqlQuestion.Tables);

            if (ServiceManager.Instance.TestQuestionsAndAnswers.ContainsKey(sqlQuestion)) {
                TestService.SqlQuestionTestAnswer sqlAnswer = (TestService.SqlQuestionTestAnswer)ServiceManager.Instance.TestQuestionsAndAnswers[sqlQuestion];
                sqlEditorCtrl.Query = sqlAnswer.Sql;
            }
        }

        void SqlCommand_RunClicked(object sender, EventArgs e) {
            string sql = sqlEditorCtrl.Query;

            if (String.IsNullOrEmpty(sql) == false) {
                DbResult dbResult = DbManager.Instance.GetSqlResult(sql);
                sqlResultCtrl.LoadResult(dbResult.Data);
                sqlResultMessageCtrl.SetMessage(dbResult);
                if (dbResult.ResultStatus == DbResultStatus.Success) {
                    SqlHistory.AddHist(sqlQuestion, sql);
                }
            }
        }

        void SqlCommand_PauseClicked(object sender, EventArgs e) {

        }

        void SqlCommand_HistoryClicked(object sender, EventArgs e) {
            SqlHistoryForm histForm = new SqlHistoryForm();
            histForm.LoadForm(sqlQuestion);
            if (histForm.ShowDialog() == DialogResult.OK) {
                sqlEditorCtrl.Query = Environment.NewLine + histForm.SelectedQuery;
            }
        }

        void sqlCommandCtrl_SqlQuerySaved(object sender, EventArgs e) {
            SaveAnswer();
        }

        #region INvnTestControl Members

        public void SaveAnswer() {
            if (ServiceManager.Instance.TestQuestionsAndAnswers.ContainsKey(sqlQuestion)) {
                TestService.SqlQuestionTestAnswer sqlAnswer = (TestService.SqlQuestionTestAnswer)ServiceManager.Instance.TestQuestionsAndAnswers[sqlQuestion];
                sqlAnswer.Sql = sqlEditorCtrl.Query;

                ServiceManager.Instance.SaveTestAnswersLocal();
            }
        }

        #endregion
    }
}