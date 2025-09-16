using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Manager_ButtonNormal : HandleText_Normal
{
    public static int score = 0;
    private int egg = 0;
    public static bool getback;

    private void Start()
    {
        Time.timeScale = 1;
        score = 0;
        egg = 0;
        getback = true;
        SystemLevelUpNormal.instance.Harder();
    }
    private void Update()
    {
        if (cout < 0) { cout = 0; }
        else if (cout > maxCount) { cout = maxCount; }
    }

    public void Number_0()
    {
        SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.button_0);
        TextInput("0");
    }
    public void Number_1()
    {
        SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.button_1);
        TextInput("1");
    }
    public void Number_2()
    {
        SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.button_2);
        TextInput("2");
    }

    public void Number_3()
    {
        SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.button_3);
        TextInput("3");
    }

    public void Number_4()
    {
        SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.button_4);
        TextInput("4");
    }

    public void Number_5()
    {
        SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.button_5);
        TextInput("5");
    }

    public void Number_6()
    {
        SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.button_6);
        TextInput("6");
    }

    public void Number_7()
    {
        SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.button_7);
        TextInput("7");
    }

    public void Number_8()
    {
        SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.button_8);
        TextInput("8");
    }

    public void Number_9()
    {
        SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.button_9);
        TextInput("9");
    }

    public void Dot()
    {
        SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.morse_Short);
        TextInput(".");
    }

    public void Minus()
    {
        SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.morse_Long);
        TextInput("-");
    }


   
    public void Delete()
    {
        SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.button_Delete);
        if (text_Input.text == "Enter Number") { text_Input.text = ""; }
        else
        {
            AdjustFontSize("delete");
            --cout;

            if (text_Input.text.Length > 0)
            {
                text_Input.text = text_Input.text.Substring(0, text_Input.text.Length - 1);
            }
        }
    }


    public void Submit()
    {
        cout = 0;
        SystemOverTime.elapsedTime = 0;
        SystemOverTime.timeStart = 0.7f;

        if (text_Input.text == GameCore_Normal.string_Total) // show menu Correct
        {
            score ++;
            text_Score.text = score.ToString();
            SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.effect_Winner);
            Eastereggs.instance.ActiveTimeOver();
            StartCoroutine(GamePlay());
        }

        else if (text_Input.text == SystemHandleEasterEgg.egg_Normal && egg == 0) // show easter eggs
        {
            score += 5;
            egg = 1;
            text_Score.text = score.ToString();

            SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.effect_Winner);
            Eastereggs.instance.Eastereggs_Normal(text_Input.text);
        }

        else if (text_Input.text != GameCore_Normal.string_Total && score >= 10 && getback == true) // show get back if wrong answer
        {
            getBack.SetActive(true);
            getback = false;
        }

        else // show Game Over
        {
            text_ScoreLose.text = score.ToString();
            SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.effect_Wrong);

            show_GameOver.SetActive(true);
            Time.timeScale = 0;
        }      
    }
   
}
