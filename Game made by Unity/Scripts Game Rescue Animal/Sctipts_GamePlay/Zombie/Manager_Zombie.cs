using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Zombie : Zombie_Moving
{
    protected void InactiveSomeUI()
    {
        foreach (GameObject go in Parameter_Zombie.Instance.inActive)
        {
            go.SetActive(false); // turn off joystick
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            Time.timeScale = 0;
            // Save money when show menu Ui You lose          
            float saveMoney = PlayerPrefs.GetFloat("Current Money") + SystemPlusMoney.Instance.g_moneyAfterPlus;
            // show money menu Lose
            UpdateUIMoney.Instace.UpdateTextMoneyLose(SystemPlusMoney.Instance.g_moneyAfterPlus);

            PlayerPrefs.SetFloat("Current Money", saveMoney); // save current money

            Parameter_Zombie.Instance.menu_Lose.SetActive(true); // show menu Ui You Lose
            InactiveSomeUI();

            Manager_AudioGamePlay.Instance.PlayEffect(Manager_AudioGamePlay.Instance.effect_Fail); // Playe effect
        }
    }
}
