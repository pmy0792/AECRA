using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    bool isMoving = false;

    public bool isDamaged;
    public float effectTime=1.5f;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource walkSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        isDamaged=false;
    }

    // Update is called once per frame
    private void Update()
    {   
        //sprite.flipX = Input.GetAxisRaw("Horizontal") == -1;
        if (Input.GetAxisRaw("Horizontal") == -1 ){
            sprite.flipX=true;
        }
        if (Input.GetAxisRaw("Horizontal") == 1){
            sprite.flipX=false;
        }
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX*moveSpeed, rb.velocity.y);

        if(rb.velocity.x != 0 && IsGrounded()) 
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if(isMoving) {
            if(!walkSoundEffect.isPlaying)
            {
                walkSoundEffect.Play();
            }
        } else {
            walkSoundEffect.Stop();
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //Debug.Log("isDamaged: "+isDamaged.ToString());
        if (isDamaged){
            Debug.Log("Start Coroutine");
            StartCoroutine("DamageEffect");
        }

        
    }
    

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void JumpedOnEnemy()
    {
        jumpSoundEffect.Play();
        rb.velocity = new Vector2(rb.velocity.x, 3);
    }

    IEnumerator DamageEffect()
{
    for(int i = 0; i < effectTime; ++i)
    {
        if(i%2 == 0)
            sprite.color = new Color32(255, 255, 255, 90);
        else
            sprite.color = new Color32(255, 255, 255, 180);

        yield return new WaitForSeconds(0.1f);
    }

    //Alpha Effect End
    sprite.color = new Color32(255, 255, 255, 255);
    
    isDamaged = false;

    yield return null;
}
}

