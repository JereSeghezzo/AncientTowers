using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTowerController : MonoBehaviour
{
    public Transform target;
    public float range = 15f;

    public float fireRate = 1f;
    public float damage;
    private float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    //float shortestDistance;
    public float currentEnemyDistance;

    public TowerStats towerStats;
    void Start()
    {   
      UpdateStats();
      InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }


    void FixedUpdate()
    {
        if (target == null)
            return;

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void UpdateTarget()
    {
        if(target != null)
        {
           currentEnemyDistance = Vector3.Distance(transform.position, target.transform.position);
           if(currentEnemyDistance > range) target = null;
        }

         if(target == null)
         {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distancetoEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distancetoEnemy < shortestDistance)
            {
                shortestDistance = distancetoEnemy;
                nearestEnemy = enemy;
            }
        }

        currentEnemyDistance = shortestDistance;


        if (nearestEnemy != null && shortestDistance <= range) 
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
         }

    }

    void Shoot()
    {
        UpdateStats();
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        ArcherArrow bullet = bulletGo.GetComponent<ArcherArrow>();

        if (bullet != null)
            bullet.Seek(target);
            bullet.damage = (int)damage;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void UpdateStats()
    {
     range = towerStats.range;
     fireRate = towerStats.fireRate;
     damage = towerStats.damage;   
    }
}
