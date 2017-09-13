using System.Collections.Specialized;

namespace TaskManage.Core.Exception
{
    public class SchedulerProviderException : System.Exception
    {
        public SchedulerProviderException(string message, NameValueCollection properties)
            : this(message, null, properties)
        {
        }

        public SchedulerProviderException(string message, System.Exception innerException, NameValueCollection properties)
            : base(message, innerException)
        {
            SchedulerInitialProperties = properties;
        }

        private NameValueCollection SchedulerInitialProperties { get; set; }
    }
}
