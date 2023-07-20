using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public TowerMain towerMain;

    public int TotalMoney = 50;

    //public GameObject moneyText;

    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI healthText;



    void Start()
    {
       // moneyText.text = "50g";
    }


    void Update()
    {
        healthText.text = towerMain.towerHealth.ToString();
    }
}
