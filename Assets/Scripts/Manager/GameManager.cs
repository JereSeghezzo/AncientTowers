using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int PlayerCoins;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI healthText;

    void Start()
    {
      PlayerCoins += 200;  
      UpdateMoneyText();
    }

    void Update()
    {
        
    }

   public void UpdateMoneyText()
   {
     moneyText.text = PlayerCoins.ToString() + "$";
   }
}
