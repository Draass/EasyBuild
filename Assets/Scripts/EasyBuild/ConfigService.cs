using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace EasyBuild
{
    public static class ConfigDefinitions
    {
        public const string CONFIG_FILE_NAME = "config.json";
        public const string CONFIGH_FILE_PATH = "EasyBuildConfig";
    }
    
    public static class ConfigService
    {
        public static void WriteConfig(EasyBuildOptions option)
        {
            Debug.Log("Writing new config");
            
            var path = Application.persistentDataPath;
            var finalPath = Path.Combine(path, ConfigDefinitions.CONFIGH_FILE_PATH);
            Directory.CreateDirectory(finalPath);
            
            string configJson = JsonConvert.SerializeObject(option);
            
            File.WriteAllText(Path.Combine(finalPath, ConfigDefinitions.CONFIG_FILE_NAME), configJson);
        }

        public static EasyBuildOptions ReadConfig()
        {
            string configJson = File.ReadAllText(Application.streamingAssetsPath);

            var config = JsonConvert.DeserializeObject<EasyBuildOptions>(configJson);
            
            return config;
        }
    }
}
