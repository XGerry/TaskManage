using Quartz;
using TaskManage.Core.Domain.TriggerTypes;

namespace TaskManage.Core.SchedulerProviders
{
  public  class TriggerTypeExtractor
    {
      public TriggerType GetFor(ITrigger trigger)
      {
          var simpleTrigger = trigger as ISimpleTrigger;
          if (simpleTrigger != null)
          {
              return new SimpleTriggerType(
                  simpleTrigger.RepeatCount,
                  (long)simpleTrigger.RepeatInterval.TotalMilliseconds,
                  simpleTrigger.TimesTriggered);
          }

          var cronTrigger = trigger as ICronTrigger;
          if (cronTrigger != null)
          {
              return new CronTriggerType(cronTrigger.CronExpressionString);
          }

          return new TriggerType("unknown");
      }
    }
}
