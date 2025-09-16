using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetValue : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 75; // Giới hạn FPS ở 75
        QualitySettings.vSyncCount = 0;   // Tắt VSync để đảm bảo FPS không bị hạn chế bởi màn hình
        Debug.unityLogger.logEnabled = false;
        //Unlock_Random(0); 
       // PlayerPrefs.DeleteAll();
        Set();
    }

    private void Set()
    {
        if (PlayerPrefs.GetInt("Set") == 0)
        {
            //Debug.Log("Set");
            SetValueVolume();
            PlayerPrefs.SetInt("Set", 1);
        }
        else return;
    }
    
    private void SetValueVolume()
    {
        PlayerPrefs.SetFloat("Music",1);
        PlayerPrefs.SetFloat("Effect",1);
    }

    private void Unlock_Random(int value)
    {
        PlayerPrefs.SetInt("ScoreEasy", value);
        PlayerPrefs.SetInt("ScoreNormal", value);
        PlayerPrefs.SetInt("ScoreHard", value);
    }
}
