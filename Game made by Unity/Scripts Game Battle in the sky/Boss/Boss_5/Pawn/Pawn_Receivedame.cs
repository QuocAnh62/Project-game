using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Pawn_Receivedame : MonoBehaviour
{
    Animator anim;
    public static int currentHealt_Pawn;

    private Data data;
    private Data_Enemy data_enemy;
    private Pawn_Spawn pawn_spawn;
    private Boss_ReceiveDame b_rDame;

    private void Start()
    {
        anim = GetComponent<Animator>();

        data = GameObject.FindObjectOfType<Data>().GetComponent<Data>();
        data_enemy = GameObject.FindObjectOfType<Data_Enemy>().GetComponent<Data_Enemy>();

        pawn_spawn = GameObject.FindObjectOfType<Pawn_Spawn>().GetComponent<Pawn_Spawn>();
        b_rDame = GameObject.FindObjectOfType<Boss_ReceiveDame>().GetComponent<Boss_ReceiveDame>();
        currentHealt_Pawn = 5;
    }
    void MinusHealthpawn(int dame)
    {
        currentHealt_Pawn -= dame;
        if (currentHealt_Pawn <= 0)
        {
            pawn_spawn.Pawn();
            currentHealt_Pawn = 0; // Because of Spawn_Pawn, not this line maybe Spawn_Pawn can Spawn 2 or 3 or infinity
            StartCoroutine(Die());
        }
    }

    private void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (Boss_ReceiveDame.currenthealth > 0)
            {
                MinusHealthpawn(data.Dame_Player);
                StartCoroutine(Dame());
            }
            else if (Boss_ReceiveDame.currenthealth <= 0)
                return;
        }

        else if (collision.gameObject.CompareTag("PinkBullet"))
        {
            if (Boss_ReceiveDame.currenthealth > 0)
            {
                MinusHealthpawn(data.Dame_Pink_Bullet);
                StartCoroutine(Dame());
            }
            else if (Boss_ReceiveDame.currenthealth <= 0)
                return;
        }

        else if (collision.gameObject.CompareTag("Rocket"))
        {
            if (Boss_ReceiveDame.currenthealth > 0)
            {
                MinusHealthpawn(data.Dame_Rocket);
            }
            else if (Boss_ReceiveDame.currenthealth <= 0)
                return;
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            b_rDame.Player_ReceiveDame_Boss(data_enemy.Dame_Collision);
            Destroy(gameObject);
        }
    }

    IEnumerator Dame()
    {
        anim.SetBool("HitDame", true);
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("HitDame", false);
    }


    IEnumerator Die()
    {
        anim.SetBool("Die", true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Die", false);
        Destroy(gameObject);
    }
}
