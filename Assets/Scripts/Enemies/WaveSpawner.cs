using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform skeletonPrefab;
    public Transform spawnpoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public int waveNumber = 0;
    public GameManager gameManager;



    void Update()
    {
        // if (countdown <= 0f)
        // {
        //     StartCoroutine(SpawnWave());
        //     countdown = timeBetweenWaves;
        // }

        // countdown -= Time.deltaTime;

    }

    void SpawnEnemy()
    {
        Instantiate(skeletonPrefab, spawnpoint.position, spawnpoint.rotation);
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        gameManager.amountOfEnemies = waveNumber;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    public void StartNextWave()
    {
        gameManager.ToggleNextWaveButton();
        StartCoroutine(SpawnWave());
    }

}
