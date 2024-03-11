using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack4weapon : MonoBehaviour
{
    Touching touching;
    Leafranger leafranger;
    Animator animator;
    Rigidbody2D rb;
    public CtrSkill ctrskill;



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
        
        touching = transform.parent.GetComponent<Touching>();
        animator = GetComponent<Animator>();
        leafranger = transform.parent.GetComponent<Leafranger>();
        
        if (leafranger != null && leafranger.Leafattack4 && touching.IsGround&&leafranger.Isalive&&leafranger.Attack4cooldown==0 && ctrskill.canskill4)
        {
            Debug.Log("animator");
            animator.SetTrigger("leafattack4weapon");

        }
        

    }
}
