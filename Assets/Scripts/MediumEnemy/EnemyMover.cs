using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public GameObject bulletPrefab;
    public Transform spwanPosition;
    

    public float fireRate;
    public float delay;
    public GameObject player;
    Transform target;

    void Start()
    {
        player = GameObject.Find("Player");
        target = player.transform;

        InvokeRepeating("Shoot", delay, fireRate);

    }


    void Update()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        var offset = 90f;
        Vector2 direction = target.position - transform.position; //get the direction of the target.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;// to set angle wrt to position of target.
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));//rotate towards target with initial offset

    }

    
    public void Shoot()
    {
       GameObject go= Instantiate(bulletPrefab, spwanPosition.position, Quaternion.identity) as GameObject;
       go.transform.parent = this.transform;
    }


}
