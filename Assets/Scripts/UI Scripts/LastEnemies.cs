using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LastEnemies : MonoBehaviour
{
    public GameObject[] lastEnemies;
    public GameObject victory;
    // Start is called before the first frame update
    void Start()
    {
        victory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!lastEnemies.Any(t=> t != null))
        {
            victory.SetActive(true);
        }
    }
}
