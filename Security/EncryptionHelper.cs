using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace ViveroElSalto.clases
{

    public class EncryptionHelper
    {
        public static string password_to_decryp = "un clave para desencriptar";

        public static string Encrypt(string plainText, string password)
        {
            byte[] salt = GenerateSalt();
            byte[] key = GenerateKey(password, salt);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;

                byte[] iv = aesAlg.IV;

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(iv, 0, iv.Length);
                    using (ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(plainText);
                            }
                        }
                    }
                    return Convert.ToBase64String(salt.Concat(msEncrypt.ToArray()).ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText, string password)
        {
            
            try
            {
                byte[] allBytes = Convert.FromBase64String(cipherText);
                byte[] salt = allBytes.Take(16).ToArray();
                byte[] cipherTextBytes = allBytes.Skip(16).ToArray();
                byte[] key = GenerateKey(password, salt);

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = key;
                    aesAlg.IV = cipherTextBytes.Take(16).ToArray();

                    using (MemoryStream msDecrypt = new MemoryStream(cipherTextBytes.Skip(16).ToArray()))
                    {
                        using (ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                        {
                            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                            {
                                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                                {
                                    return srDecrypt.ReadToEnd();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return cipherText;
            }
            
        }

        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(salt);
            }
            return salt;
        }

        private static byte[] GenerateKey(string password, byte[] salt)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                return deriveBytes.GetBytes(32);
            }
        }
    }

}
