using System;
using UnityEngine;
using Scripts.Importer.Parts;
using UnityEngine.UI;
using System.IO;
using Helpers;
using System.Xml.Serialization;

namespace AssemblyCSharp.Assets.Scripts.UI.Navigation
{
    public class RunMenu : MonoBehaviour, IPartMenu<RunPart>
    {
        #region Inspector Fields
        [SerializeField]
        Movable MovableTarget;

        [SerializeField]
        FloatIncrementButton MaxRunSpeed;

        [SerializeField]
        FloatIncrementButton MoveForce;

        [SerializeField]
        Toggle IsConstantSpeed;

        [SerializeField]
        Toggle HoldToRun;

        [SerializeField]
        Toggle HasForwardMomentum;

        [SerializeField]
        public Button Import;

        [SerializeField]
        public Button Export;

        #endregion Inspector Fields

        private RunPart runPart;

        public RunPart Part
        {
            get
            {
                return runPart;
            }
        }

        void OnEnable()
        {
            runPart = this.MovableTarget.RunData;
            SetInitBindings();
            UpdateValues();
        }

        void Start()
        {
            SetInitBindings();
            UpdateValues();
        }

        void OnDestroy()
        {
            MaxRunSpeed.OnUpdate -= UpdateMaxSpeed;
            MoveForce.OnUpdate -= UpdateMoveForce;
            Export.onClick.RemoveAllListeners();
            Import.onClick.RemoveAllListeners();
            HasForwardMomentum.onValueChanged.RemoveAllListeners();
            IsConstantSpeed.onValueChanged.RemoveAllListeners();
        }

        void SetInitBindings()
        {
            runPart = this.MovableTarget.RunData;
            AddClickListenersToButtons();
            AddValueChangedListenersToControls();
        }

        void UpdateValues()
        {
            MaxRunSpeed.Value = runPart.MaxSpeed;
            MoveForce.Value = runPart.MoveForce;
        }

        public void AddValueChangedListenersToControls()
        {
            MaxRunSpeed.OnUpdate += UpdateMaxSpeed;
            MoveForce.OnUpdate += UpdateMoveForce;
            HasForwardMomentum.onValueChanged.AddListener(UpdateHasMomentum);
        }

        public void AddClickListenersToButtons()
        {
            Export.onClick.AddListener(this.ExportJson);
            Import.onClick.AddListener(this.ImportJson);
        }

        public void UpdateMaxSpeed(float val) => this.runPart.MaxSpeed = val;
        public void UpdateMoveForce(float val) => this.runPart.MoveForce = val;
        public void UpdateHasMomentum(bool val) => runPart.HasMomentum = val;

    }
}
