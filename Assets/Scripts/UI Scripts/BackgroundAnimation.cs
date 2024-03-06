using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Mathematics;

public class BackgroundAnimation : MonoBehaviour
{
    public float speed = 1f;
    public float amplitudeX = 0.5f;
    public float amplitudeY = 1f;
    public float frequency = 1f;
    public float sita = 30f;
    Transform transform = null;
    private Vector3 startPos;
    void newmove()
    {
        float3 delmove = new float3(speed, 0,0);
        delmove = new Vector3(speed + (float)Mathf.Sin(Time.time * frequency) * amplitudeX, (float)Mathf.Cos(Time.time * frequency) * amplitudeY,0f);
        transform.position += new Vector3(math.cos(sita) * delmove.x+math.sin(sita)*delmove.y, math.sin(sita) * delmove.x+math.cos(sita)*delmove.y,0);

    }
    void Start()
    {
        sita = sita / 180f * 3.14f;
        transform = GetComponent<Transform>();
        startPos = transform.position;
    }
    void ovalmove()
    {
        float newY = Mathf.Sin(Time.time * frequency) * amplitudeX;
        float newX = Mathf.Cos(Time.time * frequency) * amplitudeY;
        float3 posivect = startPos + new Vector3((float)Math.Cos(sita) * newX + (float)Math.Sin(sita) * newY, -(float)Math.Sin(sita) * newX + (float)Math.Cos(sita) * newY, 0f) * speed;
        float3 transposi = transform.position;
        if (posivect.x > 484)
        {
            transposi.x = 2 * 484 - posivect.x;
        }
        else if (posivect.x < -484)
        {
            transposi.x = 2*-484-posivect.x;
        }
        else
        {
            transposi.x = posivect.x;
        }
        if (posivect.y > 221)
        {
            transposi.y = 2 * 221 - posivect.y;
        }
        else if (posivect.y < -221)
        {
            transposi =2*-221 -posivect.y;
        }
        else { transposi = posivect.y; }
        transform.position = transposi;
    }
    void Update()
    {
        newmove();
    }
}
