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
            Time.timeScale = 1.0f;
        }

        public void ResetWorld()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Reset World Initiated");
            Time.timeScale = 1.0f;
        }

        void OnEnable()
        {

        }

        private void Start()
        {
            ResetStageButton.onClick.AddListener(ResetWorld);
            ResetPlayerButton.onClick.AddListener(ResetPlayer);
        }

        private void OnDestroy()
        {
            ResetStageButton.onClick.RemoveListener(ResetWorld);
            ResetPlayerButton.onClick.RemoveListener(ResetPlayer);
        }
    }
}
