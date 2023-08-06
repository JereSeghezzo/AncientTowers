using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleValueController : MonoBehaviour
{
    public GameManager gameManager;

    enum DataType {Tree, Rock, BigTree, BigRock}
    [SerializeField] DataType obstacleType;

    public int RemoveCost;

    void Start()
    {
     gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();   
     SelectValue();   
    }

   void SelectValue()
    {
     if(obstacleType == DataType.Tree) RemoveCost = gameManager.treeRemoveCost; 
     if(obstacleType == DataType.Rock) RemoveCost = gameManager.rockRemoveCost; 
     if(obstacleType == DataType.BigTree) RemoveCost = gameManager.bigTreeRemoveCost; 
     if(obstacleType == DataType.BigRock) RemoveCost = gameManager.bigRockRemoveCost;
    } 
}
