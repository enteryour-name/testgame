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
[SerializeField]   public CtrPlayerHealth health;

    void Start()
    {
        StartCoroutine(WaitForSeconds(0.01f));
    }
    IEnumerator WaitForSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        health = GameObject.FindObjectOfType<CtrPlayerHealth>();
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
        Debug.Log("pause");
    }
    // Update is called once per frame
    void Update()
    {
        if (health == null)
        { }
        else if (health.health <= 0 && !dead)
        {
            Time.timeScale = 0.5f;
            StartCoroutine(WaitForDeath(2));
            dead = true;
        }
    }
}
