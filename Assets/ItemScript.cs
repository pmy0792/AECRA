using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public int ScoreUp=50;
    public GameObject gameobject;
    
    // Start is called before the first frame update
    void Start()
    {
        //gameobject=GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="Player"){
            ScoreScript.score+=ScoreUp;
            //gameObject.SetActive(false);
            gameObject.SetActive(false);
        }    
    }
}