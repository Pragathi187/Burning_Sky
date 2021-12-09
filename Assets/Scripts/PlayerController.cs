using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    

    public float playerSpeed = 10f;
    public Transform shotSpawn;
    public int health;
    public GameObject playerExplosion;
    public Text HealthText;
    public GameController gameController;

    float spawnWait = 1f;
    float startWait = 1f;
    float waveWait = 4f;
    public int powerUpsPerWave = 4;
    public GameObject powerUpprefab;

    bool shieldenable = false;
   
    public GameObject shield;

    void Start()
    {
        gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
        Invoke("shootBullets", 0f);
        this.playerExplosion = (GameObject)GameObject.Find("CartoonBlast_Player");
        HealthText.text = health.ToString();
        InvokeRepeating("ShootPowerUps", 5f,40f);
    }

    // Update is called once per frame
    void Update()
    {
        

       
        HealthText.text = "Health: " + health.ToString();
        Movement();
        
        if(gameController.powerUpScore>2)
        {
            
            StopCoroutine("SpawnPowerUps");
            shieldenable = true;

            if (shieldenable)
            {
                EnableShield();
                shieldenable = false;
            }
           

        }
    }

    void Movement() //move the player with arrow keys.
    {
        Boundary();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * playerSpeed * Time.deltaTime);
    }


    void Boundary() //restrict player movement out of boundary
    {
        float xClamp = Mathf.Clamp(transform.position.x, -8, 8);
        float yClamp = Mathf.Clamp(transform.position.y, -3, 3);
        transform.position = new Vector3(xClamp, yClamp, 0);
    }


    public void shootBullets()
    {
        GameObject bullet = gameObject.GetComponent<BulletPooler>().GetPooledObject();

        if (bullet != null)
        {

            bullet.transform.position = shotSpawn.transform.position;
            bullet.transform.rotation = shotSpawn.transform.rotation;
            bullet.SetActive(true);


        }

        Invoke("shootBullets", 0.5f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("enemyBullet"))
        {
            if (health <= 0)
            {

                other.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
                playerExplosion.transform.position = other.transform.position;
                playerExplosion.GetComponent<ParticleSystem>().Play();
               FindObjectOfType<AudioManager>().GetComponent<AudioManager>().PlayAudio(1);
                Invoke("GameOver", 0.5f);

            }
            else
            {
                other.gameObject.SetActive(false);
                health -= 1;
            }
        }
        if (other.gameObject.tag.Equals("Enemy1"))
        {
            health -= 2;
        }
        if (other.gameObject.tag.Equals("Enemy2"))
        {
            health -= 2;
        }
        if (other.gameObject.tag.Equals("Enemy3"))
        {
            health -= 1;
        }
    }

    public void GameOver()
    {

        FindObjectOfType<GameController>().GetComponent<GameController>().GameOver();
    }
    void ShootPowerUps()
    {
        StartCoroutine("SpawnPowerUps");
    }

    IEnumerator SpawnPowerUps()
    {
        yield return new WaitForSeconds(startWait);
       
        for (int i = 0; i < powerUpsPerWave; i++)
        {


            Vector3 spawn = new Vector3(Random.Range(-6f, 6f), 7f, 0);
            Instantiate(powerUpprefab, spawn, Quaternion.identity);


            yield return new WaitForSeconds(spawnWait);
        }
        yield return new WaitForSeconds(waveWait);
    }

    void EnableShield()
    {
        shield.SetActive(true);
        gameController.powerUpScore = 0;
        
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(WaitTime());
        IEnumerator WaitTime()
        {

            yield return new WaitForSeconds(10);
            shield.SetActive(false);
            StartCoroutine("SpawnPowerUps");
            GetComponent<BoxCollider2D>().enabled = true;
            StopCoroutine("WaitTime()");
        }
    }

}

