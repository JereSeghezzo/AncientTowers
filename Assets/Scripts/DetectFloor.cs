using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class DetectFloor : MonoBehaviour
{
    TowerGrid selectedGround;
    public Text objetive;

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
         if(touch.phase == TouchPhase.Began)
         {
            Ray ray = Camera.main.ScreenPointToRay(touch.position); 
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
              selectedGround = hit.transform.gameObject.GetComponent<TowerGrid>();
              if(selectedGround.available)
              {
                Debug.Log("found");
              }
              if(selectedGround = null)
              {
                Destroy(hit.transform.gameObject);
              }
            }
         }
        }
    }
}
