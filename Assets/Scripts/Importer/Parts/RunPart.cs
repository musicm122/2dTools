using UnityEngine;
using Scripts.Importer;
using System.IO;
using Helpers;
using System;

[Serializable]
public class RunPart : BasePart
{
    public RunPart()
    {
        FileName = "RunPart";
    }
    public bool IsConstant;

    public float MaxSpeed;

    public void ExportToJson()
    {
        ExportHelper.ExportToJson<RunPart>(this.ExportConfig.ExportPath, FileName, this);
    }

    public void ImportFromJson(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            var rawJson = reader.ReadToEnd();
            RunPart importedRunPart = (RunPart)JsonUtility.FromJson<RunPart>(rawJson);

            this.MaxSpeed = importedRunPart.MaxSpeed;
            this.Gravity = importedRunPart.Gravity;

        }
    }

}
