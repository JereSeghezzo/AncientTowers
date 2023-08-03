using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileState : MonoBehaviour
{
    public bool available=false;
    public bool towerObstruction;
    public int towerObstructionCount;
    public bool obstacleObstruction;

 public void UpdateTileAvailability()
 {
   if(towerObstructionCount > 0)
   {
      towerObstruction = true;
   } else towerObstruction = false;
    if(towerObstruction || obstacleObstruction)
    {
       available =  false;
    } else available =  true;
 }

}
