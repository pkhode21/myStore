using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace idea_UX.App_Code
{
    public class PasswordHandler
    {
        public static string EncryptPassword(string pwd)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(pwd);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString(); ;
        }
    }
}