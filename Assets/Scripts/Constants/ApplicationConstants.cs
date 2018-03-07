using UnityEngine;
using System.Collections;
using System.IO;
using System;

namespace Constants
{
    public static class ApplicationConstants
    {
        public static readonly string ApplicationName = "2dTools";
    }

    public static class DefaultConfig
    {


        public static string GetPartDir(string fileName)
        {
            return Path.Combine(Environment.CurrentDirectory, "Assets/Json", fileName + ".json");
        }

        public static string GeDefaulttExportDir()
        {
            return Path.Combine(Environment.CurrentDirectory, "Assets/Json");
        }
    }

}