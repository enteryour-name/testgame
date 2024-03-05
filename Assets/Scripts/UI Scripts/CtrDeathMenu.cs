using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CtrDeathMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private CanvasRenderer canvasRenderer;
    public GameObject deathmenu;
    private bool dead = false;
    public CtrGenerateCharacter ctrGenerateCharacter;
    public CtrPlayerHealth health;

    void Start()
    {
        if(ctrGenerateCharacter.Refreshtime == 0)
        {
            ctrGenerateCharacter.Refresh();
        }
        health = ctrGenerateCharacter.character.GetComponent<CtrPlayerHealth>();
        deathmenu.SetActive(false);
        if(deathmenu == null)
        {
            deathmenu = GameObject.Find("EndMenu");
        }
    }


    IEnumerator WaitForDeath(float time)
    {
        yield return new WaitForSeconds(time);
        deathmenu.SetActive(true);
        Time.timeScale = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (health == null)
        { }
        else if (health.health <= 0 && !dead)
        {
            Time.timeScale = 0.3f;
            StartCoroutine(WaitForDeath(2));
            dead = true;
        }
    }
}
