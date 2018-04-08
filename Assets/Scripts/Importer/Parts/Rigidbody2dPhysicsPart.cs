using System;
using AssemblyCSharp.Assets.Scripts.PartValidation;
using Scripts.Importer.Parts;
using SimpleJSON;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Importer.Parts
{

    [Serializable]
    [CreateAssetMenu(menuName = "2dTools/Create Common Physics Part")]
    public class Rigidbody2dPhysicsPart : BasePart
    {

        public float AngularDrag;
        public float AngularVelocity;
        public RigidbodyType2D BodyType;
        public Vector2 CenterOfMass;
        public CollisionDetectionMode2D CollisionDetectionMode = CollisionDetectionMode2D.Discrete;
        public RigidbodyConstraints2D Constraints = RigidbodyConstraints2D.FreezeRotation;

        public float Drag;
        public bool FixedAngle;
        public bool FreezeRotation;
        public float GravityScale;
        public float Inertia;
        public RigidbodyInterpolation2D Interpolation;
        public bool IsKinematic;
        public float Mass;
        public Vector2 Position;
        public float Rotation;
        public PhysicsMaterial2D SharedMaterial;
        public bool Simulated;
        public RigidbodySleepMode2D SleepMode;
        public bool UseAutoMass;
        public bool UseFullKinematicContacts;
        public Vector2 Velocity;


        public float VelocityThreshold;


        public override BasePart CreateInstance()
        {
            throw new NotImplementedException();
        }

        public override void Load(JSONNode json)
        {
            AngularDrag = json["AngularDrag"].AsFloat;
            AngularVelocity = json["AngularVelocity"].AsFloat;
            BodyType = (RigidbodyType2D)json["BodyType"].AsInt;
            CenterOfMass = (Vector2)json["CenterOfMass"].AsObject;
            CollisionDetectionMode = (CollisionDetectionMode2D)json["CollisionDetectionMode"].AsInt;
            FreezeRotation = json["FreezeRotation"].AsBool;
            Drag = json["Drag"].AsFloat;
            FixedAngle = json["FixedAngle"].AsBool;
            FreezeRotation = json["FreezeRotation"].AsBool;
            GravityScale = json["GravityScale"].AsFloat;
            Inertia = json["Inertia"].AsFloat;
            Interpolation = (RigidbodyInterpolation2D)json["Interpolation"].AsInt;
            IsKinematic = json["IsKinematic"].AsBool;
            Mass = json["Mass"].AsFloat;
            Position = (Vector2)json["Position"].AsObject;
            Rotation = json["Rotation"].AsFloat;

            Simulated = json["Simulated"].AsBool;
            SleepMode = (RigidbodySleepMode2D)json["SleepMode"].AsInt;
            UseAutoMass = json["UseAutoMass"].AsBool;
            UseFullKinematicContacts = json["UseFullKinematicContacts"].AsBool;
            Velocity = (Vector2)json["Velocity"].AsObject;
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
