using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerButton : ManagerUprate
{
    [SerializeField] private UpdateUI_Text updateUI_Text;
    public void Play()
    {
        SceneManager.LoadScene("GamePlay");
        Manager_Audio.Instance.PlayEffect(Manager_Audio.Instance.effect_Button);
    }

    public void UprateStamina()
    {
        PLus_Stamina();

        updateUI_Text.ShowTextStaminaBar(); // Update show text stamina
        updateUI_Text.ShowTextMoney(); // Update show text money
        updateUI_Text.ShowPrice(); // Update show text price

        Manager_Audio.Instance.PlayEffect(Manager_Audio.Instance.effect_Button);
    }

    public void UprateSpeed()
    {
        PLus_Speed();

        updateUI_Text.ShowTextStamina_Speed(); // Update show text speed
        updateUI_Text.ShowTextMoney(); // Update show text money
        updateUI_Text.ShowPrice(); // Update show text price

        Manager_Audio.Instance.PlayEffect(Manager_Audio.Instance.effect_Button);
    }

    public void Money()
    {
        Plus_money();

        updateUI_Text.ShowTextMoney(); // Update show text money
        updateUI_Text.ShowPrice(); // Update show text price

        Manager_Audio.Instance.PlayEffect(Manager_Audio.Instance.effect_Button);
    }

    public void PlusSpeedAndMoney()
    {
        Debug.Log("Speed and Money");
    }

    public void DisADS()
    {
        Debug.Log("Not ADS");
    }
}
