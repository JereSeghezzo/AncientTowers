using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{

    public TowerStats selectedTower;
    public GameObject DamageUI;
    public GameObject RangeUI;
    public GameObject SpeedUI;

    public Image LvlBar;
    public GameObject button;
    public TMP_Text priceText;

    public int upgradePriceDamage;
    public int upgradePriceRange;
    public int upgradePriceFireRate;

    public GameManager gameManager;
    public TowerMenuController towerMenuController;

 public void UpdateSelectedTower()
 {
   selectedTower.UpdateStatsLvl();
   LvlBar = DamageUI.transform.Find("LvlBarFill").GetComponent<Image>();
   priceText = DamageUI.transform.Find("Price").GetComponent<TMP_Text>();
   button = LvlBar.gameObject.transform.GetChild(0).gameObject;
   LvlBar.fillAmount = selectedTower.damageLvl / 3;
   priceText.text = selectedTower.damagePrice.ToString();
   if(selectedTower.damageLvl >= 3)
   {
   button.SetActive(false);
   priceText.text = "Maximo";
   } else button.SetActive(true);

   selectedTower.UpdateStatsLvl();
   LvlBar = RangeUI.transform.Find("LvlBarFill").GetComponent<Image>();
   priceText = RangeUI.transform.Find("Price").GetComponent<TMP_Text>();
   button = LvlBar.gameObject.transform.GetChild(0).gameObject;
   LvlBar.fillAmount = selectedTower.rangeLvl / 3;
   priceText.text = selectedTower.rangePrice.ToString();
   if(selectedTower.rangeLvl >= 3)
   {
   button.SetActive(false);
   priceText.text = "Maximo";
   } else button.SetActive(true);

   selectedTower.UpdateStatsLvl();
   LvlBar = SpeedUI.transform.Find("LvlBarFill").GetComponent<Image>();
   priceText = SpeedUI.transform.Find("Price").GetComponent<TMP_Text>();
   button = LvlBar.gameObject.transform.GetChild(0).gameObject;
   LvlBar.fillAmount = selectedTower.fireRateLvl / 3;
   priceText.text = selectedTower.fireRatePrice.ToString();
   if(selectedTower.fireRateLvl >= 3)
   {
   button.SetActive(false);
   priceText.text = "Maximo";
   } else button.SetActive(true);


 }

 public void AddDamageLvl()
 {
  if(selectedTower.damageLvl < 3 && gameManager.playerCoins >= selectedTower.damagePrice)
  {
   selectedTower.damageLvl += 1;
   gameManager.playerCoins -= selectedTower.damagePrice;
  } else towerMenuController.NotEnoghCoinsAlert();
  UpdateSelectedTower();
  gameManager.UpdateMoneyText();
 }

 public void AddRangeLvl()
 {
  if(selectedTower.rangeLvl < 3 && gameManager.playerCoins >= selectedTower.rangePrice)
  {
   selectedTower.rangeLvl += 1;
   gameManager.playerCoins -= selectedTower.rangePrice;
  } else towerMenuController.NotEnoghCoinsAlert();
  UpdateSelectedTower();
  gameManager.UpdateMoneyText();
 }

 public void AddFireRateLvl()
 {
  if(selectedTower.fireRateLvl < 3 && gameManager.playerCoins >= selectedTower.fireRatePrice)
  {
   selectedTower.fireRateLvl += 1;
   gameManager.playerCoins -= selectedTower.fireRatePrice;
  } else towerMenuController.NotEnoghCoinsAlert();
  UpdateSelectedTower();
  gameManager.UpdateMoneyText();
 }
}
