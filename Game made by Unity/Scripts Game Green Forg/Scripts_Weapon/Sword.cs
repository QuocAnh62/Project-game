using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Animator anim;
    public Transform attackPoint;
    public float attackRange = 1.55f;
    public int Sowrd_Dame = 15;
    public LayerMask enemyLayer;
    private float timeAttack;
    private float resetTimeAcctack = 0.25f;

    private void Start()
    {
        anim = GetComponent<Animator>();        
    }

    private void Update()
    {
        Sword_Attack();
    }

    private void Sword_Attack()
    {
        timeAttack -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timeAttack < 0)
        {
            Attack();
            AudioManager.Instance.PlayEffect(AudioManager.Instance.Sword);// PLaye Effect Bonk
            timeAttack = resetTimeAcctack;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void Attack()
    {
        StartCoroutine(Anim_Attack());

        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemy)
        {          
            Health health = enemy.GetComponent<Health>();
            if (health != null) 
            {
                health.Enemy_GetDame(Sowrd_Dame);
            }                                       
        }
    }

    IEnumerator Anim_Attack()
    {
        anim.SetBool("Attack",true);
        yield return new WaitForSeconds(resetTimeAcctack);
        anim.SetBool("Attack", false);
    }
}
