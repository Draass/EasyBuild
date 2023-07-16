using System.IO;
using UnityEditor;
using UnityEngine;

namespace EasyBuild
{
    public static class PlayerBuilder 
    {
        public static void BuildPlayer()
        {
            Debug.Log("Begin building player");
            ConfigService.WriteConfig(new EasyBuildOptions());
            //GetBuildPath(BuildTarget.Android);
            // GetBuildPath(BuildTarget.iOS);
            // BuildPipeline.BuildPlayer(new BuildPlayerOptions());
            
        }


        // TODO даже при нескольких платформах должно вызываться лишь единожды
        private static void GetBuildPath(BuildTarget buildTarget)
        {
            Debug.Log("Getting build path");
            //НЕСКОЛЬКО ВАРИАНТОВ
     
            //АВТОИНКРЕМЕНТ
            string desiredLocation = EditorUtility.OpenFolderPanel("Target build folder", "", "");
            //ВЕРСИЯ
            //ВАРИАНТ ВЕРСИИ: 1-version.1-subversion.1-path version
            //eg 2.4.14 - основная версия 2, сабверсия 4, патч 14

            string fileName = GetFileName();
            
            //озможно, нужно добавлять билд платформу? Учитывая, что мы можем билдить сразу несколько
            string finalPath = Path.Combine(desiredLocation, fileName, buildTarget.ToString());
            Debug.Log($"Final build path is {finalPath}");
            Directory.CreateDirectory(finalPath);
        }

        private static string GetFileName()
        {
            //читаем конфиг из памяти
            
            
            string file = "1.2.12";

            return file;
        }
    }
}
