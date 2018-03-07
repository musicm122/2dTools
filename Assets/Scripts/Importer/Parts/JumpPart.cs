using UnityEngine;
using System.Collections;
using Scripts.Importer;
using System.IO;
using Helpers;

public struct JumpPart : IExportable
{
    public ExportConfiguration ExportConfig { get; set; }

    public float Gravity { get; set; }

    ExportConfiguration IExportable.ExportConfig { get; set; }

    public string GetFileName() => "JumpPart";

}
