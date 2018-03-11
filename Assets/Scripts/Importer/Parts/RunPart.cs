using System;
using System.IO;
using Scripts.Importer;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Tools/2dTools/Create RunPart")]
public class RunPart : ScriptableObject
{
    [SerializeField]
    public float MaxSpeed;

    [SerializeField]
    public float Gravity;

    [SerializeField]
    public ExportConfiguration ExportConfig;

    public void Initialize(GameObject obj)
    {
        ScriptableObject asset = ScriptableObject.CreateInstance<RunPart>();
    }

    public Tuple<bool, string> ExportToJson()
    {
        var filePath = ExportConfig.GetRunPartExportPath();
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

