using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CtrMonsterHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth;
    public float health;
    public GameObject healthbarobj;
    private Transform tr;
    private Vector3 origin;
    private Monster2 monster;
    private void Refresh()
    {
        health = maxHealth;
    }
    private void DecreaseHealth()
    {
        health = maxHealth - Time.time;
    }
    void Start()
    {
        monster = GetComponent<Monster2>();
        if(monster != null )
        {
            Debug.Log("successmonster");
        }
        Refresh();
        tr = healthbarobj.GetComponent<Transform>();
        origin = tr.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(monster.WalkDirection == Monster2.WalkableDirection.Left)
        {
            tr.rotation = new Quaternion (0, 180, 0,0);
        }
        DecreaseHealth();
        tr.localScale = new(health / maxHealth * origin.x, origin.y, origin.z);
    }
}
