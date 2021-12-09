using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public BulletSpwan bulletSpawn;
    public GameObject player;
    Transform target;

    void Start()
    {
        player = GameObject.Find("Player");
        target = player.transform;

        Invoke("ShootBullets",0.5f);

    }


    void Update()
    {
       
        var offset = 90f;
        Vector2 direction = target.position - transform.position; //get the direction of the target.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;// to set angle wrt to position of target.
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));//rotate towards target with initial offset

    }


    public void ShootBullets()
    {
        bulletSpawn.ShootBullets();
    }

}
