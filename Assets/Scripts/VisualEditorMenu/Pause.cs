using System;
using Helpers;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.VisualEditorMenu
{
    public class Pause : MonoBehaviour
    {

        [SerializeField]
        private Canvas Menu;

        [SerializeField]
        private string PauseButtoName;


        private void Start()
        {
            Menu.enabled = false;
        }

        private void Update()
        {
            PauseCheck();
        }

        void PauseCheck()
        {
            if (Input.GetButtonDown(PauseButtoName))
            {
                TogglePauseMenu();
            }
        }

        void TogglePauseMenu()
        {
            Menu.enabled = !Menu.enabled;
            if (Menu.enabled)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}