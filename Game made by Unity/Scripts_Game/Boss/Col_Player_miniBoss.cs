using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Player_miniBoss : MonoBehaviour
{
    private Boss_ReceiveDame b_rDame;
    private void Start()
    {
        b_rDame = GameObject.FindObjectOfType<Boss_ReceiveDame>().GetComponent<Boss_ReceiveDame>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            b_rDame.Player_ReceiveDame_Boss(4);       
        }
    }

    private void Update()
    {
        if (Boss_5_ReceiveDame.currentHealth_Boss_5 <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
