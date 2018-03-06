using UnityEngine;
using System;

namespace Scripts.Importer
{
    [Serializable]
    public class BasePart
    {

        public string FileName { set; get; }

        [NonSerialized]
        protected ExportConfiguration ExportConfig;

        [SerializeField]
        public float Gravity;

    }
}