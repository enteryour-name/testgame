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
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        startPos = transform.position;
        start =3* Random.value;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =startPos +new Vector3 (amplitude * Mathf.Sin((0.8f*speed+0.5f * startoffset) * (Time.time-startTime) + start) ,0,0);
    }
}
