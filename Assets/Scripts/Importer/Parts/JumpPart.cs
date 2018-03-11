using UnityEngine;
using System.Collections;
using Scripts.Importer;
using System.IO;
using Helpers;
using System;

[Serializable]
[CreateAssetMenu(menuName = "Tools/2dTools/Create JumpPart")]
public class JumpPart : ScriptableObject
{
    [SerializeField]
    public float Gravity { get; set; }

    public ExportConfiguration ExportConfig { get; set; }

    public void Initialize(GameObject obj)
    {
        ScriptableObject asset = ScriptableObject.CreateInstance<JumpPart>();
    }

    public Tuple<bool, string> ExportToJson()
    {
        var filePath = ExportConfig.GetJumpPartExportPath();
        try
        {
            var json = JsonUtility.ToJson(this);
            File.AppendAllText(filePath, json);
            return Tuple.Create(true, $"File exported successfully :{filePath}");
        }
        catch (Exception ex)
        {
            return Tuple.Create(false, $"File failed to export : {filePath} : Error : {ex.Message}");
        }
    }
}
