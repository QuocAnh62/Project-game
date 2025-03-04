using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StaminaBar : MonoBehaviour
{
    [SerializeField] private Image full_StaminaBar;
    [SerializeField] TMP_Text current_Stamina;
    [SerializeField] TMP_Text full_Stamina;
    private float time_Plus = 7f; // this is time cool down plus Stamina 


    private void Start()
    {
        UpdateStaminaBar(PlayerPrefs.GetFloat("Stamina"), PlayerPrefs.GetFloat("Stamina"));
        UpdateTextStamina(PlayerPrefs.GetFloat("Stamina"), PlayerPrefs.GetFloat("Stamina"));
    }

    private void FixedUpdate()
    {
        ManagerPlusStamina();
    }

    public void UpdateStaminaBar(float currentStamina, float maxStamina) // Updat stamina Image UI Stamina bar
    {
        full_StaminaBar.fillAmount = currentStamina / maxStamina;
    }

    public void UpdateTextStamina(float currentStamina, float maxStamina)
    {
        current_Stamina.text = currentStamina.ToString();
        full_Stamina.text = maxStamina.ToString();
    }


    public void CurrentStamina(float stamina) // update text of current stamina
    {
        current_Stamina.text = stamina.ToString();
    } 


    private void ManagerPlusStamina() // use function plus stamina follow time
    {
        time_Plus -= Time.deltaTime;
        if(time_Plus <= 0)
        {
            Pluss_Stamina();
            time_Plus = 1f;
        }
    }

    private void Pluss_Stamina()// function plus stamina
    {
        if (Parameter_Manager.Instance.current_Stamina < Parameter_Manager.Instance.full_Stamina)
        {            
            float stamina = Parameter_Manager.Instance.current_Stamina += Parameter_Manager.Instance.speedPlayer; // plus stamina
            NotGreater_MaxStamina(stamina);
        }
        else // if current stamina greater max stamina.Then set current stamina = max stamina
        {
            Parameter_Manager.Instance.current_Stamina = Parameter_Manager.Instance.full_Stamina;
        }
    }

    private void NotGreater_MaxStamina(float stamina)
    {
        if(stamina < Parameter_Manager.Instance.full_Stamina)
        {
            CurrentStamina(stamina);
            UpdateStaminaBar(stamina, Parameter_Manager.Instance.full_Stamina);
        }
        else
        {
            CurrentStamina(Parameter_Manager.Instance.full_Stamina);
            UpdateStaminaBar(stamina, Parameter_Manager.Instance.full_Stamina);
        }
    }
  
}
