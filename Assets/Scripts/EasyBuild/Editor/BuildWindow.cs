using System;
using System.IO;
using Unity.Plastic.Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace EasyBuild.Editor
{
    public class BuildWindow : EditorWindow
    {
        private BuildTarget _target;
        private EasyBuildOptions _options;
        
        [MenuItem("EasyBuild/My Window")]
        public static void ShowBuildWindow()
        {
            EditorWindow.GetWindow(typeof(BuildWindow));
        }

        private void OnGUI()
        {
            // меню с основными опциями
            
            GUILayout.Label ("Base Settings", EditorStyles.boldLabel);

            //DrawTargetPlatformSelection();

            //DrawEasyBuildOptions();
            
            
            //в самом низу при нажатии на кнопку собираем данные о настройках и билдим
            if (GUILayout.Button("Build player"))
            {
                PlayerBuilder.BuildPlayer();

                ConfigService.WriteConfig(_options);
            }
        }

        private void DrawEasyBuildOptions()
        {
            EditorGUILayout.BeginVertical();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Name type");
                _options.NamingType = (NamingType)EditorGUILayout.EnumPopup(_options.NamingType);
                EditorGUILayout.EndHorizontal();
                
            
            EditorGUILayout.EndVertical();
        }

        private void DrawTargetPlatformSelection()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Target platform", EditorStyles.boldLabel);
            _target = (BuildTarget)EditorGUILayout.EnumPopup(_target);
            EditorGUILayout.EndHorizontal();
        }
    }
    
    /*
     * Итак, что должен включать в себя идеальный билдинг тул?
     * Опции:
     * выбор платформы
     * метод компиляции
     * какая компрессия
     * выбор папки
     * версионирование/автоинкрементирование названия билда?
     * Возможное допназвание билда
     * несколько билдов с уникальными настройками за раз
     */
    
}
