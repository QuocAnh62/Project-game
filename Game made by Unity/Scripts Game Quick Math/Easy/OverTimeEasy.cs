using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OverTimeEasy : MonoBehaviour
{
    [SerializeField] private Image imgae_FullTime;

    [SerializeField] private GameObject show_GameOver;
    [SerializeField] private TMP_Text show_TextScoreLose;

    [SerializeField] private GameCore_Easy GameCore_Easy;
    [SerializeField] private GameObject getBack;

    public static float elapsedTime = 0f;
    public static float timeStart = 4f;

    public static float duration = 5f; // 6f = 10s, 7f = 11s, 11f = 15s


    private int effect = 1;
    private void Start()
    {
        Time.timeScale = 1f;
        elapsedTime = 0f;
        timeStart = 4f;
    }

    private void Update()
    {
        CoreGame();
    }

    private void CoreGame()
    {
        timeStart -= Time.deltaTime;
        if (timeStart <= 0)
        {
            if (imgae_FullTime.fillAmount > 0)
            {
                elapsedTime += Time.deltaTime;
                imgae_FullTime.fillAmount = Mathf.Lerp(1f, 0f, elapsedTime / duration); // calculate minus fillAmount               
            }

            else if (imgae_FullTime.fillAmount <= 0 && Manager_ButtonEasy.score >= 10 && Manager_ButtonEasy.getback == true)
            {
                getBack.SetActive(true); // show menu get back
                imgae_FullTime.fillAmount = 1;

                Manager_ButtonEasy.getback = false;
            }
            else if(imgae_FullTime.fillAmount <= 0)
            {
                PlayEffectTimeOver();
                show_TextScoreLose.text = Manager_ButtonEasy.score.ToString();

                show_GameOver.SetActive(true);
                Time.timeScale = 0f;
            }

                timeStart = 0;
        }
    }
    private void PlayEffectTimeOver()
    {
        if(effect == 1)
        {
            SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.effect_TimeOver);
            effect = 0;
        }
    }
}
