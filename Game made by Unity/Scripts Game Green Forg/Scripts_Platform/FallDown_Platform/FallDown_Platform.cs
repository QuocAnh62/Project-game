using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown_Platform : MonoBehaviour
{
    Rigidbody2D rb;
    public float speedDown;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector2.down * speedDown;
            Destroy(gameObject, 2f);
        }
        else return;
    }
}
