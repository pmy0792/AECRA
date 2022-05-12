using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3[] positions;
    private int index;

    public int hp = 100;
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

    void FixedUpdate() {

        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);
        if (transform.position == positions[index])
        {
            if (index == positions.Length -1)
            {
                index = 0;
            }
            else
            {
                index++;
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
