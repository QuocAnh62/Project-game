using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlantShot : MonoBehaviour
{
    public static bool isShot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isShot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isShot = false;
        }
    }
}
