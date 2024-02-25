using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touching : MonoBehaviour
{
    Animator animator;
    public ContactFilter2D castFilter;
    public float groundDistance=0.05f;
    CapsuleCollider2D touchingcol;
    RaycastHit2D[] groundHites = new RaycastHit2D[5];
    public bool _isground;
    public bool IsGround { get
        {
            return _isground;
        } private set
        {
            _isground = value;
            animator.SetBool("isground", value);
        } }

    // Start is called before the first frame update
    void Start()
    {
        touchingcol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGround = touchingcol.Cast(Vector2.down, castFilter, groundHites, groundDistance) > 0;
    }

}
