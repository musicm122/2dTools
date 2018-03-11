using System;
using System.IO;
using UnityEngine;

namespace Scripts.Importer.Parts
{
    public abstract class BasePart : ScriptableObject, IExportable
    {
        public abstract BasePart CreateInstance(GameObject obj);

        [SerializeField]
        public float Gravity;

        [SerializeField]
        public ExportConfiguration ExportConfig;

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

        public Tuple<bool, string> ImportFromJson(string filePath)
        {
            throw new NotImplementedException();
        }
    }

}