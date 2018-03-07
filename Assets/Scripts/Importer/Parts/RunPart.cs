using System;
using Scripts.Importer;
using UnityEngine;

[Serializable]
public struct RunPart : IExportable
{

    [SerializeField]
    public float Gravity;

    [SerializeField]
    public float MaxSpeed;


    ExportConfiguration IExportable.ExportConfig { get; set; }

    public string GetFileName() => "RunPart";
}