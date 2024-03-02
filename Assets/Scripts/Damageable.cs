using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent<int, Vector2> damageableHit;
    Animator animator;
    public float _maxhealth=100;
    public float Maxhealth
    {
        get
        {
            return _maxhealth;
        }
        set
        {
            _maxhealth = value;
        }
    }
    public float _health = 100;
    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if (_health <= 0)
            {
                Isalive = false;
            }
        }
    }

    
    public bool _isalive = true;
   public bool isInvincible=false;

   

    private float timesincehit=0;
    public float invincibilityTimer=0.25f;

    public bool Isalive
    {
        get
        {
            return _isalive;
        }
        set
        {
            _isalive = value;
            animator.SetBool("isalive", value);
            Debug.Log("Isalive set" + value);
        }
    }
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            if (timesincehit > invincibilityTimer)
            {
                isInvincible = false;
                timesincehit = 0;
            }
            timesincehit += Time.deltaTime;
        }
       
        
    }
    public bool Hit(int damage,Vector2 knockback)
    {
        if (Isalive && !isInvincible)
        {
            Health -= damage;
            isInvincible = true;
            animator.SetTrigger("hit");
            damageableHit?.Invoke(damage, knockback);
            return true;
        }
        return false;
    }
}
