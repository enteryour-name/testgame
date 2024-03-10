using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(Touching), typeof(Damageable))]
public class Boss : MonoBehaviour
{
    public float randomvalue=7f; 
    public float walkspeed = 5f;
    public DitectionZone attackzone;
    public DitectionZone cliffditectionzone;
    Animator animator;
    Rigidbody2D rb;
    Touching touching;
    Damageable damageable;
    public enum WalkableDirection { Right, Left }
    private WalkableDirection _walkDirection;
    private Vector2 walkDirectionVector = Vector2.right;
    public Transform player;
    public Transform boss;
    public CtrGenerateCharacter ctrGenerateCharacter;
    public GameObject character1;



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
       set
        {
            _hastarget = value;
            animator.SetBool("hastarget", value);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        touching = GetComponent<Touching>();
        damageable = GetComponent<Damageable>();
    }
    private void FixedUpdate()
    {
       
       

    }

    
    // Start is called before the first frame update
    void Start()
    {
        character1 = ctrGenerateCharacter.character;
    }
   public float attack2time = 5f;
    public float attack1time = 4f;
    public float attack4time = 2f;
    public float attack5time = 2f;
    public float cooldown=3f;
    public float randomtimecooldown = 3f;
    // Update is called once per frame
    public void Update()
    {
        rb.velocity = new Vector2(3f * walkDirectionVector.x, rb.velocity.y);
        animator.SetFloat("yvelocity", rb.velocity.y);
        Hastarget = attackzone.detectedColiders.Count < 0;

        if (damageable.Health > 500) 
        {
            if (randomvalue >= 5 && (boss.transform.position.x - character1.transform.position.x) < 15f && (boss.transform.position.x - character1.transform.position.x) > -15f)
            {
                attack2time -= Time.deltaTime;
                if (attack2time > 4f)
                {
                    rb.velocity = new Vector2(10f * walkDirectionVector.x, rb.velocity.y);
                }
                else if (attack2time <= 4f && attack2time >= 3f)
                {

                    Attack2 = true;
                }
                else if (attack2time < 3.1f && attack2time >= 2f)
                {
                    Attack2 = false;
                    Attack3 = true;
                }
                else if (attack2time < 2f&&attack2time>=0f)
                {
                    Attack3 = false;
                    
                }
                else if (attack2time<0f)
                {
                    attack2time = 5f;
                    randomvalue = UnityEngine.Random.Range(0, 10);
                }

            }

            if (randomvalue < 5 &&randomvalue>=2&& (boss.transform.position.x - character1.transform.position.x) < 15f && (boss.transform.position.x - character1.transform.position.x) > -15f)
            {
                attack1time -= Time.deltaTime;
                if (attack1time > 3f)
                {
                    rb.velocity = new Vector2(10f * walkDirectionVector.x, rb.velocity.y);
                }
                else if (attack1time < 3f && attack1time >= 2.5f)
                {
                    rb.velocity = new Vector2(walkDirectionVector.x, 8f);
                   

                }
                else if (attack1time < 2.5f && attack1time > 1.5f)
                {
                    Attack1 = true;
                }
                else if (attack1time < 1.5f&&attack1time>=0f)
                {
                    Attack1 = false;
                    
                }
                else if (attack1time < 0f)
                {
                    attack1time = 4f;
                    randomvalue = UnityEngine.Random.Range(0, 10);
                }
            }
            if(randomvalue < 2 && (boss.transform.position.x - character1.transform.position.x) < 15f && (boss.transform.position.x - character1.transform.position.x) > -15f)
            {
                attack4time-=Time.deltaTime;
                if(attack4time < 1.5f&&attack4time>0.5f)
                {
                    Attack4 = true;
                }
                else if(attack4time < 0.5f&&attack4time>0f)
                {
                    Attack4=false;
                }
                else if (attack4time < -1f)
                {
                    attack4time = 2f;
                    randomvalue = UnityEngine.Random.Range(0, 10);
                }
            }
        }
        else if (damageable.Health <= 500)
        {
            if (randomvalue >= 6 && (boss.transform.position.x - character1.transform.position.x) < 15f && (boss.transform.position.x - character1.transform.position.x) > -15f)
            {
                attack4time -= Time.deltaTime;
                if (attack4time < 1.5f && attack4time > 0.5f)
                {
                    Attack4 = true;
                }
                else if (attack4time < 0.5f && attack4time >= 0f)
                {
                    Attack4 = false;
                }
                else if (attack4time < 0f)
                {
                    attack4time = 2f;
                    randomvalue = UnityEngine.Random.Range(0, 10);
                }
            }
            if (randomvalue < 6 && (boss.transform.position.x - character1.transform.position.x) < 15f && (boss.transform.position.x - character1.transform.position.x) > -15f)
            {
                attack5time -= Time.deltaTime;
                if (attack5time < 1.5f && attack5time > 0.5f)
                {
                    Attack5 = true;
                }
                else if (attack5time < 0.5f && attack5time >= 0f)
                {
                    Attack5 = false;
                }
                else if (attack5time < 0f)
                {
                    attack5time = 2f;
                    randomvalue = UnityEngine.Random.Range(0, 10);
                }
            }

        }



        if ((boss.transform.position.x - character1.transform.position.x) > 1f || (boss.transform.position.x - character1.transform.position.x )< -1f)
        {
          
            
                if (boss.transform.position.x <= character1.transform.position.x)
                {
                    WalkDirection = WalkableDirection.Right;

                }
                if (boss.transform.position.x > character1.transform.position.x)
                {
                    WalkDirection = WalkableDirection.Left;
                }
            
        }
        
        if (Attack1cooldown > 0)
        {
            Attack1cooldown -= Time.deltaTime;
        }


    }
    public bool _attack1;
   

    public bool Attack1
    {
        get
        {
            return _attack1;
        }
        private set
        {
            _attack1 = value;
            animator.SetBool("attack1", value);
            
        }
    }
    public bool _attack3;


    public bool Attack3
    {
        get
        {
            return _attack3;
        }
        private set
        {
            _attack3 = value;
            animator.SetBool("attack3", value);

        }
    }
    public bool _attack4;


    public bool Attack4
    {
        get
        {
            return _attack4;
        }
        private set
        {
            _attack4 = value;
            animator.SetBool("attack4", value);

        }
    }
    public bool _attack5;


    public bool Attack5
    {
        get
        {
            return _attack5;
        }
        private set
        {
            _attack5 = value;
            animator.SetBool("attack5", value);

        }
    }
    public void OnAttack1()
    {
        if (Hastarget)
        {
            Attack1 = true;
            rb.velocity=new Vector2(rb.velocity.x, 10f);

        }
        else
        {
            Attack1 = false;
        }
    }
    public bool _attack2;
    public float speedup=10f;

    public bool Attack2
    {
        get
        {
            return _attack2;
        }
        private set
        {
            _attack2 = value;
            animator.SetBool("attack2", value);

        }
    }
    public void BAttack2()
    {
        Debug.Log("11");
        if ((boss.transform.position.x-character1.transform.position.x)<100f&& (boss.transform.position.x - character1.transform.position.x) > -100f)
        {
            Attack2 = true;
            rb.velocity=new Vector2(speedup,rb.velocity.y);

        }
        else
        {
            Attack2 = false;
        }
    }
    public float Attack1cooldown
    {
        get
        {
            return animator.GetFloat("attack1cooldown");
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
