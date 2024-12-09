using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class St_Level : MonoBehaviour
{
    public static St_Level st_level;
    GameObject lel_0;
    GameObject lel_1;
    GameObject lel_2;
    GameObject lel_3;
    GameObject lel_4;
    GameObject lel_5;

    private void Awake()
    {
        st_level = this;
    }
    void Start()
    {
        lel_0 = GameObject.Find("Button_Level 0");
        lel_1 = GameObject.Find("Button_Level 1");
        lel_2 = GameObject.Find("Button_Level 2");
        lel_3 = GameObject.Find("Button_Level 3");
        lel_4 = GameObject.Find("Button_Level 4");
        lel_5 = GameObject.Find("Button_Level 5");

        //PlayerPrefs.SetInt("Level 0", 0);
        //PlayerPrefs.SetInt("Level 1", 0);
        //PlayerPrefs.SetInt("Level 2", 0);
        //PlayerPrefs.SetInt("Level 3", 0);
        //PlayerPrefs.SetInt("Level 4", 0);
        //PlayerPrefs.SetInt("Level 5", 0);

    }

    public void Level_0()
    {
        if (PlayerPrefs.GetInt("Level 0") == 1)
        {
            lel_0.SetActive(false);
        }
        else return;
    }

    public void Level_1()
    {
        if (PlayerPrefs.GetInt("Level 1") == 1)
        {
            lel_1.SetActive(false);
        }
        else return;
    }

    public void Level_2()
    {
        if (PlayerPrefs.GetInt("Level 2") == 1)
        {
            lel_2.SetActive(false);
        }
        else return;
    }

    public void Level_3()
    {
        if (PlayerPrefs.GetInt("Level 3") == 1)
        {
            lel_3.SetActive(false);
        }
        else return;
    }

    public void Level_4()
    {
        if (PlayerPrefs.GetInt("Level 4") == 1)
        {
            lel_4.SetActive(false);
        }
        else return;
    }

    public void Level_5()
    {
        if (PlayerPrefs.GetInt("Level 5") == 1)
        {
            lel_5.SetActive(false);
        }
        else return;
    }
}
