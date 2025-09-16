using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevel : MonoBehaviour
{
    [SerializeField] private GameObject infor_UnClock;
    public void Button_LevelEasy()
    {
        SystemPlayAudio.instance.PlayEffect(SystemPlayAudio.instance.button_Effect);
        SceneManager.LoadScene("Easy");
    }

    public void Button_LevelNormal()
    {
        SystemPlayAudio.instance.PlayEffect(SystemPlayAudio.instance.button_Effect);
        SceneManager.LoadScene("Normal");
    }

    public void Button_LevelHard()
    {
        SceneManager.LoadScene("Hard");
    }

    public void Button_LevelRandom()
    {
        SceneManager.LoadScene("Random");
    }

    public void Button_InfUnClock()
    {
        infor_UnClock.SetActive(true);
    }

    public void Button_Close_InfUnClock()
    {
        infor_UnClock.SetActive(false);
    }
}
