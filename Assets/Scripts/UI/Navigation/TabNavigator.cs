using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;

namespace AssemblyCSharp.Assets.Scripts.UI
{
    public class TabNavigator : MonoBehaviour
    {
        [SerializeField]
        Canvas[] MenuPanels;

        [SerializeField]
        NavigatorButton RunMenuNavigation;

        [SerializeField]
        Canvas RunMenuCanvas;

        [SerializeField]
        NavigatorButton JumpMenuNavigation;

        [SerializeField]
        Canvas JumpMenuCanvas;

        [SerializeField]
        Button DashMenuNavigation;

        [SerializeField]
        NavigatorButton EnvironmentMenuNavigation;

        private void Start()
        {
            //wire up events
            //var runMenu = MenuPanels.FirstOrDefault(canvas => canvas.name == "RunMenuCanvas");
            RunMenuNavigation.InitializeArguments(MenuPanels, RunMenuCanvas);
            JumpMenuNavigation.InitializeArguments(MenuPanels, JumpMenuCanvas);
        }

        void SetEnabledRunPanelTab(BaseEventData data) { }
    }
}
