using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrcommunication : MonoBehaviour
{
    public int character = 2;//1 >> Fire Knight , 2 >> Leaf Ranger
    // Start is called before the first frame update
    public ctrcommunication commu;
    private void FixedUpdate()
    {
        if (commu == null)
        {
            Debug.Log("error");
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
