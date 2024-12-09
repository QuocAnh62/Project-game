using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle_State : Health
{
    [SerializeField] private Health_Bar healthBar;
    Animator anim;

    protected override void Start()
    {
        health_enemy = Specifications.Instance.health_turtle;

        anim = GetComponent<Animator>();        

        healthBar.UpdatHealthBar(health_enemy, max_Health);

    }

    private void OnEnable()
    {
        health_enemy = Specifications.Instance.health_turtle;
        max_Health = health_enemy;

        healthBar.UpdatHealthBar(health_enemy, max_Health);
    }

    public override void Enemy_GetDame(int dame)
    {
        DoAnima();
        healthBar.UpdatHealthBar(health_enemy, max_Health);

        base.Enemy_GetDame(dame);
        Check_PlayerWinner(health_enemy);        
    }
    public override void Enemy_GetDameBullet(int dame)
    {
        DoAnima();
        healthBar.UpdatHealthBar(health_enemy, max_Health);

        base.Enemy_GetDameBullet(dame);
        Check_PlayerWinner(health_enemy);       
    }

    private void Check_PlayerWinner(int health)
    {
        if (health <= 0)
        {
            Debug.Log("Player Destroy Turtle");
            Check_PlayerWin.Instance.PlayerWin_BossTurtle();
            Active_Turtle.Instance.Des_ActiveTurlte();
        }
    }

    protected override void DoAnima()
    {
        StartCoroutine(Anim_Hit());
    }
  

    IEnumerator Anim_Hit()
    {
        anim.SetBool("Hit", true);
        yield return new WaitForSeconds(0.15f);
        anim.SetBool("Hit", false);
    }

   
}
