using System;
using UnityEngine;

namespace EasyBuild
{
    [Serializable]
    public class EasyBuildOptions
    {
        public NamingType NamingType = NamingType.Autoincrement;
        
        public VersionName LastVersionName = new VersionName()
        {
            VersionIndex = 0,
            SubVersionIndex = 0,
            PatchIndex = 0
        };
        
        public int lastAutoincrementName = 0;
    }

    public struct VersionName
    {
        public int VersionIndex;
        public int SubVersionIndex;
        public int PatchIndex;
    }
    
    public enum NamingType
    {
        /// <summary>
        /// Every time player built its name is incremented by 1
        /// </summary>
        Autoincrement,
        
        /// <summary>
        /// 
        /// </summary>
        Version,
        
        /// <summary>
        /// Defining custom build name each time
        /// TODO Check if same name already exists in target directory!
        /// </summary>
        Custom
    }

    public enum VersionUpdate
    {
        /// <summary>
        /// Increment main version name e.g. 2.x.x
        /// </summary>
        Major,
        
        /// <summary>
        /// Increment subversion e.g. x.3.x
        /// </summary>
        Minor,
        
        /// <summary>
        /// Increment patch version e.g. x.x.12
        /// </summary>
        Patch
    }
}
