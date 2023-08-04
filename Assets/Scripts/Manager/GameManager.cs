using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int playerCoins;
    public int startPlayerGold;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI healthText;
    public GameObject nextWaveButton;


    public int cannonTowerBuyValue, cannonTowerSellValue, archerTowerBuyValue, archerTowerSellValue, mortarTowerBuyValue, mortarTowerSellValue, magicTowerBuyValue, magicTowerSellValue;

    public int treeRemoveCost, bigTreeRemoveCost, rockRemoveCost, bigRockRemoveCost;
    public int skeletonGoldDrop, enemie2GoldDrop, enemie3GoldDrop, enemie4GoldDrop;

    public bool isWaveActive;
    public int amountOfEnemies;
    public int killedEnemies;
    void Start()
    {
      playerCoins += startPlayerGold;  
      UpdateMoneyText();
    }

   public void UpdateMoneyText()
   {
     moneyText.text = playerCoins.ToString() + "$";
   }

   public void ToggleNextWaveButton()
   {
    nextWaveButton.SetActive(!nextWaveButton.activeSelf);
   }

   void CheckWaveStatus()
   {
    if(killedEnemies >= amountOfEnemies)
    {
     ToggleNextWaveButton();
     killedEnemies = 0;
    }
   }

   public void EnemyKilled()
   {
    killedEnemies++;
     CheckWaveStatus();
   }

  
}
