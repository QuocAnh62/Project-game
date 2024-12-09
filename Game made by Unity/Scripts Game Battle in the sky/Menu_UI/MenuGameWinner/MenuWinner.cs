using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuWinner : MonoBehaviour
{    
     Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Apply());
    }  

    IEnumerator Apply()
    {
        //Time.timeScale = 0.2f;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Time", true);
        yield return new WaitForSeconds(0.52f);
        anim.SetBool("Time", false);
        anim.SetBool("Button", true);
        yield return new WaitForSeconds(0.50f);
        anim.SetBool("Button", false);
        anim.SetBool("Done",true);      
    }

}
