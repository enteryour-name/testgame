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
    // Start is called before the first frame update
    void Start()
    {
        cr = GetComponent<CanvasRenderer>();
        firecontrol = GetComponent<Firecontrol>();
    }
    IEnumerator WaitForSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        cr.SetMaterial(NormalStage, null);
    }
    private void IntoCoolDown()
    {
        cr.SetMaterial(CooldownStage, null);
        CooldownStage.SetFloat("_Speed", (float)Math.PI * 2 / CoolDownTime);
        CooldownStage.SetFloat("_StartTime", Time.time);
        StartCoroutine(WaitForSeconds(CoolDownTime));
    }

    // Update is called once per frame
    void Update()
    {
        if(firecontrol.Fireattack5) 
        {
            IntoCoolDown();
        }
    }
}
