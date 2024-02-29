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
    // Start is called before the first frame update
    void Start()
    {
        cr = GetComponent<CanvasRenderer>();
    }
    IEnumerator WaitForSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Waited for " + time + " seconds.");
        Debug.Log("start");
        cr.SetMaterial(NormalStage, null);
    }
    private void IntoCoolDown()
    {
        cr.SetMaterial(CooldownStage, null);
        StartCoroutine(WaitForSeconds(CoolDownTime));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)) 
        {
            IntoCoolDown();
        }
    }
}
