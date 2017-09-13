using Quartz;

namespace TaskManage.Core.SchedulerProviders
{
    public interface ISchedulerProvider
    {
        void Init();
        IScheduler Scheduler { get; }
    }
}
