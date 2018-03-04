using UnityEngine;
using System.Collections;

public class HoldButtonBehavior : MonoBehaviour
{
    public string HoldButtonName = string.Empty;
    public float holdTime = 0f;
    //public int btnCount = 0;
    //public int downCount = 0;
    //public int upCount = 0;
    void PrintButtonHoldLength()
    {
        if (Input.GetButton(HoldButtonName))
        {
            if (holdTime.Equals(0f))
            {
                Debug.Log("Starting Button Hold ");
            }
            holdTime += Time.deltaTime;
            StartCoroutine(HoldTime(HoldButtonName));
        }
        if (Input.GetButtonUp(HoldButtonName))
        {
            StopCoroutine(HoldTime(HoldButtonName));
            Debug.Log("final hold time = " + holdTime.ToString());
            Debug.Log("total time reset");
            holdTime = 0f;
        }
    }

    IEnumerator HoldTime(string buttonName)
    {
        holdTime += Time.deltaTime;
        yield return 0;
    }

    void FixedUpdate()
    {
        PrintButtonHoldLength();
        /*
        if (Input.GetButton(HoldButtonName))
        {
            btnCount++;
        }

        if (Input.GetButtonDown(HoldButtonName))
        {
            downCount++;
        }
        if (Input.GetButtonUp(HoldButtonName))
        {
            upCount++;
        }
        */
    }

}
