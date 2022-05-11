using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource walkSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private int lives;
    [SerializeField] private Transform lifeParent;
    [SerializeField] GameObject lifePrefab;
    private static Stack<GameObject> l = new Stack<GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

        AddLife(Lives);
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

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

        if (l.Count == 0)
        {
            deathSoundEffect.Play();
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void JumpedOnEnemy()
    {
        jumpSoundEffect.Play();
        rb.velocity = new Vector2(rb.velocity.x, 7);
    }

    public void AddLife(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            l.Push(Instantiate(lifePrefab, lifeParent));
        }
    }

    public static void RemoveLife()
    {
        if(l.Count > 0)
        {
            Destroy(l.Pop());   
        }
    }

    public static int GetSize()
    {
        int liv = -1;

        liv = l.Count;

        return liv;
    }

    public int Lives { get => lives; set => lives = value; }
}