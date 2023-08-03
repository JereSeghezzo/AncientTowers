using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyLife = 5;
    public int goldDrop; 
    public GameManager gameManager;

    void Start()
    {
      gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "MainTower")
        {
            Destroy(gameObject);
        }
    }

   public void TakeDamage(int damage)
   {
    enemyLife -= damage;
    if(enemyLife <= 0)
    {
        gameManager.playerCoins += goldDrop;
        gameManager.UpdateMoneyText();
        Destroy(gameObject); 
    }
   }
}
