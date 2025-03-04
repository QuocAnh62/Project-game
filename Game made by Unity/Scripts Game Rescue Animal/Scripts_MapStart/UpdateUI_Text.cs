using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUI_Text : MonoBehaviour
{
    [Header("=== Text Stamina ===")]
    [SerializeField] TMP_Text text_Stamina;
    [SerializeField] TMP_Text text_StaminaBar;
    // Text Speed
    [Header("=== Text Speed ===")]
    [SerializeField] TMP_Text text_Speed;
    [SerializeField] TMP_Text text_ClockSpeed;
    // Text money
    [Header("=== Text Money ===")]
    [SerializeField] TMP_Text text_CurrentMoney;
    [SerializeField] TMP_Text text_Money;

    // Price Text
    [Header("=== Text All Price ===")]
    [SerializeField] TMP_Text text_PriceStamina;
    [SerializeField] TMP_Text text_PriceSpeed;
    [SerializeField] TMP_Text text_PriceMoney;

    private void Start()
    {
        ShowTextStaminaBar();
        ShowTextStamina_Speed();
        ShowTextMoney();
        ShowPrice();
    }

    public void ShowTextStaminaBar()
    {
        text_StaminaBar.text = 
            PlayerPrefs.GetFloat("Stamina").ToString() + "/" + PlayerPrefs.GetFloat("Stamina").ToString();

        text_Stamina.text = PlayerPrefs.GetFloat("Stamina").ToString();
    }
    public void ShowTextStamina_Speed()
    {      
        float a = PlayerPrefs.GetFloat("Speed Player");
        var result = (Mathf.Round(a * 100)) / 100.0; // calculate to take 1 decimal place ( because error text float)

        text_Speed.text = result.ToString();
        text_ClockSpeed.text = result.ToString();
    }

    public void ShowTextMoney()
    {
        var m = (Mathf.Round(PlayerPrefs.GetFloat("Current Money") * 100)) / 100.0;
        text_CurrentMoney.text = m.ToString();

        text_Money.text = PlayerPrefs.GetFloat("Money").ToString();
    }

    public void ShowPrice()
    {
        text_PriceStamina.text = PlayerPrefs.GetFloat("Price Stamina").ToString();
        text_PriceSpeed.text = PlayerPrefs.GetFloat("Price Speed").ToString();
        text_PriceMoney.text = PlayerPrefs.GetFloat("Price Money").ToString();
    }
}
