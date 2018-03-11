using UnityEngine;
using UnityEditor;
using Constants;
using System;

[CustomEditor(typeof(RunPart))]
[CanEditMultipleObjects]
public class PartEditorScript : Editor
{
    SerializedProperty MaxSpeedProp;
    SerializedProperty GravityProp;
    SerializedProperty ExportConfigProp;
    SerializedProperty FileNameProp;


    void OnEnable()
    {
        GravityProp = serializedObject.FindProperty("Gravity");

        MaxSpeedProp = serializedObject.FindProperty("MaxSpeed");
        //FileNameProp = serializedObject.FindProperty("FileName");
        ExportConfigProp = serializedObject.FindProperty("ExportConfig");
    }

    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector();
        serializedObject.Update();

        var part = (RunPart)target;
        //EditorGUIUtility.LookLikeControls();

        //EditorGUILayout.FloatField("Gravity", GravityProp.floatValue);

        EditorGUILayout.BeginVertical();

        part.Gravity = EditorGUILayout.FloatField("Gravity", GravityProp.floatValue);
        part.MaxSpeed = EditorGUILayout.FloatField("MaxSpeed", MaxSpeedProp.floatValue);

        //target.myClass = EditorGUILayout.ObjectField("Label:", target.myClass, typeof(MyClass), true);

        part.ExportConfig = (ExportConfiguration)EditorGUILayout.ObjectField("Export Config", part.ExportConfig, typeof(ExportConfiguration), true);
        //var source = EditorGUILayout.ObjectField(source, typeof(Object), true);
        //part.ExportConfig = EditorGUILayout.ObjectField(ExportConfigProp);
        //EditorGUILayout.FloatField("Gravity", GravityProp.floatValue);
        //EditorGUILayout.FloatField("MaxSpeed", MaxSpeedProp.floatValue);
        //EditorGUILayout.ObjectField(ExportConfigProp);
        /*
        GUILayout.IntSlider(GravityProp, 0, 10, new GUIContent("Gravity"));
        EditorGUILayout.IntSlider(MaxSpeedProp, 0, 200, new GUIContent("MaxSpeed"));

        EditorGUILayout.TextField("FileName", FileNameProp.stringValue);
        EditorGUILayout.TextField("ExportConfig", ExportConfigProp.stringValue);
        */

        if (GUILayout.Button("Import"))
        {
            var result = EditorUtility.OpenFilePanel("Json To Import", Constants.DefaultConfig.GeDefaulttExportDir(), "json");
            EditorUtility.DisplayDialog("2d Tools Import Successful", result, "Okay");
            var temp = Helpers.ImportHelper.ImportFromJson<RunPart>(result);
            GravityProp.floatValue = temp.Gravity;
            MaxSpeedProp.floatValue = temp.MaxSpeed;
            Debug.Log("$ Gravity = {temp.Gravity.ToString()}; MaxSpeed = {temp.MaxSpeed.ToString()} ");
        }
        if (GUILayout.Button("Export"))
        {
            var result = part.ExportToJson();
            var fileName = part.ExportConfig.RunPartFileName;
            var path = part.ExportConfig.GetRunPartExportPath();
            if (result.Item1)
            {
                var message = $"{fileName} Exported successfully to : {path}";
                Debug.Log(message);
                //EditorUtility.DisplayDialog("2d Tools Error", "Missing ExportPath", "Okay");
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

        EditorGUILayout.EndVertical();
        EditorUtility.SetDirty(target);

        //myTarget.experience = EditorGUILayout.IntField("Experience", myTarget.experience);
        //EditorGUILayout.LabelField("Level", myTarget.Level.ToString());
    }

}

