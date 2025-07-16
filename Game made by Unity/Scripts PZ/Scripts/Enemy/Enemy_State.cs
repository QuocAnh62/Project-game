using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_State : ObjDealDame
{
    public int dameEnemyRecieve;
    //public int curentHealth;

    protected override void Start()
    {
        currentHealth = 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            HandleMinusHealth(dameEnemyRecieve);
        }
    }
}
