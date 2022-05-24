using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccineScript : MonoBehaviour
{
    int ScoreUp=120;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="Player"){
            VaccineUIScript.vaccine+=1;
            ScoreScript.score+=ScoreUp;
            gameObject.SetActive(false);
        }    
    }
}
