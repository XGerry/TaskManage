using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManage.Utils.Mail
{
   public class MailHostConfig
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }  
    }
}
