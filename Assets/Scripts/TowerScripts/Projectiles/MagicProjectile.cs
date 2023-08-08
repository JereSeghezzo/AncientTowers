using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicProjectile : MonoBehaviour
 {
    public Transform target;

    public float speed;
    public float damage;
    public float riseSpeed;
    public float riseTime;
    public int areaDamage;
    public GameObject splashZonePrefab;
    MagicSplashEffect landZone;


    public void Seek (Transform _target)
    {
        if (target == null)
        {
        target = _target;
        }
    }
    void FixedUpdate()
    {
     
     riseTime -= Time.deltaTime;
     if(riseTime > 0f)
     {
      Rise();
     } 
     else
     {
     Fall();
     } 
    
    }

    void HitTarget()
    {
        Destroy(gameObject);
    }

    void Fall()
    {
       if (target == null) 
         {
             Destroy(gameObject);
             return;
         }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            
           landZone = target.gameObject.GetComponent<MagicSplashEffect>();
           landZone.Activate();
           landZone.damage = damage;
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);  
    }

    void Rise()
    {
     transform.position = new Vector3(transform.position.x, transform.position.y + riseSpeed, transform.position.z);
    }
}
