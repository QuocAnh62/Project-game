using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_State : MonoBehaviour
{
    private Rigidbody2D rb;
    private float timeInActive;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.right * 7f;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);
        }       
    }

}
