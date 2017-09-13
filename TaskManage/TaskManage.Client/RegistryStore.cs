using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace TaskManage.Client
{
    public class RegistryStore
    {

        public static List<ConnectionInfo> GetLastConnections()
        {
            List<ConnectionInfo> lastConnections = new List<ConnectionInfo>();

            RegistryKey managerKey = Registry.CurrentUser.CreateSubKey("QuartzNetManager");
            RegistryKey key = null;
            if (managerKey == null)
            {
                return lastConnections;
            }

            key = managerKey.CreateSubKey("MRUList");

            if (key == null)
            {
                return lastConnections;
            }
            //TODO: show more than one server in dropdown
            for (int i = 0; i < 1; i++)
            {
                ConnectionInfo info = ConnectionInfo.Parse((key.GetValue(string.Format("connection{0}", i), null) as string));
                if (info != null)
                {
                    lastConnections.Add(info);
                }
            }

            key.Close();
            managerKey.Close();

            return lastConnections;
        }
        public static void AddConnection(ConnectionInfo info)
        {
            RegistryKey managerKey = Registry.CurrentUser.CreateSubKey("QuartzNetManager");
            RegistryKey key = null;
            if (managerKey == null)
            {
                return;
            }

            key = managerKey.CreateSubKey("MRUList");

            if (key == null)
            {
                return;
            }
            key.SetValue("connection0", info, RegistryValueKind.String);

        }
    }
}
