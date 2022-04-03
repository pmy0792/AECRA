using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsInfo : MonoBehaviour
{
    public GameObject controlsInfo;
    void Update()
    {
        // Reverse the active state every time c is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Check whether it's active / inactive 
            bool isActive = controlsInfo.activeSelf;

            controlsInfo.SetActive(!isActive);
        }
    }
}
