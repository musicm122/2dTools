using System;
using Scripts.Importer.Parts;
using UnityEngine;

namespace AssemblyCSharpEditor.Assets.Editor
{
    public class CommonFixture
    {
        public CommonFixture()
        {
        }

        public static JumpPart GetJumpPart()
        {
            return Constants.DefaultValues.GetDefaultJumpPart();
        }

        public static RunPart GetRunPart()
        {
            return Constants.DefaultValues.GetDefaultRunPart();
        }



    }
}
