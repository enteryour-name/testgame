using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrSkill : MonoBehaviour
{
    public bool canskill3 = false;
    public bool canskill4 = false;
    public bool canskill5 = false;
    private Animator animator;
    // Start is called before the first frame update
    void OnEnable()
    {
        refresh();
    }
    public void refresh()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("canattack3", canskill3);
        animator.SetBool("canattack4", canskill4);
        animator.SetBool("canattack5", canskill5);
    }

    // Update is called once per frame
    void Update()
    {
        refresh();
    }
}
