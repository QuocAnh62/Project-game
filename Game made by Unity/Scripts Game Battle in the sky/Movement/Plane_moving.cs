using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Plane_moving : MonoBehaviour
{
    public Joystick joyStick;
    public GameObject Player;
    private Data data;
    private Data_Enemy data_enemy;
    private Receive_Dame receive_dame;

    Animator anim;
    Rigidbody2D rb;
    float move_x;
    float move_y;

    float notdie;

    void Start()
    {
        data = GameObject.FindWithTag("Data").GetComponent<Data>();
        notdie = data.notdead;

        data_enemy = GameObject.FindAnyObjectByType<Data_Enemy>().GetComponent<Data_Enemy>();

        receive_dame = GameObject.FindAnyObjectByType<Receive_Dame>().GetComponent<Receive_Dame>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        //joyStick.Horizontal
        if (joyStick.Horizontal >= 0.15f)
        {          
            move_x = data.speed_x;
        }
        else if(joyStick.Horizontal <= -0.15f)
        {            
            move_x = -data.speed_x;
        }
        else
        {
            move_x = 0f;
        }

        //joyStick.Vertical
        if (joyStick.Vertical >= 0.15f)
        {
            move_y = data.speed_y;
        }
        else if (joyStick.Vertical <= -0.15f)
        {
            move_y = -data.speed_y;
        }
        else
        {
            move_y = 0f;
        }

        /* rb.velocity = new Vector2(move_x * data.speed_x, move_y * data.speed_y);*/ // add direction and speed for player
        rb.velocity  = new Vector2 (move_x, move_y);


        if (Receive_Dame.currentHealth_Player <= 0)
        {
            Debug.Log(Receive_Dame.currentHealth_Player);
            rb.velocity = Vector2.zero;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(PlayerDead());
           receive_dame.Player_ReceiveDame(data_enemy.Dame_Enemy);            
        }
    }
    public void playerDead()
    {
        StartCoroutine(PlayerDead());  
    }


    public void CantDie()
    {       
        StartCoroutine(NoTDied());             
    }


    IEnumerator PlayerDead()
    {      
        anim.SetBool("Dead", true);  
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("Dead", false);
        Destroy(Player);          
    }

   
    IEnumerator NoTDied()
    {
         anim.SetBool("NotDied", true);

         if (Boss_ReceiveDame.currenthealth <= 0)
         {  
            yield return new WaitForSeconds(notdie);
         }
         else if (Boss_ReceiveDame.currenthealth <= 0)
         {
            yield break;
         }

         anim.SetBool("NotDied", false);        
    }

}
