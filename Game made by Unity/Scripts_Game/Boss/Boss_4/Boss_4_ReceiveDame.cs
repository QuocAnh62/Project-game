using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_4_ReceiveDame : MonoBehaviour
{
    Animator anim;

    private Data data;
    private Data_Enemy data_enemy;

    private Boss_ReceiveDame boss_receivedame;
    private Timer timer;

    public static float currentHealth_Boss_4;

    void Start()
    {
        anim = GetComponent<Animator>();

        boss_receivedame = GameObject.FindObjectOfType<Boss_ReceiveDame>().GetComponent<Boss_ReceiveDame>();
        timer = GameObject.FindObjectOfType<Timer>().GetComponent<Timer>();

        data = GameObject.FindObjectOfType<Data>().GetComponent<Data>();
        data_enemy = GameObject.FindObjectOfType<Data_Enemy>().GetComponent<Data_Enemy>();

        currentHealth_Boss_4 = data_enemy.maxHealth_Boss_4;
    }


    void boss_4_ReceiveDame(int dame)
    {
        currentHealth_Boss_4 -= dame;
        Debug.Log(currentHealth_Boss_4);
        if (currentHealth_Boss_4 <= 0)
        {
            boss_receivedame.boss_Receivedame();
            StartCoroutine(Boss_4_Die());
        }
    }


    private void FixedUpdate()
    {
        if (currentHealth_Boss_4 > 0)
        {
            timer.timmer();
        }
        else
        {
            return;
        }
    }


    // Destroy boss by Bullet and Rocket
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (Boss_ReceiveDame.currenthealth > 0)
            {
                boss_4_ReceiveDame(data.Dame_Player);
                StartCoroutine(Boss_4_HitDame());
            }
            else if (Boss_ReceiveDame.currenthealth <= 0)
                return;
        }

        else if (collision.gameObject.CompareTag("PinkBullet"))
        {
            if (Boss_ReceiveDame.currenthealth > 0)
            {
                boss_4_ReceiveDame(data.Dame_Pink_Bullet);
                StartCoroutine(Boss_4_HitDame());
            }
            else if (Boss_ReceiveDame.currenthealth <= 0)
                return;
        }

        else if (collision.gameObject.CompareTag("Rocket"))
        {
            if (Boss_ReceiveDame.currenthealth > 0)
            {
                boss_4_ReceiveDame(data.Dame_Rocket);
                StartCoroutine(Boss_4_HitDame());
            }
            else if (Boss_ReceiveDame.currenthealth <= 0)
                return;
        }
    }


    //Destroy boss and Plane When collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            boss_receivedame.Player_ReceiveDame_Boss(data_enemy.Dame_Collision);
            StartCoroutine(Boss_4_Die());
        }
    }

    IEnumerator Boss_4_HitDame()
    {
        anim.SetBool("ReceiveDame", true);
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("ReceiveDame", false);
    }

    IEnumerator Boss_4_Die()
    {
        anim.SetBool("Die", true);
        yield return new WaitForSeconds(0.50f);
        Destroy(gameObject);
    }
}
