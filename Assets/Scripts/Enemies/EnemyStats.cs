using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyHealth;
    public int maxHealth; 
    public int damage;
    public int goldDrop; 
    public GameManager gameManager;
    enum DataType {Skeleton, BlackSkeleton, Vampire, Golem, Goblin}
    [SerializeField] DataType enemieType;

    public HealthBar healthBar;

    void Start()
    {
      gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
      SelectValues();
      gameManager.amountOfEnemies++;
      enemyHealth = maxHealth;
      healthBar.UpdateHealthBar(maxHealth, enemyHealth);
    }

    void OnDisable()
    {
     gameManager.amountOfEnemies--;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "MainTower")
        {
          col.GetComponent<TowerMain>().TakeDamage(damage);
          EnemyDeath();
        }
    }

   public void TakeDamage(int damage)
   {
    enemyHealth -= damage;
    healthBar.UpdateHealthBar(maxHealth, enemyHealth);
    if(enemyHealth <= 0)
    {
        GoldDrop();
        EnemyDeath();
    }
   }

   void SelectValues()
    {
     if(enemieType == DataType.Skeleton) goldDrop = gameManager.skeletonGoldDrop; 
     if(enemieType == DataType.Vampire) goldDrop = gameManager.vampireGoldDrop;
     if(enemieType == DataType.Golem) goldDrop = gameManager.golemGoldDrop; 
     if(enemieType == DataType.BlackSkeleton) goldDrop = gameManager.blackSkeletonGoldDrop;
     if(enemieType == DataType.Goblin) goldDrop = gameManager.goblinGoldDrop;
    }

    void EnemyDeath()
    {
      gameManager.Invoke("EnemyKilled", 1.0f);
      Destroy(gameObject);   
    }

    void GoldDrop()
    {
       gameManager.playerCoins += goldDrop;
       gameManager.UpdateMoneyText();  
    }
}
