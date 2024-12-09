using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Receive_Dame : MonoBehaviour
{

    [Header("---------- Show GameOver ----------")]
    public GameObject SpawnCoints;
    public GameObject SpawnEnemy;
    public GameObject gameOver;
    

    private Data data;
    private Data_Enemy data_enemy;
    //private Enemy_ReceiveDame e_ReceiveD;

    public static float currentHealth_Player;
    public static float currentHealth_Enemy;

    void Start()
    {     
        //e_ReceiveD = GameObject.FindObjectOfType<Enemy_ReceiveDame>().GetComponent<Enemy_ReceiveDame>();

        data = GameObject.FindAnyObjectByType<Data>().GetComponent<Data>();       
        data_enemy = GameObject.FindObjectOfType<Data_Enemy>().GetComponent<Data_Enemy>();             
        currentHealth_Player = data.maxHealth_Player;
        currentHealth_Enemy = data_enemy.maxHealth_Enemy;
    }

    public void Player_ReceiveDame(int dame)
    {
        currentHealth_Player -= dame;
        if (currentHealth_Player <= 0)
        {
            Destroy(SpawnCoints);
            Destroy(SpawnEnemy);
            StartCoroutine(ShowGameOver());
        }
    }

    public void Enemy_ReceiveDame(GameObject enemy,int dame)
    {
        currentHealth_Enemy -= dame;
        if (currentHealth_Enemy == 0)
        {
            Courotine_Coint.instance.killEnemy();
            //e_ReceiveD.Enemy_Die();
            Destroy(enemy);
            currentHealth_Enemy = 3;
        }
    }

    
    IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(1f);
        gameOver.SetActive(true);            
    }

}
