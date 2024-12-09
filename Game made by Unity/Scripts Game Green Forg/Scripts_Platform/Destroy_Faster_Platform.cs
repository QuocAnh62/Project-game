using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Faster_Platform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == Data_Player.Instance.capsuleColli)       
            Destroy(gameObject, 0.1f);
    }
}
