using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManage.Utils.Mail
{
   public class SystemMailHostConfig
    {
        public string FromName { get; set; }
        public string From { get; set; }
        public MailHostConfig MailHostConfig { get; set; }
    }
}
