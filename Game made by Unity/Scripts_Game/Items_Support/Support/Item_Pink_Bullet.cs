using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pink_Bullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.left * speed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LimitBack") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
