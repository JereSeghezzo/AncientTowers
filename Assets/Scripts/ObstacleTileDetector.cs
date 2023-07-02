using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTileDetector : MonoBehaviour
{
    BoxCollider boxCollider;
    Rigidbody rigidbody;
    void Start()
    {
       boxCollider = this.gameObject.GetComponent<BoxCollider>(); 
       rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }
    
    void OnTriggerStay(Collider col) 
    {
      if(col.transform.CompareTag("Tile")) 
      {
        col.gameObject.GetComponent<TileState>().available = false;
      }
        Destroy(boxCollider, 0.2f);
        Destroy(rigidbody, 0.3f);
    }
}
