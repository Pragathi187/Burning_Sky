using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpwan : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject Parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void ShootBullets()
    {

        Vector3 spawnPos = this.transform.parent.position + new Vector3(0, 0, 0);
        GameObject go=Instantiate(bulletPrefab, spawnPos, transform.parent.rotation);
        go.transform.parent = Parent.transform;
        Invoke("ShootBullets", 0.35f);  // spawn bullets every .35s 
    }
}
