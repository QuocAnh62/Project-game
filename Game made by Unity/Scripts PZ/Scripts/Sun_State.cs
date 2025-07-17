using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun_State : MonoBehaviour
{
    private float timer;
    public float timerDisabl;
    private void OnEnable()
    {
        timer = timerDisabl;
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
        this.gameObject.SetActive(false);
    }
}
