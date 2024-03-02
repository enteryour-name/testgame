using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CtrPauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private CanvasRenderer canvasRenderer;
    public GameObject pausemenu;
    private bool ispause = true;
    
    void Start()
    {
        pausemenu.SetActive(false);
        Debug.Log("Start!");
    }
    void ChangePauseMenu()
    {
        pausemenu.SetActive(ispause);
        Debug.Log(ispause);
        if(ispause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        ispause = !ispause;
    }
    void ChangePauseMenuForButton()
    {
        pausemenu.SetActive(ispause);
        Debug.Log(ispause);
        if (ispause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        ispause = !ispause;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePauseMenu();
        }
    }
}
