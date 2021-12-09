using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    float spawnWait = 0.5f;
    float startWait = 0.5f;
    float waveWait = 2f;
    public float min_Y = -6f, max_Y = 6f;
    [HideInInspector]
    public int score;
    //UI elements
    public Text scoreText;
    public Text highScore;
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;

    public int enemiesPerWave = 2;
    public GameObject enemyPrefab;
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;

    bool activatemediumenemies = true;
    bool activateBoss = true;
    public int powerUpScore;



    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore,0").ToString();
        Invoke("Waves", 1f);
    }

    void Update()
    {
        if ((score > 20 || score > 30) && activatemediumenemies)
        {

            activatemediumenemies = false;
            Invoke("SpwanMediumEnemies", 0.5f);

        }
        if ((score > 40 || score > 50) && activateBoss)
        {

            activateBoss = false;
            Invoke("SpwanBoss", 0.5f);

        }
        if(score>150)
        {

            Time.timeScale = 0f;
            gameWinPanel.SetActive(true);
        }
    }

    IEnumerator SpawnSmallEnemies()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {

            //float waveType = Random.Range(1.0f, 6.0f);

            for (int i = 0; i < enemiesPerWave; i++)
            {


                Vector3 enemyspawn = new Vector3(Random.Range(-8f, 8f), 7f, 0);
                Instantiate(enemyPrefab, enemyspawn, Quaternion.identity);


                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }



    }

    void SpwanMediumEnemies()
    {
        StartCoroutine("ExecuteMediumEnemies");

    }

    void SpwanBoss()
    {
        Invoke("ExecuteBossEnemies", 0.2f);

    }


    IEnumerator ExecuteMediumEnemies()
    {

        for (int i = 0; i < 2; i++)
        {
            Vector3 enemyspawn = new Vector3(Random.Range(-8f, 8f), 7f, 0);
            Instantiate(enemyPrefab1, enemyspawn, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }


        Invoke("SpwanMediumEnemies", 10f);
    }


    void ExecuteBossEnemies()
    {

        Vector3 enemyspawn = new Vector3(0f, 4f, 0f);
        Instantiate(enemyPrefab2, enemyspawn, Quaternion.identity);


        Invoke("ExecuteBossEnemies", 30f);
    }

    public void Waves()
    {
        StartCoroutine("SpawnSmallEnemies");

    }

    public void GameOver()
    {
        Time.timeScale = 0f;
       gameOverPanel.SetActive(true);
      if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);


        }
        highScore.text = "High score: " + PlayerPrefs.GetInt("HighScore").ToString();

    }
   
    
    
    //to start over the game again
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //exit the game
    public void Exit()
    {
        //SceneManager.LoadScene(0);
        Application.Quit();
    }
}
