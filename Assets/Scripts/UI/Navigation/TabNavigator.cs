using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;
using AssemblyCSharp.Assets.Scripts.Extensions;
using AssemblyCSharp.Assets.Scripts.VisualEditorMenu;

namespace AssemblyCSharp.Assets.Scripts.UI
{
    public class TabNavigator : MonoBehaviour
    {
        string lastNavigatedMenu;
        Selectable lastSelected;

        [SerializeField]
        GameState GameState;

        Canvas[] MenuPanels { get { return GetAllMenuCanvases(); } }

        [SerializeField]
        CanvasRenderer ParentMenu;

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

        private NavigatorButton defaultMenuNav;

        private void OnEnable()
        {
            Debug.Log("<color=green>OnEnable Called for Tab Manager</color>");
            defaultMenuNav = RunMenuNavigation;
            InitNavBindings();
            FocusLastNavigatedMenu();
        }

        private void Start()
        {

        }

        private void OnDestroy()
        {
            Debug.Log("<color=green>Destroy Called for Tab Manager</color>");
            //wire up events
            GameState.RaisePauseStateChanged -= HandlePauseStateChange;
            RunMenuNavigation.OnNavigateTo = null;
            JumpMenuNavigation.OnNavigateTo = null;
            DashMenuNavigation.OnNavigateTo = null;
            EnvironmentMenuNavigation.OnNavigateTo = null;
        }

        void SetMenuVisibility(bool state)
        {
            ParentMenu.gameObject.SetActive(state);
            var i = 0;
            for (i = 0; i < MenuPanels.Length; i++)
            {
                MenuPanels[i].SetEnabledStateOnChildrenCanvas(state);
            }
        }

        void InitMenuItemBindings(NavigatorButton btn, Canvas[] canvases, Canvas target, Action<Selectable, Canvas> updateSelection)
        {
            btn.InitializeArguments(canvases, target);
            btn.OnNavigateTo = updateSelection;
        }

        void InitNavBindings()
        {
            GameState.RaisePauseStateChanged += HandlePauseStateChange;
            InitMenuItemBindings(RunMenuNavigation, MenuPanels, RunMenuCanvas, UpdateSelection);
            InitMenuItemBindings(JumpMenuNavigation, MenuPanels, JumpMenuCanvas, UpdateSelection);
            InitMenuItemBindings(DashMenuNavigation, MenuPanels, DashMenuCanvas, UpdateSelection);
            InitMenuItemBindings(EnvironmentMenuNavigation, MenuPanels, EnvironmentMenuCanvas, UpdateSelection);
        }

        void HandlePauseStateChange(object sender, PauseEventArgs eventArgs)
        {
            Debug.Log("OnPauseHandler called for Tab Navigator");
            SetMenuVisibility(eventArgs.IsPaused);
            if (eventArgs.IsPaused)
            {
                FocusLastNavigatedMenu();
            }
        }

        void UpdateSelection(Selectable sender, Canvas canvas)
        {
            this.lastSelected = sender;
            this.lastNavigatedMenu = sender.name;
            Debug.Log($"last selected element = {lastNavigatedMenu}");
        }

        void FocusLastNavigatedMenu()
        {
            if (!String.IsNullOrWhiteSpace(lastNavigatedMenu))
            {
                var navButtonToSelect = GetAllNavigatorButtons().FirstOrDefault(nav => lastNavigatedMenu == nav.name);
                SelectElement(navButtonToSelect);
            }
            else
            {
                SelectElement(defaultMenuNav);
            }
        }

        void SelectElement(Selectable selectable)
        {
            EventSystem.current.SetSelectedGameObject(selectable.gameObject);
            selectable.Select();
            selectable.OnSelect(new BaseEventData(EventSystem.current));
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


    }
}
