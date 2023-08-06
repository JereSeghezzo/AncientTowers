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
       gameManager.UpdateTowerPrices();
    }
    void SelectValues()
 {
    switch (TowerType)
    {
        case DataType.Cannon:
            buyValue = gameManager.cannonTowerBuyValue;
            sellValue = gameManager.cannonTowerSellValue;
             gameManager.cannonTowers++;
            break;
        case DataType.Archer:
            buyValue = gameManager.archerTowerBuyValue;
            sellValue = gameManager.archerTowerSellValue;
             gameManager.archerTowers++;
            break;
        case DataType.Mortar:
            buyValue = gameManager.mortarTowerBuyValue;
            sellValue = gameManager.mortarTowerSellValue;
             gameManager.mortarTowers++;
            break;
        case DataType.MagicTower:
            buyValue = gameManager.magicTowerBuyValue;
            sellValue = gameManager.magicTowerSellValue;
             gameManager.magicTowers++;
            break;
        default:
            // Código para el caso por defecto
            break;
    }
 }


    void OnDisable() 
    {
        switch (TowerType)
    {
        case DataType.Cannon:
             gameManager.cannonTowers--;
            break;
        case DataType.Archer:
             gameManager.archerTowers--;
            break;
        case DataType.Mortar:
             gameManager.mortarTowers--;
            break;
        case DataType.MagicTower:
             gameManager.magicTowers--;
            break;
        default:
            
            break;
    }
      gameManager.UpdateTowerPrices();
    }
}
