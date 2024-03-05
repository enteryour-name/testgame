using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CtrMonsterExp : MonoBehaviour
{
    public Damageable damageable;
    public CtrExpLevel ctrExpLevel;
    public float exp;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(damageable.Health <= 0)
        {
            ctrExpLevel.exp += exp;
            Destroy(this.gameObject);
        }
    }
}
