using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskManage.Utils.Data
{
  public  class CommonUtils
    {
        #region 通用正则验证
        private static Regex RegMaskHtml = new Regex("<(.*?)>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        private static readonly Regex RegUInt = new Regex("^[0-9]+$");
        private static readonly Regex RegInt = new Regex("^[+-]?[0-9]+$");
        private static readonly Regex RegUNumber = new Regex("^(0|[0-9]+[.]?[0-9]+)$");//^(0|[1-9][0-9]*)$
        private static readonly Regex RegNumber = new Regex("^(-?[0-9]*[.]*[0-9]{0,5})$"); //等价于^[+-]?\d+[.]?\d+$
        private static readonly Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info|cn|cc)$", RegexOptions.IgnoreCase | RegexOptions.Singleline);//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
        private static readonly Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");
        #endregion 通用正则验证

        public static string CheckStr(object ObjInfo)
        {
            try
            {
                return (ObjInfo != null) ? ObjInfo.ToString().Replace("'", "''") : "";
            }
            catch
            {
                return "";
            }
        }

        public static bool IsInt32(string strText)
        {
            try
            {
                int num = Convert.ToInt32(strText);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断字符串是不是无符号整数，并返回该数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static double ConvertToDouble(object str)
        {
            if (str == null)
                return 0;
            return (str.ToString().Length > 0 && IsNumber(str.ToString())) ? Math.Round(Convert.ToDouble(str), 4) : 0;
        }

        #region 是否是一个正整数
        /// <summary>
        /// 是否是一个正整数
        /// </summary>
        /// <param name="number">被检测的字符串</param>
        /// <returns></returns>
        public static bool IsUInt(string number)
        {
            Match m = RegUInt.Match(number);
            return m.Success;
        }
        #endregion

        public static double ValDividend(double para1, double para2)
        {
            if (para2 > 0)
                return Math.Round(para1 / para2, 4);
            else
                return 0.00;
        }

        #region 是否是一个整数
        /// <summary>
        /// 是否是一个整数
        /// </summary>
        /// <param name="number">被检测的字符</param>
        /// <returns></returns>
        public static bool IsInt(string number)
        {
            Match m = RegInt.Match(number);
            return m.Success;
        }
        #endregion

        #region 是否是一个正数
        /// <summary>
        /// 是否是一个正数
        /// </summary>
        /// <param name="number">被检测的字符串</param>
        /// <returns></returns>
        public static bool IsUNumber(string number)
        {
            Match m = RegUNumber.Match(number);
            return m.Success;
        }

        #endregion

        #region 是否是一个数，可带正负号
        /// <summary>
        /// 是否是一个数 可带正负号
        /// </summary>
        /// <param name="number">被检测的数</param>
        /// <returns></returns>
        public static bool IsNumber(string number)
        {
            Match m = RegNumber.Match(number);
            return m.Success;
        }

        #endregion

        #region 是否包含中文
        /// <summary>
        /// 检测是否有中文字符
        /// </summary>
        /// <param name="str">被检查的内容</param>
        /// <returns></returns>
        public static bool IsExistsCN(string str)
        {
            Match m = RegCHZN.Match(str);
            return m.Success;
        }

        #endregion 是否包含中文

        #region 检查邮件地址
        /// <summary>
        /// 检查邮件地址
        /// </summary>
        /// <param name="email">邮件地址</param>
        /// <returns></returns>
        public static bool IsEmail(string email)
        {
            Match m = RegEmail.Match(email);
            return m.Success;
        }
        #endregion 检查邮件地址

        public static string left(string str, int count)
        {
            if ((count != 0) && (str.Length > count))
            {
                str = str.Substring(0, count);
            }
            return str;
        }

        public static bool IsDateTime(string strText)
        {
            try
            {
                DateTime time = Convert.ToDateTime(strText);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
