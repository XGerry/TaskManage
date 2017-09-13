using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quartz;
using TaskManage.Core.SchedulerProviders;

namespace TaskManage.Client
{
    public class SchedulerNode : TreeNode
    {
        public SchedulerNode(IScheduler scheduler)
        {
            this.Text = scheduler.SchedulerName;
            this.Name = scheduler.SchedulerInstanceId;
            Scheduler = scheduler;
        }
        public IScheduler Scheduler { get; private set; }

    }
}
