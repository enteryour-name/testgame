using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CtrMonsterExp : MonoBehaviour
{
    private Damageable damageable;
    public CtrExpLevel ctrExpLevel;
    public float exp;
    // Start is called before the first frame update
    void Start()
    {
        damageable  = GetComponent<Damageable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(damageable.Health <= 0)
        {
            ctrExpLevel.exp += exp;
            this.enabled = false;
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
