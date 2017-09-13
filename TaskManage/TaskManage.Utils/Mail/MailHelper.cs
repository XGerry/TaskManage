using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace TaskManage.Utils.Mail
{
    public class MailHelper
    {
        private static SystemMailHostConfig _config;
        public static MailHelper SystemMail
        {
            get { return new MailHelper(); }
        }

        public MailHelper()
        {
            _config = new SystemMailHostConfig
            {
                FromName = MailConfig.SystemMailFromName,
                From = MailConfig.SystemMailFrom,
                MailHostConfig = new MailHostConfig
                {
                    HostName = MailConfig.SmtpHostName,
                    Port = MailConfig.MailPort.ToInt32(),
                    Account = MailConfig.MailAccount,
                    Password = MailConfig.MailPassword
                }
            };
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailInfo"></param>
        /// <param name="message">默认为null。 System.Net.Mail.MailMessage </param>
        public void Send(MailInfo mailInfo, MailMessage message = null)
        {
            var sender = new SmtpClient();
            message = message ?? new MailMessage();
            if (mailInfo.Receivers.IsNotNullOrEmpty())
            {
                message.To.AddRange(mailInfo.Receivers.ToArray());
            }
            if (mailInfo.Ccs.IsNotNullOrEmpty())
            {
                message.CC.AddRange(mailInfo.Ccs.ToArray());
            }
            if (mailInfo.Bccs.IsNotNullOrEmpty())
            {
                message.Bcc.AddRange(mailInfo.Bccs.ToArray());
            }
            message.Subject = mailInfo.Subject;
            message.Body = mailInfo.Body;

            if (mailInfo.Attachments.IsNotNullOrEmpty())
            {
                message.Attachments.AddRange(mailInfo.Attachments.ToArray());
            }
            message.IsBodyHtml = true;
            try
            {
                message.From = new MailAddress(_config.From, _config.FromName);
                sender.Port = _config.MailHostConfig.Port;
                sender.Host = _config.MailHostConfig.HostName;
                sender.UseDefaultCredentials = false;
                sender.Credentials = new NetworkCredential(_config.MailHostConfig.Account, _config.MailHostConfig.Password);
                sender.DeliveryMethod = SmtpDeliveryMethod.Network;
                sender.EnableSsl = true;
                sender.Send(message);
            }
            catch (SmtpException exception)
            {
                throw exception;
            }
        }

        public bool SendMail(MailInfo mailInfo, MailMessage message = null)
        {
            bool flag = false;
            var sender = new SmtpClient();
            message = message ?? new MailMessage();
            if (mailInfo.Receivers.IsNotNullOrEmpty())
            {
                message.To.AddRange(mailInfo.Receivers.ToArray());
            }
            if (mailInfo.Ccs.IsNotNullOrEmpty())
            {
                message.CC.AddRange(mailInfo.Ccs.ToArray());
            }
            if (mailInfo.Bccs.IsNotNullOrEmpty())
            {
                message.Bcc.AddRange(mailInfo.Bccs.ToArray());
            }
            message.Subject = mailInfo.Subject;
            message.Body = mailInfo.Body;

            if (mailInfo.Attachments.IsNotNullOrEmpty())
            {
                message.Attachments.AddRange(mailInfo.Attachments.ToArray());
            }
            message.IsBodyHtml = true;
            try
            {
                message.From = new MailAddress(_config.From, _config.FromName);
                sender.Port = _config.MailHostConfig.Port;
                sender.Host = _config.MailHostConfig.HostName;
                sender.UseDefaultCredentials = false;
                sender.Credentials = new NetworkCredential(_config.MailHostConfig.Account, _config.MailHostConfig.Password);
                sender.DeliveryMethod = SmtpDeliveryMethod.Network;
                sender.EnableSsl = true;
                sender.Send(message);
                flag = true;
            }
            catch (SmtpException exception)
            {
                flag = false;
                throw exception;
            }
            return flag;
        }

        private static bool CheckValidationResult(object sender,
                           X509Certificate certificate,
                           X509Chain chain,
                           SslPolicyErrors errors)
        {
            return true;
        }

        public static MailAddressCollection GetAddressCollection(IEnumerable<string> strReceiverOrCc)
        {
            var receiversOrCCs = strReceiverOrCc.Aggregate(new MailAddressCollection(), (c, r) =>
            {
                if (!string.IsNullOrEmpty(r))
                {
                    c.Add(new MailAddress(r));
                }
                return c;
            });
            return receiversOrCCs;
        }
    }
}
