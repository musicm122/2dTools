using UnityEngine;
using UnityEditor;

public class MovementObject : ScriptableObject
{
    [MenuItem("Tools/MyTool/Do It in C#")]
    static void DoIt()
    {
        EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
    }

    public float MovementSpeed;
}
