using System;
using System.Security.Cryptography;
using System.Text;

namespace PersonDirectory.Application.Commons
{
    public static class Functions
    {
        public static string GetPasswordHash(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var bytes = Encoding.ASCII.GetBytes(password);

            var computeHash = md5.ComputeHash(bytes);
            return BitConverter.ToString(computeHash).Replace("-", "");
        }
    }
}
