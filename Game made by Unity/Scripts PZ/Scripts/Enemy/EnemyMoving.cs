using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speedEnemy = 0.4f;
    //public float normalSpeed = 0.4f;

    private bool isMove = true;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (isMove != false)
        {
            rb.velocity = Vector2.left * speedEnemy;
        }
        else rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {           
            isMove = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            //Debug.Log("Stop trigger");
            isMove = true;
        }
    }
}
