using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Launcher.Updater
{
    class FileCheck
    {
        private static string LocalHashFile;

        public static void GetHashList(UpdateProgressCallback callback, bool forceUpdate = false)
        {
            Thread t = new Thread(() =>
            {
                LocalHashFile = Path.GetTempFileName();
                using (WebClient hashFileDL = new WebClient())
                {
                    hashFileDL.DownloadProgressChanged += (sender, e) =>
                    {
                        callback(e.ProgressPercentage, "Getting Hashlist...");
                    };

                    hashFileDL.DownloadFile(Settings.HashlistURL, LocalHashFile);

                    if (Properties.Settings.Default.Hashlist == MD5Lib.GetHash(LocalHashFile) && !forceUpdate)
                    {
                        // Hashlist hasnt changed
                        callback(100, "Your client is up-to-date", true);
                        return;
                    }
                }

                CheckFiles(callback);
            });
            t.Start();
        }

        public static void CheckFiles(UpdateProgressCallback callback)
        {
            string line = null;
            string[] file;

            int lineCount = 0;
            int totalLines = TotalLines(LocalHashFile);
            int existingCount = 0;

            using (StreamReader hashReader = new StreamReader(LocalHashFile))
            {
                while ((line = hashReader.ReadLine()) != null)
                {
                    lineCount++;
                    file = line.Split(new char[] { ':' });

                    if (file.Length != 2)
                        throw new FormatException("Hashlist got wrong format!");

                    callback((int)((float)((float)lineCount / (float)totalLines) * 100), "Checking files...");

                    if (!File.Exists(file[0]))
                    {
                        DownloadManager.Add(file[0]);
                    }
                    else
                    {
                        existingCount++;

                        if (MD5Lib.GetHash(file[0]) != file[1])
                            DownloadManager.Add(file[0]);
                    }
                }
            }

            string Hashlist = MD5Lib.GetHash(LocalHashFile);

            DeleteLocalHashfile();

            if (existingCount == 0)
            {
                string Message = String.Format("Would you like to install Cosmic Ascension to \"{0}\"?\nIf not, move this file to your preferred folder and start it again!", Application.StartupPath);

                if (MessageBox.Show(Message, "Install", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    callback(100, "Cancelled Installation");
                    return;
                }
            }

            DownloadManager.StartDownload(callback, Hashlist);
        }

        static int TotalLines(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                int i = 0;
                while (r.ReadLine() != null) { i++; }
                return i;
            }
        }

        private static void DeleteLocalHashfile()
        {
            if (!String.IsNullOrEmpty(LocalHashFile) && File.Exists(LocalHashFile))
                File.Delete(LocalHashFile);
        }
    }
}
