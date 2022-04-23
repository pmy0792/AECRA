using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour
{
    public float speed = 5;
    float horizontal;
    public SpriteRenderer rend;

    [SerializeField]
    private AudioSource jumpSoundEffect;
    void Start()
    { 
        rend=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 pos = transform.position;

        pos.x += speed*h*Time.deltaTime;
        pos.y += speed*v*Time.deltaTime;

        transform.position = pos;


     horizontal=Input.GetAxis("Horizontal");
            if (horizontal!=0){
                jumpSoundEffect.Play();
                if (horizontal>0) rend.flipX=false;
                else rend.flipX=true;
                }

        
    }

    //private void OnCollisionEnter2D(Collision2D other) {
    //   SceneManager.LoadScene("GameOverScene");
    //}
}
