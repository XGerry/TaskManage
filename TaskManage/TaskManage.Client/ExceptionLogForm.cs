using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using TaskManage.Utils.Db;

namespace TaskManage.Client
{
    public partial class ExceptionLogForm : Form
    {
        public ExceptionLogForm()
        {
            InitializeComponent();
            dtStart.Format = DateTimePickerFormat.Custom;
            dtStart.CustomFormat = "yyyy-MM-dd";
            dtEnd.Format = DateTimePickerFormat.Custom;
            dtEnd.CustomFormat = "yyyy-MM-dd";
            InitDataGW();
        }

        private void InitDataGW()
        {
            var db = new DBHelper("connStr");
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT CONVERT(VARCHAR(10),Date,120) AS OccurDate,ClassName,Message,StackTrace FROM dbo.Job_ExceptionLog WHERE 1=1 ");
            if (!string.IsNullOrEmpty(dtStart.Value.ToString(CultureInfo.InvariantCulture)))
            {
                sb.Append("AND (CONVERT(VARCHAR(10),Date,120) BETWEEN '" + dtStart.Value.ToString(dtStart.CustomFormat) + "' ");
            }
            if (!string.IsNullOrEmpty(dtEnd.Value.ToString(CultureInfo.InvariantCulture)))
            {
                sb.Append("AND '" + dtEnd.Value.ToString(dtEnd.CustomFormat) + "') ");
            }
            var cmd = db.CreateCommand(sb.ToString());
            var dt = db.ExecuteDataTable(cmd);
            gwExceptionLog.AutoGenerateColumns = true;
            gwExceptionLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gwExceptionLog.DataSource = dt;
        }

        private void gwExceptionLog_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gwExceptionLog.RowHeadersWidth = 50;
            for (int i = 0; i < gwExceptionLog.Rows.Count; i++)
            {
                int j = i + 1;
                gwExceptionLog.Rows[i].HeaderCell.Value = j.ToString();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            InitDataGW();
        }
    }
}
