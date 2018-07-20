using System;
using System.Text;

namespace WinterSpider.Core
{
    public class SpiderHelper
    {
        
        public static string Md5Encrypt(string encryptingString)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(encryptingString));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}