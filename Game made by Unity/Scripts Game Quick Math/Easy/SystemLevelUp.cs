using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SystemLevelUp : MonoBehaviour
{
    public static SystemLevelUp instance;
    [SerializeField] private TMP_Text text_Math;
    private void Awake()
    {
        if (instance == null) { instance = this; }
    }
    public void Harder()
    {
        switch (Manager_ButtonEasy.score)
        {

            case 10:
                GameCore_Easy.max_Value = 15;
                break;
            case 20:
                OverTimeEasy.duration = 6f;

                GameCore_Easy.time_TurnOffText = 0.7f;               
                GameCore_Easy.max_Value = 20;
                break;

            case 30:
                OverTimeEasy.duration = 7f;

                GameCore_Easy.time_TurnOffText = 0.8f;               
                GameCore_Easy.max_Value = 30;
                break;

            case 40:
                OverTimeEasy.duration = 8f;

                GameCore_Easy.time_TurnOffText = 1f;
                GameCore_Easy.max_Value = 40;
                break;

            case 100:
                GameCore_Easy.time_TurnOffText += 0.5f;
                GameCore_Easy.valueCount = 3;
                break;

            case 250:
                text_Math.fontSize -= 2;
                break;

            case 1000:
                Application.Quit();
                break;
        }

        LevelUpValue();

    }
    private void LevelUpValue()
    {
        if (Manager_ButtonEasy.score >= 50 && Manager_ButtonEasy.score <= 990 && Manager_ButtonEasy.score % 10 == 0)
        {
            GameCore_Easy.max_Value = Manager_ButtonEasy.score - 10;
            SetValueOther();
        }
        if (Manager_ButtonEasy.score >= 30 && Manager_ButtonEasy.score <= 990 && Manager_ButtonEasy.score % 30 == 0)
        {           
            Manager_ButtonEasy.getback = true; // set get back again
        }
    }
  
    private void SetValueOther()
    {
        if (Manager_ButtonEasy.score >= 100 && Manager_ButtonEasy.score <= 990 && Manager_ButtonEasy.score % 50 == 0)
        {
            if (text_Math.fontSize > 21) { text_Math.fontSize--; }
        }
        if (Manager_ButtonEasy.score >= 150 && Manager_ButtonEasy.score <= 990 && Manager_ButtonEasy.score % 150 == 0)
        {
            
            if (OverTimeEasy.duration < 17) OverTimeEasy.duration += 0.5f;
            if (GameCore_Easy.time_TurnOffText < 2.5f) { GameCore_Easy.time_TurnOffText += 0.5f; }
            if (GameCore_Easy.valueCount < 5) { GameCore_Easy.valueCount++; }
            if (text_Math.fontSize > 21) { text_Math.fontSize -= 2; }
        }
    }
}
