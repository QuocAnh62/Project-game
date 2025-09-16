using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeWaitToPlay : MonoBehaviour
{
    [SerializeField] private TMP_Text text_Time;
    [SerializeField] private GameObject text_Input;
    void Start()
    {
        StartCoroutine(cout());
    }

    private IEnumerator cout()
    {

        for(int i = 3; i >=1; i--)
        {
            text_Time.text = ""+ i;
             yield return new WaitForSeconds(0.9f);
        }

        if(text_Time.text == "1")
        {
            text_Time.text = "Go";
        }

        yield return new WaitForSeconds(0.9f);
        text_Input.SetActive(true);
        this.gameObject.SetActive(false);
    }


}
