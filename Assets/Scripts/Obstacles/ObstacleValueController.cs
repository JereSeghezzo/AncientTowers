using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleValueController : MonoBehaviour
{
    public GameManager gameManager;

    enum DataType {Tree, Rock, BigTree, BigRock}
    [SerializeField] DataType TowerType;

    public int RemoveCost;

    void Start()
    {
     gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();   
     SelectValue();   
    }

   void SelectValue()
    {
     if(TowerType == DataType.Tree) RemoveCost = gameManager.treeRemoveCost; 
     if(TowerType == DataType.Rock) RemoveCost = gameManager.rockRemoveCost; 
     if(TowerType == DataType.BigTree) RemoveCost = gameManager.bigTreeRemoveCost; 
     if(TowerType == DataType.BigRock) RemoveCost = gameManager.bigRockRemoveCost;
    } 
}
