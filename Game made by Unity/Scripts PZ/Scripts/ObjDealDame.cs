using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDealDame : MonoBehaviour
{
    protected float currentHealth;
    [SerializeField] protected float maxHealth;

    protected void Start()
    {
        currentHealth = maxHealth;        
    }

    protected virtual void HandleMinusHealth(int dame)
    {
        currentHealth -= dame;
        if (currentHealth <= 0)
        {
            this.gameObject.SetActive(false);          
        }
    }
}
