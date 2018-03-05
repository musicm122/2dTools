using UnityEngine;
using System;

namespace Scripts.Importer
{
    [Serializable]
    public abstract class BasePart
    {

        public string FileName { private set; get; }

        [NonSerialized]
        protected ExportConfiguration ExportConfig;

        [SerializeField]
        public float Gravity;

        public abstract void ExportToJson();

        public abstract void ImportFromJson(string filePath);

    }
}