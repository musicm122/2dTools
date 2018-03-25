using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

namespace AssemblyCSharp.Assets.Scripts.UI
{
    public class NavigatorButton : Button, ISelectHandler
    {
        Canvas TargetMenu;

        Canvas[] AvailableMenuPanels;

        Action OnNavigateTo;

        public void InitializeArguments(Canvas[] availableMenus, Canvas targetMenu)
        {
            this.TargetMenu = targetMenu;
            this.AvailableMenuPanels = availableMenus;
        }

        void ValidateAvailableMenus()
        {
            if (AvailableMenuPanels == null || AvailableMenuPanels.Length == 0)
            {
                throw new EmptyAvailableMenuNavigationException("There is no target navigation menu to enable.");
            }

        }

        void ValidateTargetMenu()
        {
            if (TargetMenu == null)
            {
                throw new NullNavigationTargetException("There is no target navigation menu to enable.");
            }

        }
        void DisableOtherMenuPanels()
        {
            ValidateTargetMenu();
            ValidateAvailableMenus();

            for (int i = 0; i < AvailableMenuPanels.Length; i++)
            {
                if (TargetMenu != AvailableMenuPanels[i])
                {
                    AvailableMenuPanels[i].enabled = false;
                }
            }
        }

        public override void OnSelect(BaseEventData eventData)
        {
            base.OnSelect(eventData);
            TargetMenu.enabled = true;
            DisableOtherMenuPanels();
            OnNavigateTo?.Invoke();
        }
    }

    public class NullNavigationTargetException : Exception
    {
        public NullNavigationTargetException(string message) : base(message)
        {
            Debug.LogError(message);
        }
    }

    public class EmptyAvailableMenuNavigationException : Exception
    {
        public EmptyAvailableMenuNavigationException(string message) : base(message)
        {
            Debug.LogError(message);
        }
    }
}
