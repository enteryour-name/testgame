using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CtrExpLevel : MonoBehaviour
{
    public TextMeshProUGUI ExpBartext;
    public TextMeshProUGUI LvText;
    public RectTransform TargetExpBar;
    public float exp = 0;
    public int level = 1;
    public float[] maxexp = {0,100,120,160,250,400,10000};
    public Damageable damageable;
    public GameObject LevelUpMenu;
    // Start is called before the first frame update
    void Start()
    {
        LevelUpMenu.SetActive(false);
    }

    // Update is called once per frame
    void Normal()
    {
        if(exp >= maxexp[level])
        {
            exp -= maxexp[level];
            level++;
            LvText.text = $"Lv.{level}";
            damageable.Health = damageable.Maxhealth;
            LevelUpMenu.SetActive(true);
            Time.timeScale = 0f;
            //
        }
        ExpBartext.text = $"{exp:f0}/{maxexp[level]:f0}";
        TargetExpBar.localScale = new Vector3 (exp / maxexp[level],1,0);
    }
    public void MadeChoice()
    {
        Time.timeScale = 1;
        LevelUpMenu.SetActive (false);
    }
    private void Update()
    {
        if(level <= 5)
        {
            Normal();
        }
        else
        {
            ExpBartext.text = "Lv.Max";
            TargetExpBar.localScale = new Vector3(0, 0, 0);
        }
    }
}
