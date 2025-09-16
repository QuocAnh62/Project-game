using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetBackForTwoEndLevel : MonoBehaviour
{

    [SerializeField] private Image imgae_FullTime;
    [SerializeField] protected TMP_Text text_Input;
    [SerializeField] private GameObject show_GameOver;
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

        else if (imgae_FullTime.fillAmount <= 0 && imgae_FullTime.fillAmount >= -1)
        {
            PlayEffectTimeOver();
            show_GameOver.SetActive(true);
            this.gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void Button_GetBackHard()
    {
        StartCoroutine(GetBackHard());
    }

    private IEnumerator GetBackHard() // Handle Event GetBack scenes Hard
    {
        ADS_Manager.instance.ShowRewardedAd();
        yield return new WaitForSeconds(0.05f);

        text_Input.text = Manager_ButtonHard.score.ToString();
        call_NextQuestion.SetActive(true);

        Handle_TextInput(true); // Handle text input
        call_NextQuestion.GetComponent<GameCore_Hard>().CallExtrem(); // Handle show next Text
        GameCore_Hard.time_TurnOff = GameCore_Hard.time_TurnOffText + 0.5f;

        this.gameObject.SetActive(false);
    }

    public void Button_GetBackRandom()
    {
        StartCoroutine(GetBackRandom());
    }

    private IEnumerator GetBackRandom()// Handle Event GetBack scenes Random
    {
        ADS_Manager.instance.ShowRewardedAd();
        yield return new WaitForSeconds(0.05f);

        text_Input.text = Manager_ButtonRandom.score.ToString();
        call_NextQuestion.SetActive(true);

        Handle_TextInput(true); // Handle text input
        call_NextQuestion.GetComponent<GameCore_Random>().CallExtrem(); // Handle show next Text
        GameCore_Random.time_TurnOff = GameCore_Random.time_TurnOffText + 0.5f;

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
