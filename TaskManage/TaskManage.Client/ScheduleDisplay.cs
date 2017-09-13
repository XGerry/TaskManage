using System;
using System.Windows.Forms;
using TaskManage.Core.Domain;

namespace TaskManage.Client
{
    public partial class ScheduleDisplay : UserControl
    {
        private readonly SchedulerData _schedulerData;

        public ScheduleDisplay()
        {
            InitializeComponent();
            this.Load += ScheduleDisplay_Load;
        }

        public ScheduleDisplay(SchedulerData schedulerData):this()
        {
            this._schedulerData = schedulerData;
        }

        void ScheduleDisplay_Load(object sender, EventArgs e)
        {
            this.lblSchedulerName.Text = _schedulerData.Name;
            this.lblInstainID.Text = _schedulerData.InstanceId;
            this.lblIsRemote.Text = _schedulerData.IsRemote.ToString();
            this.lblSchedulerType.Text = _schedulerData.SchedulerType.ToString();
            this.lblTotalJobs.Text = _schedulerData.JobsTotal.ToString();
            this.lblExecutedJob.Text = _schedulerData.JobsExecuted.ToString();
        }

    }
}
