using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack3weapon : MonoBehaviour
{
    Leafranger leafranger;
    Animator animator;
    Rigidbody2D rb;
    public bool _leafattack3weapon;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
        
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        animator = GetComponent<Animator>();
        leafranger = transform.parent.GetComponent<Leafranger>();
        if (leafranger!=null && leafranger.Leafattack3)
        {
            animator.SetTrigger("leafattack3weapon");
            
        }
    }
}
