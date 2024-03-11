
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack1Weapon : MonoBehaviour
{
   Leafranger leafranger;
    Animator animator;
    Rigidbody2D rb;
    Touching touching;
    

   
   
   
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator = GetComponent<Animator>();
        touching = transform.parent.GetComponent<Touching>();
        leafranger = transform.parent.GetComponent<Leafranger>();
        if (leafranger != null && leafranger.Leafattack1&&!touching.IsGround&&leafranger.Isalive)
        {
            animator.SetTrigger("leafattack1weapon");

        }
    }
}
