using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown_Up : MonoBehaviour
{   
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == Data_Player.Instance.capsuleColli)
        {
            rb.velocity = Vector2.up * 3.5f;
            Destroy(gameObject, 3f);
        }
        else return;
    }

}
