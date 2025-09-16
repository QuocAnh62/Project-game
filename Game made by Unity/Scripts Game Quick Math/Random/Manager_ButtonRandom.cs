using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager_ButtonRandom : HandleText_Random
{
    protected int egg = 0;
    protected int eggSpecial = 0;
    public static int score = 0;
    public static bool getback;

    protected void Start()
    {
        Time.timeScale = 1;
        score = 0;
        egg = 0;
        eggSpecial = 0;
        getback = true;
        LevelUpRandom.instance.Harder();
    }
    protected void Update()
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

        if (text_Input.text == GameCore_Random.string_Total) // show menu Correct
        {
            score ++;
            text_Score.text = score.ToString();
            SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.effect_Winner);

            StartCoroutine(GamePlay());
        }

        else if (text_Input.text == SystemHandleEasterEgg.egg_Random && egg < 2) // show easter eggs
        {
            score += 50;
            egg++;
            text_Score.text = score.ToString();
            Eastereggs.instance.Eastereggs_Random(text_Input.text);
        }

        else if (text_Input.text == SystemHandleEasterEgg.egg_Special && eggSpecial < 2) // show easter eggs Special
        {
            score += 100;
            eggSpecial++;
            text_Score.text = score.ToString();
            Eastereggs.instance.Eastereggs_Special(text_Input.text);
        }

        else if (text_Input.text != GameCore_Random.string_Total && score >= 5 && getback == true) // show get back if wrong answer
        {
            getBack.SetActive(true);
            getback = false;
        }

        else // Show Menu GameOver
        {
            text_ScoreLose.text = score.ToString();
            SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.effect_Wrong);

            show_GameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
   
}
