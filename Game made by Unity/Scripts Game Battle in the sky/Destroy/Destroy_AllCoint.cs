using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_AllCoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LimitBack"))
        {           
            Destroy(gameObject,2f);
        }
    }
}
