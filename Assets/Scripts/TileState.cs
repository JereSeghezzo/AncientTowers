using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileState : MonoBehaviour
{
    public bool available=false;
    public bool towerObstruction;
    public bool obstacleObstruction;

 public void UpdateTileAvailability()
 {
    if(towerObstruction || obstacleObstruction)
    {
       available =  false;
    } else available =  true;
 }
}
