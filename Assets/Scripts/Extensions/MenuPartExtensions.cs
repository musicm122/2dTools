using UnityEngine;
using System.Collections;
using AssemblyCSharp.Assets.Scripts.UI.Navigation;
using System;
using Scripts.Importer.Parts;

public static class MenuPartExtensions
{
    public static void ImportJson<T>(this IPartMenu<T> partMenu) where T : BasePart
    {
        var result = UnityEditor.EditorUtility.OpenFilePanel("Json To Import", Constants.DefaultConfig.GetDefaultExportDir(), "json");
        if (!String.IsNullOrWhiteSpace(result))
        {
            partMenu.Part.ImportFromJson(result);
            UnityEditor.EditorUtility.DisplayDialog($"2d Tools Import Successful", $"File at {result} imported successfully.", "Okay");
        }
    }

    public static void ExportJson<T>(this IPartMenu<T> partMenu) where T : BasePart
    {
        var result = partMenu.Part.ExportToJson();
        if (result.Item1)
        {
            Debug.Log("Export Part successful");
        }
        else
        {
            Debug.LogError($"Export Pard failed : {result.Item2}");
        }
    }
}
