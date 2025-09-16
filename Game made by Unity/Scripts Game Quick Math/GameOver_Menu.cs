using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Menu : MonoBehaviour
{
    public TMP_Text result;
    public TMP_Text text_Score;
    public string nameSence;

    private void Start()
    {
        if (Random.value < 0.4f)
        {
            ADS_Manager.instance.ShowInterstitialAd();
        }
        showResults(nameSence);
    }
    public void Buuton_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Buuton_MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Buuton_Exit()
    {
        Application.Quit();
    }
    private void showResults(string nameSence)
    {
        switch (nameSence)
        {
            case "Easy":
                result.text = GameCore_Easy.string_Total.ToString();
                text_Score.text = Manager_ButtonEasy.score.ToString();
                break;
            case "Normal":
                result.text = GameCore_Normal.string_Total.ToString();
                text_Score.text = Manager_ButtonNormal.score.ToString();
                break;
            case "Hard":
                result.text = GameCore_Hard.string_Total.ToString();
                text_Score.text = Manager_ButtonHard.score.ToString();
                break;
            case "Random":
                result.text = GameCore_Random.string_Total.ToString();
                text_Score.text = Manager_ButtonRandom.score.ToString();
                break;

        }
    }

}
