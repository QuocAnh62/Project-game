using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeaturePlusSpeed : MonoBehaviour
{
    [SerializeField] private StaminaBar stamina_Bar;
    [SerializeField] private Clock_Speed clock_Speed;
    private float time = 13f; // This is time set back to normal speed
    private float plusSpeedPlayer = 0.2f;
    private float stamina_NeedPlsSpeed;

    private float equal = 0;
    bool isPlus = true;

    private void Start()
    {
        stamina_NeedPlsSpeed = Parameter_Manager.Instance.speedPlayer;
        StartCoroutine(BackToNormalSpeed());       
    }

    private void Update()
    {
        if (Parameter_Manager.Instance.current_Stamina <= 11) { isPlus = false; }
        else { isPlus = true; }

    }

    public void PlusSpeed()
    {
        Manager_AudioGamePlay.Instance.PlayEffect(Manager_AudioGamePlay.Instance.effect_SpeedUp);

        if (Parameter_Manager.Instance.current_Stamina >= stamina_NeedPlsSpeed && isPlus == true)
        {
            Parameter_Manager.Instance.current_Stamina -= stamina_NeedPlsSpeed;     

            Parameter_Manager.Instance.speedPlayer += plusSpeedPlayer;
            equal += plusSpeedPlayer; // this is for after 13s to minus speed and back to speed normal 

            UpdateUI();
        }
    }


    private void UpdateUI() // Update Ui Speed and Stamina
    {
        stamina_Bar.UpdateStaminaBar(Parameter_Manager.Instance.current_Stamina, Parameter_Manager.Instance.full_Stamina);
        clock_Speed.CurrentSpeed(Parameter_Manager.Instance.speedPlayer); // change the text current speed
        stamina_Bar.CurrentStamina(Parameter_Manager.Instance.current_Stamina); // change the text current stamina
    }

    private IEnumerator BackToNormalSpeed() // set speed back to normal speedPlayer
    {
        yield return new WaitForSeconds(time);

        Parameter_Manager.Instance.speedPlayer -= equal;
        clock_Speed.CurrentSpeed(Parameter_Manager.Instance.speedPlayer);     
    }
}
