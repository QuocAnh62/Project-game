using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_Controll : MonoBehaviour
{

    public float speed_H;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.left * speed_H * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (HeartSystem.Health > 3)
            {
                return;
            }
            else
            {
                Boss_ReceiveDame.currenthealth += 1;
                HeartSystem.Health += 1;
                Destroy(gameObject);
            }
            
        }
        if (collision.gameObject.CompareTag("LimitBack"))
        {
            Destroy(gameObject);
        }
    }
}
