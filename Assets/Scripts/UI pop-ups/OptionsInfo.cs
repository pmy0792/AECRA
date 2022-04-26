using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsInfo : MonoBehaviour
{
    public GameObject optionsInfo;
    public bool isPause=false;

    public void IsPause(){
        isPause=!isPause;
        if (isPause){
            Time.timeScale=0f;
        }
        else{
            Time.timeScale=1f;
        }
        Time.fixedDeltaTime=0.02f*Time.timeScale;
    }
    void Update()
    {
        // Reverse the active state every time letter P is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            IsPause();
            // Check whether it's active / inactive 
            bool isActive = optionsInfo.activeSelf;

            optionsInfo.SetActive(!isActive);
        }
    }
}
