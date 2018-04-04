using UnityEngine;
using System.Collections;
using System.IO;
using System;
using Scripts.Importer.Parts;
using AssemblyCSharp.Assets.Scripts.Importer.PartFactory;

namespace Constants
{
    public static class ApplicationConstants
    {
        public static readonly string ApplicationName = "2dTools";
    }

    public static class DefaultConfig
    {
        public static string GetPartDir(string fileName)
        {
            return Path.Combine(Environment.CurrentDirectory, "Assets/Json", fileName + ".json");
        }

        public static string GetDefaultExportDir()
        {
            return Path.Combine(Environment.CurrentDirectory, "Assets/Json");
        }
    }

    public static class DefaultGlobalPhysic2dValues
    {
        public static Vector2 Gravity = new Vector2(0f, -9.81f);
        //public float DefaultMaterial;
        public static float VelocityIterations = 8f;
        public static float PositionIterations = 3f;
        public static float VelocityThreshold = 1f;
        public static float MaxLinearCorrection = 0.2f;
        public static float MaxAngularCorrection = 8f;
        public static float MaxTranslationSpeed = 100f;
        public static float MaxRotationSpeed = 360f;
        public static float MinPenetration = 0.01f;
        public static float BaumgarteScale = 0.2f;
        public static float BaumgarteTimeofImpactScale = 0.75f;
        public static float TimetoSleep = 0.5f;
        public static float LinearSleepTolerance = 0.1f;
        public static float AngularSleepTolerance = 2f;
        public static bool QueriesHitTriggers = true;
        public static bool QueriesStartInColliders = true;
        public static bool ChangeStopsCallbacks = false;
    }

    public static class DefaultValues
    {
        public static readonly float Gravity = 9.8f;
        public static readonly float JumpForce = 1000.0f;
        public static readonly float MaxRunSpeed = 20.0f;
        public static readonly float MoveForce = 365f;
        public static readonly float MaxDashSpeed = 10.0f;
        public static string GroundLayer = "Ground";
        public static string JumpButtonName = "Jump";

        public static JumpPart GetDefaultJumpPart()
        {
            var part = PartFactory.CreatePart<JumpPart>();
            part.GravityScale = Gravity;
            part.JumpForce = JumpForce;
            part.GroundLayer = GroundLayer;
            part.JumpButtonName = JumpButtonName;
            return part;
        }

        public static RunPart GetDefaultRunPart()
        {
            var part = PartFactory.CreatePart<RunPart>();
            part.MaxSpeed = MaxRunSpeed;
            return part;
        }

        public static DashPart GetDefaultDashPart()
        {
            var part = PartFactory.CreatePart<DashPart>();
            part.MaxDashSpeed = MaxDashSpeed;
            return part;
        }
    }
}