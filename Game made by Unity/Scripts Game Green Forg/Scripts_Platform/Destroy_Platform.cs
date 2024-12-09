using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Platform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == Data_Player.Instance.capsuleColli)
            Destroy(this.gameObject, 0.5f);
        else Debug.LogError("Can't Destroy platform");
    }
}
