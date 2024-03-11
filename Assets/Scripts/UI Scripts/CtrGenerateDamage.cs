using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CtrGenerateDamage : MonoBehaviour
{
    public GameObject textObj;
    private Damageable damageable;
    private TextMeshPro textMeshPro;
    private float pastHealth;
    private float nowHealth;
    private float damage;

    // Start is called before the first frame update
    void Start()
    {
        damageable = gameObject.GetComponent<Damageable>();
        pastHealth = damageable.Health;
    }

    // Update is called once per frame
    void Update()
    {
        damage = pastHealth-damageable.Health;
        if(damage != 0)
        {
            GenerateText();
            pastHealth = damageable.Health;
        }
        
    }
    void GenerateText()
    {
        Debug.Log("Generate!");
        GameObject gameObject = Instantiate(textObj,Vector3.zero,Quaternion.identity, transform);
        textMeshPro = gameObject.GetComponent<TextMeshPro>();
        textMeshPro.text = $"{damage}";
        Destroy(gameObject, gameObject.GetComponent<CtrDamagePrint>().time);
    }

}
