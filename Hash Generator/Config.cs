using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Hash_Generator
{
    [DataContract]
    class Config
    {
        [DataMember]
        public string ClientPath;
        [DataMember]
        public string RootPath;
        [DataMember]
        public string HashFile;

        public static Config Load(string sFile)
        {
            Log.Write(String.Format("Using config file: {0}", sFile));

            if (!File.Exists(sFile))
            {
                Log.Error("No config file found!");
                return null;
            }

            try
            {
                using (FileStream file = new FileStream(sFile, FileMode.Open))
                {
                    DataContractJsonSerializer JsonSerializer = new DataContractJsonSerializer(typeof(Config));
                    return JsonSerializer.ReadObject(file) as Config;
                }
            }
            catch (Exception ex)
            {
                Log.Error(String.Format("Could not load config: {0}", ex.Message));
                return null;
            }
        }
    }

}
