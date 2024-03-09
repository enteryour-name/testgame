using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class TriggerSettings : MonoBehaviour
{
    public GameObject enterBlock;
    public GameObject[] lastEnemies;
    public GameObject[] enterTriggers;
    public GameObject[] lastTriggers;
    public GameObject[] antiDrops;
    public Vector3 returnPos= new Vector3(62,-29,0);
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (enterTriggers.Any(t => t==other.gameObject))
        {
            EnterTrigger();
        }
        else if (lastTriggers.Any(t => t==other.gameObject))
        {
            LastTrigger();
        }
        else if(antiDrops.Any(t => t==other.gameObject))
        {
            AntiDrop();
        }
    }
}
