using UnityEngine;
using UnityEditor;
using Constants;
using System;
using Scripts.Importer.Parts;
using Scripts.Importer;

[CustomEditor(typeof(RunPart))]
[CanEditMultipleObjects]
public class PartEditorScript : Editor
{

    public override void OnInspectorGUI()
    {

        serializedObject.Update();

        var part = (RunPart)target;

        if (GUILayout.Button("Import"))
        {
            Import(part);
        }

        if (GUILayout.Button("Export"))
        {
            Export(part);
        }

        DrawDefaultInspector();
    }


    void Import(BasePart part)
    {
        try
        {
            var result = EditorUtility.OpenFilePanel("Json To Import", Constants.DefaultConfig.GetDefaultExportDir(), "json");
            if (!String.IsNullOrWhiteSpace(result))
            {
                part.ImportFromJson(result);
                EditorUtility.DisplayDialog($"2d Tools Import Successful", $"File at {result} imported successfully.", "Okay");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Import Threw Exception ");
            Debug.LogError(ex);
            throw;
        }

    }

    void Export(BasePart part)
    {
        var result = part.ExportToJson();
        var fileName = part.ExportConfig.RunPartFileName;
        var path = part.ExportConfig.GetRunPartExportPath();
        if (result.Item1)
        {
            var message = $"{fileName} Exported successfully to : {path}";
            Debug.Log(message);
            EditorUtility.DisplayDialog("2d Tools Success", message, "Okay");
        }
        else
        {
            var errorMessage = $"{fileName} Failed to Export to {part}";
            Debug.Log(errorMessage);
            Debug.LogError(result.Item2);
            EditorUtility.DisplayDialog("2d Tools Error", errorMessage, "Okay");
        }

    }
}

