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
    public int skillnum;
    public GameObject arrowprefab;
    public void DamageUp()
    {
        monster2Attack = character.GetComponentsInChildren<Monster2Attack>();
        foreach (Monster2Attack monsterAttack in monster2Attack)
        {
            monsterAttack.attackDamage = (int)Mathf.Round((float)monsterAttack.attackDamage * damageUpTime);
        }
        arrowprefab.GetComponent<newbullet>().damage = (int)((float)arrowprefab.GetComponent<newbullet>().damage * damageUpTime);
        MadeChoice();
        GetSkillNum();
    }
    public void HealthUp()
    {
        damageable.Maxhealth += 50f;
        character.GetComponent<CtrPlayerHealth>().RefreshMax();
        damageable.Health += 50f;       
        MadeChoice();
        GetSkillNum();
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
        StartCoroutine(waitforchoose(0.5f));
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
            {
                skillnum = 3;
            }
            else
            {
                skillnum = 3 + (int)(Random.value * 2) % 2;
            }
        }
    }
    public int GetOtherNum()
    {
        return (int)(Random.value * 2) % 2;
    }
    IEnumerator waitforchoose(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        MadeChoice();
        GetSkillNum();
    }

    void Update()
    {
        
    }

}
