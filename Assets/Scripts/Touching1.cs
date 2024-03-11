using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touching1 : MonoBehaviour
{
    Animator animator;
    public ContactFilter2D castFilter;
    public float groundDistance = 0.05f;
    public float wallDistance = 0.2f;
    public float ceilingDistance = 0.05f;
    CapsuleCollider2D touchingcol;
    RaycastHit2D[] groundHites = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];
    public bool _isground;
    public bool IsGround
    {
        get
        {
            return _isground;
        }
        private set
        {
            _isground = value;
            animator.SetBool("isground", value);
        }
    }
    public bool _isonwall;
    public bool IsOnWall
    {
        get
        {
            return _isonwall;
        }
        private set
        {
            _isonwall = value;
            animator.SetBool("isonwall", value);
        }
    }
    public bool _isonceiling;
    private Vector2 wallCheckDirection => gameObject.transform.localScale.x < 0 ? Vector2.right : Vector2.left;

    public bool IsOnCeiling
    {
        get
        {
            return _isonceiling;
        }
        private set
        {
            _isonceiling = value;
            animator.SetBool("isonceiling", value);
        }
    }


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
        IsOnWall = touchingcol.Cast(wallCheckDirection, castFilter, wallHits, wallDistance) > 0;
        IsOnCeiling = touchingcol.Cast(Vector2.up, castFilter, ceilingHits, ceilingDistance) > 0;
    }

}
