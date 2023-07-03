using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStateUpdater : MonoBehaviour
{
    BoxCollider boxCollider;
    Rigidbody rigidbody;
    bool tower;
    void Start()
    {
       boxCollider = this.gameObject.GetComponent<BoxCollider>(); 
       rigidbody = this.gameObject.GetComponent<Rigidbody>();
       if(this.gameObject.CompareTag("Tower"))
       {
        tower = true;
       }
    }
    
    void OnTriggerStay(Collider col) 
    {
      if(col.transform.CompareTag("Tile")) 
      {
        if(tower)
        {
         col.gameObject.GetComponent<TileState>().towerObstruction = true;
        } else
        {
         col.gameObject.GetComponent<TileState>().obstacleObstruction = true;
        }
         col.gameObject.GetComponent<TileState>().UpdateTileAvailability();
      }
        //Destroy(boxCollider, 0.2f);
        Destroy(rigidbody, 0.2f);
    }
}
