using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_ReceiveDame : MonoBehaviour
{
    private Data data;
    private Receive_Dame receivedame;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        data = GameObject.FindAnyObjectByType<Data>().GetComponent<Data>();
        receivedame = GameObject.FindAnyObjectByType<Receive_Dame>().GetComponent<Receive_Dame>();  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // enemy collision with bullet of Player
        if (collision.gameObject.CompareTag("Bullet"))
        {
            receivedame.Enemy_ReceiveDame(this.gameObject,data.Dame_Player);
            StartCoroutine(Anim());
        }

        // enemy collision with rocket of Player
        if (collision.gameObject.CompareTag("Rocket"))
        {
            receivedame.Enemy_ReceiveDame(this.gameObject,data.Dame_Rocket);
        }

        if (collision.gameObject.CompareTag("LimitBack"))
        {
            Destroy(gameObject, 0.2f);
        }
        
    }

    public void Enemy_Die()
    {       
            StartCoroutine(Die());
            Destroy(this.gameObject);
    }


    IEnumerator Anim()
    {
        anim.SetBool("ReceiveDame", true);
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("ReceiveDame", false);
    }

    IEnumerator Die()
    {
        anim.SetBool("Die", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Die", false);
    }
}
