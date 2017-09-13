using System.Collections.Generic;

namespace TaskManage.Core.Domain
{
    public class JobDetailsData
    {
        public JobDetailsData()
        {
            JobDataMap = new Dictionary<object, object>();
            JobProperties = new Dictionary<string, object>();
        }

        public JobData PrimaryData { get; set; }

        public IDictionary<object, object> JobDataMap { get; set; }

        public IDictionary<string, object> JobProperties { get; set; }
    }
}
