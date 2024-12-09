using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource EffectSource; 

    [Header("---------- Audio Back Ground ----------")]
    public AudioClip Music_BG;
    public AudioClip Music_BG_Turtle;
    public AudioClip Music_BG_Skull;

    [Header("---------- Player ----------")]
    public AudioClip Walk;
    public AudioClip Player_Jump;
    public AudioClip Player_Dash;
    public AudioClip Player_Die;
    public AudioClip Player_Hit;
    public AudioClip Player_Health;

    [Header("------- Platform Items -------")]
    public AudioClip Eat_Apple;
    public AudioClip CheckPoint;
    public AudioClip winner;

    [Header("------- Weapon -------")]
    
    public AudioClip Sword;
    public AudioClip Reload_Ak47;
    public AudioClip Reload_Pistol;
    public AudioClip Pistol;
    public AudioClip Ak47;
    public AudioClip Ammo_PickUp;

    [Header("------- Enemy -------")]
    public AudioClip Bonk;
    public AudioClip Enemy_moving;

    [Header("------- Boss Turtle -------")]
    public AudioClip a;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    private void Start()
    {
        musicSource.clip = Music_BG;
        musicSource.Play();
    }

    public void PlayEffect(AudioClip clip)
    {
        EffectSource.PlayOneShot(clip);
    }

    public void PLayMusicTurtle()
    {
        StartCoroutine(MusicTurtle());

    }


    public void PlayerMusicSkull()
    {
        StartCoroutine(MusicSkull());
    }


    public void PlayMusicNormalBG()
    {
        StartCoroutine(MusicBacGround());
    }


   
    private IEnumerator MusicTurtle()
    {
        StartCoroutine(VolumeDown());
        yield return new WaitForSeconds(2f);

        musicSource.clip = Music_BG_Turtle;
        musicSource.Play();      
    }

    private IEnumerator MusicSkull()
    {
        StartCoroutine(VolumeDown());
        yield return new WaitForSeconds(2f);

        musicSource.clip = Music_BG_Skull;
        musicSource.Play();
    }

    private IEnumerator MusicBacGround()
    {
        StartCoroutine(VolumeDown());
        yield return new WaitForSeconds(2f);

        musicSource.clip = Music_BG;
        musicSource.Play();
    }

     

    private IEnumerator VolumeDown()
    {
        float StartVolume = musicSource.volume;
        for(int i = 0; i < 5; i++)
        {
            musicSource.volume -= 0.06f;
            yield return new WaitForSeconds(0.4f);
        }
        musicSource.volume = StartVolume;
    }
}
