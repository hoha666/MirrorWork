using System;
using System.Collections.Generic;
using System.Text;


namespace MirrorWork
{
    public class mDecoder
    {

        public static string decode(string item)
        {
            return item;
            //try
            //{
            //    SimpleAES saes = new SimpleAES();
            //    string DBCONSTR = "Server = SERVERSEJELI; Database = MirrorCMS; User Id = 'sa'; Password = 'admin123.';";
            //    if (DBCONSTR != saes.DecryptString(mConfig.GetKey("ConnectionInfo")))
            //    {
            //        mLog.write("Copy Right Issue : connection string is not valid for this product .");
            //        return "";
            //    }
            //    mLog.write(item);
            //    string tt = saes.DecryptString(item);
            //    mLog.write(tt);
            //    return tt;
            //}
            //catch (Exception ex)
            //{
            //    mLog.write("error decryption");
            //    return "";
            //}
        }

        public static string decode2(string item)
        {
            try
            {
                SimpleAES saes = new SimpleAES();
                string tt = saes.DecryptString(item);

                return tt;
            }
            catch (Exception ex)
            {

                return "";
            }
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
