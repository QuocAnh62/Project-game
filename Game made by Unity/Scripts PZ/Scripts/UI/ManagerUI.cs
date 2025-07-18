using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerUI : MonoBehaviour
{
    public static ManagerUI instance;

    [SerializeField] private TMP_Text textSun;
    private int currentSun = 0;

    public void Awake()
    {
        if (instance == null) { instance = this; }
    }

    public void SetSunVale(int valuePlus)
    {
        currentSun += valuePlus;
        textSun.text = currentSun.ToString();
    }

}
