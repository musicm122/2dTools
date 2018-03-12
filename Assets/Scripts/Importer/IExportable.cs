using System;
using UnityEngine;

namespace Scripts.Importer
{
    public interface IExportable
    {
        Tuple<bool, string> ExportToJson();
        Tuple<bool, string> ImportFromJson(string filePath);
    }
}