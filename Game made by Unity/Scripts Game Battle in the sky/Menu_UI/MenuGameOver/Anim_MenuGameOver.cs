using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_MenuGameOver : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();     
    }
    //public void ShowGameOver()
    //{
    //    StartCoroutine(AnimGameOver());
    //}
    //IEnumerator AnimGameOver()
    //{
    //    anim.SetBool("ShowBackG", true);
    //    yield return new WaitForSeconds(0.35f);
    //    anim.SetBool("ShowBackG", false);
    //    anim.SetBool("ShowButton", true);
    //    yield return new WaitForSeconds(0.30f);
    //    anim.SetBool("ShowButton", false);
    //    anim.SetBool("ShowADS", true);
    //}
}
