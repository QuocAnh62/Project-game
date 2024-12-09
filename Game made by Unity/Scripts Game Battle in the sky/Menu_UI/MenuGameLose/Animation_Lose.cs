using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Lose : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Lose());
    }

  IEnumerator Lose()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(0.50f);
        anim.SetBool("ShowButton", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("ShowButton", false);
        anim.SetBool("ShowAll", true);
    }
}
