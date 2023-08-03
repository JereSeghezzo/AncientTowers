using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStateUpdater : MonoBehaviour
{
    BoxCollider boxCollider;
    Rigidbody rigidbody;
    bool tower;
    public List<TileState> ContactedTiles = new List<TileState>();
    void Start()
    {
       boxCollider = this.gameObject.GetComponent<BoxCollider>(); 
       rigidbody = this.gameObject.GetComponent<Rigidbody>();
       if(this.gameObject.CompareTag("Tower"))
       {
        tower = true;
       }
    }
    
    void OnTriggerEnter(Collider col) 
    {
      if(col.transform.CompareTag("Tile")) 
      {
        ContactedTiles.Add(col.gameObject.GetComponent<TileState>());
        if(tower)
        {
         col.gameObject.GetComponent<TileState>().towerObstructionCount += 1;
        } else
        {
         col.gameObject.GetComponent<TileState>().obstacleObstruction = true;
        }
         col.gameObject.GetComponent<TileState>().UpdateTileAvailability();
      }
        //Destroy(boxCollider, 0.2f);
        Destroy(rigidbody, 0.2f);
    }

    public void LiberateTile()
    {
      if(tower)
        {
         foreach(TileState Tile in ContactedTiles)
      {
        Tile.towerObstructionCount -= 1;
        Tile.UpdateTileAvailability();
      }
        } else
        {
          foreach(TileState Tile in ContactedTiles)
      {
        Tile.obstacleObstruction = false;
        Tile.UpdateTileAvailability();
      }
        }
    }
}
