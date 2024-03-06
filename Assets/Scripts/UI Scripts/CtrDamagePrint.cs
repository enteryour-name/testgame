using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CtrDamagePrint : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro TextMeshPro;
    public RectTransform recttransform;
    public float speed = 1f;
    public float maxsize = 1f;
    public float time = 3f;
    public float offset = 0f;
    private float starttime;
    void Start()
    {
        starttime = 0;
        TextMeshPro = GetComponent<TextMeshPro>();
        recttransform = GetComponent<RectTransform>();
        starttime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        recttransform.localScale = new Vector3((Time.time - starttime) / time * maxsize, (Time.time-starttime)/time*maxsize, 1);
        recttransform.localPosition = new Vector3(0, offset + (Time.time - starttime) * speed, -1);
        if(transform.parent.localScale.x <0 )
        {
            recttransform.localScale = new Vector3(-recttransform.localScale.x, recttransform.localScale.x, 1);
        }
    }
}
