using System.IO;
using System.Security.Cryptography;
using System.Text;
using System;

namespace Merck.Helpers.Auth
{
    public class Encryption
    {
        private const string ENCRYPTION_KEY = "SCH-E-DULE";
        public static string Encrypt(string plainText)
        {
            if (plainText != null)
            {
                string encryptedText = string.Empty;

                byte[] bytes = Encoding.Unicode.GetBytes(plainText);

                using (Aes aes = Aes.Create())
                {
                    Rfc2898DeriveBytes rfcBytes = new Rfc2898DeriveBytes(ENCRYPTION_KEY,
                        new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    aes.Key = rfcBytes.GetBytes(32);
                    aes.IV = rfcBytes.GetBytes(16);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(bytes, 0, bytes.Length);
                        }

                        encryptedText = Convert.ToBase64String(memoryStream.ToArray());
                    }
                }

                return encryptedText;
            }

            return plainText;
        }

        public static string Decrypt(string encryptedText)
        {
            if (encryptedText != null)
            {
                string plainText = string.Empty;
                encryptedText = encryptedText.Replace(" ", "+");
                byte[] bytes = Convert.FromBase64String(encryptedText);

                using (Aes aes = Aes.Create())
                {
                    var rfcBytes = new Rfc2898DeriveBytes(ENCRYPTION_KEY,
                        new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    aes.Key = rfcBytes.GetBytes(32);
                    aes.IV = rfcBytes.GetBytes(16);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(bytes, 0, bytes.Length);
                        }

                        plainText = Encoding.Unicode.GetString(memoryStream.ToArray());
                    }
                }

                return plainText;
            }

            return encryptedText;
        }
    }
    public class EncryptedKey
    {
        public string Value { get; set; }
    }
}
