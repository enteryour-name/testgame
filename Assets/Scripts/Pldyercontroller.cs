using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]
public class Pldyercontroller : MonoBehaviour
{
    public float walkspeed = 5f;
    Vector2 moveInput;
    [SerializeField]
    private bool _ismoving = false;
    public bool IsMoving { get
        {
            return _ismoving;
        }
        private set
        {
            _ismoving = value;
            animator.SetBool("ismoving", value);
        } 
    }
    [SerializeField]
    public bool _isattack = false;
    public bool IsAttack
    {
        get
        {
            return _isattack;
        }
        private set
        {
            _isattack = value;
            animator.SetBool("isattack", value);
        }
    }

    public bool _isfacingright = true;
    public bool IsFacingRight
    {
        get
        {
            return _isfacingright;
        }
        private set
        {
            if (_isfacingright != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isfacingright = value;
        }
    }

    

    Rigidbody2D rb;
    Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        IsAttack = false;
        IsMoving = false;
    }
  
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkspeed, moveInput.y*walkspeed);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;
        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !IsFacingRight)
        {
            //face the right
            IsFacingRight = true;
        }
        else if(moveInput.x<0&&IsFacingRight)
        {
            //face the left
            IsFacingRight = false;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsAttack = true;
        }
        else if (context.canceled)
        {
            IsAttack=false;
        }
    }
    public bool _bigattack = false;
    public bool BigAttack
    {
        get
        {
            return _bigattack;
        }
        private set
        {
            _bigattack = value;
            animator.SetBool("bigattack", value);
        }
    }
    public void OnBigAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            BigAttack = true;
        }
        else if (context.canceled)
        {
            BigAttack = false;
        }
    }


}
