using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    float spawnWait = 0.5f;
    float startWait = 0.5f;
    float waveWait = 2f;
    public int powerUpsPerWave = 2;
    public GameObject powerUpprefab;
    private float timeElapsed = 0;
    


    private void Update()
    {
        

    }


    IEnumerator SpawnSmallEnemies()
    {
        yield return new WaitForSeconds(startWait);
       
         
            for (int i = 0; i < powerUpsPerWave; i++)
            {


                Vector3 spawn = new Vector3(Random.Range(-8f, 8f), 7f, 0);
                Instantiate(powerUpprefab, spawn, Quaternion.identity);


                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }



}
