using System;
using UnityEngine;

namespace Scripts.Importer
{
    public interface IExportable
    {
        string GetFileName();

        ExportConfiguration ExportConfig { get; set; }

    }
}