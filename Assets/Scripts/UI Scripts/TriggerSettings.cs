using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class TriggerSettings : MonoBehaviour
{
    public GameObject enterBlock;
    public GameObject enterBlock2;
    public GameObject[] lastEnemies;
    public GameObject enterTriggers;
    public GameObject enterTriggers1;
    public GameObject lastTriggers;
    public GameObject antiDrops;
    public Vector3 returnPos= new Vector3(62,-29,0);
    public Vector3 returnPos2;
    public Vector3 returnPos3;
    public void EnterTrigger()
    {
        enterBlock.SetActive(false);
    }
    public void EnterTrigger2()
    {
        enterBlock2.SetActive(false);
    }
    public void LastTrigger()
    {
        foreach(GameObject monster in lastEnemies)
        {
            monster.SetActive(true);
        }
    }
    public void AntiDrop()
    {
        transform.position = returnPos;
        GetComponent<Damageable>().Health -= 10;
    }
    public void AntiDrop2()
    {
        transform.position = returnPos2;
        GetComponent<Damageable>().Health -= 10;
    }
    public void AntiDrop3()
    {
        transform.position = returnPos3;
        GetComponent<Damageable>().Health -= 10;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "EnterTrigger")
        {
            EnterTrigger();
        }
        else if (other.name == "LastTrigger")
        {
            LastTrigger();
        }
        else if(other.name == "AntiDrop")
        {
            AntiDrop();
        }
        else if( other.name == "EnterTrigger (1)")
        {
            EnterTrigger2();
        }
        else if(other.name =="AntiDrop (1)")
        {
            AntiDrop2();
        }
        else if(other.name=="AntiDrop (2)")
        {
            AntiDrop3();
        }
    }
}
