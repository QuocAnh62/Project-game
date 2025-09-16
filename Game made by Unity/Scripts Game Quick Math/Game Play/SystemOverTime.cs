using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SystemOverTime : MonoBehaviour
{
    [SerializeField] private Image imgae_FullTime;
    [SerializeField] private TMP_Text show_ScoreLose;

    [SerializeField] private GameObject show_GameOver;
    [SerializeField] private GameCore_Normal GameCore_Normal;
    [SerializeField] private GameObject getBack;

    public static float elapsedTime = 0f;
    public static float timeStart = 4f;

    public static float duration; // 6f = 10s, 7f = 11s, 11f = 15s

    private int effect = 1;
    private void Start()
    {
        Time.timeScale = 1f;
        duration = 6f;
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

            else if (imgae_FullTime.fillAmount <= 0 && Manager_ButtonNormal.score >= 10 && Manager_ButtonNormal.getback == true)
            {
                getBack.SetActive(true);
                imgae_FullTime.fillAmount = 1;
                Manager_ButtonNormal.getback = false;
            }
            else if (imgae_FullTime.fillAmount <= 0)
            {
                PlayEffectTimeOver();
                show_ScoreLose.text = Manager_ButtonNormal.score.ToString();

                show_GameOver.SetActive(true);
                Time.timeScale = 0f;
            }

            timeStart = 0;
        }
    }

    private void PlayEffectTimeOver()
    {
        if (effect == 1)
        {
            SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.effect_TimeOver);
            effect = 0;
        }
    }

}
