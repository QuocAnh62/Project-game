using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpRandom : MonoBehaviour
{
    public static LevelUpRandom instance;
    [SerializeField] private TMP_Text text_Math;
    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    public void Harder()
    {
        switch (Manager_ButtonRandom.score)
        {
            case 10:
                GameCore_Random.max_Value = 15;
                GameCore_Random.min_Value = 4;
                break;
            case 20:
                GameCore_Random.time_TurnOffText = 2f;
                GameCore_Random.min_Value = 5;
                GameCore_Random.max_Value = 20;
                break;
            case 30:
                GameCore_Random.time_TurnOffText = 3f;

                GameCore_Random.min_Value = 10;
                GameCore_Random.max_Value = 25;

                GameCore_Random.min_ValueShowText = 4;
                GameCore_Random.max_ValueShowText = 6;
                break;

            case 40:
                
                GameCore_Random.time_TurnOffText = 4f;

                GameCore_Random.min_Value = 10;
                GameCore_Random.max_Value = 30;
                break;

            case 140:
                GameCore_Random.max_ValueShowText = 7;
                break;

            case 1000:
                Application.Quit();
                break;
        }
        LevelUpValue();

    }
    private void LevelUpValue()
    {
        if (Manager_ButtonRandom.score >= 50 && Manager_ButtonRandom.score <= 990 && Manager_ButtonRandom.score % 10 == 0)
        {
            if (Manager_ButtonRandom.score == 60) { GameCore_Random.time_TurnOffText = 5f; }
           
            GameCore_Random.max_Value = Manager_ButtonRandom.score - 10;
            GameCore_Random.min_Value = Manager_ButtonRandom.score - 30;

           // SetValurOther();
        }

        if (Manager_ButtonRandom.score >= 20 && Manager_ButtonRandom.score <= 990 && Manager_ButtonRandom.score % 20 == 0)
        {
            Manager_ButtonRandom.getback = true;

            if (GameCore_Random.time_TurnOffText < 9) { GameCore_Random.time_TurnOffText += 0.5f; }
        }
    }

    private void SetValurOther()
    {
        if (Manager_ButtonRandom.score >= 50 && Manager_ButtonRandom.score <= 990 && Manager_ButtonRandom.score % 20 == 0)
        {
            if (text_Math.fontSize > 17) { text_Math.fontSize--; }

            if (GameCore_Random.time_TurnOffText < 9) { GameCore_Random.time_TurnOffText += 0.5f; }
        }     
    }

}
