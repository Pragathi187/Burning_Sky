using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrolling : MonoBehaviour
{
    [SerializeField]
    private float bg_Speed = -.2f; //bg scrolling speed

    void Start()
    {

    }


    void Update()
    {
        transform.Translate(0f, bg_Speed * Time.deltaTime, 0f);
        if (transform.position.y <= -59.5f) // Check if bg has reached screen limits, then bring back to highest position.
        {
            transform.Translate(0f, 72.1f, 0f);
        }
    }
}
