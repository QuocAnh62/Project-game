using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net.Sockets;

public class Menu_Shop : MonoBehaviour
{
    public TMP_Text CointShop;
    public TMP_Text N_Rocket;
    public int Money_Rocket;


    private void Update()
    {
        Show_Coint_Rocket();       
    }

    public void Show_Coint_Rocket()
    {
        int Coint = PlayerPrefs.GetInt("Coint_3th");       
        int Rocket = PlayerPrefs.GetInt("Rocket");

        CointShop.text = Coint.ToString();
        N_Rocket.text = "X " + Rocket.ToString();
    }

    public void Buy_Rocket()
    {
        int Coint = PlayerPrefs.GetInt("Coint_3th");
        int rocket = PlayerPrefs.GetInt("Rocket");
        if (Coint > Money_Rocket)
        {
            Coint -= Money_Rocket;
            rocket += 1;
            PlayerPrefs.SetInt("Coint_3th", Coint);
            PlayerPrefs.SetInt("Coint", Coint);
            PlayerPrefs.SetInt("Rocket", rocket);
            N_Rocket.text = "X " + rocket.ToString();
            CointShop.text = Coint.ToString();
        }
        else
            Debug.Log("BabyNoMoney");
    }
}
