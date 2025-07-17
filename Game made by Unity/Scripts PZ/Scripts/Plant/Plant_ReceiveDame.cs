using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_ReceiveDame : ObjDealDame
{
    private bool isReceiDame;
    private float timeReceiDame = 0;

    public float coolDownReceiDame;

    protected void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        timeReceiDame -= Time.deltaTime;
        if (isReceiDame && timeReceiDame <= 0)
        {
            HandleMinusHealth(1);
            timeReceiDame = coolDownReceiDame;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Begin Receive Dame");
            isReceiDame = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Exit Receive Dame");
            isReceiDame = false;
        }
    }
}
