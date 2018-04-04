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
        InputField MaxRunSpeed;

        [SerializeField]
        Button IncrementSpeed;

        [SerializeField]
        Button DecrementSpeed;

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
            MaxRunSpeed.onValueChanged.AddListener((string val) => runPart.MaxSpeed = float.Parse(val));
            //HasForwardMomentum.onValueChanged.AddListener((bool val) => { runPart.HasForwardMomentum = val });
            //IsConstantSpeed.onValueChanged.AddListener((bool val) => { runPart.IsConstantSpeed = val });
            //HoldToRun.onValueChanged.AddListener((bool val) => { runPart.HoldToRun = val });
        }

        public void AddClickListenersToButtons()
        {
            //Apply.onClick.AddListener(ApplyChangesToPart);
            Export.onClick.AddListener(ExportJson);
            Import.onClick.AddListener(ImportJson);
            IncrementSpeed.onClick.AddListener(IncrementSpeedValue);
            DecrementSpeed.onClick.AddListener(DecrementSpeedValue);
        }

        void OnDestroy()
        {
            //Apply.onClick.RemoveAllListeners();
            Export.onClick.RemoveAllListeners();
            Import.onClick.RemoveAllListeners();
            MaxRunSpeed.onValueChanged.RemoveAllListeners();
            HasForwardMomentum.onValueChanged.RemoveAllListeners();
            IsConstantSpeed.onValueChanged.RemoveAllListeners();
        }

        public void UpdateValues()
        {
            MaxRunSpeed.text = runPart.MaxSpeed.ToString();
        }

        private void IncrementSpeedValue()
        {
            this.runPart.MaxSpeed += +1.0f;
        }

        private void DecrementSpeedValue()
        {
            this.runPart.MaxSpeed += -1.0f;
        }

        void OnEnable()
        {
            runPart = this.MovableTarget.RunData;
        }

        void Start()
        {
            runPart = this.MovableTarget.RunData;
            AddClickListenersToButtons();
            AddValueChangedListenersToControls();
        }

        private void FixedUpdate()
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

        void HasForwardMomentum_ValueChanged(bool value)
        {
            //update run part here
        }
    }
}
