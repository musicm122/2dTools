using System;
using UnityEngine;
using UnityEngine.UI;

namespace AssemblyCSharp.Assets.Scripts.Extensions
{
    public static class GameObjectExtensions
    {
        public static void SetEnabledStateOnChildren(this GameObject gameObj, bool state)
        {
            foreach (var element in gameObj.GetComponentsInChildren<GameObject>())
            {
                element.SetActive(state);
            }
        }

        public static void SetEnabledStateOnChildren<T>(this T gameObj, bool state) where T : MonoBehaviour
        {
            foreach (var element in gameObj.GetComponentsInChildren<T>())
            {

                element.enabled = state;
            }
        }

        public static void SetActiveOnSelectable<T>(this T gameObj, bool state) where T : Selectable
        {
            foreach (var element in gameObj.GetComponentsInChildren<T>())
            {

                element.enabled = state;
            }
        }



        public static void SetEnabledStateOnSelectable(this GameObject gameObj, bool state)
        {
            foreach (var element in gameObj.GetComponentsInChildren<Selectable>())
            {
                element.enabled = state;
            }
        }

        public static void SetEnabledStateOnSelectable(this Canvas canvas, bool state)
        {
            foreach (var element in canvas.GetComponentsInChildren<Selectable>())
            {
                element.enabled = state;
            }
        }

        public static void SetEnabledStateOnChildrenCanvas(this Canvas canvas, bool state)
        {
            foreach (var element in canvas.GetComponentsInChildren<Canvas>())
            {
                element.enabled = state;
            }
        }

        public static void SetEnabledStateOnSelectableGameObject(this Canvas canvas, bool state)
        {
            foreach (var element in canvas.GetComponentsInChildren<Selectable>())
            {
                element.gameObject.SetActive(state);
            }
        }
    }
}
