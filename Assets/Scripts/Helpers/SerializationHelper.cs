using System;
using System.Collections.Generic;
using System.Linq;
using Scripts.Importer.Parts;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Helpers
{
    public static class SerializationHelper
    {
        public static List<string> GetRunPartSerializedFields()
        {
            var typeVal = typeof(RunPart);
            var serializeFields = typeVal.GetFields().Where(field => field.IsDefined(typeof(SerializeField), true));
            return serializeFields.Select(field => field.Name).ToList();
        }
    }
}
