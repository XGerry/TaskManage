using System.Collections.Generic;
using System.Net.Mail;

namespace TaskManage.Utils.Mail
{
    public class MailInfo
    {
        public IEnumerable<MailAddress> Receivers { get; set; }
        public IEnumerable<MailAddress> Ccs { get; set; }
        public IEnumerable<MailAddress> Bccs { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public IEnumerable<Attachment> Attachments { get; set; }
    }
}
