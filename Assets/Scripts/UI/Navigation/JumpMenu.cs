using System;
using UnityEngine;
using Scripts.Importer.Parts;
using UnityEngine.UI;
using System.IO;
using Helpers;
using System.Xml.Serialization;

namespace AssemblyCSharp.Assets.Scripts.UI.Navigation
{
    public class JumpMenu : MonoBehaviour, IPartMenu
    {

        [SerializeField]
        Jumpable JumpableTarget;

        [SerializeField]
        public Button Import;

        [SerializeField]
        public Button Export;

        public void AddClickListenersToButtons()
        {
            throw new NotImplementedException();
        }

        public void AddValueChangedListenersToControls()
        {
            throw new NotImplementedException();
        }

        public void ExportJson()
        {
            throw new NotImplementedException();
        }

        public void ImportJson()
        {
            throw new NotImplementedException();
        }

        public void UpdateValues()
        {
            throw new NotImplementedException();
        }
    }
}
