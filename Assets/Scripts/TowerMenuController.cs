using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerMenuController : MonoBehaviour
{
    [SerializeField] GameObject towerMenu;
    [SerializeField] GameObject upgradesMenu;
    [SerializeField] GameObject redTowerPrefab, blueTowerPrefab, greenTowerPrefab;
    public GameObject towerToBuild;
    void Start()
    {
        towerMenu.SetActive(false); 
        upgradesMenu.SetActive(false); 
    }

    void Update()
    {
        
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


}
