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
        Canvas[] MenuPanels;

        [SerializeField]
        Canvas RunMenuCanvas;

        [SerializeField]
        Canvas JumpMenuCanvas;

        [SerializeField]
        Canvas DashMenuCanvas;

        [SerializeField]
        Canvas EnvironmentMenuCanvas;

        [SerializeField]
        NavigatorButton RunMenuNavigation;

        [SerializeField]
        NavigatorButton JumpMenuNavigation;

        [SerializeField]
        NavigatorButton DashMenuNavigation;

        [SerializeField]
        NavigatorButton EnvironmentMenuNavigation;

        private void Start()
        {
            //wire up events
            this.MenuPanels = PopulateCanvases();
            RunMenuNavigation.InitializeArguments(MenuPanels, RunMenuCanvas);
            JumpMenuNavigation.InitializeArguments(MenuPanels, JumpMenuCanvas);
            DashMenuNavigation.InitializeArguments(MenuPanels, DashMenuCanvas);
            EnvironmentMenuNavigation.InitializeArguments(MenuPanels, EnvironmentMenuCanvas);
            RunMenuNavigation.Select();
        }

        Canvas[] PopulateCanvases()
        {
            return new Canvas[]
            {
                RunMenuCanvas,
                JumpMenuCanvas,
                DashMenuCanvas,
                EnvironmentMenuCanvas
            };
        }
    }
}
