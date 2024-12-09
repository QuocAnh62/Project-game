using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_PinkEnemy : MonoBehaviour
{
    private void PinkEnemyGiveDame()
    {
        Data_Player.Instance.health_Player.Player_MinusHealth(Specifications.Instance.dame_Enemy);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("PinkEnemyGiveDame", 0, 0.02f);
            Debug.Log("Pink_Enemy Acttack");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CancelInvoke("PinkEnemyGiveDame");
        }
    }
}
