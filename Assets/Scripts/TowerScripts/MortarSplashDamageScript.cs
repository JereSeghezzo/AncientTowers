using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarSplashDamageScript : MonoBehaviour
{

 public int splashDamage;
 BoxCollider boxCollider;
    void Start()
    {
      boxCollider = this.GetComponent<BoxCollider>();  
    }
    public void Activate()
    {
      boxCollider.enabled = true;   
      Destroy(gameObject, 0.2f);

    }

    void OnTriggerEnter(Collider col) 
    {
      if(col.gameObject.tag == "Enemy")
        {
          col.gameObject.GetComponent<EnemyStats>().TakeDamage(splashDamage);
        }   
    }
}
