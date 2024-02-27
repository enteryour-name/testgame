using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Touching))]
public class Monster2 : MonoBehaviour
{
    public float walkspeed = 3f;
    Rigidbody2D rb;
    Touching touching;
    public enum WalkableDirection { Right,Left}
    private WalkableDirection _walkDirection;
    private Vector2 walkDirectionVector;

    public WalkableDirection WalkDirection
    {
        get { return _walkDirection; }
        set
        {
            if (_walkDirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x* -1,gameObject.transform.localScale.y);
                if (value == WalkableDirection.Right)
                {
                    walkDirectionVector = Vector2.right;
                }
                else if(value == WalkableDirection.Left)
                {
                    walkDirectionVector = Vector2.left;
                }
            }
            _walkDirection = value;
        }
        
    }
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touching = GetComponent<Touching>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(walkspeed * Vector2.right.x, rb.velocity.y);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
