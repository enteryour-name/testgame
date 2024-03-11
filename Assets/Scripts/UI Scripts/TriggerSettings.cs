using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class TriggerSettings : MonoBehaviour
{
    public GameObject enterBlock;
    public GameObject trap;
    public GameObject[] trapEnemies;
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
    public void Trap()
    {
        foreach (GameObject monster in trapEnemies)
        {
            monster.SetActive(true);
        }
        trap.SetActive(true);
        StartCoroutine(WaitTrap());
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
        else if(other.name =="AntiDrop (1)")
        {
            AntiDrop2();
        }
        else if(other.name=="AntiDrop (2)")
        {
            AntiDrop3();
        }
        else if(other.name=="Trap")
        {
            Trap();
        }
    }
    IEnumerator WaitTrap()
    {
        yield return new WaitForSeconds(20f);
        trap.SetActive(false);
    }
}
