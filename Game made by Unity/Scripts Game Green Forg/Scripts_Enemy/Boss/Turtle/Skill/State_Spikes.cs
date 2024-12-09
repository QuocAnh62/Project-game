using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Spikes : Health
{
    Animator anim;
    BoxCollider2D colli;
    protected override void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        health_enemy = Specifications.Instance.health_Spikes;
        //Debug.Log( name + " " + health_enemy);

        anim = GetComponent<Animator>();
        colli = GetComponent<BoxCollider2D>();

        if (colli != null) colli.enabled = false;
        
        enabled = false;
    }


    private void OnEnable()
    {
        gameObject.layer = LayerMask.NameToLayer("Enemy"); // set layer to tag "Enemy"

        if (colli != null) colli.enabled = true;
    }  


    public override void Enemy_GetDame(int dame)
    {
        DoAnima();
        base.Enemy_GetDame(dame);
       
    }

    public override void Enemy_GetDameBullet(int dame)
    {
        DoAnima();
        base.Enemy_GetDameBullet(dame);
        
    }

    protected override void DoAnima()
    {
        StartCoroutine(Anima_Hit());
    }


    IEnumerator Anima_Hit() 
    {
        anim.SetBool("Hit", true);
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("Hit", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Data_Player.Instance.health_Player.BossTurtle_MinusHealthPlayer(Specifications.Instance.dame_Boss);
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Tile")) Destroy(gameObject);
    }
}
