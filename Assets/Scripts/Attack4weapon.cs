using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack4weapon : MonoBehaviour
{
    Leafranger leafranger;
    Animator animator;
    Rigidbody2D rb;
    

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
        if (leafranger != null && leafranger.Leafattack4)
        {
            animator.SetTrigger("leafattack4weapon");

        }

    }
}
