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

        public void ResetPlayer()
        {
            throw new NotImplementedException();
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
        }

        private void OnDestroy()
        {
            ResetStageButton.onClick.RemoveListener(ResetWorld);
        }
    }
}
