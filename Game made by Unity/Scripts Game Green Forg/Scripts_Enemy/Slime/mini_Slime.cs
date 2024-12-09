using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini_Slime : Health
{
    Animator anim;
    Rigidbody2D rb;
    protected override void Start()
    {
        health_enemy = Specifications.Instance.health_MiniSlime;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    public override void Enemy_GetDame(int damage)
    {
        DoAnima();
        base.Enemy_GetDame(damage); // call function minus health
        KnocBack.instance.KnocB(rb, this.gameObject, Data_Player.Instance.trsForm_Player);
    }


    public override void Enemy_GetDameBullet(int dame)
    {
        DoAnima();
        base.Enemy_GetDameBullet(dame);
        if (health_enemy <= 0)
        {
            Debug.Log("Spawn");
        }
    }

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


    //mini_Slime cause damage player

    private void Mini_SlimeGiveDame()
    {
        Data_Player.Instance.health_Player.Player_MinusHealth(Specifications.Instance.dame_Enemy);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("Mini_SlimeGiveDame", 0, 0.02f);
            Debug.Log("miniSlime Acttack");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CancelInvoke("Mini_SlimeGiveDame");
        }
    }
}
