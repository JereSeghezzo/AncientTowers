using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerMain : MonoBehaviour
{
    public int towerHealth;
    public GameManager gameManager;

    void Start()
    {
      UpdateHealthText();
    }
   

    void UpdateHealthText()
    {
      gameManager.healthText.text = towerHealth.ToString();   
    }


public void TakeDamage(int damage)
   {
    towerHealth -= damage;
    UpdateHealthText();
    Debug.Log("Colision detectada");
    if(towerHealth <= 0)
    {
      Debug.Log("Perdiste");
      gameManager.GameLost();
    }
   }
}
