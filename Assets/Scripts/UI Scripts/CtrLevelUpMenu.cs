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
        ctrSkill.canskill3 = true;
        ctrSkill.canskill4 = true;
        ctrSkill.canskill5 = true;
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
    }
    void Update()
    {
        
    }
}
