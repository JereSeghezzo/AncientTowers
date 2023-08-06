using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform spawnpoint;
    public GameManager gameManager;

    public List<Enemy> enemies = new List<Enemy>();
    public int currWave;
    public int waveCounter;
    public int waveMultiplier;
    public int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    
    public Transform spawnLocation;
    public float waveDuration;
    float waveTimer;
    float spawnInterval;
    float spawnTimer;

    void FixedUpdate()
    {
      if(spawnTimer <= 0)
      {
        if(enemiesToSpawn.Count > 0)
        {
          Instantiate(enemiesToSpawn[0], spawnLocation.position, Quaternion.identity);
          enemiesToSpawn.RemoveAt(0);
          spawnTimer = spawnInterval;
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
      gameManager.DeactivateNextWaveButton();
      waveCounter++;
      currWave = currWave * waveMultiplier;
      waveValue = (int)currWave;
      gameManager.currentWave = waveCounter;
      GenerateEnemies();

      spawnInterval = waveDuration / enemiesToSpawn.Count;
      waveTimer = waveDuration;

      Debug.Log("Cantidad de enemigos " + enemiesToSpawn.Count);
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
