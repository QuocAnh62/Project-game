using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDealDame : MonoBehaviour
{
    protected float currentHealth;
    [SerializeField] protected float maxHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    protected void HandleMinusHealth(int dame)
    {
        currentHealth -= dame;
        //Debug.Log("hit");
        if (currentHealth <= 0)
        {
            this.gameObject.SetActive(false);          
        }
    }
}
