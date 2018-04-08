using System;
using UnityEngine;
using Scripts.Importer.Parts;
using UnityEngine.UI;
using System.IO;
using Helpers;
using System.Xml.Serialization;

namespace AssemblyCSharp.Assets.Scripts.UI.Navigation
{
    public class RunMenu : MonoBehaviour, IPartMenu
    {
        #region Inspector Fields
        [SerializeField]
        Movable MovableTarget;

        [SerializeField]
        public Button Import;

        [SerializeField]
        public Button Export;

        [SerializeField]
        Button Apply;

        [SerializeField]
        IncrementButton MaxRunSpeed;

        [SerializeField]
        IncrementButton MoveForce;

        /*
        [SerializeField]
        InputField MaxRunSpeed;

        [SerializeField]
        Button IncrementSpeed;

        [SerializeField]
        Button DecrementSpeed;
        */

        [SerializeField]
        Toggle IsConstantSpeed;

        [SerializeField]
        Toggle HoldToRun;

        [SerializeField]
        Toggle HasForwardMomentum;

        #endregion Inspector Fields

        RunPart runPart;

        public void AddValueChangedListenersToControls()
        {
            MaxRunSpeed.OnUpdate += UpdateMaxSpeed;
            MoveForce.OnUpdate += UpdateMoveForce;
            HasForwardMomentum.onValueChanged.AddListener(UpdateHasMomentum);
        }

        public void AddClickListenersToButtons()
        {
            Export.onClick.AddListener(ExportJson);
            Import.onClick.AddListener(ImportJson);
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


        void OnEnable()
        {
            runPart = this.MovableTarget.RunData;
        }

        void Start()
        {
            runPart = this.MovableTarget.RunData;
            MaxRunSpeed.Value = runPart.MaxSpeed;
            MoveForce.Value = runPart.MoveForce;
            AddClickListenersToButtons();
            AddValueChangedListenersToControls();
        }

        void FixedUpdate()
        {
            UpdateValues();
        }

        public void ImportJson()
        {
            var result = UnityEditor.EditorUtility.OpenFilePanel("Json To Import", Constants.DefaultConfig.GetDefaultExportDir(), "json");
            if (!String.IsNullOrWhiteSpace(result))
            {
                runPart.ImportFromJson(result);
                UnityEditor.EditorUtility.DisplayDialog($"2d Tools Import Successful", $"File at {result} imported successfully.", "Okay");
            }
        }

        public void ExportJson()
        {
            var result = this.runPart.ExportToJson();
            if (result.Item1)
            {
                Debug.Log("Export RunPart successful");
            }
            else
            {
                Debug.LogError($"Export RunPard failed : {result.Item2}");
            }
        }

        public void UpdateValues()
        {
        }

        public void UpdateMaxSpeed(float val) => this.runPart.MaxSpeed = val;
        public void UpdateMoveForce(float val) => this.runPart.MoveForce = val;
        public void UpdateHasMomentum(bool val) => runPart.HasMomentum = val;

    }
}
