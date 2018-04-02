using System;
using AssemblyCSharp.Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AssemblyCSharp.Assets.Scripts.VisualEditorMenu
{
    public class PlayerMenu : MonoBehaviour, IWorldInteract
    {

        [SerializeField]
        Button ResetStageButton;

        [SerializeField]
        Button ResetPlayerButton;

        [SerializeField]
        private Canvas Menu;

        [SerializeField]
        private GameState GameState;

        public void ResetPlayer()
        {
            GameState.ResetPartState();
            Debug.Log("Reset Player Initiated");
            GameState.SetPauseState(false);
            Time.timeScale = 1.0f;
        }

        public void ResetWorld()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Reset World Initiated");
            GameState.SetPauseState(false);
            Time.timeScale = 1.0f;
        }


        private void Start()
        {
            ResetStageButton.onClick.AddListener(ResetWorld);
            ResetPlayerButton.onClick.AddListener(ResetPlayer);
            GameState.SetPauseState(false);
        }

        private void OnDestroy()
        {
            ResetStageButton.onClick.RemoveListener(ResetWorld);
            ResetPlayerButton.onClick.RemoveListener(ResetPlayer);
        }
    }
}
