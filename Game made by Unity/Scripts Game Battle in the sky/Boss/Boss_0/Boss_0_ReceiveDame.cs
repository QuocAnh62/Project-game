using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_0_ReceiveDame : MonoBehaviour
{
    public GameObject Boss_0;
    Animator anim;

    private Boss_ReceiveDame receive_dame;
    private Data data;
    private Data_Enemy data_enemy;
    private Timer timer;


    public static float currentHealth_Boss_0;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
      
        receive_dame = GameObject.FindAnyObjectByType<Boss_ReceiveDame>().GetComponent<Boss_ReceiveDame>();
        timer = GameObject.FindObjectOfType<Timer>().GetComponent<Timer>();

        data = GameObject.FindAnyObjectByType<Data>().GetComponent<Data>();
        data_enemy = GameObject.FindAnyObjectByType<Data_Enemy>().GetComponent<Data_Enemy>();
       
        currentHealth_Boss_0 = data_enemy.maxHealth_Boss_0;
    }

    void boss_0Receivedame(int dame)
    {
        currentHealth_Boss_0 -= dame;       
        if (currentHealth_Boss_0 <= 0)
        {
            receive_dame.boss_Receivedame();
            StartCoroutine(Boss_Dead());           
        }
    }

    private void FixedUpdate()
    {
        if (currentHealth_Boss_0 > 0)
        {
            timer.timmer();
        }
        else
        {
            return;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (Boss_ReceiveDame.currenthealth > 0)
            {
                boss_0Receivedame(data.Dame_Player);
                StartCoroutine(EnemyHitDame());
            }  
            else if(Boss_ReceiveDame.currenthealth <= 0)            
                return;
            
        }
        else if (collision.gameObject.CompareTag("PinkBullet"))
        {
            if (Boss_ReceiveDame.currenthealth > 0)
            {
                boss_0Receivedame(data.Dame_Pink_Bullet);
                StartCoroutine(EnemyHitDame());
            }
            else if (Boss_ReceiveDame.currenthealth <= 0)
                return;
        }
        else if(collision.gameObject.CompareTag("Rocket"))
        {
            if (Boss_ReceiveDame.currenthealth > 0)
            {
                boss_0Receivedame(data.Dame_Rocket);
                StartCoroutine(EnemyHitDame());
            }
            else if (Boss_ReceiveDame.currenthealth <= 0)            
                return;
            
        }                  
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            receive_dame.Player_ReceiveDame_Boss(data_enemy.Dame_Collision);
            StartCoroutine(Boss_Dead());
        }
    }


    public void Boss_0_Dead()
    {
        StartCoroutine(Boss_Dead());
    }

    IEnumerator EnemyHitDame()
   {
        anim.SetBool("ReceiveDame", true);
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("ReceiveDame", false);
   }

    IEnumerator Boss_Dead()
    {      
        anim.SetBool("Dead",true);
        yield return new WaitForSeconds(0.50f);      
        Destroy(Boss_0);
    }
}
