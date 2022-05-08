using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int hp = 100;
    float timer=0f;
    public float speed=3.0f;
    private SpriteRenderer sprite;
    public float effectTime=5f;
    public bool isDamaged;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
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
            if (isDamaged==false){
                StartCoroutine("DamageEffect");
            }
            
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
IEnumerator DamageEffect()
{
    isDamaged=true;
    for(int i = 0; i < effectTime; ++i)
    {
        if(i%2 == 0)
            sprite.color = new Color32(255, 0, 0, 90);
        else
            sprite.color = new Color32(255, 255, 255, 180);

        yield return new WaitForSeconds(0.1f);
    }

    //Alpha Effect End
    sprite.color = new Color32(255, 255, 255, 255);
    
    isDamaged = false;
    Destroy(gameObject);
    yield return null;
}

}
