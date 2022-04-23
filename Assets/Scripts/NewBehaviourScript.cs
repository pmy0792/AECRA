using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
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




}
