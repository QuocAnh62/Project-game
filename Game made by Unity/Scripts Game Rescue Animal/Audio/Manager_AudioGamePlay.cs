using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_AudioGamePlay : MonoBehaviour
{
    public static Manager_AudioGamePlay Instance;

    [Header("------- Audio Source -------")]
    [SerializeField] protected AudioSource musicSource;
    [SerializeField] protected AudioSource effectSource;

    [Header("------- Audio Back Ground -------")]
    public AudioClip music_BG_SecenPlay;

    [Header("------- Sound Effect -------")]
    public AudioClip effect_Fail;
    public AudioClip effect_Win;
    public AudioClip effect_SpeedUp;


    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    private void Start()
    {
        musicSource.clip = music_BG_SecenPlay;
        musicSource.Play();

        AllowPlayMusic();
        AllowPlayEffect();
    }

    public void PlayEffect(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    private void AllowPlayMusic()
    {
        if (PlayerPrefs.GetInt("Mute Music") <= 0) musicSource.mute = false;

        else musicSource.mute = true;
    }

    private void AllowPlayEffect()
    {
        if (PlayerPrefs.GetInt("Mute Effect") <= 0) effectSource.mute = false;

        else effectSource.mute = true;
    }
}
