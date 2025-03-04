using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemPlusMoney : MonoBehaviour
{
    public static SystemPlusMoney Instance;
    public float g_currnetMoney;
    public float g_moneyAfterPlus;
    private float timeWaitPlusMoney = 6f;
    

    private void Awake()
    {
        if (Instance == null) Instance = this; //Singelten                                    
    }

    private void Start()
    {
        g_currnetMoney = PlayerPrefs.GetFloat("Money");
    }

    private void Update()
    {
        timeWaitPlusMoney -= Time.deltaTime;
        if (timeWaitPlusMoney <= 0)
        {
            timeWaitPlusMoney = 0;
            PlusMoney();
        }
    }

    public void PlusMoney()
    {      
       g_currnetMoney += Time.deltaTime;
        g_moneyAfterPlus = g_currnetMoney;
    }
}
