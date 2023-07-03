using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyLife = 5;

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
        Destroy(gameObject); 
    }
   }
}
