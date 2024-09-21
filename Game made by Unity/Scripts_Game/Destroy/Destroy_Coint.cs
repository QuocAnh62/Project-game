using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Coint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.CompareTag("Coint");
            Courotine_Coint.instance.AddPoints();
            Destroy(gameObject);
        }
    }
}
