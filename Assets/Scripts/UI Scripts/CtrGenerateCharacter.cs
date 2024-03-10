using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CtrGenerateCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject character1;
    public GameObject character2;
    public GameObject character;
    public ctrcommunication commu;
    public int defaultvalue = 1;
    public int receivevalue = 0;
    [SerializeField] private CinemachineVirtualCamera camera;
    public GameObject FireSkillUI;
    public GameObject LeafSkillUI;
    public StorageData storageData;
    public bool haveAwake = false;
    public CtrExpLevel expLevel;
    public CtrLevelUpMenu levelUpMenu;
    public int Round;
    public CtrLevelUpSkill ctrLevelUpSkill;
    void generate()
    {
        if (receivevalue == 1)
        {
            character = character1;
            character1.SetActive(true);
            character2.SetActive(false);
            FireSkillUI.SetActive(true);
            LeafSkillUI.SetActive(false);
            foreach(Image im in FireSkillUI.transform.GetComponentsInChildren<Image>())
            {
                im.gameObject.SetActive(false);
            }
        }
        else if (receivevalue == 2)
        {
            character = character2;
            character1.SetActive(false);
            character2.SetActive(true);
            FireSkillUI.SetActive(false);
            LeafSkillUI.SetActive(true);
            foreach (Image im in LeafSkillUI.transform.GetComponentsInChildren<Image>())
            {
                im.gameObject.SetActive(false);
            }
        }
        camera.LookAt = character.transform;
        camera.Follow = character.transform;
    }
    void Awake()
    {
        StartBeforeEvery();
    }
    public int Refreshtime = 0;
    public void Refresh()
    {
        
        camera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
        if(character1 == null)
        {
            character1 = GameObject.Find("fire_FREE_SpriteSheet_288x128_0 ");
        }
        if(character2 == null)
        {
            character2 = GameObject.Find("Elementals_leaf_ranger_288x128_SpriteSheet_0");
        }
        commu = GameObject.FindObjectOfType<ctrcommunication>();

        if (commu == null)
        {
            receivevalue = defaultvalue;
        }
        else
        {
            receivevalue = commu.character;
        }
        if (Round != 1)
            receivevalue = PlayerPrefs.GetInt("character");
        generate();
        Refreshtime++;
    }
    public void StartBeforeEvery()
    {
        if (!haveAwake)
        {
            Refresh();
            if (Round != 1)
                Load();
            haveAwake = true;
            ctrLevelUpSkill.enabled = true;
            ctrLevelUpSkill.SetSkillsUI();
            ctrLevelUpSkill.SetSkillsUI();
            ctrLevelUpSkill.SetSkillsUI();
            ctrLevelUpSkill.enabled = false;
        }
    }
    public void Load()
    {
        character.GetComponent<CtrSkill>().enabled = true;
        expLevel.exp = PlayerPrefs.GetFloat("exp");
        expLevel.level = PlayerPrefs.GetInt("level");
        levelUpMenu.damageUp = PlayerPrefs.GetFloat("DamageUp");
        character.GetComponent<CtrSkill>().canskill3 = PlayerPrefs.GetFloat("skill3") == 1;
        character.GetComponent<CtrSkill>().canskill4 = PlayerPrefs.GetFloat("skill4") == 1;
        character.GetComponent<CtrSkill>().canskill5 = PlayerPrefs.GetFloat("skill5") == 1;
        character.GetComponent<Damageable>().Maxhealth = PlayerPrefs.GetFloat("maxHealth");
        character.GetComponent<Damageable>().Health = PlayerPrefs.GetFloat("health");
        character.GetComponent<CtrSkill>().refresh();
    }
}
