using System;
using System.Collections.Specialized;
using Quartz;
using Quartz.Impl;
using TaskManage.Utils.Config;
using Topshelf;

namespace TaskManage.Server
{
    public class QuartzServer : ServiceControl
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IScheduler _scheduler;
        public QuartzServer()
        {
            _schedulerFactory = new StdSchedulerFactory(getProperties());
            try
            {
                _scheduler = _schedulerFactory.GetScheduler();
            }
            catch (SchedulerException exception)
            {
                Console.WriteLine("Create Schedule Fail!Exception:" + exception.Message);
            }
        }
        //創建作業調度池
        private NameValueCollection getProperties()
        {
            NameValueCollection properties = new NameValueCollection();
            //啟用集群
            //properties["quartz.jobStore.clustered"] = "true";
            properties["quartz.scheduler.instanceId"] = "AUTO";
            properties["quartz.scheduler.instanceName"] = "TaskScheduler";
            //線程池配置
            properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            properties["quartz.threadPool.threadCount"] = "20";
            properties["quartz.threadPool.threadPriority"] = "Normal";
            properties["quartz.jobStore.misfireThreshold"] = "60000";

            // 设置遠程服务器  
            properties["quartz.scheduler.exporter.type"] = "Quartz.Simpl.RemotingSchedulerExporter, Quartz";
            properties["quartz.scheduler.exporter.port"] = "5555";
            properties["quartz.scheduler.exporter.bindName"] = "QuartzScheduler";
            properties["quartz.scheduler.exporter.channelType"] = "tcp";
            properties["quartz.scheduler.exporter.channelName"] = "httpQuartz";

            //存儲類型
            properties["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz";
            //驅動類型
            properties["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.StdAdoDelegate, Quartz";
            properties["quartz.jobStore.dataSource"] = "default";
            properties["quartz.jobStore.tablePrefix"] = "QRTZ_";
            //連接字符串
            properties["quartz.dataSource.default.connectionString"] = ConfigHelper.GetConnectionString("connStr");
            properties["quartz.dataSource.default.provider"] = "SqlServer-20";
            return properties;
        }

        public IScheduler GetScheduler()
        {
            return _scheduler;
        }

        public bool Start(HostControl hostControl)
        {
            if (this._scheduler!=null)
            {
                this._scheduler.Start();
            }
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            if (this._scheduler != null)
            {
                this._scheduler.Shutdown(false);
            }
            return true;
        }
    }
}
