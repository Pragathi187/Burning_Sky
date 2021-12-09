using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{

    public int health;
   
    public GameObject explosion;
    public GameController gameController;


    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
        this.GetComponent<DestroyOnContact>().explosion = (GameObject)GameObject.Find("CartoonBlast_Enemy");

    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        
           if (other.gameObject.tag == "bullet")
            {
                if (health < 0)
                {
                    explosion.transform.position = this.transform.position;
                    explosion.GetComponent<ParticleSystem>().Play();
                    this.gameObject.SetActive(false);
                    gameController.score += 2;
                    gameController.scoreText.text = "Score: " + gameController.score.ToString();
                    FindObjectOfType<AudioManager>().GetComponent<AudioManager>().PlayAudio(0);


                }

                else
                {
                     health -= 1;
                     other.gameObject.SetActive(false);
                }
            }
            if (other.gameObject.tag == "Boundary")
            {
                 Destroy(this.gameObject);

             }

            if (other.gameObject.tag == "Player")
            {

            explosion.transform.position = this.transform.position;
            explosion.GetComponent<ParticleSystem>().Play();
            gameController.score += 2;
            gameController.scoreText.text = "Score: " + gameController.score.ToString();
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().GetComponent<AudioManager>().PlayAudio(0);
            }
        if (other.gameObject.tag == "Shield")
        {
            explosion.transform.position = this.transform.position;
            explosion.GetComponent<ParticleSystem>().Play();
            gameController.score += 2;
            gameController.scoreText.text = "Score: " + gameController.score.ToString();
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().GetComponent<AudioManager>().PlayAudio(0);

        }

    }

    
}
