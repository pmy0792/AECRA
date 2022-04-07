using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
using UnityEngine.SceneManagement;

public class HPbarScript : MonoBehaviour
{
    public static Slider sl;
    void Start()
    {
        sl = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
         if (sl.value==0.0f){
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
