using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;


    void OnEnable()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;


    }
}
