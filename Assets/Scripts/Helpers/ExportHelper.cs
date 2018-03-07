using UnityEngine;
using System.Collections;
using System;
using System.IO;
using Scripts.Importer;

namespace Helpers
{
    public static class ExportHelper
    {
        public static Tuple<bool, string> ExportToJson<T>(string path, string fileName, T part) where T : IExportable
        {
            var filePath = path + "/" + fileName + ".json";
            try
            {
                var json = JsonUtility.ToJson(part);
                File.AppendAllText(filePath, json);
                return Tuple.Create(true, $"File exported successfully :{filePath}");
            }
            catch (Exception ex)
            {
                return Tuple.Create(false, $"File failed to export : {filePath} : Error : {ex.Message}");
            }
        }

    }
}