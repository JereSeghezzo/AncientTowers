using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerCoins;
    public int startPlayerGold;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI healthText;
    public GameObject nextWaveButton;
    public int goldForWave;
    public TouchSelection touchSelection;
    public WaveSpawner waveSpawner;

    [Header("Tower Prices")]
    public int cannonTowerBuyValue;
    public int archerTowerBuyValue;
    public int mortarTowerBuyValue;
    public int magicTowerBuyValue;

    [HideInInspector]
    int cannonOriginalPrice, archerOriginalPrice, mortarOriginalPrice, magicOriginalPrice;

    [Header("Multipliers")]

    public float towerSellPricePercent;
    public float towerInflation;
    
    [HideInInspector]
    public int cannonTowerSellValue, archerTowerSellValue,mortarTowerSellValue,magicTowerSellValue;

    [Header("Obstacles Costs")]
    public int tree1RemoveCost;
    public int tree2RemoveCost;
    public int tree3RemoveCost;
    public int rockRemoveCost;
    public int bigRockRemoveCost;

    [Header("Enemies Drops")]
    public int skeletonGoldDrop;
    public int blackSkeletonGoldDrop;
    public int vampireGoldDrop;
    public int golemGoldDrop;
    public int goblinGoldDrop;

    [HideInInspector]
    public int amountOfEnemies;

    [Header("Amount of Towers active")]
    public int archerTowers;
    public int cannonTowers;
    public int mortarTowers;
    public int magicTowers;

 [Header("Game Over")]
    public GameObject winScreen;
    public GameObject loseScreen;

    public TowerMain mainTower;

    public int wavesToWin;
    public int currentWave;

    public TextMeshProUGUI waveCounter;


    void Start()
    {
      playerCoins = startPlayerGold;  
      UpdateMoneyText();
      UpdateTowerSellPrices();
      SetOriginalPrices();
      UpdateWaveCounter();
    }

   public void UpdateMoneyText()
   {
     moneyText.text = playerCoins.ToString() + "$";
   }

   public void ToggleNextWaveButton()
   {
    UpdateWaveCounter();
    if(amountOfEnemies > 0)
    {
    nextWaveButton.SetActive(false);
    }
    else
    {
      nextWaveButton.SetActive(true);
    }
   }
   public void DeactivateNextWaveButton()
   {
    UpdateWaveCounter();
    nextWaveButton.SetActive(false);
   }
   public void EnemyKilled()
   {
    if(amountOfEnemies <= 0 && waveSpawner.enemiesToSpawn.Count <= 0)
    {
     GoldForSurvival(); 
     ToggleNextWaveButton();
     UpdateMoneyText(); 
     Debug.Log("Oleada Terminada");
     if(wavesToWin <= currentWave)
     {
      GameWon();
     }
    }
   }

   void GoldForSurvival()
   {
     playerCoins += goldForWave;
   }

   void UpdateTowerSellPrices()
   {
    cannonTowerSellValue = (int)(cannonTowerBuyValue * towerSellPricePercent);
    archerTowerSellValue = (int)(archerTowerBuyValue * towerSellPricePercent);
    mortarTowerSellValue = (int)(mortarTowerBuyValue * towerSellPricePercent);
    magicTowerSellValue = (int)(magicTowerBuyValue * towerSellPricePercent);
   }

   void SetOriginalPrices()
   {
    cannonOriginalPrice = cannonTowerBuyValue;
    archerOriginalPrice = archerTowerBuyValue;
    mortarOriginalPrice = mortarTowerBuyValue;
    magicOriginalPrice = magicTowerBuyValue;
   }

   void UpdateTowerPricesByInflation()
   {
     cannonTowerBuyValue = (int)(cannonOriginalPrice + cannonOriginalPrice * (cannonTowers * towerInflation));
     archerTowerBuyValue = (int)(archerOriginalPrice + archerOriginalPrice * (archerTowers * towerInflation));
     mortarTowerBuyValue = (int)(mortarOriginalPrice + mortarOriginalPrice * (mortarTowers * towerInflation));
     magicTowerBuyValue = (int)(magicOriginalPrice + magicOriginalPrice * (magicTowers * towerInflation));
   }

   public void UpdateTowerPrices()
   {
    UpdateTowerPricesByInflation();
    UpdateTowerSellPrices();
   }

   public void GameLost()
   {
    touchSelection.MenuModeOn();
    loseScreen.SetActive(true);
    Time.timeScale = 0f;
   }

    public void GameWon()
   {
    touchSelection.MenuModeOn();
    winScreen.SetActive(true);
    Time.timeScale = 0f;
   }

   void UpdateWaveCounter()
   {
    waveCounter.text = "Oleada " + currentWave.ToString() + "/" + wavesToWin.ToString();
   }


  
}
