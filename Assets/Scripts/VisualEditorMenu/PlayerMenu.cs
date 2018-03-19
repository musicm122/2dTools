using System;
using AssemblyCSharp.Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using AssemblyCSharp.Assets.Scripts.Command;
using UnityEngine.UI;
using UnityEngine.Events;

namespace AssemblyCSharp.Assets.Scripts.VisualEditorMenu
{
    public class PlayerMenu : MonoBehaviour, IWorldInteract
    {

        [SerializeField]
        private Canvas Menu;

        [SerializeField]
        private string PauseButtoName;

        //ResetStageEvent onResetStage;

        [SerializeField]
        Button ResetStageButton;

        [SerializeField]
        Button ResetPlayerButton;

        public PlayerMenu()
        {
        }

        public void ResetPlayer()
        {
            throw new NotImplementedException();
        }

        public void ResetWorld()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //onResetStage.Invoke();
            Debug.Log("Reset World Initiated");
        }

        void TogglePauseMenu()
        {
            Menu.enabled = !Menu.enabled;
        }

        void FixedUpdate()
        {
            if (Input.GetButton(PauseButtoName))
            {
                TogglePauseMenu();
            }
        }

        private void Start()
        {
            Menu.enabled = false;

            ResetStageButton.onClick.AddListener(ResetWorld);

        }
        private void OnDestroy()
        {
            ResetStageButton.onClick.RemoveListener(ResetWorld);
        }


    }
}
