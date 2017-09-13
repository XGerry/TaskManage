using System.Collections.Generic;

namespace TaskManage.Core.Domain
{
    public class JobData : ActivityNode<TriggerData>
    {
        public JobData(string name, string group, IList<TriggerData> triggers)
            : base(name)
        {
            Triggers = triggers;
            GroupName = group;
        }

        public IList<TriggerData> Triggers { get; set; }

        public string GroupName { get; set; }

        public string UniqueName
        {
            get
            {
                return string.Format("{0}_{1}", GroupName, Name);
            }
        }

        public bool HasTriggers
        {
            get
            {
                return Triggers != null && Triggers.Count > 0;
            }
        }

        protected override IList<TriggerData> ChildrenActivities
        {
            get { return Triggers; }
        }
    }
}
