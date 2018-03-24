using Scripts.Importer.Parts;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Importer.PartFactory
{
    public static class PartFactory
    {
        public static T CreatePart<T>() where T : BasePart
        {
            return ScriptableObject.CreateInstance<T>();
        }
    }
}
