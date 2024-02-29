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
        Refresh();
        rtr = healthbarobj.GetComponent<RectTransform>();
        HealthBartext = TargetText.GetComponent<TextMeshProUGUI>();
        HealthBartext.text = $"{health:f0}/{maxHealth:f0}";
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseHealth();
        rtr.localScale= new (health / maxHealth,1f,1f);
        HealthBartext.text = $"{health:f0}/{maxHealth:f0}";
    }
}
