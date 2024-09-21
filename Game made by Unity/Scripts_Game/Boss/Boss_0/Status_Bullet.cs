using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Bullet : MonoBehaviour
{   
    public GameObject desTroy;
    private GameObject Player;
    private Rigidbody2D rb;

    private Boss_ReceiveDame boss_receivedame;

    private Data_Enemy data_enemy;
    public float speed;
    private void Start()
    {
        boss_receivedame = GameObject.FindObjectOfType<Boss_ReceiveDame>().GetComponent<Boss_ReceiveDame>();        

        data_enemy = GameObject.FindObjectOfType<Data_Enemy>().GetComponent<Data_Enemy>();      

        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = Player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot );
    }

    //Destroy Component When Health_Player = 0;
    private void Update()
    {
        if(Boss_ReceiveDame.currenthealth <=0)       
            Destroy(GetComponent<Status_Bullet>());       
    }

    // Minus Health_boss When Boss collision with Player
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (Boss_0_ReceiveDame.currentHealth_Boss_0 > 0)
            {
                boss_receivedame.Player_ReceiveDame_Boss(data_enemy.Dame_Boss);
                Destroy(gameObject);                 
            }
            else if (Boss_0_ReceiveDame.currentHealth_Boss_0 <= 0)
            {
                return;
            }
        }
        if(collision.gameObject.CompareTag("LimitBack"))
        {
            Destroy(gameObject);
        }
    }
}
