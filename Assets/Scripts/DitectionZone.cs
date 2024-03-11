using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DitectionZone : MonoBehaviour
{
   
    public List<Collider2D> detectedColiders = new List<Collider2D>();
    Collider2D col;
    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        detectedColiders.Add(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        detectedColiders.Remove(collision);
    }
}
