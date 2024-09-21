using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy_Level : MonoBehaviour
{
    public int Money_Level0;
    public int Money_Level1;
    public int Money_Level2;
    public int Money_Level3;
    public int Money_Level4;
    public int Money_Level5;


    public void BuyLevel0()
    {
        int money = PlayerPrefs.GetInt("Coint_3th");
        if (money > Money_Level0)
        {
            int m_money = money - Money_Level0;
            PlayerPrefs.SetInt("Coint_3th", m_money);
            PlayerPrefs.SetInt("Level 0", 1);
            Debug.Log("0");
            Debug.Log(m_money);
        }
        else return;
    }


    public void BuyLevel1()
    {
        int money = PlayerPrefs.GetInt("Coint_3th");
        if (money > Money_Level1)
        {
            int m_money = money - Money_Level1;
            PlayerPrefs.SetInt("Coint_3th", m_money);
            PlayerPrefs.SetInt("Level 1", 1);
            Debug.Log("1");
        }
        else return;
    }


    public void BuyLevel2()
    {
        int money = PlayerPrefs.GetInt("Coint_3th");
        if (money > Money_Level2)
        {
            int m_money = money - Money_Level2;
            PlayerPrefs.SetInt("Coint_3th", m_money);
            PlayerPrefs.SetInt("Level 2", 1);
            Debug.Log("2");
        }
        else return;
    }

    public void BuyLevel3()
    {
        int money = PlayerPrefs.GetInt("Coint_3th");
        if (money > Money_Level3)
        {
            int m_money = money - Money_Level3;
            PlayerPrefs.SetInt("Coint_3th", m_money);
            PlayerPrefs.SetInt("Level 3", 1);
            Debug.Log("3");
        }
        else return;
    }

    public void BuyLevel4()
    {
        int money = PlayerPrefs.GetInt("Coint_3th");
        if (money > Money_Level4)
        {
            int m_money = money - Money_Level4;
            PlayerPrefs.SetInt("Coint_3th", m_money);
            PlayerPrefs.SetInt("Level 4", 1);
            Debug.Log("4");
        }
        else return;
    }

    public void BuyLevel5()
    {
        int money = PlayerPrefs.GetInt("Coint_3th");
        if (money > Money_Level5)
        {
            int m_money = money - Money_Level5;
            PlayerPrefs.SetInt("Coint_3th", m_money);
            PlayerPrefs.SetInt("Level 5", 1);
            Debug.Log("5");
        }
        else return;
    }
}
