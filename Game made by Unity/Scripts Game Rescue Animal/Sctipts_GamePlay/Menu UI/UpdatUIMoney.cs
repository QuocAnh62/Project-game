using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUIMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text text_MoneyWin;
    [SerializeField] private TMP_Text text_MoneyLose;

    public static UpdateUIMoney Instace;
    private void Awake()
    {
        if (Instace == null) { Instace = this; }
    }

    public void UpdateTextMoneyWin(float money)
    {
        var result = (Mathf.Round(money * 100)) / 100.0;
        text_MoneyWin.text = result.ToString() + " $".ToString();
    }

    public void UpdateTextMoneyLose(float money)
    {
        var result = (Mathf.Round(money * 100)) / 100.0;
        text_MoneyLose.text = result.ToString() + " $".ToString();
    }
} 
