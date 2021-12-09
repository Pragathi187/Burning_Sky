using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{


    //turn off the gameobject once they exist the boundary
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
           
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "enemyBullet")
        {
            other.gameObject.SetActive(false);
        }


    }

    
}

       

