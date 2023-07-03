using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerMenuController : MonoBehaviour
{
    [SerializeField] GameObject redTowerPrefab, blueTowerPrefab, greenTowerPrefab,towerMenu;
    public GameObject towerToBuild, sellMenu, upgradesMenu;
    void Start()
    {
        towerMenu.SetActive(false); 
        upgradesMenu.SetActive(false); 
        sellMenu.SetActive(false);
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
    }

    public void OpenUpgradeMenu()
    {
        upgradesMenu.SetActive(true);
        TouchSelection.menuMode = true;
    }

    public void SelectRedTower()
    {
      towerToBuild = redTowerPrefab; 
       towerMenu.SetActive(false);
        upgradesMenu.SetActive(false);
        TouchSelection.menuMode = false; 
    }
    public void SelectBlueTower()
    {
      towerToBuild = blueTowerPrefab;  
       towerMenu.SetActive(false);
        upgradesMenu.SetActive(false);
        TouchSelection.menuMode = false;
    }
    public void SelectGreenTower()
    {
      towerToBuild = greenTowerPrefab;  
       towerMenu.SetActive(false);
        upgradesMenu.SetActive(false);
        TouchSelection.menuMode = false;
    }
 public void OpenSellMenu()
 {
    sellMenu.SetActive(true);
 }
}
