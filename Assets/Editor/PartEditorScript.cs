using UnityEngine;
using UnityEditor;
using Constants;

[CustomEditor(typeof(RunPart))]
public class PartEditorScript : Editor
{
    [MenuItem("Tools/2dTools/PartEditor")]
    static void DoIt()
    {
        EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RunPart part = (RunPart)target;
        if (GUILayout.Button("Export"))
        {
            var result = Helpers.ExportHelper.ExportToJson<RunPart>(Constants.DefaultConfig.GeDefaulttExportDir(), part.GetFileName(), part);
            if (result.Item1)
            {
                Debug.Log(part.GetFileName() + " Exported successfully to : " + Constants.DefaultConfig.GeDefaulttExportDir());
            }
            else
            {
                Debug.Log(part.GetFileName() + " Failed to Export to " + Constants.DefaultConfig.GeDefaulttExportDir());
                Debug.LogError(result.Item2);
            }
        }
        //myTarget.experience = EditorGUILayout.IntField("Experience", myTarget.experience);
        //EditorGUILayout.LabelField("Level", myTarget.Level.ToString());
    }

}
