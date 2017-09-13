using System;
using TaskManage.Core.Domain.TriggerTypes;

namespace TaskManage.Core.Domain
{
    public class TriggerData : Activity
    {
        public TriggerData(string name, ActivityStatus status)
            : base(name, status)
        {
        }

        public string Name { get; set; }
        public string GroupName { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? NextFireDate { get; set; }

        public DateTime? PreviousFireDate { get; set; }

        public TriggerType TriggerType { get; set; }
    }
}
