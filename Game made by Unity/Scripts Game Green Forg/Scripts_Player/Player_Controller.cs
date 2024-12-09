using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Animator anim;

     void Start()
     {
        anim = GetComponent<Animator>();
     }

    public void Player_GetDame(int dame)
    {
       // health.Player_TakeDame(dame);
    }

    IEnumerator MyCoroutine()
    {
        anim.SetBool("IsHit", true);
        yield return new WaitForSeconds(0.26f);
        anim.SetBool("IsHit", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(MyCoroutine());
        }
    }


  

}
