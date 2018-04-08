using System;
using UnityEngine;
using Scripts.Importer.Parts;
using UnityEngine.UI;
using System.IO;
using Helpers;
using System.Xml.Serialization;

namespace AssemblyCSharp.Assets.Scripts.UI.Navigation
{
    public class JumpMenu : MonoBehaviour, IPartMenu<JumpPart>
    {
        #region Inspector Fields

        [SerializeField]
        Jumpable JumpableTarget;

        [SerializeField]
        FloatIncrementButton JumpForce;

        [SerializeField]
        IntIncrementButton MaxJumpCount;

        [SerializeField]
        FloatIncrementButton MaxAirTime;

        [SerializeField]
        public Button Import;

        [SerializeField]
        public Button Export;

        #endregion Inspector Fields

        private JumpPart jumpPart;

        public JumpPart Part
        {
            get { return jumpPart; }
        }

        void OnEnable()
        {
            jumpPart = this.JumpableTarget.jumpData;
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
            JumpForce.OnUpdate -= UpdateJumpForce;
            MaxJumpCount.OnUpdate -= UpdateMaxJumpCount;
            MaxAirTime.OnUpdate -= UpdateMaxAirTime;
            Export.onClick.RemoveAllListeners();
            Import.onClick.RemoveAllListeners();
        }

        void SetInitBindings()
        {
            jumpPart = this.JumpableTarget.jumpData;
            UpdateValues();
            AddClickListenersToButtons();
            AddValueChangedListenersToControls();
        }

        void UpdateValues()
        {
            this.JumpForce.Value = jumpPart.JumpForce;
            this.MaxJumpCount.Value = jumpPart.MaxJumpCount;
            this.MaxAirTime.Value = jumpPart.MaxJumpAirTime;
        }

        public void AddClickListenersToButtons()
        {

            Export.onClick.AddListener(this.ExportJson);
            Import.onClick.AddListener(this.ImportJson);
        }

        public void AddValueChangedListenersToControls()
        {
            JumpForce.OnUpdate += UpdateJumpForce;
            MaxJumpCount.OnUpdate += UpdateMaxJumpCount;
            MaxAirTime.OnUpdate += UpdateMaxAirTime;
        }

        public void UpdateJumpForce(float val) => jumpPart.JumpForce = val;
        public void UpdateMaxAirTime(float val) => jumpPart.MaxJumpAirTime = val;
        public void UpdateMaxJumpCount(int val) => jumpPart.MaxJumpCount = val;

    }
}
