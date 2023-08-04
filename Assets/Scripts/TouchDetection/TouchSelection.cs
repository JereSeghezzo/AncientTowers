using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TouchSelection : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject selection;
    TileState tileState;
    TowerController selectedTower;
    public TMP_Text objetive, removeObstacleCost;
    [SerializeField] LayerMask whatToDetect;
    public GameObject buildTowerPopup, removeObstaclePopup;
    [SerializeField] TowerMenuController towerMenuController;
    static public bool menuMode;

    void Start() 
    {
      buildTowerPopup.SetActive(false);
      removeObstaclePopup.SetActive(false);
    }

    void Update()
    {
      RayCastByTouch();  
    }

    void RayCastByTouch()
    {
      if(Input.touchCount > 0 && !menuMode)
        {
            Touch touch = Input.GetTouch(0);
         if(touch.phase == TouchPhase.Began)
         {
            Ray ray = Camera.main.ScreenPointToRay(touch.position); 
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit,Mathf.Infinity, whatToDetect))
            {
              selection = hit.transform.gameObject;
              if(hit.transform.CompareTag("Tile"))
              {
                SelectionKindTile();                
              } 
              if(hit.transform.CompareTag("Tower"))
              {
                SelectionKindTower();
              }
              if(hit.transform.CompareTag("Obstacle"))
              {
                ObstacleSelection();
              }
            } 
         }
        }
    }

    void SelectionKindTile()
    {
      tileState = selection.GetComponent<TileState>();
      if(tileState != null && !menuMode)
            {
              if(tileState.available && towerMenuController.towerToBuild != null)
               {
                objetive.text = "Tile Disponible";
                menuMode = true;
                buildTowerPopup.SetActive(true);
                removeObstaclePopup.SetActive(false);
               }

              if(!tileState.available)
               {
                objetive.text = "Tile Ocupada";
               }
            } 
    }

    void SelectionKindTower()
    {
      selectedTower = selection.GetComponent<TowerController>();
      objetive.text = "Tower";
      towerMenuController.OpenUpgradeMenu();
      towerMenuController.towerToBuild = null;
    }
    public void BuildTower()
    {
    
     Vector3 prefabPosition = selection.transform.position;
     prefabPosition.y -= 0.5f; 
     Instantiate(towerMenuController.towerToBuild, prefabPosition, selection.transform.rotation);
     buildTowerPopup.SetActive(false);
      menuMode = false;
      towerMenuController.towerToBuild = null;

    }

    public void CancelTower()
    {
      buildTowerPopup.SetActive(false);
      menuMode = false;
    }

    void ObstacleSelection()
    {
      menuMode = true;
      removeObstacleCost.text = "Quieres eliminar este obstaculo por "+ selection.GetComponent<ObstacleValueController>().RemoveCost.ToString() +" de oro?";
       removeObstaclePopup.SetActive(true);
       buildTowerPopup.SetActive(false);
       towerMenuController.towerToBuild = null;
    }
    public void RemoveObstacle()
    {
      if(gameManager.playerCoins > selection.GetComponent<ObstacleValueController>().RemoveCost)
      {
    selection.GetComponent<TileStateUpdater>().LiberateTile();
    gameManager.playerCoins -= selection.GetComponent<ObstacleValueController>().RemoveCost;
    gameManager.UpdateMoneyText();
     Destroy(selection);
     menuMode = false;
       removeObstaclePopup.SetActive(false);
      } else towerMenuController.NotEnoghCoinsAlert(); CancelRemoveObstacle();
    }
      public void CancelRemoveObstacle()
    {
      menuMode = false;
       removeObstaclePopup.SetActive(false);
    }

  public void SellTower()
  {
    selection.GetComponent<TileStateUpdater>().LiberateTile();
    gameManager.playerCoins += selection.GetComponent<TowerValueController>().sellValue;
    gameManager.UpdateMoneyText();
    Destroy(selection);
    menuMode = false;
    towerMenuController.sellMenu.SetActive(false);
    towerMenuController.upgradesMenu.SetActive(false);
  } 

  public void CancelSellTower()
  {
    menuMode = false;
    towerMenuController.sellMenu.SetActive(false);
    towerMenuController.upgradesMenu.SetActive(false);
  }


    
}
