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
    void generate()
    {
        if(go == null)
        { Debug.Log("error"); }
        if(commu == null)
        { Debug.Log("commu!"); }
       if(commu.character == 1)
        {
            character2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            character2.GetComponent<SpriteRenderer>().enabled = false;
            character2.GetComponent<Collider2D>().enabled = false;
        }
       else if(commu.character == 2)
        {
            character1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            character1.GetComponent<SpriteRenderer>().enabled = false;
            character1.GetComponent<Collider2D>().enabled = false;
        }
    }
    void Start()
    {
        commu = GameObject.FindObjectOfType<ctrcommunication>();
        generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
