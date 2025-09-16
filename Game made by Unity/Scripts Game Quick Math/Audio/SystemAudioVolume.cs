using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SystemAudioVolume : MonoBehaviour
{
   [SerializeField] private AudioMixer my_Mixer;

    private Slider music_Slider;
    private Slider effect_Slider;

    [SerializeField] private GameObject fill_Music;
    [SerializeField] private GameObject fill_Effect;

    public static float volume_Music;
    public static float volume_Effect;

    void Start()
    {        
        music_Slider = FindSlider("Audio Music");
        effect_Slider = FindSlider("Audio Effect");

        music_Slider.value = PlayerPrefs.GetFloat("Music");
        effect_Slider.value = PlayerPrefs.GetFloat("Effect");

        SetVolumeMusic();
        SetVolumeEffect();

        this.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        SystemPlayAudio.instance.musicSource.volume = PlayerPrefs.GetFloat("Music");
        SystemPlayAudio.instance.effectSource.volume = PlayerPrefs.GetFloat("Effect");
    }

    private Slider FindSlider(string gameObjectName)
    {
        GameObject slider = GameObject.Find(gameObjectName);
        if (slider != null)
        {
            return slider.GetComponent<Slider>();
        }
        else return null;
    }

    public void SetVolumeMusic()
    {
        float volume_Music = music_Slider.value;
        my_Mixer.SetFloat("Music", Mathf.Log10(volume_Music) * 20);

        PlayerPrefs.SetFloat("Music", volume_Music);

        if (volume_Music <= 0.0001f) fill_Music.SetActive(false);
        else fill_Music.SetActive(true);
    }

    public void SetVolumeEffect()
    {
        float volume_Effect = effect_Slider.value;
        my_Mixer.SetFloat("Effect", Mathf.Log10(volume_Effect) * 20);

        PlayerPrefs.SetFloat("Effect", volume_Effect);

        if (volume_Effect <= 0.0001f) fill_Effect.SetActive(false);
        else fill_Effect.SetActive(true);
    }

    
}
