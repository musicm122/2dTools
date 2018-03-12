using UnityEngine;
using System.Collections;
using Scripts.Importer;
using System.IO;
using Helpers;
using System;
using AssemblyCSharp.Assets.Scripts.PartValidation;
using SimpleJSON;

namespace Scripts.Importer.Parts
{
    [Serializable]
    [CreateAssetMenu(menuName = "Tools/2dTools/Create JumpPart")]
    public class JumpPart : BasePart
    {
        [SerializeField]
        public float JumpForce { get; set; }

        public override BasePart CreateInstance()
        {
            return CreateInstance<JumpPart>();
        }

        public override void Load(JSONNode json)
        {
            this.JumpForce = json["MaxDashSpeed"].AsFloat;
            this.Gravity = json["Gravity"].AsFloat;
        }

        public override RuleResultSummary Validate()
        {
            throw new NotImplementedException();
        }
    }
}