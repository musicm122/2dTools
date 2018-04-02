using System;
using UnityEngine.UI;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.UI
{
    public class ChangeText : Text
    {
        public Action<string> OnChanged;
        string oldValue, currentValue;


        private void FixedUpdate()
        {
            text = oldValue;

            if (oldValue != currentValue)
            {
                Debug.Log($"<color=yellow> Changed Text from {oldValue} to {currentValue}. </color>");
                OnChanged(currentValue);
            }
            else
            {
                oldValue = currentValue;
            }

        }
    }
}
