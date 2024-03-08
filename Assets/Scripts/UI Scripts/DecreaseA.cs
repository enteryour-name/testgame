using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DecreaseA : MonoBehaviour
{
    public float speed = 0.000001f;
    private float starttime;
    public void Decrease()
    {
        starttime = Time.time;
        Color color = GetComponent<TilemapRenderer>().material.color;
        for (int i =0; color.a > 0 && Time.time <10 && i<100000;i++)
        {
            color.a = 1 - speed * (float)i;
            Debug.Log(color.a);
        }
    } 
}
