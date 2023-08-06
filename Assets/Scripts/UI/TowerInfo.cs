using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerInfo : MonoBehaviour
{
    public GameManager gameManager;

    enum DataType {Cannon, Archer, Mortar, MagicTower}
    [SerializeField] DataType TowerType;

    public TextMeshProUGUI buyPrice;
    public TextMeshProUGUI sellPrice;

    void UpdateValues()
 {
    switch (TowerType)
    {
        case DataType.Cannon:
         buyPrice.text = gameManager.cannonTowerBuyValue.ToString();
         sellPrice.text = gameManager.cannonTowerSellValue.ToString();

            break;
        case DataType.Archer:
         buyPrice.text = gameManager.archerTowerBuyValue.ToString();
         sellPrice.text = gameManager.archerTowerSellValue.ToString();

            break;
        case DataType.Mortar:
         buyPrice.text = gameManager.mortarTowerBuyValue.ToString();
         sellPrice.text = gameManager.mortarTowerSellValue.ToString();

            break;
        case DataType.MagicTower:
         buyPrice.text = gameManager.magicTowerBuyValue.ToString();
         sellPrice.text = gameManager.magicTowerSellValue.ToString();

            break;
        default:

            break;
    }
 }

 void FixedUpdate()
 {
   UpdateValues();
 }


}
