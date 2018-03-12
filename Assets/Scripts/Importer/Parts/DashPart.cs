using UnityEngine;
using System.Collections;
using Helpers;
using System.IO;
using System;
using AssemblyCSharp.Assets.Scripts.PartValidation;
using SimpleJSON;

namespace Scripts.Importer.Parts
{
    [Serializable]
    [CreateAssetMenu(menuName = "Tools/2dTools/Create DashPart")]
    public class DashPart : BasePart
    {
        [SerializeField]
        public float MaxDashSpeed;

        public override BasePart CreateInstance()
        {
            return CreateInstance<DashPart>();
        }

        public override void Load(JSONNode json)
        {
            this.MaxDashSpeed = json["MaxDashSpeed"].AsFloat;
            this.Gravity = json["Gravity"].AsFloat;
        }

        public override RuleResultSummary Validate()
        {
            throw new NotImplementedException();
        }
    }
}