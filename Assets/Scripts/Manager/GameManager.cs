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

    public int cannonTowerBuyValue, cannonTowerSellValue, archerTowerBuyValue, archerTowerSellValue, mortarTowerBuyValue, mortarTowerSellValue, magicTowerBuyValue, magicTowerSellValue;

    public int treeRemoveCost, bigTreeRemoveCost, rockRemoveCost, bigRockRemoveCost;
    void Start()
    {
      playerCoins += startPlayerGold;  
      UpdateMoneyText();
    }

   public void UpdateMoneyText()
   {
     moneyText.text = playerCoins.ToString() + "$";
   }
}
