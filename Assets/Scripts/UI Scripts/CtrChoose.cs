using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrChoose : MonoBehaviour
{
    // Start is called before the first frame update
    public string choose;
    public GameObject Targetobject;
    public ctrcommunication commu;
    public void sending()
    {
       
        if (choose == "FireKnight")
        {
            commu.character = 1;
            Debug.Log("sending"+commu.character);
        }
        else if (choose == "LeafRanger")
        {
            commu.character = 2;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
