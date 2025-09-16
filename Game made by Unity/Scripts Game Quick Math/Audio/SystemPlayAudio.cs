using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemPlayAudio : MonoBehaviour
{
    public static SystemPlayAudio instance;

    [Header("------- Audio Source -------")]
    public AudioSource musicSource;
    public AudioSource effectSource;

    [Header("------- Audio Back Ground -------")]
    public AudioClip music_BG_SecenStart;
    public AudioClip button_Effect;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    private void Start()
    {

        musicSource.volume = PlayerPrefs.GetFloat("Music");
        effectSource.volume = PlayerPrefs.GetFloat("Effect");

        musicSource.clip = music_BG_SecenStart;
        musicSource.Play();

        //Debug.Log(musicSource.volume);
        //Debug.Log(effectSource.volume);
    }

    public void PlayEffect(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }
}
