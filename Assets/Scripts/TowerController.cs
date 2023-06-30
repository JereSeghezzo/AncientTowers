using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    BoxCollider boxCollider;
    Rigidbody rigidbody;
    void Start()
    {
       boxCollider = this.gameObject.GetComponent<BoxCollider>(); 
       rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

     void OnTriggerStay(Collider col) 
    {
      if(col.transform.CompareTag("Tile")) 
      {
        col.gameObject.GetComponent<TowerGrid>().available = false;
      }
        Destroy(rigidbody, 0.2f);
    }
}
