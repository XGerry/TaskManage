using System.Collections.Generic;

namespace TaskManage.Core.Domain
{
    public class JobGroupData : ActivityNode<JobData>
    {
        public JobGroupData(string name, IList<JobData> jobs)
            : base(name)
        {
            Jobs = jobs;
        }

        public IList<JobData> Jobs { get; set; }

        protected override IList<JobData> ChildrenActivities
        {
            get { return Jobs; }
        }
    }
}
