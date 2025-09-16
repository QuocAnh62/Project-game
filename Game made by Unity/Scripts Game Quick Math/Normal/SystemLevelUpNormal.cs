using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SystemLevelUpNormal : MonoBehaviour
{
    public static SystemLevelUpNormal instance;
    //[SerializeField] private GameObject obj_TimeOver;
    [SerializeField] private TMP_Text text_Math;
    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    public void Harder()
    {
        switch (Manager_ButtonNormal.score)
        {
            case 10:
                GameCore_Normal.time_TurnOffText = 0.8f;
                GameCore_Normal.max_Value = 15;
                SystemOverTime.duration = 7f;

                //PlayerPrefs.SetInt("ScoreNormal", 1);
                break;
            case 20:
                GameCore_Normal.time_TurnOffText = 1f;
                GameCore_Normal.max_Value = 20;
                SystemOverTime.duration = 9f;
                break;
            case 30:
                GameCore_Normal.max_Value = 25;
                break;
            case 40:
                GameCore_Normal.max_Value = 30;
                SystemOverTime.duration = 11f;
                break;
            case 50:
                GameCore_Normal.time_TurnOffText = 1.25f;
                GameCore_Normal.valueCount = 3;
                break;

            case 150:
                text_Math.fontSize -= 5f;
                SystemOverTime.duration += 1f;
                GameCore_Normal.time_TurnOffText = 3f;
                GameCore_Normal.valueCount = 4;
                break;

            case 300:
                text_Math.fontSize -= 5f;
                SystemOverTime.duration += 1f;
                GameCore_Normal.time_TurnOffText = 4f;
                GameCore_Normal.valueCount = 5;
                break;

            case 1000:
                Application.Quit();
                break;
        }
        LevelUpValue();

    }

    private void LevelUpValue()
    {
        if (Manager_ButtonNormal.score >= 50 && Manager_ButtonNormal.score <= 500 && Manager_ButtonNormal.score % 10 == 0)
        {
            GameCore_Normal.max_Value = Manager_ButtonNormal.score - 10;
            SetValueOther();
        }
        if (Manager_ButtonNormal.score >= 30 && Manager_ButtonNormal.score <= 990 && Manager_ButtonNormal.score % 30 == 0)
        {
            Manager_ButtonNormal.getback = true;
        }
    }

    private void SetValueOther()
    {
        if (Manager_ButtonNormal.score >= 50 && Manager_ButtonNormal.score <= 990 && Manager_ButtonNormal.score % 50 == 0)
        {
            if (text_Math.fontSize > 20) { text_Math.fontSize--; }
            if (GameCore_Normal.time_TurnOffText < 2) { GameCore_Normal.time_TurnOffText += 0.25f; }
            if (SystemOverTime.duration < 17) { SystemOverTime.duration++; }          
        }
        if (Manager_ButtonNormal.score >= 400 && Manager_ButtonNormal.score <= 990 && Manager_ButtonNormal.score % 100 == 0)
        {
            GameCore_Normal.time_TurnOffText += 0.5f;
            SystemOverTime.duration += 1f;
        }
    }

}
