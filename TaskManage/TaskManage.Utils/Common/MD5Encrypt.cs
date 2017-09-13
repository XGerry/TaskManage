using System;
using System.Security.Cryptography;

namespace TaskManage.Utils.Common
{
    public class MD5Encrypt
    {
        public static string Encrypt(string strText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(strText));
            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }
    }
}
