using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrLevelUpMenu : MonoBehaviour
{
    public Damageable damageable;
    public GameObject character;
    public GameObject levelUpMenu;
    public CtrGenerateCharacter ctrGenerateCharacter;
    public Monster2Attack[] monster2Attack;
    public float damageUpTime = 1.3f;
    public CtrSkill ctrSkill;
    public CtrLevelUpSkill ctrLevelUpSkill;
    public int skillnum;
    public void DamageUp()
    {
        monster2Attack = character.GetComponentsInChildren<Monster2Attack>();
        foreach (Monster2Attack monsterAttack in monster2Attack)
        {
            monsterAttack.attackDamage = (int)((float)monsterAttack.attackDamage * damageUpTime);
        }
        MadeChoice();
    }
    public void HealthUp()
    {
        damageable.Maxhealth += 50f;
        character.GetComponent<CtrPlayerHealth>().RefreshMax();
        damageable.Health += 50f;
        MadeChoice();
    }
    public void AcquireSkill()
    {
        ctrSkill.enabled = true;
        switch(skillnum)
        {
            case 3: ctrSkill.canskill3 = true; break;
            case 4: ctrSkill.canskill4 = true; break;
            case 5: ctrSkill.canskill5 = true; break;
        }
        GetSkillNum();
        MadeChoice();
    }
    public void MadeChoice()
    {
        Time.timeScale = 1;
        levelUpMenu.SetActive(false); 
    }
    private void Start()
    {

        character = ctrGenerateCharacter.character;
        damageable = character.GetComponent<Damageable>();
        ctrSkill = character.GetComponent<CtrSkill>();
        GetSkillNum();
    }
    void GetSkillNum()
    {

        if (ctrSkill.canskill3)
        {
            if (ctrSkill.canskill4)
            {
                if (ctrSkill.canskill5)
                    skillnum = 1;
                else
                    skillnum = 5;
            }
            else
            {
                skillnum = 4;
            }

        }
        else
        {
            if (ctrSkill.canskill4)
                skillnum = 3;
            else
            {
                skillnum = 3 + (int)Time.time % 2;
            }
        }
    }

    void Update()
    {
        
    }

}
