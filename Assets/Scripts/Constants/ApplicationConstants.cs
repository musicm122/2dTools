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

    public static class DefaultValues
    {
        public static readonly float Gravity = 9.8f;
        public static readonly float JumpForce = 50.0f;
        public static readonly float MaxRunSpeed = 20.0f;
        public static readonly float MaxDashSpeed = 10.0f;

        public static JumpPart GetDefaultJumpPart()
        {
            var part = PartFactory.CreatePart<JumpPart>();
            part.Gravity = Gravity;
            part.JumpForce = JumpForce;
            return part;
        }

        public static RunPart GetDefaultRunPart()
        {
            var part = PartFactory.CreatePart<RunPart>();
            part.Gravity = Gravity;
            part.MaxSpeed = MaxRunSpeed;
            return part;
        }

        public static DashPart GetDefaultDashPart()
        {
            var part = PartFactory.CreatePart<DashPart>();
            part.Gravity = Gravity;
            part.MaxDashSpeed = MaxDashSpeed;
            return part;
        }
    }
}