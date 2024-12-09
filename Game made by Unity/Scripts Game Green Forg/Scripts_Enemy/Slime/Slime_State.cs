using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_State : Health
{
    Animator anim;
    Rigidbody2D rb;

    private float time_Destroy = 0.3f;
    protected override void Start()
    {
        health_enemy = Specifications.Instance.health_Slime;

        anim = GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
    }

    public override void Enemy_GetDame(int dame)
    {
        DoAnima();     
        Minus_HealthSlime(dame, health_enemy);

        KnocBack.instance.KnocB(rb, this.gameObject, Data_Player.Instance.trsForm_Player);
    }

    public override void Enemy_GetDameBullet(int dame)
    {
        DoAnima();      
        Minus_HealthSlime(dame,health_enemy);    
    }


    private void Minus_HealthSlime(int dame,int health)
    {
        AudioManager.Instance.PlayEffect(AudioManager.Instance.Bonk);

        health_enemy -= dame;
        if (health_enemy <= 0)
        {
            StartCoroutine(Call_SpawnMiniSlime());
            Destroy(this.gameObject, time_Destroy); 
        }
    }

    private IEnumerator Call_SpawnMiniSlime() // Call function Spawn_miniSlime in 0.2 second 
    {
        yield return new WaitForSeconds(time_Destroy - 0.09f);
        Spawn_miniSlime.Instance.spawn_miniSline(this.transform);
    }



    // Do animation hit
    protected override void DoAnima()
    {
        StartCoroutine(Anim_hit());
    }

    IEnumerator Anim_hit()
    {
        anim.SetBool("Hit", true);
        yield return new WaitForSeconds(0.15f);
        anim.SetBool("Hit", false);
    }



    //Slime Attack damage player
    private void SlimeGiveDame()
    {
        Data_Player.Instance.health_Player.Player_MinusHealth(Specifications.Instance.dame_Enemy);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("SlimeGiveDame", 0, 0.02f);
            Debug.Log("Slime Acttack");
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CancelInvoke("SlimeGiveDame");
        }
    }
}
