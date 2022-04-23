using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class ObstacleObject : MonoBehaviour
{
    public Slider hp;
    public float DamagePower=20f;
    [SerializeField] private AudioSource damageSoundEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="Player"){
            hp.value-=DamagePower;
            damageSoundEffect.Play();
        }
    }
}
