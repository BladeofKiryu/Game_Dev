using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
   [SerializeField]
   public Image healthBar;
   [SerializeField]
   float health = 10f;
   float maximumHealth;
   EnemyStockUp enemyStockUp;
   public bool isAwaken;

   private void Awake()
   {
      maximumHealth = health;
      enemyStockUp = gameObject.GetComponent<EnemyStockUp>();
      isAwaken = false;
   }
   void Update()
   {
      if (enemyStockUp && !enemyStockUp.hasStockedUp)
      {
         enemyStockUp.StockUp();
      }
      UpdateHUD();

      if (health <= 0)
      {
         Death();
      }
   }
   void UpdateHUD()
   {
      if (healthBar)
      {
         healthBar.fillAmount = health / maximumHealth;
      }
   }

   public void DepleteHealth(int healthDamage)
   {
      if (isAwaken)
      {
         health -= 1;
      }
   }

   void Death()
   {
      if (isAwaken)
      {
         if (enemyStockUp && enemyStockUp.hasStockedUp)
         {
            enemyStockUp.DropItems();
         }
         GameObject.Destroy(gameObject);
      }
   }

   public void GetKilled()
   {
      Death();
   }
}
