﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManage.Core.Domain
{
   public class SchedulerData
    {
        public string Name { get; set; }

        public string InstanceId { get; set; }

        public bool IsStarted
        {
            get
            {
                return Status == SchedulerStatus.Started;
            }
        }

        public bool CanStart
        {
            get
            {
                return Status == SchedulerStatus.Ready;
            }
        }

        public bool CanShutdown
        {
            get
            {
                return Status != SchedulerStatus.Shutdown;
            }
        }

        public IList<JobGroupData> JobGroups { get; set; }

        public IList<TriggerGroupData> TriggerGroups { get; set; }

       public SchedulerStatus Status { get; set; }

        public int JobsTotal { get; set; }

        public int JobsExecuted { get; set; }

        public bool IsRemote { get; set; }

        public Type SchedulerType { get; set; }

        public DateTime? RunningSince { get; set; }
    }
}
