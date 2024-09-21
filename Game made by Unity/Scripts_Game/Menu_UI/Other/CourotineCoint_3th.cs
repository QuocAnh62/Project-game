using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CourotineCoint_3th : MonoBehaviour
{
    public static CourotineCoint_3th coint_3h;

    private void Awake()
    {
        coint_3h = this;
        PlayerPrefs.SetInt("Minus_Coint", 0);
    }
    public void CheckCoint()
    {
        if (Receive_Dame.currentHealth_Player <= 0)
        {
            int coint_3th = PlayerPrefs.GetInt("Coint");
            PlayerPrefs.SetInt("Coint_3th", coint_3th);
            Debug.Log(coint_3th);
        }
        else if(Receive_Dame.currentHealth_Player > 0)
        {
            int coint_3th = PlayerPrefs.GetInt("Coint") - PlayerPrefs.GetInt("Minus_Coint");  
            PlayerPrefs.SetInt("Coint", coint_3th) ;
            Debug.Log("NotSavebb$ " + coint_3h);
        }
    }
}
