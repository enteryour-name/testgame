using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Firecontrol : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public float walkspeed = 5f;
    Vector2 moveInput;
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
        rb.velocity = new Vector2(moveInput.x * walkspeed, moveInput.y * walkspeed);
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

    public void OnAttack2(InputAction.CallbackContext context)
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
}
