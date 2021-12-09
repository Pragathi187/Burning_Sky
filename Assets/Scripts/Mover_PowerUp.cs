using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_PowerUp : MonoBehaviour
{
    private float powerupSpeed = -3f;
    private Rigidbody2D rigidBody;
    public GameController gameController;
    void Start()
    {
        gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(0, powerupSpeed);
    }

    private void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("bullet"))
        {
            this.gameObject.SetActive(false);
            gameController.powerUpScore += 1;
           
        }

        if (other.gameObject.tag.Equals("Player"))
        {
            this.gameObject.SetActive(false);
            gameController.powerUpScore += 1;
        }
    }
}
