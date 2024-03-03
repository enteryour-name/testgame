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
    Firecontrol firecontrol;
    private bool iscooldown = false;
    public float skill = 5;
    private bool isskill(float skillnumber)
    {
        switch (skillnumber)
        {
            case 3: return firecontrol.Fireattack3;
            case 4: return firecontrol.Fireattack4;
            case 5:return firecontrol.Fireattack5;
            default: return false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        cr = GetComponent<CanvasRenderer>();
        firecontrol = GameObject.FindObjectOfType<Firecontrol>().GetComponent<Firecontrol>();
        cr.SetMaterial(NormalStage,null);
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
        if(isskill(skill)) 
        {
            IntoCoolDown();
        }
    }
}
