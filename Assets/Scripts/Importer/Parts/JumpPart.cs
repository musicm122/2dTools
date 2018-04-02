using System.Collections;
using Scripts.Importer;
using System.IO;
using Helpers;
using System;
using UnityEngine;
using AssemblyCSharp.Assets.Scripts.PartValidation;
using SimpleJSON;
using Constants;

namespace Scripts.Importer.Parts
{
    [Serializable]
    [CreateAssetMenu(menuName = "Tools/2dTools/Create JumpPart")]
    public class JumpPart : BasePart
    {
        [Header("Force Applied to Jump", order = 1)]
        [SerializeField]
        public float JumpForce;

        public override BasePart CreateInstance()
        {
            return CreateInstance<JumpPart>();
        }

        public override void Load(JSONNode json)
        {
            this.JumpForce = json["MaxDashSpeed"].AsFloat;
            this.Gravity = json["Gravity"].AsFloat;
        }

        public override void Reset()
        {
            var defaultValues = DefaultValues.GetDefaultJumpPart();
            this.JumpForce = defaultValues.JumpForce;
            this.Gravity = defaultValues.Gravity;
        }

        public override RuleResultSummary Validate()
        {
            throw new NotImplementedException();
        }
    }
}