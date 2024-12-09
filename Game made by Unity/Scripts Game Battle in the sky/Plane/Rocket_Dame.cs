using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Dame : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))                 
            Destroy(collision.gameObject);
        if (collision.gameObject.CompareTag("LimitForward") || collision.gameObject.CompareTag("Pawn"))
            Destroy(gameObject);
        if (collision.gameObject.CompareTag("Boss"))
        {
            StartCoroutine(RocketHit());
        }
    }
    

    IEnumerator RocketHit()
    {
        anim.SetBool("Hit", true);
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Hit", false);
        Destroy(gameObject);
    }

}
