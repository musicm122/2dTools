using UnityEngine;
using System.Collections;
using Scripts.Importer;
using Helpers;
using System.IO;

public class DashPart : IExportable
{
    public float Gravity { get; set; }

    ExportConfiguration IExportable.ExportConfig { get; set; }

    public string GetFileName() => "DashPart";


}
