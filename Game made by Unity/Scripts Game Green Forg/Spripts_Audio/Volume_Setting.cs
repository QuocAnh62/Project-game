using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume_Setting : MonoBehaviour
{
    [SerializeField] private AudioMixer my_Mixer;
    [SerializeField] private Slider music_Slider;
    [SerializeField] private Slider effect_Slider;

    void Start()
    {
        music_Slider = FindSlider("Audio Source");
        effect_Slider = FindSlider("Audio Effect");

        SetVolumeMusic();
        SetVolumeEffect();

        gameObject.SetActive(false);
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
        float volume = music_Slider.value;
        my_Mixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }

    public void SetVolumeEffect()
    {
        float volume = effect_Slider.value;
        my_Mixer.SetFloat("Effect", Mathf.Log10(volume) * 20);
    }

}
