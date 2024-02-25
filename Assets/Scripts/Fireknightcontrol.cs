using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Firecontrol : MonoBehaviour
{
    public float rollrate = 20f;
    Rigidbody2D rb;
    Animator animator;
    public float walkspeed = 10f;
    Vector2 moveInput;
    Touching touching;
    [SerializeField]
    private bool _firemove = false;
    public bool Firemove
    {
        get
        {
            return _firemove;
        }
        private set
        {
            _firemove = value;
            animator.SetBool("firemove", value);
        }
    }
    public bool _fireisfacingright = true;
    public bool Fireisfacingright
    {
        get
        {
            return _fireisfacingright;
        }
        private set
        {
            if (_fireisfacingright != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _fireisfacingright = value;
        }
    }
    public bool _fireattack2 = false;
    public float jumpimpulse=20f;

    public bool Fireattack2
    {
        get
        {
            return _fireattack2;
        }
        private set
        {
            _fireattack2 = value;
            animator.SetBool("fireattack2", value);
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touching = GetComponent<Touching>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Fireattack2 = false;
        Firemove = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkspeed, rb.velocity.y);
        animator.SetFloat("yvelocity", rb.velocity.y);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Firemove = moveInput != Vector2.zero;
        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !Fireisfacingright)
        {
            //face the right
            Fireisfacingright = true;
        }
        else if (moveInput.x < 0 && Fireisfacingright)
        {
            //face the left
            Fireisfacingright = false;
        }
    }

    public void OnFireattack2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Fireattack2 = true;
        }
        else if (context.canceled)
        {
            Fireattack2 = false;
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        //To do check whether it is alive
        if(context.started && touching.IsGround)
        {
            animator.SetTrigger("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpimpulse);
        }
    }
    public bool _fireattack1 = false;
    public bool Fireattack1
    {
        get
        {
            return _fireattack1;
        }
        private set
        {
            _fireattack1 = value;
            animator.SetBool("fireattack1", value);
        }
    }
    public void OnFireattack1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Fireattack1 = true;
        }
        else if (context.canceled)
        {
            Fireattack1 = false;
        }
    }
    public bool _fireattack3 = false;
    public bool Fireattack3
    {
        get
        {
            return _fireattack3;
        }
        private set
        {
            _fireattack3 = value;
            animator.SetBool("fireattack3", value);
        }
    }
    public void OnFireattack3(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Fireattack3 = true;
        }
        else if (context.canceled)
        {
            Fireattack3 = false;
        }
    }
    public bool _fireattack4 = false;
    public bool Fireattack4
    {
        get
        {
            return _fireattack4;
        }
        private set
        {
            _fireattack4 = value;
            animator.SetBool("fireattack4", value);
        }
    }
    public void OnFireattack4(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Fireattack4 = true;
        }
        else if (context.canceled)
        {
            Fireattack4 = false;
        }
    }
    public bool _fireattack5 = false;
    public bool Fireattack5
    {
        get
        {
            return _fireattack5;
        }
        private set
        {
            _fireattack5 = value;
            animator.SetBool("fireattack5", value);
        }
    }
    public void OnFireattack5(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Fireattack5 = true;
        }
        else if (context.canceled)
        {
            Fireattack5 = false;
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
        if (context.started)
        {
            rb.velocity = new Vector2(rollrate, rb.velocity.y);
            Roll = true;
        }
        else if (context.canceled)
        {
            Roll = false;
        }
    }
}
