using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Launcher.Updater
{
    class DownloadManager
    {
        private static List<string> m_DownloadFiles = new List<string>();

        public static void Add(string File)
        {
            if(m_DownloadFiles != null)
                m_DownloadFiles.Add(File);
        }

        public static int GetCount()
        {
            return m_DownloadFiles.Count;
        }

        public static void StartDownload(UpdateProgressCallback callback, string Hashlist)
        {
            int downloadCount = 0;
            string currentDir = "";

            bool downloadFinished = false;
            bool downloadFailed = false;

            using (WebClient downloadClient = new WebClient())
            {
                downloadClient.DownloadFileCompleted += (sender, e) =>
                {
                    if (e.Error != null)
                    {
                        downloadFailed = true;
                        return;
                    }

                    downloadFinished = true;
                };

                downloadClient.DownloadProgressChanged += (sender, e) =>
                {
                    callback(GetPercentage((float)downloadCount + ((float)GetPercentage(e.BytesReceived, e.TotalBytesToReceive) / 100.0f), m_DownloadFiles.Count)
                    , String.Format("Downloading Files {0} of {1} "
                    , downloadCount + 1
                    , m_DownloadFiles.Count)
                    );

                };

                foreach (string file in m_DownloadFiles)
                {
                    callback(GetPercentage(downloadCount, m_DownloadFiles.Count), String.Format("Downloading Files {0} of {1}", downloadCount + 1, m_DownloadFiles.Count));

                    currentDir = Path.GetDirectoryName(file);

                    if(!string.IsNullOrWhiteSpace(currentDir) && !Directory.Exists(currentDir))
                        Directory.CreateDirectory(currentDir);

                    try
                    {
                        downloadClient.DownloadFileAsync(new Uri(string.Format("{0}{1}", Settings.UpdateBaseURL, file.Replace("\\", "/"))), file);

                        while (!downloadFinished)
                        {
                            if (downloadFailed)
                            {
                                callback(100, String.Format("Failed to download: {0}", file));
                                return;
                            }
                            Thread.Sleep(1);
                        }

                        downloadCount++;
                        downloadFinished = false;
                    }
                    catch
                    {
                        callback(100, String.Format("Failed to download: {0}", file));
                        return;
                    }
                }
            }

            Properties.Settings.Default.Hashlist = Hashlist;
            Properties.Settings.Default.Save();

            callback(100, (m_DownloadFiles.Count != 0) ? "Finished Updating" : "Your client is up-to-date", true);

            m_DownloadFiles.Clear();
        }

        private static int GetPercentage(float val1, float val2)
        {
            return (int)((float)((val1 / val2) * 100.0f));
        }
    }
}
