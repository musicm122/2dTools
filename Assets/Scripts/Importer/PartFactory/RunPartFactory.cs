using System;
using Scripts.Importer.Parts;
using Helpers;
using SimpleJSON;

namespace AssemblyCSharp.Assets.Scripts.Importer.PartFactory
{
    public static class RunPartFactory
    {
        public static RunPart CreateRunPartInstance()
        {
            return PartFactory.CreatePart<RunPart>();
        }

        public static RunPart CreateRunPartWithGivenState(string filePath)
        {
            var json = ImportHelper.ImportFromJson(filePath);
            var part = CreateRunPartInstance();
            part = LoadPartWithJson(json, part);
            return part;
        }

        public static RunPart LoadPartWithJson(JSONNode json, RunPart part)
        {
            part.MaxSpeed = json["MaxSpeed"].AsFloat;
            part.Gravity = json["Gravity"].AsFloat;
            return part;
        }

        public static RunPart LoadNewPartWithOldPart(RunPart newPart, RunPart existingPart)
        {
            newPart.MaxSpeed = existingPart.MaxSpeed;
            newPart.Gravity = existingPart.Gravity;
            return newPart;
        }
    }
}
