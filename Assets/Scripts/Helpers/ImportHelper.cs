using UnityEngine;
using System.Collections;
using System.IO;

namespace Helpers
{
    public static class ImportHelper
    {
        public static T ImportFromJson<T>(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                var rawJson = reader.ReadToEnd();
                return JsonUtility.FromJson<T>(rawJson);
            }
        }
    }
}