using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Eastereggs : SystemHandleEasterEgg
{
    public static Eastereggs instance;

    public void Awake()
    {
        if (instance == null) { instance = this; }
    }

    public void Eastereggs_Easy(string stringEgg)
    {
        if (stringEgg == egg_Easy)
        {
            StartCoroutine(EasterEgg_Easy());
        }
        else return;
    }

    public void Eastereggs_Normal(string stringEgg)
    {
        if (stringEgg == egg_Normal)
        {
            StartCoroutine(EasterEgg_Normal());
        }
        else return;
    }

    public void Eastereggs_Hard(string stringEgg)
    {
        if (stringEgg == egg_Hard)
        {
            StartCoroutine(EasterEgg_hard());
        }
        else return;
    }

    public void Eastereggs_Random(string stringEgg)
    {
        if (stringEgg == egg_Random)
        {
            StartCoroutine (EasterEgg_Random());
        }
        else return;
    }

    public void Eastereggs_Special(string stringEgg)
    {
        if (stringEgg == egg_Special)
        {
            StartCoroutine(EasterEgg_Special());
        }
        else return;
    }

    public void ActiveTimeOver()
    {
        eggIndex++;
        if (eggIndex == 10)
        {
            timeOver_Obj.SetActive(true);
        }
    }
}
