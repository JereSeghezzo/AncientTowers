using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSplashEffect : MonoBehaviour
{

 public int splashDamage;
 public GameObject visuals;
 public float areaDuration;
 public float debuffDuration;
 BoxCollider boxCollider;
    void Start()
    {
      boxCollider = this.GetComponent<BoxCollider>();  
    }
    public void Activate()
    {
      boxCollider.enabled = true;   
      visuals.SetActive(true);
      Destroy(gameObject, areaDuration);

    }

    void OnTriggerEnter(Collider col) 
    {
      if(col.gameObject.tag == "Enemy")
        {
          col.gameObject.GetComponent<EnemyStats>().VenomDebuff(debuffDuration);
        }   
    }
}
