using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LandOnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyScript hp;
    public PlayerMovement bounce;
    public int DamagePower = 20;
    [SerializeField] private AudioSource damageSoundEffect;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hp.TakeDamage(DamagePower);
            bounce.JumpedOnEnemy();
            Debug.Log("Land");
        }
    }
}
