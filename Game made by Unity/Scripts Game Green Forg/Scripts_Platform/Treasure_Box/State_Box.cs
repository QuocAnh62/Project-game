using System.Collections;
using UnityEngine;

public class State_Box : Health
{
 
    Animator anim;

    protected override void Start()
    {
        health_enemy = Specifications.Instance.health_box;
        anim = GetComponent<Animator>();
    }


    public override void Enemy_GetDame(int dame)
    {
        DoAnima();       
        base.Enemy_GetDame(dame);
        SpawnItems();

    }


    public override void Enemy_GetDameBullet(int dame)
    {
        DoAnima();       
        base.Enemy_GetDameBullet(dame);
        SpawnItems();
    }


    private void SpawnItems()
    {
        if (health_enemy <= 0)
        {
            After_BreakBox.Instance.Manager_Spawn(this.gameObject, this.gameObject.transform);
        }
    }

    protected override void DoAnima()
    {
        StartCoroutine(Anim_Hit());
    }

  

    IEnumerator Anim_Hit()
    {
        anim.SetBool("Hit", true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Hit", false);
    }
}
