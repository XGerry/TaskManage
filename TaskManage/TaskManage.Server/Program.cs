using System;
using Quartz;
using Topshelf;

namespace TaskManage.Server
{
    internal class Program
    {
        //安装：TaskManage.Server.exe install
        //启动：TaskManage.Server.exe start
        //卸载：TaskManage.Server.exe uninstall
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.UseLog4Net("log4net.config", true);
                x.SetDescription("該服務將支撐所有定時任務的運作");
                x.SetDisplayName("TaskManage Service");
                x.SetServiceName("TaskManageServer");
                x.Service(s =>
                {
                    var server = new QuartzServer();
                    return server;
                });
            });
        }
    }
}
