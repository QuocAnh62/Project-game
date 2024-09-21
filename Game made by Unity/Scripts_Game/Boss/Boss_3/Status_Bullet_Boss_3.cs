using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Bullet_Boss_3 : MonoBehaviour
{
    private Boss_ReceiveDame boss_receivedame;

    private Data_Enemy data_enemy;

    void Start()
    {
        boss_receivedame = GameObject.FindObjectOfType<Boss_ReceiveDame>().GetComponent<Boss_ReceiveDame>();
        data_enemy = GameObject.FindObjectOfType<Data_Enemy>().GetComponent<Data_Enemy>();
    }


    void Update()
    {
        if (Boss_ReceiveDame.currenthealth <= 0)
            Destroy(GetComponent<Status_Bullet>());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Boss_3_ReceiveDame.currentHealth_Boss_3 > 0)
            {
                boss_receivedame.Player_ReceiveDame_Boss(data_enemy.Dame_Boss);
                Destroy(gameObject);
            }
            else if (Boss_3_ReceiveDame.currentHealth_Boss_3 <= 0)
            {
                return;
            }
        }
        if (collision.gameObject.CompareTag("LimitBack"))
        {
            Destroy(gameObject);
        }
    }
}
