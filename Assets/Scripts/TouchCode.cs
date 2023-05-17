using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TouchCode : MonoBehaviour
{

 public NavMeshAgent navMeshAgent;

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
         if(touch.phase == TouchPhase.Began)
         {
            Ray ray = Camera.main.ScreenPointToRay(touch.position); 
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                navMeshAgent.destination = hit.point;
            }
         }
        }
    }
}
