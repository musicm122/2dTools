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
        string lastNavigatedElement;

        Canvas[] MenuPanels { get { return GetAllMenuCanvases(); } }

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


        private void OnEnable()
        {
            InitNavBindings();
            SetSelectionFromHistory();

            //Masks?
            //https://docs.unity3d.com/Manual/script-Mask.html
        }

        void onDisable()
        {

        }

        void InitRunTabMenuBindings()
        {
            RunMenuNavigation.InitializeArguments(MenuPanels, RunMenuCanvas);
            RunMenuNavigation.OnNavigateTo = UpdateSelection;
        }

        void InitJumpTabMenuBindings()
        {
            JumpMenuNavigation.InitializeArguments(MenuPanels, JumpMenuCanvas);
            JumpMenuNavigation.OnNavigateTo = UpdateSelection;

        }

        void InitDashTabMenuBindings()
        {
            DashMenuNavigation.InitializeArguments(MenuPanels, DashMenuCanvas);
            DashMenuNavigation.OnNavigateTo = UpdateSelection;
        }

        void InitEnvironmentTabMenuBindings()
        {
            EnvironmentMenuNavigation.InitializeArguments(MenuPanels, EnvironmentMenuCanvas);
            EnvironmentMenuNavigation.OnNavigateTo = UpdateSelection;
        }

        void InitNavBindings()
        {
            InitRunTabMenuBindings();
            InitJumpTabMenuBindings();
            InitDashTabMenuBindings();
            InitEnvironmentTabMenuBindings();
        }

        private void Start()
        {
            //wire up events
            InitNavBindings();
            SelectElement(RunMenuNavigation);
        }

        private void OnDestroy()
        {
            Debug.Log("On Destroy Called for Tab Manager");
            //wire up events
            RunMenuNavigation.OnNavigateTo = null;
            JumpMenuNavigation.OnNavigateTo = null;
            DashMenuNavigation.OnNavigateTo = null;
            EnvironmentMenuNavigation.OnNavigateTo = null;
        }

        Canvas[] GetAllMenuCanvases()
        {
            return new Canvas[]
            {
                RunMenuCanvas,
                JumpMenuCanvas,
                DashMenuCanvas,
                EnvironmentMenuCanvas
            };
        }

        NavigatorButton[] GetAllNavigatorButtons()
        {
            return new NavigatorButton[]{
                RunMenuNavigation,
                JumpMenuNavigation,
                DashMenuNavigation,
                EnvironmentMenuNavigation
            };
        }

        void UpdateSelection(NavigatorButton sender, Canvas canvas)
        {
            this.lastNavigatedElement = sender.name;
            Debug.Log($"last selected element = {lastNavigatedElement}");
        }

        void SetSelectionFromHistory()
        {
            if (!String.IsNullOrWhiteSpace(lastNavigatedElement))
            {
                var navButtonToSelect = GetAllNavigatorButtons().FirstOrDefault(nav => lastNavigatedElement == nav.name);

                SelectElement(navButtonToSelect);
            }
        }

        void SelectElement(Button button)
        {
            EventSystem.current.SetSelectedGameObject(button.gameObject);
            //navButtonToSelect.Select();
            button.OnSelect(new BaseEventData(EventSystem.current));

        }
    }
}
