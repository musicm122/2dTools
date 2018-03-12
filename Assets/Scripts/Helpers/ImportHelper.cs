using UnityEngine;
using System.Collections;
using System.IO;
using SimpleJSON;
using Scripts.Importer.Parts;

namespace Helpers
{
    public static class ImportHelper
    {
        public static JSONNode ImportFromJson(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                var rawJson = reader.ReadToEnd();
                return JSON.Parse(rawJson);
            }
        }
    }
}