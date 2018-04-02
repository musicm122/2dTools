using System;
using Helpers;
using UnityEngine;
using System.Linq;
using AssemblyCSharp.Assets.Scripts.Extensions;

namespace AssemblyCSharp.Assets.Scripts.VisualEditorMenu
{

    public class PauseEventArgs : EventArgs
    {
        public bool IsPaused { get; set; }
        public PauseEventArgs(bool isPaused)
        {
            IsPaused = isPaused;
        }
    }

    public interface IHandlePause
    {
        void OnPause(PauseEventArgs eventArgs);
        void OnUnpause(PauseEventArgs eventArgs);
    }


    public class Pause : MonoBehaviour
    {

        [SerializeField]
        GameState GameState;

        //[SerializeField]
        //private Canvas Menu;

        [SerializeField]
        private string PauseButtonName;


        private void Start()
        {
            GameState.IsPaused = false;
            GameState.RaisePauseStateChanged += HandlePauseStateChange;
        }

        private void OnDestroy()
        {
            GameState.RaisePauseStateChanged -= HandlePauseStateChange;
        }

        private void Update()
        {
            PauseCheck();
        }

        void PauseCheck()
        {
            if (Input.GetButtonDown(PauseButtonName))
            {
                GameState.TogglePause();
            }
        }

        public void HandlePauseStateChange(object sender, PauseEventArgs e)
        {
            Time.timeScale = (e.IsPaused) ? 0 : 1;
        }
    }
}