using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CtrMonsterHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth;
    public float health;
    public GameObject healthbarobj;
    private Transform tr;
    private Vector3 origin;
    private Rigidbody2D rigidbody2D;
    private Damageable damageable;
    public GameObject wholehealthbar;
    public Vector3 pos;
    public Transform wholetransform;
    private void Refresh()
    {
        maxHealth = GetComponent<Damageable>().Maxhealth;
        damageable = GetComponent<Damageable>();
        health = damageable.Health;
    }
    private void DecreaseHealth()
    {
        health = maxHealth - Time.time;
    }
    void Start()
    {
        Refresh();
        tr = healthbarobj.GetComponent<Transform>();
        origin = tr.localScale;
        rigidbody2D = GetComponent<Rigidbody2D>();
        wholetransform = wholehealthbar.GetComponent<Transform>();
        wholetransform.localPosition = new Vector3(0, 0.2f, 0);
    }
        // Update is called once per frame
        void Update()
        {
            health = damageable.Health;
            if (health > 0)
            {
                tr.localScale = new(health / maxHealth * origin.x, origin.y, origin.z);
            }
            else
            {
                wholehealthbar.SetActive(false);
            }
        }
}
    

