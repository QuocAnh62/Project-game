using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ManagerUprate : SystemSpeed_PlusMoney
{ 
    protected void PLus_Speed()
    {
        if (PlayerPrefs.GetFloat("Current Money") >= PlayerPrefs.GetFloat("Price Speed"))
        {
            // Minus Money and Increase Price
            MinusMoney("Price Speed");

            float plus_Speed = PlayerPrefs.GetFloat("Speed Player") + 0.3f;
            PlayerPrefs.SetFloat("Speed Player", plus_Speed);

        }
    }

    protected void PLus_Stamina()
    {
        if (PlayerPrefs.GetFloat("Current Money") >= PlayerPrefs.GetFloat("Price Stamina"))
        {
            // Minus Money and Increase Price
            MinusMoney("Price Stamina");

            float equal = PlayerPrefs.GetFloat("Plus Stamina") + 2;  // +3, +5, +7, +9, +11,.......
            PlayerPrefs.SetFloat("Plus Stamina", equal); 

            float plus_Stamina = PlayerPrefs.GetFloat("Stamina") + equal;
            PlayerPrefs.SetFloat("Stamina", plus_Stamina);

        }        
    }

    protected void Plus_money()
    {
        if (PlayerPrefs.GetFloat("Current Money") >= PlayerPrefs.GetFloat("Price Money"))
        {
            // Minus Money and Increase Price
            MinusMoney("Price Money");

            PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + 0.5f);

        }
    }

    private void MinusMoney(string key)
    {
        float moneyAfterMinus = PlayerPrefs.GetFloat("Current Money") - PlayerPrefs.GetFloat(key);
        PlayerPrefs.SetFloat("Current Money", moneyAfterMinus);

        // Increase Price
        float increasePrice = PlayerPrefs.GetFloat(key) + 3.6f;
        PlayerPrefs.SetFloat(key, increasePrice);

    }
}
