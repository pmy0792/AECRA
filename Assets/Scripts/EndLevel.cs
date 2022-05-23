using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public bool wonLevel = false;
    public string sceneName = "";
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Flag"))
        {            
            Debug.Log("won");
            wonLevel = true;

            if (wonLevel)
            {
                Thread.Sleep(300);
                PlayerPrefs.SetInt("coins", ItemCollector.coins);
                PlayerPrefs.SetInt("Saved", 1);

                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
