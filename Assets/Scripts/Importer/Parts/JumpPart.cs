using UnityEngine;
using System.Collections;
using Scripts.Importer;
using System.IO;
using Helpers;

public struct JumpPart : IExportable
{

    [SerializeField]
    public float Gravity;

    ExportConfiguration IExportable.ExportConfig { get; set; }

    public string GetFileName() => "JumpPart";

}
