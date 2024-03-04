using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CtrCoolDown : MonoBehaviour
{
    public Material NormalStage;
    public Material CooldownStage;
    public CanvasRenderer cr;
    public float CoolDownTime;
    public Firecontrol firecontrol;
    public Leafranger leafranger;
    public Touching touching;
    public GameObject character1;
    public GameObject character2;
    private bool iscooldown = false;
    public float skill = 15;
    private bool isskill(float skillnumber)
    {
        switch (skillnumber)
        {
            case 13: return firecontrol.Fireattack3;
            case 14: return firecontrol.Fireattack4;
            case 15:return firecontrol.Fireattack5;
            case 23:return leafranger.Leafattack3;
            case 24:return leafranger.Leafattack4;
            case 25:return leafranger.Leafattack5;
            default: return false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        cr = GetComponent<CanvasRenderer>();
        cr.SetMaterial(NormalStage,null);
        if(10f<skill&& skill<20f)
        {
            touching = character1.GetComponent<Touching>();
        }
        else
        {
            touching=character2.GetComponent<Touching>();
        }
    }
    IEnumerator WaitForSeconds(float time)
    {
        iscooldown = true;
        yield return new WaitForSeconds(time);
        cr.SetMaterial(NormalStage, null);
        iscooldown = false;
    }
    private void IntoCoolDown()
    {
        if (!iscooldown)
        {
            cr.SetMaterial(CooldownStage, null);
            CooldownStage.SetFloat("_Speed", (float)Math.PI * 2 / CoolDownTime);
            CooldownStage.SetFloat("_StartTime", Time.time);
            StartCoroutine(WaitForSeconds(CoolDownTime));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isskill(skill) && touching.IsGround) 
        {
            IntoCoolDown();
        }
    }
}
