using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Touching1), typeof(Damageable))]
public class Monster1 : MonoBehaviour
{
    public float walkspeed = 3f;
    public DitectionZone attackzone;
    public DitectionZone cliffditectionzone;
    Animator animator;
    Rigidbody2D rb;
    Touching1 touching;
    Damageable damageable;
    public enum WalkableDirection { Right, Left }
    private WalkableDirection _walkDirection;
    private Vector2 walkDirectionVector = Vector2.right;

    public WalkableDirection WalkDirection
    {
        get { return _walkDirection; }
        set
        {
            if (_walkDirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
                if (value == WalkableDirection.Right)
                {
                    walkDirectionVector = Vector2.right;
                }
                else if (value == WalkableDirection.Left)
                {
                    walkDirectionVector = Vector2.left;
                }
            }
            _walkDirection = value;
        }

    }
    public bool _hastarget = false;
    public bool Hastarget
    {
        get
        {
            return _hastarget;
        }
        private set
        {
            _hastarget = value;
            animator.SetBool("hastarget", value);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        touching = GetComponent<Touching1>();
        damageable = GetComponent<Damageable>();
    }
    private void FixedUpdate()
    {
        if (touching.IsOnWall && touching.IsGround || cliffditectionzone.detectedColiders.Count == 0)
        {
            FlipDirection();
        }
        if (!damageable.Lockvelocity)
        {
            if (Canmove&&touching.IsGround)
                rb.velocity = new Vector2(walkspeed * walkDirectionVector.x, rb.velocity.y);
            else
            {
                rb.velocity = new Vector2(1f * walkDirectionVector.x, rb.velocity.y);
            }
        }

    }

    private void FlipDirection()
    {
        if (WalkDirection == WalkableDirection.Right)
        {
            WalkDirection = WalkableDirection.Left;
        }
        else if (WalkDirection == WalkableDirection.Left)
        {
            WalkDirection = WalkableDirection.Right;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale *= new Vector2(-1, 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        Hastarget = attackzone.detectedColiders.Count > 0;
        if (Attackcooldown > 0)
        {
            Attackcooldown -= Time.deltaTime;
        }


    }
    public float Attackcooldown
    {
        get
        {
            return animator.GetFloat("attackcooldown");
        }
        private set
        {
            animator.SetFloat("attackcooldown", Mathf.Max(value, 0));
        }
    }
    public bool Canmove
    {
        get
        {
            return animator.GetBool("canmove");
        }
    }



    public void OnHit(int damage, Vector2 knockback)
    {

        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }
}
