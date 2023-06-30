using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectFloor : MonoBehaviour
{
    GameObject selection;
    TowerGrid selectedTile;
    TowerController selectedTower;
    [SerializeField] GameObject towerPreFab;

    public TMP_Text objetive;
    [SerializeField] LayerMask whatToDetect;

    void Update()
    {
      RayCastByTouch();  
    }

    void RayCastByTouch()
    {
      if(Input.touchCount > 0)
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
      selectedTile = selection.GetComponent<TowerGrid>();
      if(selectedTile != null)
            {
              if(selectedTile.available)
               {
                objetive.text = "Tile Disponible";
                Vector3 prefabPosition = selection.transform.position;
                prefabPosition.y += 1f; 
                Instantiate(towerPreFab, prefabPosition, selection.transform.rotation);
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
    }
    
}
