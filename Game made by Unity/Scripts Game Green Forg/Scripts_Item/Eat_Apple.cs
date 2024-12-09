using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat_Apple : MonoBehaviour
{    
    Rigidbody2D rb;   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayEffect(AudioManager.Instance.Eat_Apple);
            UI_Apple.instance.AddPoints();
            Destroy(this.gameObject);
        }
    }

}
