using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Quartz;
using System.Reflection;
using Quartz.Impl.Triggers;
using TaskManage.Core.Domain;
using TaskManage.Core.SchedulerProviders;

namespace TaskManage.Client
{
    public partial class AddJobForm : Form
    {
        public AddJobForm()
        {
            InitializeComponent();
            try
            {
                LoadJobAssemblies();
                LoadTriggerType();
            }
            catch (Exception)
            {
                MessageBox.Show("加載任務程序集失敗，請確認程序集是否存在！");
            }
        }
        public AddJobForm(TriggerNode node)
            : this()
        {
            setTriggerData((CronTriggerImpl)node.Trigger);
            setJobData(((JobNode)node.Parent.Parent).Detail);
        }
        private void setTriggerData(CronTriggerImpl trigger)
        {
            setTriggerType();
            txtCronExpression.Text = trigger.CronExpressionString;
            txtTriggerDescription.Text = trigger.Description;
            txtTriggerGroup.Text = trigger.Key.Group;
            txtTriggerName.Text = trigger.Key.Name;
        }

        private void setJobData(IJobDetail detail)
        {
            setJobType(detail);
            txtJobDescription.Text = detail.Description;
            txtJobGroup.Text = detail.Key.Group;
            txtJobName.Text = detail.Key.Name;
        }

        private void setJobType(IJobDetail detail)
        {
            int index = cboJobType.FindString(detail.JobType.FullName);
            cboJobType.SelectedIndex = index;
        }

        private void setTriggerType()
        {
            //nothing to do right now
        }

        //加載觸發器類型，包含SimpleTrigger和CronTrigger兩種
        private void LoadTriggerType()
        {
           // cboTriggerType.Items.Add("Simple");
            cboTriggerType.Items.Add("Cron");
            cboTriggerType.SelectedIndex = 0;
        }

        //加載任務類型
        private void LoadJobAssemblies()
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
                cboJobType.Items.Add(new JobType() { AssemblyName = item.Value, FullName = item.Key });
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public IJobDetail JobDetail { get; private set; }

        public ITrigger Trigger { get; private set; }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            JobDetail = GetJobDetail();
            Trigger = GetTrigger(JobDetail);
            this.Close();
        }

        private IJobDetail GetJobDetail()
        {
            IJobDetail detail = JobBuilder
                .Create()
                .OfType(GetJobType())
                .WithDescription(txtJobDescription.Text.Trim())
                .WithIdentity(new JobKey(txtJobName.Text.Trim(), txtJobGroup.Text.Trim()))
                .RequestRecovery()  //故障恢復
                .Build();
            return detail;
        }

        private Type GetJobType()
        {
            JobType type = (JobType)cboJobType.SelectedItem;
            return Type.GetType(type.FullName + "," + type.AssemblyName, true);
        }

        private ITrigger GetTrigger(IJobDetail jobDetail)
        {
            TriggerBuilder builder = TriggerBuilder
                .Create()
                .ForJob(jobDetail)
                .WithDescription(txtTriggerDescription.Text.Trim())
                .WithIdentity(new TriggerKey(txtTriggerName.Text.Trim(), txtTriggerGroup.Text.Trim()));
            if (cboTriggerType.SelectedText == "Simple")
            {
                return builder.WithSchedule(SimpleScheduleBuilder.Create()).Build();
            }
            return builder.WithSchedule(CronScheduleBuilder.CronSchedule(txtCronExpression.Text)).Build();
        }
    }
}
