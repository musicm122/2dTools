using System;
using Scripts.Importer.Parts;
using UnityEngine;
using Constants;

namespace AssemblyCSharp.Assets.Scripts
{
    public class GameState : MonoBehaviour
    {
        [SerializeField]
        private Movable Movable;

        [SerializeField]
        private Jumpable Jumpable;

        //private JumpPart JumpPart;
        //private RunPart RunPart;

        private void Start()
        {
            //JumpPart = JumpPart ?? DefaultValues.GetDefaultJumpPart();
            //RunPart = RunPart ?? DefaultValues.GetDefaultRunPart();
        }

        public void ResetPartState()
        {
            Movable.RunData = DefaultValues.GetDefaultRunPart();
            Jumpable.jumpData = DefaultValues.GetDefaultJumpPart();
            //JumpPart = DefaultValues.GetDefaultJumpPart();
            //RunPart = DefaultValues.GetDefaultRunPart();
        }


    }
}
