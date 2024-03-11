using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CtrPlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth;
    public float health;
    public GameObject healthbarobj;
    private RectTransform rtr;
    public GameObject TargetText;
    private TextMeshProUGUI HealthBartext;
    Damageable damageable;
    private void Refresh()
    {
        damageable = GetComponent<Damageable>();
        maxHealth = damageable.Maxhealth;
        health = maxHealth;
        if(healthbarobj == null)
        {
            healthbarobj = GameObject.Find("HealthBarin");
        }
        if(TargetText == null) 
        {
            TargetText = GameObject.Find("HealthBarText");
        }
    }
    private void DecreaseHealth()
    {
        health = maxHealth - Time.time;
    }
    private void GetHealth()
    {
        health = damageable.Health;
    }
    void Start()
    {
        Refresh();
        rtr = healthbarobj.GetComponent<RectTransform>();
        HealthBartext = TargetText.GetComponent<TextMeshProUGUI>();
        HealthBartext.text = $"{health:f0}/{maxHealth:f0}";
    }

    // Update is called once per frame
    void Update()
    {
        GetHealth();
        rtr.localScale= new (health / maxHealth,1f,1f);
        HealthBartext.text = $"{health:f0}/{maxHealth:f0}";
    }
    public void RefreshMax()
    {
        maxHealth = damageable.Maxhealth;
    }
}
