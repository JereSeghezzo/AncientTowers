using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform skeletonPrefab;
    public Transform spawnpoint;
    public int waveNumber = 0;
    public GameManager gameManager;
    public int skeletonAmount,enemy2Amount, enemy3Amount, enemy4Amount, enemy5Amount;
    public int enemyToSpawn;

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

    public void SelectWaveEnemies()
    {
      ClearEnemies();
      if(waveNumber == 1)  
      {
        skeletonAmount = 1;
      }
      if(waveNumber == 2)
      {
        skeletonAmount = 2;
      }
      if(waveNumber == 3)
      {
        skeletonAmount = 4;
      }
    }

    public void ClearEnemies()
    {
      skeletonAmount = 0;  
      enemy2Amount = 0; 
      enemy3Amount = 0; 
      enemy4Amount = 0; 
      enemy5Amount = 0; 
      
    }

    public void Spawn()
    {
        
    }

}
