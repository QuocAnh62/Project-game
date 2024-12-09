using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    BoxCollider2D colli;
    Animator anim;
    private void Awake()
    {       
        colli = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayEffect(AudioManager.Instance.CheckPoint); // Play audio effect
            GameControll.Instance.UpdateCheckPoint(transform.position); // save check point

            colli.enabled = false; // Destroy Boxcollider because not trigger again

            anim.SetBool("CheckPoint", true);
        }
    }
}
