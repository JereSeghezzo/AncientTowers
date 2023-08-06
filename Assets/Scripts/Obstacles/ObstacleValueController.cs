using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleValueController : MonoBehaviour
{
    public GameManager gameManager;

    enum DataType {Tree1, Tree2, Tree3, Rock, BigRock}
    [SerializeField] DataType obstacleType;

    public int RemoveCost;

    void Start()
    {
     gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();   
     SelectValue();   
    }

   void SelectValue()
    {
     if(obstacleType == DataType.Tree1) RemoveCost = gameManager.tree1RemoveCost; 
     if(obstacleType == DataType.Tree2) RemoveCost = gameManager.tree2RemoveCost; 
      if(obstacleType == DataType.Tree3) RemoveCost = gameManager.tree3RemoveCost; 
     if(obstacleType == DataType.Rock) RemoveCost = gameManager.rockRemoveCost; 
     if(obstacleType == DataType.BigRock) RemoveCost = gameManager.bigRockRemoveCost;
    } 
}
