using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace MirrorWork
{
    public class mCryption
    {
        public static string encryptString(string strToEncrypt)
        {
            UTF8Encoding ue = new UTF8Encoding();
            byte[] bytes = ue.GetBytes(strToEncrypt);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hashBytes = md5.ComputeHash(bytes);
            // Bytes to string
            return System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(hashBytes), "-", "").ToLower();
        }
    }
}
