using System;
using Helpers;
using UnityEngine;
using System.Linq;
using AssemblyCSharp.Assets.Scripts.Extensions;

namespace AssemblyCSharp.Assets.Scripts.VisualEditorMenu
{
    public class Pause : MonoBehaviour
    {

        [SerializeField]
        private Canvas Menu;

        [SerializeField]
        private string PauseButtonName;


        private void Start()
        {
            Menu.enabled = false;
            Menu.SetEnabledStateOnSelectable(false);
        }

        private void Update()
        {
            PauseCheck();
        }

        void PauseCheck()
        {
            if (Input.GetButtonDown(PauseButtonName))
            {
                TogglePauseMenu();
            }
        }

        void TogglePauseMenu()
        {
            Menu.enabled = !Menu.enabled;
            Menu.SetEnabledStateOnSelectable(Menu.enabled);

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