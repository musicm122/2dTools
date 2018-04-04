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
    [CreateAssetMenu(menuName = "2dTools/Create JumpPart")]
    public class JumpPart : BasePart
    {
        [Header("Force Applied to Jump", order = 1)]
        [SerializeField]
        public float JumpForce;

        [SerializeField]
        public string GroundLayer = "Ground";

        [SerializeField]
        public string JumpButtonName = "Jump";

        [SerializeField]
        public float GravityScale = 1f;

        public override BasePart CreateInstance()
        {
            return CreateInstance<JumpPart>();
        }

        public override void Load(JSONNode json)
        {
            this.JumpForce = json["MaxDashSpeed"].AsFloat;
            this.GravityScale = json["Gravity"].AsFloat;
            this.GroundLayer = json["GroundLayer"].Value;
            this.JumpButtonName = json["JumpButtonName"].Value;
        }

        public override void Reset()
        {
            var defaultValues = DefaultValues.GetDefaultJumpPart();
            this.JumpForce = defaultValues.JumpForce;
            this.GravityScale = defaultValues.GravityScale;
            this.GroundLayer = defaultValues.GroundLayer;
            this.JumpButtonName = defaultValues.JumpButtonName;
        }

        public override RuleResultSummary Validate()
        {
            throw new NotImplementedException();
        }
    }
}