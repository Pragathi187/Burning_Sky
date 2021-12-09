using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyMovement : MonoBehaviour
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
      

    }


    public void Shoot()
    {
        GameObject go = Instantiate(bulletPrefab, spwanPosition.position, Quaternion.identity) as GameObject;
        go.transform.parent = this.transform;
    }

}
