using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AmazonRestOAuth.Helpers
{
    public class Encrypt
    {
        private static string strKey = "U2A9/R*41FD412+4-123";

        public static string EncryptPassword(string password)
        {
            string strValue = "";


            if (!string.IsNullOrWhiteSpace(strKey))
            {
                if (strKey.Length < 16)
                {
                    char c = "XXXXXXXXXXXXXXXX"[16];
                    strKey = strKey + strKey.Substring(0, 16 - strKey.Length);
                }

                if (strKey.Length > 16)
                {
                    strKey = strKey.Substring(0, 16);
                }

                var byteKey = Encoding.UTF8.GetBytes(strKey.Substring(0, 8));
                var byteVector = Encoding.UTF8.GetBytes(strKey.Substring(strKey.Length - 8, 8));

                var byteData = Encoding.UTF8.GetBytes(password);

                var objDES = new DESCryptoServiceProvider();
                var objMemoryStream = new MemoryStream();
                var objCryptoStream = new CryptoStream(objMemoryStream, objDES.CreateEncryptor(byteKey, byteVector), CryptoStreamMode.Write);
                objCryptoStream.Write(byteData, 0, byteData.Length);
                objCryptoStream.FlushFinalBlock();

                strValue = Convert.ToBase64String(objMemoryStream.ToArray());
            }
            else
            {
                strValue = password;
            }
            return strValue;
        }
    }
}