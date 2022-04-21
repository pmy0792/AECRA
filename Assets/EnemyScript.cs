using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed=3.0f;
    float timer=0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right*speed*Time.deltaTime);
        
        if (speed!=3f){
            timer+=Time.deltaTime;
            if (timer>1){
                speed=3f;
                timer=0;
            }
        }
    }
}
