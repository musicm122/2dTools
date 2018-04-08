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
    [CreateAssetMenu(menuName = "2dTools/Create RunPart")]
    public class RunPart : BasePart
    {
        [Header("Max Run Speed", order = 0)]
        [SerializeField]
        public float MaxSpeed;

        [Header("Max Run Speed", order = 1)]
        [SerializeField]
        public float MoveForce;

        [Header("Has Momentum", order = 2)]
        [SerializeField]
        public bool HasMomentum;

        public override BasePart CreateInstance()
        {
            var part = RunPartFactory.CreateRunPartInstance();
            part.MaxSpeed = this.MaxSpeed;
            part.MoveForce = this.MoveForce;
            part.HasMomentum = this.HasMomentum;
            return part;
        }

        public override void Load(JSONNode json)
        {
            this.MaxSpeed = json["MaxSpeed"].AsFloat;
            this.MoveForce = json["MoveForce"].AsFloat;
            this.HasMomentum = json["HasMomentum"].AsBool;
        }

        public override void Reset()
        {
            var defaultValues = DefaultValues.GetDefaultRunPart();
            this.MaxSpeed = defaultValues.MaxSpeed;
            this.MoveForce = defaultValues.MoveForce;
            this.HasMomentum = false;
        }

        public override RuleResultSummary Validate()
        {
            throw new NotImplementedException();
        }
    }
}