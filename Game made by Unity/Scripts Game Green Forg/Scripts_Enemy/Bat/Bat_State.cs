using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bat_State : Health
{
    public Transform StartPoint;

    float dis;
    Animator anim;
    Rigidbody2D rb;
    protected override void Start()
    {
        health_enemy = Specifications.Instance.health_Bat;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        UnityEngine.Vector3 Dir = transform.position - StartPoint.position;
        dis = Dir.magnitude;
        Anim_Bat();
    }

    public override void Enemy_GetDame(int dame)
    {
        DoAnima();
        base.Enemy_GetDame(dame);
        KnocBack.instance.KnocB(rb, this.gameObject, Data_Player.Instance.trsForm_Player);

    }

    public override void Enemy_GetDameBullet(int dame)
    {
        DoAnima();
        base.Enemy_GetDameBullet(dame);       
    }


    protected override void DoAnima()
    {
        StartCoroutine(Anim_Hit());
    }

    IEnumerator Anim_Hit()
    {
        anim.SetBool("IsHit", true);
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("IsHit", false);
    }

    private void Anim_Bat()
    {
        if (dis <= 0.1f)
        {
            anim.SetFloat("IsFly", -1);
        }
        else anim.SetFloat("IsFly", 1);

    }


    // Bat cause damage player
    private void BatGiveDame()
    {
        Data_Player.Instance.health_Player.Player_MinusHealth(Specifications.Instance.dame_Enemy);

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("BatGiveDame", 0, 0.02f);
            Debug.Log("Bat Acttack");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CancelInvoke("BatGiveDame");            
        }
    }
}
