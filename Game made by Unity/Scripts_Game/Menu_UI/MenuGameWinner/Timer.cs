using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timeText;
    float time;
    float coolDown = 6f;

    public void timmer()
    {
        if (coolDown <= 0)
        {
            time += Time.deltaTime;
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }


    private void FixedUpdate()
    {
        coolDown -= Time.deltaTime;
    }
}
