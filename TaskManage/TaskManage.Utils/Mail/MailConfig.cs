using TaskManage.Utils.Config;

namespace TaskManage.Utils.Mail
{
    public class MailConfig
    {
        /// <summary>
        /// 系統寄件人名稱
        /// </summary>
        public static string SystemMailFromName
        {
            get
            {
                return ConfigHelper.GetConfigString("SystemMailFromName");
            }
        }
        /// <summary>
        /// 系統寄件人郵箱
        /// </summary>
        public static string SystemMailFrom
        {
            get { return ConfigHelper.GetConfigString("SystemMailFrom"); }

        }
        /// <summary>
        /// 寄件人Smtp服務器名稱
        /// </summary>
        public static string SmtpHostName
        {
            get
            {
                return ConfigHelper.GetConfigString("SmtpHostName");
            }
        }
        /// <summary>
        /// 系統Smtp服務器賬號
        /// </summary>
        public static string MailAccount
        {
            get
            {
                return ConfigHelper.GetConfigString("MailAccount");
            }
        }
        /// <summary>
        /// 系統Smtp服務器密碼
        /// </summary>
        public static string MailPassword
        {
            get
            {
                return ConfigHelper.GetConfigString("MailPassword");
            }
        }
        /// <summary>
        /// 系統服務端口
        /// </summary>
        public static string MailPort
        {
            get
            {
                return ConfigHelper.GetConfigString("MailPort");
            }
        }
    }
}
