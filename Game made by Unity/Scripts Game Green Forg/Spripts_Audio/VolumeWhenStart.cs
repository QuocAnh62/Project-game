using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeWhenStart : MonoBehaviour
{
    [SerializeField] private AudioMixer my_Mixer;

    void Start()
    {
        my_Mixer.SetFloat("Music", 0.7f);
        my_Mixer.SetFloat("Effect", 0.7f);
    }

   
}
