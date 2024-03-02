using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2Attack : MonoBehaviour
{
    Collider2D attackcolloider;
    public int attackDamage=10;
    public Vector2 knockback=Vector2.zero;

    private void Awake()
    {
        attackcolloider=GetComponent<Collider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        if(damageable!= null )
        {
            Vector2 deliveredknockback = transform.parent.localScale.x > 0?knockback:new Vector2(-knockback.x,knockback.y);
           bool gotHit= damageable.Hit(attackDamage,deliveredknockback);
            if(gotHit)
            {
                Debug.Log(collision.name+"hit for"+attackDamage);
            }
        }
    }
}
