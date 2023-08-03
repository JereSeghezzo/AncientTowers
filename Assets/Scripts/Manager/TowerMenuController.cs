using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerMenuController : MonoBehaviour
{
    [SerializeField] GameObject redTowerPrefab, blueTowerPrefab, greenTowerPrefab,towerMenu;
    public GameObject towerToBuild, sellMenu, upgradesMenu, notEnoghCoins;
    [SerializeField] TouchSelection touchSelection;
    public GameManager gameManager;
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

    public void SelectRedTower()
    {
        if(gameManager.playerCoins > gameManager.mortarTowerBuyValue) 
        {
      towerToBuild = redTowerPrefab; 
       towerMenu.SetActive(false);
        upgradesMenu.SetActive(false);
        TouchSelection.menuMode = false; 
        }else NotEnoghCoinsAlert();
    }
    public void SelectBlueTower()
    {
      if(gameManager.playerCoins > gameManager.cannonTowerBuyValue) 
        {
      towerToBuild = blueTowerPrefab;  
       towerMenu.SetActive(false);
        upgradesMenu.SetActive(false);
        TouchSelection.menuMode = false;
        } else NotEnoghCoinsAlert();
    }
    public void SelectGreenTower()
    {
      if(gameManager.playerCoins > gameManager.magicTowerBuyValue) 
        {  
      towerToBuild = greenTowerPrefab;  
       towerMenu.SetActive(false);
        upgradesMenu.SetActive(false);
        TouchSelection.menuMode = false;
        } else NotEnoghCoinsAlert();
    }
 public void OpenSellMenu()
 {
    sellMenu.SetActive(true);
    towerToBuild = null;
 }

 void NotEnoghCoinsAlert()
 {
   notEnoghCoins.SetActive(true); 
 }
}
