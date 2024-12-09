using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_HeartPlayer : MonoBehaviour
{
    protected int Health = 4;
    [SerializeField] protected List<Image> heart;

    [SerializeField] protected int currenthealth_Player;
    [SerializeField] protected int maxHealth_Player;

    protected virtual void Start()
    {
        currenthealth_Player = maxHealth_Player;
    }

    protected void Active_Heart(int health)
    {
        for (int i = 0; i < heart.Count; i++)
        {
            if (i < health)                        
                heart[i].enabled = true;                                           
            else            
                heart[i].enabled = false;
        }
    }
    
    protected void Reset_Health()
    {
        currenthealth_Player = maxHealth_Player / 2;
        Health = currenthealth_Player;
        Active_Heart(Health);
    }

}
