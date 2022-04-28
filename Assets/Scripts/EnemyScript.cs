using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int hp = 100;
    float timer=0f;
    public float speed=3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Deal Damage");
        hp = hp - amount;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }
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
