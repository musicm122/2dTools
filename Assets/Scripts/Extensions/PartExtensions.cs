using UnityEngine;
using System.Collections;
using Scripts.Importer;
using System.IO;
using Helpers;
using Constants;

public static class PartExtensions
{
    public static T ImportFromJson<T>(this IExportable part, string filePath) where T : IExportable
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            var rawJson = reader.ReadToEnd();
            return JsonUtility.FromJson<T>(rawJson);
        }
    }

    public static bool ExportToJson<T>(this T part, string filePath) where T : IExportable
    {
        var defaultExportPath = DefaultConfig.GeDefaulttExportDir();
        var result = ExportHelper.ExportToJson<T>(defaultExportPath, part.GetFileName(), part);
        if (!result.Item1)
        {
            Debug.LogError(result.Item2);
        }
        return result.Item1;
    }
}
