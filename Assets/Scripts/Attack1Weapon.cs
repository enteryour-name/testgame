using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack1Weapon : MonoBehaviour
{
   Leafranger leafranger;
    Animator animator;
    Rigidbody2D rb;
    

   
   
   
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
        leafranger = transform.parent.GetComponent<Leafranger>();
        if (leafranger != null && leafranger.Leafattack1)
        {
            animator.SetTrigger("leafattack1weapon");

        }
    }
}
