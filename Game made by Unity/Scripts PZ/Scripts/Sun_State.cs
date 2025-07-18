using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun_State : MonoBehaviour
{
    private float timer;
    public float timerDisabl;
    private int valueSunShine;
    public int valuePlusSun;
    private void OnEnable()
    {
        timer = timerDisabl;
        valueSunShine = valuePlusSun;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Take Sun");
        ManagerUI.instance.SetSunVale(valueSunShine);
        this.gameObject.SetActive(false);
    }
}
