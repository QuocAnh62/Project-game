using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSetting : MonoBehaviour
{
    [SerializeField] private AudioSource sound_BackGround;
    [SerializeField] private AudioSource sound_Effect;

    [SerializeField] private GameObject menu_Setting;
    [SerializeField] private GameObject button_Music;
    [SerializeField] private GameObject close_Music;
    [SerializeField] private GameObject button_Effect;
    [SerializeField] private GameObject close_Effect;

    private void Start()
    {
        UpdateUIMusic();
    }

    public void OpenMenuSetting()
    {
        menu_Setting.SetActive(true);
        Manager_Audio.Instance.PlayEffect(Manager_Audio.Instance.effect_Button);
    }

    public void CloseMenuSetting()
    {
        menu_Setting.SetActive(false);
        Manager_Audio.Instance.PlayEffect(Manager_Audio.Instance.effect_Button);
    }

    public void CloseMusic()
    {
        Manager_Audio.Instance.PlayEffect(Manager_Audio.Instance.effect_Button);

        button_Music.SetActive(false);
        close_Music.SetActive(true);
              
        PlayerPrefs.SetInt("Mute Music", 1);
        Manager_Audio.Instance.AllowPlayMusic();
    }
    public void OpenMusic()
    {
        Manager_Audio.Instance.PlayEffect(Manager_Audio.Instance.effect_Button);
      
        button_Music.SetActive(true);
        close_Music.SetActive(false);
                  
        PlayerPrefs.SetInt("Mute Music", 0);
        Manager_Audio.Instance.AllowPlayMusic();
    }


    public void CloseEffect() 
    {
        Manager_Audio.Instance.PlayEffect(Manager_Audio.Instance.effect_Button);
     
        button_Effect.SetActive(false);
        close_Effect.SetActive(true);
                   
        PlayerPrefs.SetInt("Mute Effect", 1);
        Manager_Audio.Instance.AllowPlayEffect();
    }
    
    public void OpenEffect()
    {
        Manager_Audio.Instance.PlayEffect(Manager_Audio.Instance.effect_Button);
      
        button_Effect.SetActive(true);
        close_Effect.SetActive(false);
                   
        PlayerPrefs.SetInt("Mute Effect", 0);
        Manager_Audio.Instance.AllowPlayEffect();
    }

    private void UpdateUIMusic()
    {
        if (PlayerPrefs.GetInt("Mute Music") > 0)
        {
            button_Music.SetActive(false);
            close_Music.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Mute Music") <= 0)
        {
            button_Music.SetActive(true);
            close_Music.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Mute Effect") > 0)
        {
            button_Effect.SetActive(false);
            close_Effect.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Mute Effect") <= 0)
        {
            button_Effect.SetActive(true);
            close_Effect.SetActive(false);
        }

    }
}
