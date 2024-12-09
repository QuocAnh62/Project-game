using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss_ReceiveDame : MonoBehaviour
{
    public GameObject MenuLose;
    public GameObject MenuWinner;

    private Data data;
    private Data_Enemy data_enemy;

    private Plane_moving plane; 

    public static float currenthealth;
    
    //public static float currentHealth_Boss_1;
    void Start()
    {       
        plane = GameObject.FindObjectOfType<Plane_moving>().GetComponent<Plane_moving>();
       
        data = GameObject.FindAnyObjectByType<Data>().GetComponent<Data>(); 
        data_enemy = GameObject.FindObjectOfType<Data_Enemy>().GetComponent<Data_Enemy>();
       
        currenthealth = data.maxHealth_PlayerBoss;
          
    }

    // Player RceiveDame
    public void Player_ReceiveDame_Boss(int dame)
    {

        if (dame == 4) // if player collision with boss
        {
            currenthealth = 0;
            HeartSystem.Health -= 4; // minus 4 heart
            plane.CantDie(); // Handle animation notdead in 2s
            plane.playerDead(); // Handel animation when PLayer Died
            MenuLose.SetActive(true); // Show GameOver
        }

        if (data.notdead_Cooldown <= 0)
        {
            currenthealth -= dame;
            plane.CantDie();

                // call 1 or 2 function heartsystem.MinusHeart(1); when Player receive Dame 1 or 2
                for (int i = 0; i < dame; i++)
                {
                    if (HeartSystem.Health > 0)
                    {
                    HeartSystem.Health -= 1;
                    }
                }
                       
                // if Player = 0 Health then show Menu Deid
                if (currenthealth <= 0)
                {                   
                    plane.playerDead();
                    MenuLose.SetActive(true);
                }
            
            data.notdead_Cooldown = data.notdead;
        }
       
    }

    private void Update()
    {
        data.notdead_Cooldown -= Time.deltaTime;
    }


    // ALL Boss_ReceiveDame
    public void boss_Receivedame()
    {
        StartCoroutine(waitWinner());       
    }


    IEnumerator waitWinner()
    {
        Time.timeScale = 0.7f;
        yield return new WaitForSeconds(1);
        MenuWinner.SetActive(true);
    }
}
