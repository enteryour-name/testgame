using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
  
     Damageable damageable;
    public Vector2 knockback = Vector2.zero;
    public int attackDamage = 10;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") // 如果碰撞到角色
        {
            Debug.Log("Hit");
            Damageable damageable = other.GetComponent<Damageable>(); // 获取角色的生命值组件
            if (damageable != null)
            {
                Vector2 deliveredknockback1 = transform.parent.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);
                bool gothit = damageable.Hit(attackDamage, deliveredknockback1); // 触发角色受伤害的方法
            }
            
            // 销毁子弹
        }
    }
}
