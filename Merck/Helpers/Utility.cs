using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Merck.Helpers
{
    public class Utility
    {
        public static string GetMd5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static string GetHashFileName(string sourceFileName)
        {
            try
            {
                string fileName = Path.GetFileName(sourceFileName);
                string newName = Regex.Replace(fileName, @"(\d+)\.json$", "h_$1.json");
                // newName = Path.Combine("hashed", newName);
                return $"hashed/{newName}";
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
