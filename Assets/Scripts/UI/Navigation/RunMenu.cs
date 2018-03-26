using System;
using UnityEngine;
using Scripts.Importer.Parts;
using UnityEngine.UI;
namespace AssemblyCSharp.Assets.Scripts.UI.Navigation
{
    public class RunMenu : MonoBehaviour
    {
        [SerializeField]
        Movable MovableTarget;

        [SerializeField]
        Button Import;

        [SerializeField]
        Button Export;

        [SerializeField]
        Button Apply;

        [SerializeField]
        InputField MaxRunSpeed;

        [SerializeField]
        Toggle IsConstantSpeed;

        [SerializeField]
        Toggle HoldToRun;

        [SerializeField]
        Toggle HasForwardMomentum;


        RunPart runPart;

        void AddValueChangedListenersToControls()
        {
            MaxRunSpeed.onValueChanged.AddListener((string val) => runPart.MaxSpeed = float.Parse(val));
            //HasForwardMomentum.onValueChanged.AddListener((bool val) => { runPart.HasForwardMomentum = val });
            //IsConstantSpeed.onValueChanged.AddListener((bool val) => { runPart.IsConstantSpeed = val });
            //HoldToRun.onValueChanged.AddListener((bool val) => { runPart.HoldToRun = val });
        }

        void AddClickListenersToButtons()
        {
            Apply.onClick.AddListener(ApplyChangesToPart);
            Export.onClick.AddListener(ExportJson);
            Import.onClick.AddListener(ImportJson);
        }

        private void OnDestroy()
        {
            Apply.onClick.RemoveAllListeners();
            Export.onClick.RemoveAllListeners();
            Import.onClick.RemoveAllListeners();
            MaxRunSpeed.onValueChanged.RemoveAllListeners();
            HasForwardMomentum.onValueChanged.RemoveAllListeners();
            IsConstantSpeed.onValueChanged.RemoveAllListeners();
        }

        void SetDefaultValues()
        {
            MaxRunSpeed.text = runPart.MaxSpeed.ToString();

        }

        private void Start()
        {
            runPart = this.MovableTarget.RunData;
            AddClickListenersToButtons();
            AddValueChangedListenersToControls();
            SetDefaultValues();
        }

        void ApplyChangesToPart()
        {

        }


        void ImportJson()
        {
        }

        void ExportJson()
        {
        }


        void HasForwardMomentum_ValueChanged(bool value)
        {
            //update run part here
        }

    }
}
