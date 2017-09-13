using System.Collections.Specialized;

namespace TaskManage.Core.SchedulerProviders
{
    public class RemoteSchedulerProvider : StdSchedulerProvider
    {
        public string SchedulerHost { get; set; }

        protected override bool IsLazy
        {
            get { return true; }
        }

        protected override NameValueCollection GetSchedulerProperties()
        {
            var properties = base.GetSchedulerProperties();
            properties["quartz.scheduler.proxy"] = "true";
            properties["quartz.scheduler.proxy.address"] = SchedulerHost;
            return properties;
        }
    }
}
