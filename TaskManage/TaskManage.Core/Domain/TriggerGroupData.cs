using System.Collections.Generic;

namespace TaskManage.Core.Domain
{
    public class TriggerGroupData : ActivityNode<TriggerData>
    {
        public TriggerGroupData(string name)
            : base(name)
        {
        }

        public IList<TriggerData> Triggers { get; set; }
        protected override IList<TriggerData> ChildrenActivities
        {
            get { return Triggers; }
        }
    }
}
