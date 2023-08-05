using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyHealth = 5;
    public int goldDrop; 
    public GameManager gameManager;
    enum DataType {Skeleton, Enemie2, Enemie3, Enemie4}
    [SerializeField] DataType enemieType;

    void Start()
    {
      gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
      SelectValues();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "MainTower")
        {
          EnemyDeath();
        }
    }

   public void TakeDamage(int damage)
   {
    enemyHealth -= damage;
    if(enemyHealth <= 0)
    {
        GoldDrop();
        EnemyDeath();
    }
   }

   void SelectValues()
    {
     if(enemieType == DataType.Skeleton) goldDrop = gameManager.skeletonGoldDrop; 
     if(enemieType == DataType.Enemie2) goldDrop = gameManager.enemie2GoldDrop;
     if(enemieType == DataType.Enemie3) goldDrop = gameManager.enemie3GoldDrop; 
     if(enemieType == DataType.Enemie4) goldDrop = gameManager.enemie4GoldDrop;
    }

    void EnemyDeath()
    {
      gameManager.EnemyKilled();  
      Destroy(gameObject);   
    }

    void GoldDrop()
    {
       gameManager.playerCoins += goldDrop;
       gameManager.UpdateMoneyText();  
    }
}
