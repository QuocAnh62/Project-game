using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Parameter : MonoBehaviour
{
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        setParameter();

        Destroy(this.gameObject, 0.5f);
    }

    private void setParameter()
    {
        if (PlayerPrefs.GetInt("CheckDestroy") <= 0)
        {
            PlayerPrefs.SetInt("Number Car", 10);

            // Speed
            PlayerPrefs.SetFloat("Speed Animal", 11f);
            PlayerPrefs.SetFloat("Speed Zombie", 12f);
            PlayerPrefs.SetFloat("Speed Player", 9);

            //Stamina
            PlayerPrefs.SetFloat("Stamina", 64);
            PlayerPrefs.SetFloat("Plus Stamina", 1);

            //Money
            PlayerPrefs.SetFloat("Current Money", 0);
            PlayerPrefs.SetFloat("Money", 64);

            //Price
            PlayerPrefs.SetFloat("Price Stamina", 30);
            PlayerPrefs.SetFloat("Price Speed", 30);
            PlayerPrefs.SetFloat("Price Money", 30);

            //Time
            PlayerPrefs.SetFloat("Time Zombie Move", 3);

            PlayerPrefs.SetInt("CheckDestroy", 1);

        }
    }

}
