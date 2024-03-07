using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CtrLevelUpSkill : MonoBehaviour
{
    public int skillnum;
    public Sprite skill13;
    public Sprite skill14;
    public Sprite skill15;
    public Sprite skill23;
    public Sprite skill24;
    public Sprite skill25;
    public GameObject FATK3;
    public GameObject FATK4;
    public GameObject FATK5;
    public GameObject LATK3;
    public GameObject LATK4;
    public GameObject LATK5;
    public Image image;
    public CtrGenerateCharacter ctrGenerateCharacter;
    public CtrLevelUpMenu ctrLevelUpMenu;
[SerializeField]    private GameObject character;
[SerializeField]    private CtrSkill ctrSkill;
    private bool haveset= false;
    private bool haveset1 = false;
    private bool haveset2 = false;
    private bool haveset3 = false;

    // Start is called before the first frame update
    // Update is called once per frame
    private void OnEnable()
    {
        haveset = false;
        skillnum = 10 * ctrGenerateCharacter.receivevalue + ctrLevelUpMenu.skillnum;
        switch (skillnum)
        {
            case 13: image.sprite = skill13; break;
            case 14: image.sprite = skill14; break;
            case 15: image.sprite = skill15; break;
            case 23: image.sprite = skill23; break;
            case 24: image.sprite = skill24; break;
            case 25: image.sprite = skill25; break;
            default: break;
        }
    }
    private void Start()
    {
        haveset = false;
        image = GetComponent<Image>();
        character = ctrGenerateCharacter.character;
        ctrSkill = character.GetComponent<CtrSkill>();
    }
    public void Update()
    {
        if(!haveset)
        {
            if(ctrSkill.canskill3 && !haveset1)
            {
                if(ctrGenerateCharacter.receivevalue ==1)
                {                    
                    FATK3.SetActive(true);
                    haveset = true;
                    haveset1 = true;
                }
                else
                {
                    LATK3.SetActive(true) ;
                    haveset = true;
                    haveset1 = true;
                }
            }
            if (ctrSkill.canskill4 && !haveset2)
            {
                if (ctrGenerateCharacter.receivevalue == 1)
                {
                    FATK4.SetActive(true);
                    haveset = true;
                    haveset2 = true;
                }
                else
                {
                    LATK4.SetActive(true);
                    haveset = true;
                    haveset2 = true;
                }
            }
            if (ctrSkill.canskill5 && !haveset3)
            {
                if (ctrGenerateCharacter.receivevalue == 1)
                {
                    FATK5.SetActive(true);
                    haveset = true;
                    haveset3 = true;
                }
                else
                {
                    LATK5.SetActive(true);
                    haveset = true;
                    haveset3 = true;
                }
            }
        }

    }
        
        
    
}
