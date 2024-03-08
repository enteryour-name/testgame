using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TriggerSettings : MonoBehaviour
{
    public GameObject enterBlock;
    public GameObject[] lastEnemies;
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
        transform.position = new Vector3(62, -29, 0);
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
    }
}
