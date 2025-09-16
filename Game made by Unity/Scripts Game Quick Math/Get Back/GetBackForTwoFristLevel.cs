using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetBackForTwoFristLevel : MonoBehaviour
{

    [SerializeField] private Image imgae_FullTime;
    [SerializeField] protected TMP_Text text_Input;
    [SerializeField] private GameObject show_GameOver;
    [SerializeField] private GameObject show_TimeOver;
    [SerializeField] private GameObject call_NextQuestion;


    private float elapsedTime;
    private float duration;

    private int effect = 1;

    private void Start()
    {
        duration = 6f;        
    }

    private void OnEnable()
    {
        elapsedTime = 0f;
        show_TimeOver.SetActive(false);
    }

    void Update()
    {
        TimeGetBack();
    }
    private void TimeGetBack()
    {
        if (imgae_FullTime.fillAmount > 0)
        {
            elapsedTime += Time.deltaTime;
            imgae_FullTime.fillAmount = Mathf.Lerp(1f, 0f, elapsedTime / duration); // calculate minus fillAmount               
        }

        else if (imgae_FullTime.fillAmount <= 0 && imgae_FullTime.fillAmount>=-1)
        {
            PlayEffectTimeOver();
            show_GameOver.SetActive(true);
            this.gameObject.SetActive(false);
            Time.timeScale = 0f;
        }        
    }

    public void Button_GetBackEasy()
    {
        StartCoroutine(GetBackEasy());
    }
    private IEnumerator GetBackEasy() // Handle Event GetBack scenes Eayse
    {
        ADS_Manager.instance.ShowRewardedAd();
        yield return new WaitForSeconds(0.1f);

        text_Input.text = Manager_ButtonEasy.score.ToString();
        show_TimeOver.SetActive(true);

        OverTimeEasy.elapsedTime = 0;
        OverTimeEasy.timeStart = 0.1f;

        call_NextQuestion.SetActive(true);

        Handle_TextInput(true); // Handle text input   
        call_NextQuestion.GetComponent<GameCore_Easy>().CallExtrem(); // Handle show next Text
        GameCore_Easy.time_TurnOff = GameCore_Easy.time_TurnOffText + 0.5f;

        this.gameObject.SetActive(false);
    }



    public void Button_GetBackNormal()
    {
        StartCoroutine(GetBackNormal());      
    }

    private IEnumerator GetBackNormal()// Handle Event GetBack scenes Normal
    {
        ADS_Manager.instance.ShowRewardedAd();
        yield return new WaitForSeconds(0.1f);

        text_Input.text = Manager_ButtonNormal.score.ToString();
        show_TimeOver.SetActive(true);

        SystemOverTime.elapsedTime = 0;
        SystemOverTime.timeStart = 0.1f;

        call_NextQuestion.SetActive(true);
        Handle_TextInput(true); // Handle text input

        call_NextQuestion.GetComponent<GameCore_Normal>().CallExtrem(); // Handle show next Text
        GameCore_Normal.time_TurnOff = GameCore_Normal.time_TurnOffText + 0.5f;

        this.gameObject.SetActive(false);
    }


    protected void Handle_TextInput(bool isNormalText)
    {
        if (isNormalText)
        {
            text_Input.fontStyle = FontStyles.Italic;
            text_Input.text = "Enter Number";
        }
        else text_Input.fontStyle = FontStyles.Bold;
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

