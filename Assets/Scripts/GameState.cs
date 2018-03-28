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

        private void Start()
        {
        }

        public void ResetPartState()
        {
            Movable.RunData.Reset();
            Jumpable.jumpData.Reset();
        }
    }
}
