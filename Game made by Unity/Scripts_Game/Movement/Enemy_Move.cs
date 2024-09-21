using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    private Data_Enemy data_enemy;  
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        data_enemy = GameObject.FindAnyObjectByType<Data_Enemy>().GetComponent<Data_Enemy>();
    }

    private void Update()
    {
        if(data_enemy.currentHealth_Enemy <= 0)
        {
            rb.velocity = Vector3.zero;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = Vector3.left * data_enemy.SpeedEnemy * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }
}
