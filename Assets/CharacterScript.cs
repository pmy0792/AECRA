using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour
{
    public float speed = 5;
    float horizontal;
    public SpriteRenderer rend;
    
    public Animator animator;
    void Start()
    { 
        rend=GetComponent<SpriteRenderer>();
        animator=GetComponent<Animator>();
        animator.SetBool("Attack",false);
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


        
                
    if (Input.anyKeyDown){
        if (Input.GetKeyDown("a") ){
            Debug.Log("Attack");
            animator.SetBool("Attack",true);
        }

        

        else{
            horizontal=Input.GetAxis("Horizontal");
            if (horizontal!=0){
                if (horizontal>0) rend.flipX=false;
                else rend.flipX=true;
        }
    }
    }
    if (Input.GetKeyUp("a") ){
            animator.SetBool("Attack",false);
        }
        
    }

    //private void OnCollisionEnter2D(Collision2D other) {
    //   SceneManager.LoadScene("GameOverScene");
    //}
}
