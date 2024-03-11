using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10f;
    public Monster1 monster1;
    public Transform firepoint;
    public GameObject bulletprefab;
    private GameObject bullet;
    
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        monster1 = GetComponent<Monster1>();
        if (monster1.Hastarget&& monster1.Attackcooldown>0&& monster1.Attackcooldown<0.1f)
        {
            shoot();
        }
        void shoot()
        {
            bullet=Instantiate(bulletprefab,firepoint.position,firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
          
            if(monster1.WalkDirection == Monster1.WalkableDirection.Right)
            {
                bullet.transform.right = Vector2.left;
                rb.velocity = firepoint.right * speed;
            }
            else if(monster1.WalkDirection == Monster1.WalkableDirection.Left)
            {
                bullet.transform.right= Vector2.right;
                rb.velocity=-firepoint.right * speed;
            }

            
        }

    }
   
   
}
