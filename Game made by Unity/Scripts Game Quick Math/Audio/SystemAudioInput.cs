using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemAudioInput : MonoBehaviour
{
    public static SystemAudioInput instance;

    public AudioClip chicken_Effect;
    [Header("====== Part Effect Win Wrong ======")]
    public AudioClip effect_Winner;
    public AudioClip effect_Wrong;
    public AudioClip effect_TimeOver;

    [Header("====== Part Effect Button ======")]

    public AudioClip morse_Short;
    public AudioClip morse_Long;

    public AudioClip button_0;
    public AudioClip button_1;
    public AudioClip button_2;
    public AudioClip button_3;
    public AudioClip button_4;
    public AudioClip button_5;
    public AudioClip button_6;
    public AudioClip button_7;
    public AudioClip button_8;
    public AudioClip button_9;
    public AudioClip button_Delete;

    [Header("====== Easter Egg ======")]
    public AudioClip egg_Random;
    public AudioClip egg_Special;
    private void Awake()
    {
        if (instance == null) { instance = this; }
    }
}
