using UnityEngine;
using System.Collections;
using Scripts.Importer;
using System.IO;
using Helpers;
using Constants;
using System;

public static class PartExtensions
{
    /*
    public static Tuple<bool, string> ExportToJson<T>(this T part)
    {
        var filePath = part.ExportConfig.GetExportPath();
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
    */
}
