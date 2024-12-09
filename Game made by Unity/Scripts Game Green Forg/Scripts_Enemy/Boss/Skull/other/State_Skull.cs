using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Skull : Health
{
    [SerializeField] private Skull_CastSkill castSkull;
    [SerializeField] private Skull_CastSkill_2 castSkull2;
    [SerializeField] private Health_Bar healthBar;
    [SerializeField] private int health_ChangeSkull = 1100;
    Animator anim;

    public bool Health_Boss => health_enemy > 0; // check about health boss have to great 0

    protected override void Start()
    {
        health_enemy = Specifications.Instance.health_skull;        
        anim = GetComponent<Animator>();

        healthBar.UpdatHealthBar(health_enemy, max_Health);
    }


    private void OnEnable()
    {
        health_enemy = Specifications.Instance.health_skull;
        max_Health = health_enemy;

        changeSkull2();

        healthBar.UpdatHealthBar(health_enemy, max_Health);
    }

    public override void Enemy_GetDame(int dame)
    {
        DoAnima();
        healthBar.UpdatHealthBar(health_enemy, max_Health);

        base.Enemy_GetDame(dame);

        changeSkull2();
        Check_PlayerWinner(health_enemy);

    }


    public override void Enemy_GetDameBullet(int dame)
    {
        DoAnima();
        healthBar.UpdatHealthBar(health_enemy, max_Health);

        base.Enemy_GetDameBullet(dame);

        changeSkull2();
        Check_PlayerWinner(health_enemy);

    }


    protected override void DoAnima()
    {
        StartCoroutine(Anim_hit());      
    }


    private void changeSkull2()
    {
        if (health_enemy <= health_ChangeSkull)
        {
            anim.SetBool("Skull2", true);
            castSkull.enabled = false;
            castSkull2.enabled = true;
            Specifications.Instance.speed_Skull = 600;
        }
        else
        {
            castSkull.enabled = true;
            castSkull2.enabled = false;
        }

        Check_PlayerWinner(health_enemy);
    }

    private void Check_PlayerWinner(int health)
    {
        if (health <= 0)
        {
            Debug.Log("Player Destroy Skull");
            Check_PlayerWin.Instance.PlayerWin_BossSkull();
            Active_Boss_Skull.Instance.Des_ActiveSkull();
        }
    }


    private IEnumerator Anim_hit()
    {
        anim.SetBool("Hit", true);
        yield return new WaitForSeconds(0.25f);
        anim.SetBool("Hit", false);
    }

}
