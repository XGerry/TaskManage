using Quartz;
using TaskManage.Core.Domain;

namespace TaskManage.Core.SchedulerProviders
{
    public interface ISchedulerDataProvider
    {
        SchedulerData Data { get; }

        JobDetailsData GetJobDetailsData(string name, string group);

        TriggerData GetTriggerData(TriggerKey key);
    }
}
