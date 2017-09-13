using Quartz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using TaskManage.Core.Domain;
using TaskManage.Utils.Db;

namespace TaskManage.Client
{
    public partial class AddEmailForm : Form
    {
        public AddEmailForm()
        {
            InitializeComponent();
            LoadClassName();
        }

        private void LoadClassName()
        {
            var assemblies = AssemblyRepository.GetAssemblies();
            SortedList<string, string> jobTypes = new SortedList<string, string>();
            foreach (var assemblyName in assemblies)
            {
                Assembly assembly = Assembly.LoadFile(Environment.CurrentDirectory + "\\" + assemblyName);
                foreach (Type type in assembly.GetTypes())
                {
                    if (typeof(IJob).IsAssignableFrom(type) && type.IsClass)
                    {
                        jobTypes.Add(type.FullName, assembly.GetName().Name);
                    }
                }
            }
            foreach (var item in jobTypes)
            {
                cboClassName.Items.Add(new JobType { AssemblyName = item.Value, FullName = item.Key });
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string className = this.cboClassName.SelectedItem.ToString();
            if (string.IsNullOrEmpty(className))
            {
                MessageBox.Show("請選擇需要添加Email的Class Name!", "提示");
                return;
            }
            if (string.IsNullOrEmpty(txtReceivers.Text.Trim()))
            {
                MessageBox.Show("請至少輸入一個收件人郵箱!", "提示");
                return;
            }
            var db = new DBHelper("connStr");
            var commandText = "DELETE dbo.TT_UserEmail WHERE GroupType='Email' AND GroupName='" + className + "' ";
            var command = db.CreateCommand(commandText);
            db.ExecuteNonQuery(command);
            string[] receivers = txtReceivers.Text.Split(';');
            string[] ccs = txtCcs.Text.Split(';');
            string[] bccs = txtBCcs.Text.Split(';');
            string remark = txtRemark.Text.Trim().ToString();
            string creator = txtCreator.Text.Trim().ToString();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < receivers.Length; i++)
            {
                string receiver = receivers[i];
                string cc = string.Empty;
                string bcc = string.Empty;
                if (ccs.Length > i)
                {
                    cc = ccs[i];
                }
                if (bccs.Length > i)
                {
                    bcc = bccs[i];
                }
                sb.Append("INSERT INTO dbo.TT_UserEmail( GroupType ,GroupName ,Receivers ,Ccs ,BCcs ,Remark ,Creator ,CreateDate)");
                sb.Append("VALUES('Email','" + className + "','" + receiver + "','" + cc + "','" + bcc + "','" + remark + "','" + creator + "','" + DateTime.Now + "');");
            }
            command = db.CreateCommand(sb.ToString());
            if (db.ExecuteNonQuery(command) > 0)
            {
                MessageBox.Show("保存成功!");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtReceivers.Text = string.Empty;
            this.txtCcs.Text = string.Empty;
            this.txtBCcs.Text = string.Empty;
            this.txtCreator.Text = string.Empty;
            this.txtRemark.Text = string.Empty;
        }

        private void cboClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string className = this.cboClassName.SelectedItem.ToString();
            var db = new DBHelper("connStr");
            var commandText = "SELECT Receivers,Ccs,BCcs,Remark,Creator FROM dbo.TT_UserEmail WHERE GroupType='Email' AND GroupName='" + className + "' ";
            var command = db.CreateCommand(commandText);
            var dt = db.ExecuteDataTable(command);
            if (dt.Rows.Count > 0)
            {
                StringBuilder sbReceivers = new StringBuilder();
                StringBuilder sbCcs = new StringBuilder();
                StringBuilder sbBccs = new StringBuilder();
                string remark = string.Empty;
                string creator = string.Empty;
                foreach (DataRow row in dt.Rows)
                {
                    if (!string.IsNullOrEmpty(row["Receivers"].ToString()))
                    {
                        sbReceivers.Append(row["Receivers"].ToString() + ";");
                    }
                    if (!string.IsNullOrEmpty(row["Ccs"].ToString()))
                    {
                        sbCcs.Append(row["Ccs"].ToString() + ";");
                    }
                    if (!string.IsNullOrEmpty(row["BCcs"].ToString()))
                    {
                        sbBccs.Append(row["BCcs"].ToString() + ";");
                    }
                    remark = row["Remark"].ToString();
                    creator = row["Creator"].ToString();
                }
                if (!string.IsNullOrEmpty(sbReceivers.ToString()))
                {
                    txtReceivers.Text = sbReceivers.ToString().Substring(0, sbReceivers.Length - 1);
                }
                if (!string.IsNullOrEmpty(sbCcs.ToString()))
                {
                    txtCcs.Text = sbCcs.ToString().Substring(0, sbCcs.Length - 1);
                }
                if (!string.IsNullOrEmpty(sbBccs.ToString()))
                {
                    txtBCcs.Text = sbBccs.ToString().Substring(0, sbBccs.Length - 1);
                }
                txtRemark.Text = remark;
                txtCreator.Text = creator;
            }
            else
            {
                btnReset_Click(null, null);
            }
        }
    }
}
