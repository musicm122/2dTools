using System;
using System.IO;
using Scripts.Importer;
using UnityEngine;
using Helpers;
using AssemblyCSharp.Assets.Scripts.Helpers;
using SimpleJSON;
using AssemblyCSharp.Assets.Scripts.PartValidation;
using AssemblyCSharp.Assets.Scripts.Importer.PartFactory;
using Constants;

namespace Scripts.Importer.Parts
{

    [Serializable]
    [CreateAssetMenu(menuName = "Tools/2dTools/Create RunPart")]
    public class RunPart : BasePart
    {
        [Header("Max Run Speed", order = 0)]
        [SerializeField]
        public float MaxSpeed;

        public override BasePart CreateInstance()
        {
            var part = RunPartFactory.CreateRunPartInstance();
            part.MaxSpeed = this.MaxSpeed;
            part.Gravity = this.Gravity;
            return part;
        }

        public override void Load(JSONNode json)
        {
            this.MaxSpeed = json["MaxSpeed"].AsFloat;
            this.Gravity = json["Gravity"].AsFloat;
        }

        public override void Reset()
        {
            var defaultValues = DefaultValues.GetDefaultRunPart();
            this.MaxSpeed = defaultValues.MaxSpeed;
            this.Gravity = defaultValues.Gravity;

        }

        public override RuleResultSummary Validate()
        {
            throw new NotImplementedException();
        }
    }
}