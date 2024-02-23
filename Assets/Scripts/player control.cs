using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    public float speed;
    public float playerspeed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rigidbody2D.velocity = new Vector2(0,5f);
        Debug.Log("Hello world");
        Debug.Log(transform.Find("feet_trigger"));
        Debug.Log(transform);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Attack();
    }
    void move()
    {
        playerspeed = Input.GetAxis("Horizontal")*speed;
        if (playerspeed >= 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        if (Input.GetKeyDown("d"))
        {
            rigidbody2D.velocity = new Vector2(speed, 0);
        }
        rigidbody2D.velocity=new Vector2(speed*Input.GetAxis("Horizontal"),rigidbody2D.velocity.y);

        if (Input.GetKeyDown("k"))
        {
            rigidbody2D.velocity = new Vector2(0, speed);
        }
    }
    void Attack()
    {
        if (Input.GetKeyDown("j"))
        {
            animator.SetBool("Attacking", true);
        }
        else
        {
            animator.SetBool("Attacking", false);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collides!");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter!");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit!");
    }
   
}
