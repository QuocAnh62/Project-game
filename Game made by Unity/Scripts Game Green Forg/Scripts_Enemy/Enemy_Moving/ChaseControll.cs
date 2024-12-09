using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseControll : MonoBehaviour
{

    public Enemy_Fly_Moving[] enemyArry;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {          
            foreach (Enemy_Fly_Moving enemy in enemyArry)
            {               
                enemy.chase = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (Enemy_Fly_Moving enemy in enemyArry)
            {
                enemy.chase = false;
            }
        }
    }

   
}
