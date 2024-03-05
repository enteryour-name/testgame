using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newbullet : MonoBehaviour
{
    public Vector2 movespeed =new Vector2 (3f,0);
    public int damage = 10;
    public Vector2 knockback=new Vector2(0,0);
    Rigidbody2D rb;
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity=new Vector2( movespeed.x*transform.localScale.x,movespeed.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        if (damageable != null)
        {
            Vector2 deliveredknockback = transform.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);
            bool gotHit = damageable.Hit(damage, deliveredknockback);
            if (gotHit)
            {
                Debug.Log(collision.name + "hit for" + damage);
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
