using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LimitForward") || collision.gameObject.CompareTag("Enemy") 
            || collision.gameObject.CompareTag("Boss") || collision.gameObject.CompareTag("Pawn"))

        {
            Destroy(gameObject);
        }
    }

}

