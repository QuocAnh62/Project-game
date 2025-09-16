using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SystemLevelUpHard : MonoBehaviour
{
    public static SystemLevelUpHard instance;
    [SerializeField] private TMP_Text text_Math;
    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    public void Harder()
    {
        switch (Manager_ButtonHard.score)
        {
            //case 5:
            //    PlayerPrefs.SetInt("ScoreHard", 1);
            //    break;
            case 20:
                text_Math.fontSize--;
                GameCore_Hard.valueCount = 4;
                GameCore_Hard.time_TurnOffText = 2f;

                GameCore_Hard.min_Value = 20;
                GameCore_Hard.max_Value = 30;
                break;
            case 30:
                text_Math.fontSize--;
                GameCore_Hard.time_TurnOffText = 2.5f;

                GameCore_Hard.min_Value = 30;
                GameCore_Hard.max_Value = 40;
                break;
            case 40:
                text_Math.fontSize--;
                GameCore_Hard.valueCount = 5;
                GameCore_Hard.time_TurnOffText = 3f;

                break;
            case 1000:
                Application.Quit();
                break;
        }

        LevelUpValue();
    }
    private void LevelUpValue()
    {
        if (Manager_ButtonHard.score >= 50 && Manager_ButtonHard.score <= 990 && Manager_ButtonHard.score % 10 == 0)
        {
            if (Manager_ButtonHard.score == 50) { GameCore_Hard.time_TurnOffText = 5f; }
            GameCore_Hard.max_Value = Manager_ButtonHard.score - 10;
            GameCore_Hard.min_Value = Manager_ButtonHard.score - 20;

            SetValueOther();
        }

        // handle set get back again
        if (Manager_ButtonHard.score >= 20 && Manager_ButtonHard.score <= 990 && Manager_ButtonHard.score % 20 == 0)
        {
            Manager_ButtonHard.getback = true;
        }
    }

    private void SetValueOther()
    {
        // handle minus text show Math fontSize and plus time to turnOffText show math
        if (Manager_ButtonHard.score >= 50 && Manager_ButtonHard.score <= 990 && Manager_ButtonHard.score % 10 == 0)
        {
            if (text_Math.fontSize > 18) { text_Math.fontSize--; }
            if (GameCore_Hard.time_TurnOffText <= 9) GameCore_Hard.time_TurnOffText += 0.75f;
        }        

        if (Manager_ButtonHard.score >= 50 && Manager_ButtonHard.score <= 990 && Manager_ButtonHard.score % 100 == 0)
        {
            if (text_Math.fontSize > 18) { text_Math.fontSize -= 2; }
        }
    }


    public void HarderForEasterEgg()
    {
        for(int i = 0; i <= 4; i++)
        {
            GameCore_Hard.max_Value = Manager_ButtonHard.score - 10;
            GameCore_Hard.min_Value = Manager_ButtonHard.score - 20;
            text_Math.fontSize--;
            GameCore_Hard.time_TurnOffText += 0.75f;
        }
        text_Math.fontSize -= 2;
        GameCore_Hard.valueCount = 5;
    }   
}
