using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponlaucher : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform lauchpoint;
    public void fireweapon()
    {
        GameObject bullet= Instantiate(bulletPrefab,lauchpoint.position,bulletPrefab.transform.rotation);
        Vector3 originScale = bullet.transform.localScale;
        bullet.transform.localScale = new Vector3(
            originScale.x*transform.localScale.x>0?1:-1, originScale.y,originScale.z
            );
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
