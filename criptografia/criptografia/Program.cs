using System;
using System.Linq;

namespace criptografia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var keyUSer = "AKMJFGVCBNXMMAKDYDADIMJUSMSURYIADWDD";
            var textUser = "CYZPWGOU! WBZQ OOXVCJULC GBUJ M GHV-RQMH LDG";

            Console.Write(Transform(keyUSer, textUser));

            Console.ReadLine();
        }

        public static string Transform(string key, string text)
        {
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var encryptKey = key;
            var src = CleanSe(text, alphabet);

            if (encryptKey.Length == 0)
                return "";

            encryptKey = encryptKey.Split("").Where(c => alphabet.IndexOf(c) != -1).ToString();
            var dst = "";

            for (var i = 0; i < src.Length; i++)
            {
                if (alphabet.IndexOf(src[i].ToString().ToUpper()) != -1)
                {
                    if (i >= key.Length)
                    {
                        dst += "***TRUNCATED***";
                        break;
                    }

                    var charCode = (alphabet.IndexOf(src[i].ToString().ToUpper()) - alphabet.IndexOf(key[i]) + alphabet.Length) % alphabet.Length;
                    var ch = alphabet[charCode].ToString();
                    if (src[i] >= 'a')
                        ch = ch.ToString().ToLower();
                    dst += ch;
                }
            }

            return dst;
        }

        public static string CleanSe(string src, string alphabet)
        {
            src = src.ToString().ToUpper();
            var dst = "";
            for (var i = 0; i < src.Length; i++)
            {
                if (alphabet.IndexOf(src[i]) != -1)
                    dst += src[i];
            }

            return dst;
        }

        /*
            3. Pelo fato de que a cópia seria expandida também para caracteres especiais, sendo assim, 
               iria dificultar a cópia e poderia abrir brexas para serem burladas
         */
    }
}
