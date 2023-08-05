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

    public List<Enemy> enemies = new List<Enemy>();
    public int currWave;
    int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    
    public Transform spawnLocation;
    public float waveDuration;
    float waveTimer;
    float spawnInterval;
    float spawnTimer;

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
        StartCoroutine(SpawnWave());
    }

    void FixedUpdate()
    {
      if(spawnTimer <= 0)
      {
        if(enemiesToSpawn.Count > 0)
        {
          Instantiate(enemiesToSpawn[0], spawnLocation.position, Quaternion.identity);
          enemiesToSpawn.RemoveAt(0);
          spawnTimer = spawnInterval;
          //Debug.Log(spawnInterval);
        }
        else
        {
          waveTimer = 0;
        }
      }
      else{
        spawnTimer-= Time.fixedDeltaTime;
        waveTimer-= Time.fixedDeltaTime;
      }
    }

    public void GenerateWave()
    {
      gameManager.killedEnemies = 0;
      gameManager.amountOfEnemies = 0;
      gameManager.ToggleNextWaveButton();
      currWave++;
      waveValue = currWave;
      GenerateEnemies();

      spawnInterval = waveDuration / enemiesToSpawn.Count;
      waveTimer = waveDuration;

      gameManager.amountOfEnemies = enemiesToSpawn.Count;
      Debug.Log("Cantidad de enemigos " + gameManager.amountOfEnemies);
    }

    public void GenerateEnemies()
    {
      List<GameObject> generatedEnemies = new List<GameObject>();
      while(waveValue>0)
      {
        int randEnemyId = Random.Range(0,enemies.Count);
        int randEnemyCost = enemies[randEnemyId].cost;

        if(waveValue-randEnemyCost>=0)
        {
          generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
          waveValue -= randEnemyCost;
        }
        else if(waveValue<=0)
        {
          break;
        }
      }
         // gameManager.ToggleNextWaveButton();
      enemiesToSpawn.Clear();
      enemiesToSpawn = generatedEnemies;
    }



    [System.Serializable]
    public class Enemy
    {
     public GameObject enemyPrefab;
     public int cost;
    }

}
