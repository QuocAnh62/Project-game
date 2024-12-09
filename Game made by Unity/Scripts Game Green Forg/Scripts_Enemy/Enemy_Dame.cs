using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Dame : MonoBehaviour
{
    public Player_Controller controller;

    public int dame;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controller.Player_GetDame(dame);         
        }
    }

}
