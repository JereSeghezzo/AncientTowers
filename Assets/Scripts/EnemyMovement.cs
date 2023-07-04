using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private int targetIndex = 1;
    public float movementSpeed = 4;
    public float rotationSpeed = 6;

    //private Transform target;
    //private int wavepointIndex = 0;

    //void Start()
    //{
    //    target = Waypoints.points[0];    
    //}
    void Update()
    {
        Movement();
        LookAt();
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetIndex].position, movementSpeed * Time.deltaTime);
        var distance = Vector3.Distance(transform.position, waypoints[targetIndex].position);
        if (distance <=0.1f)
        {
            if (targetIndex >= waypoints.Count - 1)
            {
                Debug.Log("Llegaste al final");
                return;
            }
            targetIndex++;
        }
    }

    private void LookAt()
    {
        var dir = waypoints[targetIndex].position - transform.position;
        var rootTarget = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rootTarget, rotationSpeed * Time.deltaTime);
    }

    //void GetNextWP()
    //{
    //    wavepointIndex++;
    //    target = Waypoints.points[wavepointIndex];  
    //}


}
