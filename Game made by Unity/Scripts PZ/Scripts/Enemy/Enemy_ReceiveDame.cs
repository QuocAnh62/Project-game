using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ReceiveDame : ObjDealDame
{
    public int dameEnemyRecieve;
    public static int nEnemy = 0;

    protected void OnEnable()
    {
        currentHealth = maxHealth;
    }

    protected override void HandleMinusHealth(int dame)
    {
        currentHealth -= dame;
        if(currentHealth <= 0)
        {
            nEnemy++;
            Debug.Log(nEnemy);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            HandleMinusHealth(dameEnemyRecieve);
        }       
    }
}
