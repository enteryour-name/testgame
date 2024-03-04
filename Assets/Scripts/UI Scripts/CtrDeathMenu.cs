using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CtrDeathMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private CanvasRenderer canvasRenderer;
    public GameObject deathmenu;
    private bool ispause = true;
[SerializeField]    private CtrPlayerHealth health;

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
        ChangeDeadMenu();
    }
    void ChangeDeadMenu()
    {
        deathmenu.SetActive(ispause);
        Time.timeScale = 1.0f;
        Time.timeScale = 0f;
        return;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(health.health);
        if (health.health <= 0)
        {
            ispause = true;
            Time.timeScale = 0.5f;
            StartCoroutine(WaitForDeath(3));
        }
    }
}
