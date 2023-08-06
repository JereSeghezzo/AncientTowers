using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerMain : MonoBehaviour
{
    public int towerHealth = 10;
    public GameManager gameManager;

    void Start()
    {
      UpdateHealthText();
    }
   
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Debug.Log("Colision detectada");
            towerHealth = towerHealth - 1;
            UpdateHealthText();
            if(towerHealth <= 0) 
            {
                Debug.Log("Derrotado");
            }
        }

    }

    void UpdateHealthText()
    {
      gameManager.healthText.text = towerHealth.ToString();   
    }

}
