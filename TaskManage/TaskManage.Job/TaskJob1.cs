using Common.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using TaskManage.Utils.Data;
using TaskManage.Utils.Log;

namespace TaskManage.Job
{
    [DisallowConcurrentExecution]
    [PersistJobDataAfterExecution]
    public class TaskJob1 : IJob
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(TaskJob1));
        private List<string> listReceivers = new List<string>();
        private List<string> listCcs = new List<string>();
        private List<string> listBccs = new List<string>();

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                _log.Info("TaskJob1任務開始執行...");
                GetReceiverAndCcsList();
            }
            catch (Exception ex)
            {
                _log.Error("TaskJob1b任務執行失敗...");
                LogManage.NSLog("LabelSystem_ReceivingJob.txt", ex.Message, ex.StackTrace);
            }
        }

        private void GetReceiverAndCcsList()
        {
            CommonStr.GetReceiverAndCcsList(typeof(TaskJob1).FullName, out listReceivers, out listCcs,
               out listBccs);
        }
    }
}
