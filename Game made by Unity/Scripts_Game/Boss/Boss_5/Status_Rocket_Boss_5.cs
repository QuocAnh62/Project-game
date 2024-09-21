using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Rocket_Boss_5 : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    private Data_Enemy data_enemy;
    private Boss_ReceiveDame boss_receivedame;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        data_enemy = GameObject.FindObjectOfType<Data_Enemy>().GetComponent<Data_Enemy>();
        boss_receivedame = GameObject.FindObjectOfType<Boss_ReceiveDame>().GetComponent<Boss_ReceiveDame>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Boss_ReceiveDame.currenthealth <= 0)
            Destroy(GetComponent<Status_Bullet>());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Boss_5_ReceiveDame.currentHealth_Boss_5 > 0)
            {
                boss_receivedame.Player_ReceiveDame_Boss(data_enemy.Dame_Rocket_Boss);
                StartCoroutine(Rocket());
            }
            else if (Boss_5_ReceiveDame.currentHealth_Boss_5 <= 0)
            {
                return;
            }
        }
        if (collision.gameObject.CompareTag("LimitBack"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Rocket()
    {
        anim.SetBool("Destroy", true);
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.15f);
        anim.SetBool("Destroy", false);
        Destroy(gameObject);
    }
}
