using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TouchSelection : MonoBehaviour
{
    GameObject selection;
    TileState selectedTile;
    TowerController selectedTower;
   // [SerializeField] GameObject towerPreFab;

    public TMP_Text objetive;
    [SerializeField] LayerMask whatToDetect;
    [SerializeField] GameObject buildTowerPopup;
    [SerializeField] TowerMenuController towerMenuController;
    static public bool menuMode;

    void Start() 
    {
      buildTowerPopup.SetActive(false);
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

            if(Physics.Raycast(ray, out hit,20, whatToDetect))
            {
              selection = hit.transform.gameObject;
              if(hit.transform.CompareTag("Tile"))
              {
                SelectionKindTile();                
              } else if(hit.transform.CompareTag("Tower"))
              {
                SelectionKindTower();
              }
            } 
         }
        }
    }

    void SelectionKindTile()
    {
      selectedTile = selection.GetComponent<TileState>();
      if(selectedTile != null)
            {
              if(selectedTile.available && towerMenuController.towerToBuild != null)
               {
                objetive.text = "Tile Disponible";
                menuMode = true;
                buildTowerPopup.SetActive(true);
               }

              if(!selectedTile.available)
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
    }
    public void BuildTower()
    {
     Vector3 prefabPosition = selection.transform.position;
     prefabPosition.y += 1f; 
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
    
}
