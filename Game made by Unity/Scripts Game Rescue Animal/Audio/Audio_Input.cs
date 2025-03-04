using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Input : MonoBehaviour
{
    [Header("------- Audio Source -------")]
    [SerializeField] protected AudioSource musicSource;
    [SerializeField] protected AudioSource effectSource;

    [Header("------- Audio Back Ground -------")]
    public AudioClip music_BG_SecenStart;


    [Header("------- Sound Effect -------")]
    public AudioClip effect_Button;
}
