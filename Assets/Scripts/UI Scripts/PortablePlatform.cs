using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortablePlatform : MonoBehaviour
{
    private Transform tr;
    private float startTime;
    private Vector3 startPos;
    public float amplitude;
    public float speed;
    public float start;
    private float startoffset;
    public Vector2 vec;
    public Transform player;
    public Transform platform;
    public Transform enemy;
    public Transform enemy2;
    public Rigidbody2D rigidbody2;
    public CtrGenerateCharacter ctrGenerateCharacter;
    public GameObject character1;
    Rigidbody2D rb;
   
    // Start is called before the first frame update
    void Start()
    {
        character1 = ctrGenerateCharacter.character;
        rb=character1.GetComponent<Rigidbody2D>();
        rigidbody2=GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        startPos = transform.position;
        start =3* Random.value;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        vec= new Vector3(amplitude * Mathf.Sin((0.8f * speed + 0.5f * startoffset) * (Time.time - startTime) + start), 0,0);
        platform.transform.position =startPos +new Vector3 (amplitude * Mathf.Sin((0.8f*speed+0.5f * startoffset) * (Time.time-startTime) + start) ,0,0);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        

        if (collision.CompareTag("Player"))
        {
            
            character1.transform.position += new Vector3(amplitude * Mathf.Cos((0.8f * speed + 0.5f * startoffset) * (Time.time - startTime) + start), 0, 0)*Time.deltaTime;
           
        }
        if (collision.CompareTag("Enemy"))
        {

            enemy.transform.position += new Vector3(amplitude * Mathf.Cos((0.8f * speed + 0.5f * startoffset) * (Time.time - startTime) + start), 0, 0) * Time.deltaTime;

        }
        if (collision.CompareTag("Enemy2"))
        {

            enemy2.transform.position += new Vector3(amplitude * Mathf.Cos((0.8f * speed + 0.5f * startoffset) * (Time.time - startTime) + start), 0, 0) * Time.deltaTime;

        }


    }
    
}
