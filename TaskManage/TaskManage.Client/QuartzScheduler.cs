using System.Collections.Specialized;
using Quartz.Impl;
using Quartz;
using System.Windows.Forms;

namespace TaskManage.Client
{
	public class QuartzScheduler
	{
		public QuartzScheduler(string server, int port, string scheduler)
		{
			Address = string.Format("tcp://{0}:{1}/{2}", server, port, scheduler);
			_schedulerFactory = new StdSchedulerFactory(getProperties(Address));

			try
			{
				_scheduler = _schedulerFactory.GetScheduler();
			}
			catch (SchedulerException)
			{
				MessageBox.Show("Unable to connect to the specified server", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		public string Address { get; private set; }
		private NameValueCollection getProperties(string address)
		{
			NameValueCollection properties = new NameValueCollection();
            properties["quartz.scheduler.instanceName"] = "TaskScheduler";
			properties["quartz.scheduler.proxy"] = "true";
			properties["quartz.threadPool.threadCount"] = "10";
			properties["quartz.scheduler.proxy.address"] = address;
			return properties;
		}

        public IScheduler GetScheduler()
		{
			return _scheduler;
		}

		private readonly ISchedulerFactory _schedulerFactory;

		private readonly IScheduler _scheduler;
	}
}
