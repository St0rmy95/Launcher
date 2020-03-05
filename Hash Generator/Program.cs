using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace Hash_Generator
{
    class Program
    {
        static Config ConfigData;
        static List<string> Files;

        private static void Main(string[] args)
        {
            Console.Title = "Cosmic-Ascension Hash Generator";

            ConfigData = Config.Load("config.json");

            if (ConfigData == null || !Directory.Exists(ConfigData.ClientPath))
            {
                Log.Error("Invalid config, aborting...");
                Exit();
            }

            Files = new List<string>(Directory.GetFiles(ConfigData.ClientPath, "*.*", SearchOption.AllDirectories));

            RelativatePaths(Files);

            MakeHashes();

            Log.Write("Done.");

            Exit();
        }

        private static void RelativatePaths(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = list[i].Replace(ConfigData.RootPath, "");
            }
        }

        private static void MakeHashes()
        {
            Console.Write("Calculating hashes... ");
            using (StreamWriter sw = new StreamWriter(String.Format("{0}.tmp", ConfigData.HashFile), false))
            {
                using (ProgressBar bar = new ProgressBar())
                {
                    for (int i = 0; i < Files.Count; i++)
                    {
                        bar.Report((double)i / (double)Files.Count);

                        sw.WriteLine(String.Format("{0}:{1}", Files[i], GetHash(Files[i])));
                    }
                }
            }

            Log.Write("\nWriting hashes to file...");

            if (!File.Exists(ConfigData.HashFile))
                File.Create(ConfigData.HashFile).Close();

            File.Replace(String.Format("{0}.tmp", ConfigData.HashFile), ConfigData.HashFile, String.Format("{0}.bak", ConfigData.HashFile));
        }


        private static string GetHash(string sFile)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(String.Format("{0}{1}", ConfigData.RootPath,sFile)))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        private static void Exit()
        {
            Console.Write("Press any key to quit...");
            Environment.Exit(0);
        }
    }
}
