using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
 public Image healthBarSprite;

 Camera cam;

 void Start()
 {
   cam = Camera.main; 
 }

 public void UpdateHealthBar(float maxHealth, float currentHealth)
 {
   healthBarSprite.fillAmount = currentHealth / maxHealth;
 }
 
 void FixedUpdate() 
 {
   transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
 }
}
