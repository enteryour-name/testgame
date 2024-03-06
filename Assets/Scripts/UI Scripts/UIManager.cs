using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject damagetextPrefab;
    public GameObject healthtextPrefab;
    public Canvas gamecanvas;
    private void Awake()
    {
        gamecanvas=FindObjectOfType<Canvas>();
    }
    public void Charactertookdamage(GameObject character,int damagerecevied)
    {
        Vector3 spawnposition=Camera.main.WorldToScreenPoint(character.transform.position);
        TMP_Text tmpText=Instantiate(damagetextPrefab,spawnposition,Quaternion.identity,gamecanvas.transform).GetComponent<TMP_Text>();
        tmpText.text=damagerecevied.ToString();
    }
    public void Characterhealed(GameObject character, int healthrestored)
    {
        Vector3 spawnposition = Camera.main.WorldToScreenPoint(character.transform.position);
        TMP_Text tmpText = Instantiate(damagetextPrefab, spawnposition, Quaternion.identity, gamecanvas.transform).GetComponent<TMP_Text>();
        tmpText.text = healthrestored.ToString();
    }
    public void CharacterHealed()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
