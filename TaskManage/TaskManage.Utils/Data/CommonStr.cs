using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TaskManage.Utils.Db;

namespace TaskManage.Utils.Data
{
    public class CommonStr
    {
        public static void GetReceiverAndCcsList(string groupName, out  List<string> listReceivers, out  List<string> listCcs, out  List<string> listBccs)
        {
            listReceivers = new List<string>();
            listCcs = new List<string>();
            listBccs = new List<string>();
            var db = new DBHelper("connStr");
            var commandText = "SELECT Receivers,Ccs,BCcs FROM dbo.TT_UserEmail WHERE GroupType='Email' AND GroupName='" + groupName + "' ";
            var command = db.CreateCommand(commandText);
            var dt = db.ExecuteDataTable(command);
            foreach (DataRow row in dt.Rows)
            {
                if (!string.IsNullOrEmpty(row["Receivers"].ToString()))
                {
                    listReceivers.Add(row["Receivers"].ToString());
                }
                if (!string.IsNullOrEmpty(row["Ccs"].ToString()))
                {
                    listCcs.Add(row["Ccs"].ToString());
                }
                if (!string.IsNullOrEmpty(row["BCcs"].ToString()))
                {
                    listBccs.Add(row["BCcs"].ToString());
                }
            }
        }

    }
}
