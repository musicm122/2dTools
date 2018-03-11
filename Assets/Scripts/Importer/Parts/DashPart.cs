using UnityEngine;
using System.Collections;
using Scripts.Importer;
using Helpers;
using System.IO;
using System;

[Serializable]
[CreateAssetMenu(menuName = "Tools/2dTools/Create DashPart")]
public class DashPart : ScriptableObject
{
    [SerializeField]
    public float MaxSpeed;

    [SerializeField]
    public float Gravity;

    public ExportConfiguration ExportConfig;


    public void Initialize(GameObject obj)
    {
        ScriptableObject asset = ScriptableObject.CreateInstance<DashPart>();
    }

    public Tuple<bool, string> ExportToJson()
    {
        var filePath = ExportConfig.GetDashPartExportPath();
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
