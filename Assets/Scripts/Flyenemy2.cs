using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyenemy2 : MonoBehaviour
{
    public float speed = 2f;
    public DitectionZone flyditectionzone;
    Animator animator;
    Rigidbody2D rb;
    public bool _hastarget = false;
    public List<Transform> waypoints;
    Damageable damageable;
    int waypointnum = 0;
    Transform nextwaypoint;
    public float waypointreacheddistance;

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
        damageable = GetComponent<Damageable>();

    }
    public bool Canmove
    {
        get
        {
            return animator.GetBool("canmove");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        nextwaypoint = waypoints[waypointnum];
    }

    // Update is called once per frame
    void Update()
    {
        Hastarget = flyditectionzone.detectedColiders.Count > 0;
    }
    private void FixedUpdate()
    {
        if (damageable.Isalive)
        {
            if (Canmove)
            {
                Flight();
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void Flight()
    {
        Vector2 directiontowaypoint = (nextwaypoint.position - transform.position).normalized;
        float distance = Vector2.Distance(nextwaypoint.position, transform.position);
        rb.velocity = directiontowaypoint * speed;
        UpdateDirection();
        if (distance <= waypointreacheddistance)
        {
            waypointnum++;
            if (waypointnum >= waypoints.Count)
            {
                waypointnum = 0;
            }
            nextwaypoint = waypoints[waypointnum];
        }
    }

    private void UpdateDirection()
    {
        if (transform.localScale.x > 0)
        {
            if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }

        }
        else
        {
            if (rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }
    }
}
