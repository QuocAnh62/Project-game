using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock_Speed : MonoBehaviour
{
    [SerializeField] protected Image speedMeter;
    [SerializeField] protected TMP_Text current_Speed;
    private float speed_NmalPlayer; // this speed is normal speed player

    private void Start()
    {
        speed_NmalPlayer = Parameter_Manager.Instance.speedPlayer;// set this speed = normal speed player       
    }

    public void CurrentSpeed(float speed)
    {
        var result = (Mathf.Round(speed * 100)) / 100.0; // calculate to take 1 decimal place

        current_Speed.text = result.ToString();
        Meter();
    }

    protected void Meter()
    {       
        speedMeter.transform.rotation = Quaternion.Euler(0f, 0f, 270f);
              
    }
    
}
