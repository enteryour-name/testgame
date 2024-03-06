using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

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
    void generate()
    {
        if (receivevalue == 1)
        {
            character = character1;
            character1.SetActive(true);
            character2.SetActive(false);
            FireSkillUI.SetActive(true);
            LeafSkillUI.SetActive(false);
        }
        else if (receivevalue == 2)
        {
            character = character2;
            character1.SetActive(false);
            character2.SetActive(true);
            FireSkillUI.SetActive(false);
            LeafSkillUI.SetActive(true);
        }
        camera.LookAt = character.transform;
        camera.Follow = character.transform;
    }
    void Awake()
    {
        Refresh();
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
        generate();
        Refreshtime++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
