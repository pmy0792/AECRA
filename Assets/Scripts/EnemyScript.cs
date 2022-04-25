using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int hp = 100;

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
}
