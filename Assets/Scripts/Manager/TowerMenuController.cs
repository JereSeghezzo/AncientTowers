using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerMenuController : MonoBehaviour
{
  [Header("Tower Prefabs")]
    [SerializeField] GameObject mortarTowerPrefab;
    [SerializeField] GameObject cannonTowerPrefab;
    [SerializeField] GameObject archerTowerPrefab;
    [SerializeField] GameObject magicTowerPrefab;
     [Header("Scripts")]
    [SerializeField] GameObject towerMenu;
    public GameObject towerToBuild, sellMenu, upgradesMenu, notEnoghCoins;
    [SerializeField] TouchSelection touchSelection;
    public GameManager gameManager;
     [Header("Tower Price Text")]
    public TMP_Text sellTowerValue;
    [Header("Upgrade System")]
    public UpgradeSystem upgradeSystem;

    void Start()
    {
        towerMenu.SetActive(false); 
        upgradesMenu.SetActive(false); 
        sellMenu.SetActive(false);
        notEnoghCoins.SetActive(false); 
    }
    public void OpenAndCloseTowerMenu()
    {
        if(towerMenu.activeSelf || upgradesMenu.activeSelf)
        {
        towerMenu.SetActive(false);
        upgradesMenu.SetActive(false);
        sellMenu.SetActive(false);
        TouchSelection.menuMode = false;
        }else 
        {
        towerMenu.SetActive(true);
        TouchSelection.menuMode = true;
        }
        touchSelection.buildTowerPopup.SetActive(false);
        touchSelection.removeObstaclePopup.SetActive(false);
    }

    public void OpenUpgradeMenu()
    {
        upgradesMenu.SetActive(true);
        TouchSelection.menuMode = true;
        towerToBuild = null;
    }

    public void SelectMortarTower()
    {
        if(gameManager.playerCoins >= gameManager.mortarTowerBuyValue) 
        {
      towerToBuild = mortarTowerPrefab; 
       towerMenu.SetActive(false);
        upgradesMenu.SetActive(false);
        TouchSelection.menuMode = false; 
        }else NotEnoghCoinsAlert();
    }
    public void SelectCannonTower()
    {
      if(gameManager.playerCoins >= gameManager.cannonTowerBuyValue) 
        {
      towerToBuild = cannonTowerPrefab;  
       towerMenu.SetActive(false);
        upgradesMenu.SetActive(false);
        TouchSelection.menuMode = false;
        } else NotEnoghCoinsAlert();
    }
    public void SelectArcherTower()
    {
      if(gameManager.playerCoins >= gameManager.archerTowerBuyValue) 
        {  
      towerToBuild = archerTowerPrefab;  
       towerMenu.SetActive(false);
        upgradesMenu.SetActive(false);
        TouchSelection.menuMode = false;
        } else NotEnoghCoinsAlert();
    }
    public void SelectMagicTower()
    {
      if(gameManager.playerCoins >= gameManager.magicTowerBuyValue) 
        {  
      towerToBuild = magicTowerPrefab;  
       towerMenu.SetActive(false);
        upgradesMenu.SetActive(false);
        TouchSelection.menuMode = false;
        } else NotEnoghCoinsAlert();
    }
 public void OpenSellMenu()
 {
    sellTowerValue.text = "Quieres vender esta torre por "+ touchSelection.selection.GetComponent<TowerValueController>().sellValue.ToString() +" de oro?";  
    sellMenu.SetActive(true);
    //towerToBuild = null;
 }

 public void NotEnoghCoinsAlert()
 {
   notEnoghCoins.SetActive(true); 
 }
}
