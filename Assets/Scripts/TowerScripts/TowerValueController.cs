using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerValueController : MonoBehaviour
{
    public GameManager gameManager;

    enum DataType {Cannon, Archer, Mortar, MagicTower}
    [SerializeField] DataType TowerType;

    public int buyValue, sellValue;
    void Start()
    {
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       SelectValues();
       gameManager.playerCoins -= buyValue;
       gameManager.UpdateMoneyText(); 
    }

    void SelectValues()
    {
     if(TowerType == DataType.Cannon) buyValue = gameManager.cannonTowerBuyValue; sellValue = gameManager.cannonTowerSellValue;
     if(TowerType == DataType.Archer) buyValue = gameManager.archerTowerBuyValue; sellValue = gameManager.archerTowerSellValue;
     if(TowerType == DataType.Mortar) buyValue = gameManager.mortarTowerBuyValue; sellValue = gameManager.mortarTowerSellValue;
     if(TowerType == DataType.MagicTower) buyValue = gameManager.magicTowerBuyValue; sellValue = gameManager.magicTowerSellValue;
    }
}
