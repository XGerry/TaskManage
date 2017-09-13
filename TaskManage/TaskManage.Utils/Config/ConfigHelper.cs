using System;
using System.Configuration;

namespace TaskManage.Utils.Config
{
   public class ConfigHelper
    {
       public static string GetConnectionString(string key)
       {
           return ConfigurationManager.ConnectionStrings[key].ConnectionString;
       }

       public static string GetConfigString(string key)
       {
           try
           {
               return ConfigurationManager.AppSettings[key];
           }
           catch (Exception)
           {
               return string.Empty;
           }
       }
    }
}
