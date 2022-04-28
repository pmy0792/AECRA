using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class ObstacleObject : MonoBehaviour
{
    public Slider hp;
    public float DamagePower=20f;
    public GameObject player_object;
    float timer;
    [SerializeField] private AudioSource damageSoundEffect;
    void Start()
    {
        timer=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="Player"){
            hp.value-=DamagePower;
            damageSoundEffect.Play();
            change_color();

        }
    }
    private void change_color(){
        
        while (timer<1f){
            timer+=Time.deltaTime;
            player_object.GetComponent<SpriteRenderer>().material.color=new Color(30,0,0,30);
            Debug.Log("Change color");
        }
        if (timer>1f){
            Debug.Log("Change color over");
            //player_object.GetComponent<SpriteRenderer>().material.color=new Color(255,255,255,255);
            timer=0;
        }
    }
}
