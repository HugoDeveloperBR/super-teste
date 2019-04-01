using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SuperTest.Domain.Helpers
{
    public class StringHelper
    {
        public static string CriptografarTexto(string texto)
        {
            string privateKey = "ABh154DeAWe89d65";

            if (string.IsNullOrEmpty(texto))
                return texto;

            using (var provider = new TripleDESCryptoServiceProvider())
            {
                provider.Key = Encoding.ASCII.GetBytes(privateKey.Substring(0, 16));
                provider.IV = Encoding.ASCII.GetBytes(privateKey.Substring(8, 8));

                byte[] encryptedBinary = CriptografarTextoEmMemoria(texto, provider.Key, provider.IV);
                return Convert.ToBase64String(encryptedBinary);
            }
        }

        private static byte[] CriptografarTextoEmMemoria(string data, byte[] key, byte[] iv)
        {
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, new TripleDESCryptoServiceProvider().CreateEncryptor(key, iv), CryptoStreamMode.Write))
                {
                    byte[] toEncrypt = Encoding.Unicode.GetBytes(data);
                    cs.Write(toEncrypt, 0, toEncrypt.Length);
                    cs.FlushFinalBlock();
                }

                return ms.ToArray();
            }
        }

        public static bool EmailEhValido(string texto)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(texto);

            return match.Success;
        }

        public static bool TextoTemMinCaracteres(string texto, int min)
        {
            string expressao = @"^\S{" + min + @" ,}$\S";
            Regex regex = new Regex(expressao);
            Match match = regex.Match(texto);

            return match.Success;

        }
    }
}
