using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.SessionState;
namespace MirrorWork
{
    public class mConfig
    {

        public static string GetKey(string KeyName)
        {
            return (ConfigurationSettings.AppSettings[KeyName] != null) ? ConfigurationSettings.AppSettings[KeyName].ToString() : "";
        }
        public static bool IsAccessable(string uid)
        {
            DataTable mdt = mDataBase.SQLquery("select class from users where id=" + uid);
            if (mdt != null && mdt.Rows[0][0].ToString() == "مدیر")
                return true;
            return false;
        }
        public static bool IsAccessable(string username, string mudulename)
        {
            DataTable mdt = mDataBase.SQLquery("select id from modules where name ='" + mudulename + "'");
            if (mdt != null && mdt.Rows.Count > 0)
            {
                mdt = mDataBase.SQLquery("select * from module_user where module_id = " + mdt.Rows[0][0].ToString() + " and username='" + username + "'");
                if (mdt != null && mdt.Rows.Count > 0)
                    return true;
                else return false;
            }
            return false;
        }

    }
}
