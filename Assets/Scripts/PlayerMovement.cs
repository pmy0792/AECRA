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
    public Transform target;

    public bool isDamaged,isDead;
    public float effectTime=2f;
    bool isDying;
    float rotate_val=2f;
    int count;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource walkSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private int lives;
    [SerializeField] private Transform lifeParent;
    [SerializeField] GameObject lifePrefab;
    public GameObject player;
    private static Stack<GameObject> l = new Stack<GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

        AddLife(Lives);

        isDying=false;
        isDead=false;
        count=0;
    }

    // Update is called once per frame
    private void Update()
    {   
        if (isDying==false){
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

            if (isDamaged){
                StartCoroutine("DamageEffect");
            }
        }
        if (l.Count == 0)
        {   
            if (isDead){
                 SceneManager.LoadScene("GameOverScene");
            }

            else {
                if (isDying==false){
                    
                //StartCoroutine(FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.Out,"GameOverScene"));
                StartCoroutine("DyingEffect");}
            } 
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


    IEnumerator DyingEffect(){
        
        isDying=true;

        while (count<30){
            if (sprite.flipX==true){
                rb.transform.eulerAngles=new Vector3(0,0,rotate_val*count);
            }
            else{
                 rb.transform.eulerAngles=new Vector3(0,0,(-1)*rotate_val*count);
            }
            count+=1;
            yield return new WaitForSeconds(0.1f);
        }    

        isDying=false;
        isDead=true;
        yield return null;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FallDetector"))
        {
            RemoveLife();
            player.transform.position = target.position;
        }
    }

}

