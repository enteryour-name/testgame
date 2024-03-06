using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CtrDamagePrint : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro TextMeshPro;
    public float speed = 1f;
    public float maxsize = 1f;
    void Start()
    {
        TextMeshPro = GetComponent<TextMeshPro>();
        this.enabled = false;
    }
    IEnumerable DestroIt(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
