using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrGenerateCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject character1;
    public GameObject character2;
    public ctrcommunication commu;
    private GameObject go;
    public int defaultvalue = 1;
    [SerializeField] private CinemachineVirtualCamera camera;
    void generate()
    {
       if(commu == null)
        {
            commu = new ctrcommunication();
            commu.character = defaultvalue;
        }
       if(commu.character == 1)
        {
            camera.LookAt = character1.transform;
            camera.Follow = character1.transform;
            character1.SetActive(true);
            character2.SetActive(false);
        }
       else if(commu.character == 2)
        {
            camera.LookAt = character2.transform;
            camera.Follow = character2.transform;
            character1.SetActive(false);
            character2.SetActive(true);
        }
    }
    void Start()
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
        generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
