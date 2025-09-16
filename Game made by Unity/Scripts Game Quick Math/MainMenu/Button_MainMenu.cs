using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject show_Level;
    [SerializeField] private GameObject menu_Setting;
    [SerializeField] private GameObject managerChicken;
    [SerializeField] private GameObject chicken_Obj;
    //[SerializeField] private GameObject unBlockRandom;

    private void Awake()
    {
        Time.timeScale = 1;
    }


    public void Button_Play()
    {
        SystemPlayAudio.instance.PlayEffect(SystemPlayAudio.instance.button_Effect);
        show_Level.SetActive(true);

        managerChicken.SetActive(false);
        chicken_Obj.SetActive(false);     
    }
    public void Button_CloseMenuPlay()
    {
        SystemPlayAudio.instance.PlayEffect(SystemPlayAudio.instance.button_Effect);
        show_Level.SetActive(false);
        managerChicken.SetActive(true);
    }

    public void Button_Setting()
    {
        SystemPlayAudio.instance.PlayEffect(SystemPlayAudio.instance.button_Effect);
        menu_Setting.SetActive(true);
    }
    public void Button_CloseSetting()
    {
        SystemPlayAudio.instance.PlayEffect(SystemPlayAudio.instance.button_Effect);
        menu_Setting.SetActive(false);
    }

    public void Button_Quit()
    {
        Application.Quit();
    }

   
}
