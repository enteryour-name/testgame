using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        Destroy(GameObject.FindObjectOfType<DontDestroy>().gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
