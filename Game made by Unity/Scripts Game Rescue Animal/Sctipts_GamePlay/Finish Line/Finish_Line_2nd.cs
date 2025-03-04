using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_Line_2nd : MonoBehaviour
{
    [SerializeField] private GameObject menu_End;

    private void ShowMenuEnd()
    {
        menu_End.SetActive(true);
    }

    private void Harder()
    {
        PlayerPrefs.SetInt("Number Car", Parameter_Manager.Instance.number_Car + 2);

        PlayerPrefs.SetFloat("Speed Zombie", Parameter_Zombie.Instance.speedZombie + 2);

        PlayerPrefs.SetFloat("Speed Animal", Parameter_Manager.Instance.speedAnimal + 2);

        PlayerPrefs.SetFloat("Time Zombie Move", PlayerPrefs.GetFloat("Time Zombie Move") + 1);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ShowMenuEnd();
            Harder();
            Manager_AudioGamePlay.Instance.PlayEffect(Manager_AudioGamePlay.Instance.effect_Win);
            Time.timeScale = 0;

            // Save money when show menu Ui Winner  
            float saveMoney = PlayerPrefs.GetFloat("Current Money") + SystemPlusMoney.Instance.g_moneyAfterPlus;
            UpdateUIMoney.Instace.UpdateTextMoneyWin(SystemPlusMoney.Instance.g_moneyAfterPlus); // show money menu Win
            PlayerPrefs.SetFloat("Current Money", saveMoney);

            Debug.Log(PlayerPrefs.GetFloat("Current Money"));
        }
    }
}
