using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_idle : MonoBehaviour
{
    private void TrapGiveDame()
    {
        Data_Player.Instance.health_Player.Player_MinusHealth(Specifications.Instance.dame_Trap);
    }   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("TrapGiveDame", 0, 0.02f);
            //Debug.Log("Trap Acttack");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CancelInvoke("TrapGiveDame");
        }
    }
}
