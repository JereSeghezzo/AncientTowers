using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherArrow : MonoBehaviour
{
    private Transform target;

    public float speed;
    public int damage;
    public void Seek (Transform _target)
    {
        target = _target;

        Vector3 targetPosition = new Vector3(target.transform.position.x, 90f, target.transform.position.z);
        transform.LookAt(targetPosition);  
    }
    void Update()
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
            target.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        Destroy(gameObject);
    }

}