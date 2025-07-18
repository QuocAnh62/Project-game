using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HomeCheckGameOver : MonoBehaviour
{
    public GameObject LoseMenu;
    private bool isLose = true;
    private void Awake()
    {
        Time.timeScale = 1;
    }

    //private void Update()
    //{
    //    if (Enemy_ReceiveDame.nEnemy >= 10 && isLose == true)
    //    {
    //        LoseMenu.SetActive(true);
    //        Time.timeScale = 0;
    //        isLose = false;
    //    }
    //}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
            LoseMenu.SetActive(true);
        }
    }
}
