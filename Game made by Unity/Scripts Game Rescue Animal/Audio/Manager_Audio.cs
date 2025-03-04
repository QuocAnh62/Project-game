using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Audio : Audio_Input
{
    public static Manager_Audio Instance;

    public void PlayEffect(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    private void Start()
    {
        musicSource.clip = music_BG_SecenStart;
        musicSource.Play();

        AllowPlayMusic();
        AllowPlayEffect();
    }


    public void AllowPlayMusic()
    {
        if (PlayerPrefs.GetInt("Mute Music") <= 0) musicSource.mute = false;

        else musicSource.mute = true;
    }

    public void AllowPlayEffect()
    {
        if (PlayerPrefs.GetInt("Mute Effect") <= 0) effectSource.mute = false;

        else effectSource.mute = true;
    }
  
}
