using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : MonoBehaviour
{
    [Header("Tower Stats")]
    public float damage;
    public float range;
    public float fireRate;

    float _damage;
    float _range;
    float _fireRate;



[Header("Tower Levels")]
    public float damageLvl;
    public float rangeLvl;
    public float fireRateLvl;

    [Header("Upgrade Prices")]
    public int damagePrice;
    public int rangePrice;
    public int fireRatePrice;

    int _damagePrice;
    int _rangePrice;
    int _fireRatePrice;


[Header("Level Multiplier")]
    public float lvlMultiplier;

    void Start()
    {
     _damage = damage;
     _range = range;
     _fireRate = fireRate;

    _damagePrice = damagePrice;
    _rangePrice = rangePrice;
    _fireRatePrice = fireRatePrice;

    }
    

    public void UpdateStatsLvl()
    {
     if(damageLvl > 0)
     {
      damage = _damage + (_damage * damageLvl * lvlMultiplier);
      damagePrice = (int)(_damagePrice + (_damagePrice * damageLvl));
     }

    if(rangeLvl > 0)
     {
      range = _range + (_range * rangeLvl * lvlMultiplier);
      rangePrice = (int)(_rangePrice + (_rangePrice * rangeLvl));
     }

  if(fireRateLvl > 0)
     {
      fireRate = _fireRate + (_fireRate * fireRateLvl * lvlMultiplier);
      fireRatePrice = (int)(_fireRatePrice + (_fireRatePrice * fireRateLvl));
     }
    }
}
