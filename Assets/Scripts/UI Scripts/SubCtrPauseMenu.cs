using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCtrPauseMenu : MonoBehaviour
{
    private CanvasRenderer canvasRenderer;
    public GameObject pausemenu;
    private bool ispause = true;
    public void ChangePauseMenuForButton()
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
    public void BackToMainStart()
    {
        Time.timeScale = 1;
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
