using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorageData : MonoBehaviour
{
    public CtrGenerateCharacter ctrGenerateCharacter;
    public CtrExpLevel expLevel;
    public CtrLevelUpMenu levelUpMenu;
    private Damageable damageable;
    private string storgeName;
    // Start is called before the first frame update
    public void StorgePlayerData()
    {
        GameObject character = ctrGenerateCharacter.character;
        character.GetComponent<CtrSkill>().enabled = true;
        PlayerPrefs.SetInt("character",ctrGenerateCharacter.receivevalue);
        PlayerPrefs.SetString("Round",$"Round{ctrGenerateCharacter.Round}");
        PlayerPrefs.SetFloat("exp", expLevel.exp);
        PlayerPrefs.SetInt("level", expLevel.level);
        PlayerPrefs.SetFloat("DamageUp", levelUpMenu.damageUp);
        PlayerPrefs.SetFloat("skill3", character.GetComponent<CtrSkill>().canskill3 ? 1 : 0);
        PlayerPrefs.SetFloat("skill4", character.GetComponent<CtrSkill>().canskill4 ? 1 : 0);
        PlayerPrefs.SetFloat("skill5", character.GetComponent<CtrSkill>().canskill5 ? 1 : 0);
        PlayerPrefs.SetFloat("maxHealth", character.GetComponent<Damageable>().Maxhealth);
        PlayerPrefs.SetFloat("health",character.GetComponent<Damageable>().Health);
        character.GetComponent<CtrSkill>().enabled = false;
    }
    public void LoadPlayerData()
    {
        ctrGenerateCharacter.receivevalue = PlayerPrefs.GetInt("character");
        ctrGenerateCharacter.character = ctrGenerateCharacter.receivevalue==1?ctrGenerateCharacter.character1 :ctrGenerateCharacter.character2;
        GameObject character = ctrGenerateCharacter.character;
        character.GetComponent<CtrSkill>().enabled = true;
        SceneManager.LoadScene(PlayerPrefs.GetString("Round"));
        expLevel.exp = PlayerPrefs.GetFloat("exp");
        expLevel.level = PlayerPrefs.GetInt("level");
        levelUpMenu.damageUp = PlayerPrefs.GetFloat("DamageUp");
        character.GetComponent<CtrSkill>().canskill3 = PlayerPrefs.GetFloat("skill3") == 1;
        character.GetComponent<CtrSkill>().canskill4 = PlayerPrefs.GetFloat("skill4") == 1;
        character.GetComponent<CtrSkill>().canskill5 = PlayerPrefs.GetFloat("skill5") == 1;
        character.GetComponent<Damageable>().Maxhealth = PlayerPrefs.GetFloat("maxHealth");
        character.GetComponent<Damageable>().Health = PlayerPrefs.GetFloat("health");
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
