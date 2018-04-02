using System;
using System.IO;
using Helpers;
using UnityEngine;
using System.Runtime.Serialization;
using SimpleJSON;
using AssemblyCSharp.Assets.Scripts.PartValidation;

namespace Scripts.Importer.Parts
{
    public abstract class BasePart : ScriptableObject, IExportable
    {
        public abstract BasePart CreateInstance();


        [Header("Amount of Applied Gravity Per Fixed Update", order = 9)]
        [SerializeField]
        public float Gravity;

        [Header("Json Export Configuration", order = 10)]
        [SerializeField]
        public ExportConfiguration ExportConfig;

        public Tuple<bool, string> ExportToJson()
        {

            var filePath = ExportConfig.GetRunPartExportPath();
            try
            {
                var json = JsonUtility.ToJson(this);
                File.WriteAllText(filePath, json);
                return Tuple.Create(true, $"File exported successfully :{filePath}");
            }
            catch (Exception ex)
            {
                return Tuple.Create(false, $"File failed to export : {filePath} : Error : {ex.Message}");
            }

        }

        public Tuple<bool, string> ImportFromJson(string filePath)
        {
            try
            {
                //Todo: add validation rules here
                var result = ImportHelper.ImportFromJson(filePath);
                this.Load(result);
                return new Tuple<bool, string>(true, String.Empty);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
                return new Tuple<bool, string>(false, ex.Message);
            }
        }

        public abstract void Reset();
        public abstract void Load(JSONNode json);
        public abstract RuleResultSummary Validate();
    }
}

