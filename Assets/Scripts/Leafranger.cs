using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Leafranger : MonoBehaviour
{
    public float fastspeed=20f;
    public float normalspeed = 10f;
    public float rollrate = 20f;
    Rigidbody2D rb;
    Animator animator;
    Vector2 moveInput;
    Touching touching;
    Damageable damageable;
    
    public float currentspeed
    {
        get
        {
            if (Canmove)
            {
                if (Leafmove && !touching.IsOnWall)
                {
                    if (Slide)
                    {
                        return fastspeed;
                    }
                    else
                    {
                        return normalspeed;
                    }

                }
                else
                {
                    return 0;
                }
            }
            else
            {//move locked
                return 0;
            }
        }
    }
    [SerializeField]
    private bool _leafmove = false;
    public bool Leafmove
    {
        get
        {
            return _leafmove;
        }
        private set
        {
            _leafmove = value;
            animator.SetBool("leafmove", value);
        }
    }
    public bool _leafisfacingright = true;
    public bool Leafisfacingright
    {
        get
        {
            return _leafisfacingright;
        }
        private set
        {
            if (_leafisfacingright != value&&!Leafattack2&&!Leafattack3&&!Leafattack4&&!Leafattack5)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _leafisfacingright = value;
        }
    }
    public float jumpimpulse = 20f;
    public bool _leafattack1;
    public bool Leafattack1
    {
        get
        {
            return _leafattack1;
        }
        private set
        {
            _leafattack1 = value;
            animator.SetBool("leafattack1", value);
            
        }
    }
    public void OnLeafattack1(InputAction.CallbackContext context)
    {
        if (context.started&& !touching.IsGround)
        {
            Leafattack1 = true;
           
        }
        else if (context.canceled)
        {
            Leafattack1 = false;
           
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touching = GetComponent<Touching>();
        damageable=GetComponent<Damageable>();
       
    }

    // Start is called before the first frame update
    void Start()
    {
        Leafattack1 = false;
        Leafmove = false;
        Jumped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Attack3cooldown > 0)
        {
            Attack3cooldown -= Time.deltaTime;
        }
        if (Attack4cooldown > 0)
        {
            Attack4cooldown -= Time.deltaTime;
        }
        if (Attack5cooldown > 0)
        {
            Attack5cooldown -= Time.deltaTime;
        }
        if (rb.velocity.x==0)
        {
            Attacktime-=Time.deltaTime;
            transform.rotation = Quaternion.identity;
        }
    }
    public float Attacktime
    {
        get
        {
            return animator.GetFloat("attacktime");
        }
        private set
        {
            animator.SetFloat("attacktime", Mathf.Max(value, 0));
        }
    }
    public float Attack3cooldown
    {
        get
        {
            return animator.GetFloat("attack3cooldown");
        }
        private set
        {
            animator.SetFloat("attack3cooldown", Mathf.Max(value, 0));
        }
    }
    public float Attack4cooldown
    {
        get
        {
            return animator.GetFloat("attack4cooldown");
        }
        private set
        {
            animator.SetFloat("attack4cooldown", Mathf.Max(value, 0));
        }
    }
    public float Attack5cooldown
    {
        get
        {
            return animator.GetFloat("attack5cooldown");
        }
        private set
        {
            animator.SetFloat("attack5cooldown", Mathf.Max(value, 0));
        }
    }

    private void FixedUpdate()
    {
        if(!damageable.Lockvelocity)
        rb.velocity = new Vector2(moveInput.x * currentspeed, rb.velocity.y);
        animator.SetFloat("yvelocity", rb.velocity.y);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (Isalive)
        {
            
                Leafmove = moveInput != Vector2.zero;
                SetFacingDirection(moveInput);
            
        }
        else
        {
            Leafmove = false;
        }
       
        
    }
    
    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !Leafisfacingright)
        {
            //face the right
            Leafisfacingright = true;
        }
        else if (moveInput.x < 0 && Leafisfacingright)
        {
            //face the left
            Leafisfacingright = false;
        }
    }
    public bool Jumped = false;
    public void OnJump(InputAction.CallbackContext context)
    {
        //To do check whether it is alive
        if (context.started && touching.IsGround&&Canmove)
        {
            animator.SetTrigger("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpimpulse);
            Jumped = true;
        }
    }
    public bool _doublejump = false;
    public bool Doublejump
    {
        get
        {
            return _doublejump;
        }
        private set
        {
            _doublejump = value;
            animator.SetBool("doublejump", value);
        }
    }
    public void OnDoublejump(InputAction.CallbackContext context)
    {
        if (context.started && Jumped && !touching.IsGround)
        {
            Doublejump = true;


        }
        else if (context.canceled)
        {
            Doublejump = false;
        }
        if (!touching.IsGround && Doublejump && Jumped)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpimpulse);
            Jumped = false;
        }

    }
   
    public bool _leafattack2;
    public bool Leafattack2
    {
        get
        {
            return _leafattack2;
        }
        private set
        {
            _leafattack2 = value;
            animator.SetBool("leafattack2", value);
        }
    }
    
    public void OnLeafattack2(InputAction.CallbackContext context)
    {
        if (context.started&& touching.IsGround)
        {
            Leafattack2 = true;
         

        }
        else if (context.canceled)
        {
            Leafattack2 = false;
            
           
        }
    }
    public bool _leafattack3;
    public bool Leafattack3
    {
        get
        {
            return _leafattack3;
        }
        private set
        {
            _leafattack3 = value;
            animator.SetBool("leafattack3", value);
            animator.SetBool("leafattack3weapon",value);
        }
    }
    public void OnLeafattack3(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Leafattack3 = true;
          
        }
        else if (context.canceled)
        {
            Leafattack3 = false;
        }
    }
    public bool _leafattack4;
    public bool Leafattack4
    {
        get
        {
            return _leafattack4;
        }
        private set
        {
            _leafattack4 = value;
            animator.SetBool("leafattack4", value);
            animator.SetBool("leafattack4weapon", value);
        }
    }
    public void OnLeafattack4(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Leafattack4 = true;
            
        }
        else if (context.canceled)
        {
            Leafattack4 = false;
        }
    }
    public bool _leafattack5;
    public bool Leafattack5
    {
        get
        {
            return _leafattack5;
        }
        private set
        {
            _leafattack5 = value;
            animator.SetBool("leafattack5", value);
        }
    }
    public void OnLeafattack5(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Leafattack5 = true;
            
        }
        else if (context.canceled)
        {
            Leafattack5 = false;
        }
    }
    public bool _roll = false;
    public bool Roll
    {
        get
        {
            return _roll;
        }
        private set
        {
            _roll = value;
            animator.SetBool("roll", value);
        }
    }

    public void OnRoll(InputAction.CallbackContext context)
    {
        if (context.started && touching.IsGround)
        {
            Roll = true;
            rb.velocity = new Vector2(rollrate, rb.velocity.y);

        }
        else if (context.canceled)
        {
            Roll = false;
        }
    }
    public bool _slide = false;
    public bool Slide
    {
        get
        {
            return _roll;
        }
        private set
        {
            _roll = value;
            animator.SetBool("slide", value);
        }
    }

    public void OnSlide(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Slide = true;
            rb.velocity = new Vector2(rollrate, rb.velocity.y);

        }
        else if (context.canceled)
        {
            Slide = false;
        }
    }
    public bool Canmove
    {
        get
        {
            return animator.GetBool("canmove");
        }
    }
    public bool Isalive
    {
        get
        {
            return animator.GetBool("isalive");
        }
    }

   

    public void OnHit(int damage,Vector2 knockback)
    {
        
        rb.velocity=new Vector2(knockback.x,rb.velocity.y+ knockback.y);
    }
   
}
