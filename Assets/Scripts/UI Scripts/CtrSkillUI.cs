using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrSkillUI : MonoBehaviour
{
    public GameObject FATK3;
    public GameObject FATK4;
    public GameObject FATK5;
    public GameObject LATK3;
    public GameObject LATK4;
    public GameObject LATK5;
    public CtrGenerateCharacter ctrGenerateCharacter;
    public CtrLevelUpMenu ctrLevelUpMenu;
    [SerializeField] private GameObject character;
    public CtrSkill ctrSkill;
    private bool haveset = false;
    private bool haveset1 = false;
    private bool haveset2 = false;
    private bool haveset3 = false;
    private float skillnum = 0;
    // Start is called before the first frame update
    void Start()
    {
        ctrGenerateCharacter.StartBeforeEvery();
        haveset = false;
        character = ctrGenerateCharacter.character;
        ctrSkill = character.GetComponent<CtrSkill>();
    }
    private void OnEnable()
    {
        haveset = false;
        skillnum = 10 * ctrGenerateCharacter.receivevalue + ctrLevelUpMenu.skillnum;
    }
    // Update is called once per frame
    void Update()
    {
        SetSkillsUI();
    }
    public void SetSkillsUI()
    {
        if (!haveset)
        {
            if (ctrSkill.canskill3 && !haveset1)
            {
                if (ctrGenerateCharacter.receivevalue == 1)
                {
                    FATK3.SetActive(true);
                    haveset1 = true;
                }
                else
                {
                    LATK3.SetActive(true);
                    haveset1 = true;
                }
            }
            if (ctrSkill.canskill4 && !haveset2)
            {
                if (ctrGenerateCharacter.receivevalue == 1)
                {
                    FATK4.SetActive(true);
                    haveset2 = true;
                }
                else
                {
                    LATK4.SetActive(true);
                    haveset2 = true;
                }
            }
            if (ctrSkill.canskill5 && !haveset3)
            {
                if (ctrGenerateCharacter.receivevalue == 1)
                {
                    FATK5.SetActive(true);
                    haveset3 = true;
                }
                else
                {
                    LATK5.SetActive(true);
                    haveset3 = true;
                }
            }
        }
    }
}
