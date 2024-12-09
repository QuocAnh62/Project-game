using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock_Level : MonoBehaviour
{
    private void Update()
    {
        //int levelAt = PlayerPrefs.GetInt("LevelAt", 0);
        //for (int i = 0; i < levelButton.Length; i++)
        //{

        //    if (i + 1 > levelAt)
        //    {
        //        levelButton[i].SetActive(true);
        //    }
        //    else if (i < levelAt)
        //    {
        //        levelButton[i].SetActive(false);
        //    }

        //}

        St_Level.st_level.Level_0();
        St_Level.st_level.Level_1();
        St_Level.st_level.Level_2();
        St_Level.st_level.Level_3();
        St_Level.st_level.Level_4();
        St_Level.st_level.Level_5();
    }
}
