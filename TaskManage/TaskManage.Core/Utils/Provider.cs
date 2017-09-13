using System;
using System.Configuration;
using TaskManage.Core.SchedulerProviders;

namespace TaskManage.Core.Utils
{
    public class Provider
    {
        public static ISchedulerProvider SchedulerProvider
        {
            get
            {
                var section = ConfigurationManager.AppSettings;
                var type = Type.GetType(section["Type"]);
                var provider = Activator.CreateInstance(type);
                foreach (string property in section.Keys)
                {
                    if (property != "Type")
                    {
                        provider.GetType().GetProperty(property).SetValue(provider, section[property], new object[] { });
                    }
                }
                return (ISchedulerProvider)provider;
            }
        }
    }
}
