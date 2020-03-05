using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
    class MD5Lib
    {
        static MD5 md5 = MD5.Create();

        public static string GetHash(string sFile)
        {
            using (var stream = File.OpenRead(sFile))
            {
                var hash = md5.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }

        public static byte[] GetPasswordMD5(string input)
        {

            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            return md5.ComputeHash(inputBytes);
        }
    }
}
