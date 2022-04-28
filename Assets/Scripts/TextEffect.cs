using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEffect : MonoBehaviour
{
    public GameObject player;
    bool col_vec;
    float timer;
    void Start()
    {
        player=transform.parent.gameObject;
        gameObject.SetActive(false);
        col_vec=false;
        timer=0f;
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        //col_vec=this.transform.parent.GetComponent<ItemCollector>().collecting_vaccine;
        //if (this.transform.parent.GetComponent<ItemCollector>().collecting_vaccine==true){

        //}
        
        if (player.GetComponent<ItemCollector>().collecting_vaccine==true){
            Debug.Log("collecting vaccine!");
            
            if (timer!=1f){
            timer+=Time.deltaTime;
            if (timer>1f){
                timer=0;
                gameObject.SetActive(false);
            }
        }
        }
    
    }
}
