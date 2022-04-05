using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInfo : MonoBehaviour
{
    public GameObject tutorialInfo;
    void Update()
    {
        // Reverse the active state every time T is pressed
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Check whether it's active / inactive 
            bool isActive = tutorialInfo.activeSelf;

            tutorialInfo.SetActive(!isActive);
        }
    }
}
