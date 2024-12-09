using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Courotine_Coint : MonoBehaviour
{
    public static Courotine_Coint instance;
    public Text Coint;
    public TMP_Text Coint_Menu_GameO;
    public TMP_Text Coints_ADS;

    int courotine = 0;
    private void Awake()
    {
        instance = this;       
    }

    private void Start()
    {
        Coint.text = "X " + courotine.ToString();
        PlayerPrefs.SetInt("Minus_Coint", 0);
    }

    public void AddPoints() // Plus 1 coint if eat coin
    {
        courotine += 1;
        Coint.text = "X " + courotine.ToString();
        Coint_Menu_GameO.text = courotine.ToString();
        Coints_ADS.text = "+ " + (courotine * 2).ToString(); // add coint x2

        int save = PlayerPrefs.GetInt("Coint");
        int T = save += 1;
        PlayerPrefs.SetInt("Coint", T);
        Debug.Log("Plus 1: " + save);

        PlayerPrefs.SetInt("Minus_Coint", courotine);
    }

    public void killEnemy() // Plus 2 coint if kill enemy
    {
        courotine += 2;
        Coint.text = "X " + courotine.ToString();
        Coint_Menu_GameO.text = courotine.ToString();
        Coints_ADS.text = "+ " + (courotine * 2).ToString();

        int save = PlayerPrefs.GetInt("Coint") ;
        int T = save += 2;
        PlayerPrefs.SetInt("Coint", T);
        Debug.Log("Plus 2: " + save);

        PlayerPrefs.SetInt("Minus_Coint", courotine);
        //Debug.Log("Minus_Coint " + PlayerPrefs.GetInt("Minus_Coint"));
    }


}
