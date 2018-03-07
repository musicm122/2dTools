using UnityEngine;
using System.Collections;
using Scripts.Importer;
using Helpers;
using System.IO;

public class DashPart : IExportable
{

    [SerializeField]
    public float Gravity;

    ExportConfiguration IExportable.ExportConfig { get; set; }

    public string GetFileName() => "DashPart";

}
