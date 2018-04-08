using System;
using AssemblyCSharp.Assets.Scripts.PartValidation;
using Scripts.Importer.Parts;
using SimpleJSON;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Importer.Parts
{
    [Serializable]
    [CreateAssetMenu(menuName = "2dTools/Create Global Physics Part")]
    public class GlobalPhysicsDefaults : BasePart
    {
        public Vector2 Gravity = new Vector2(0f, -9.81f);
        //public float DefaultMaterial;
        public float VelocityIterations = 8f;
        public float PositionIterations = 3f;
        public float VelocityThreshold = 1f;
        public float MaxLinearCorrection = 0.2f;
        public float MaxAngularCorrection = 8f;
        public float MaxTranslationSpeed = 100f;
        public float MaxRotationSpeed = 360f;
        public float MinPenetration = 0.01f;
        public float BaumgarteScale = 0.2f;
        public float BaumgarteTimeofImpactScale = 0.75f;
        public float TimetoSleep = 0.5f;
        public float LinearSleepTolerance = 0.1f;
        public float AngularSleepTolerance = 2f;
        public bool QueriesHitTriggers = true;
        public bool QueriesStartInColliders = true;
        public bool ChangeStopsCallbacks = false;

        public override BasePart CreateInstance()
        {
            throw new NotImplementedException();
        }

        public override void Load(JSONNode json)
        {
            throw new NotImplementedException();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }

        public override RuleResultSummary Validate()
        {
            throw new NotImplementedException();
        }
    }
}
