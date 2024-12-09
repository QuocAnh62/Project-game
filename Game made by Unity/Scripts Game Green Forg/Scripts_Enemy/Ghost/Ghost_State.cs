using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost_State : Health
{
    public Transform  StartPoint;

    [Header("Axis Doge")]
    public float minX, minY, maxX, maxY;  
    private Enemy_Fly_Moving enemy_fly_moving;

    Animator anim;
    Rigidbody2D rb;
    protected override void Start()
    {
        health_enemy = Specifications.Instance.health_Ghost;
        anim = GetComponent<Animator>();
        enemy_fly_moving = GetComponent<Enemy_Fly_Moving>();
        rb = GetComponent<Rigidbody2D>();
    }

    public override void Enemy_GetDame(int damage)
    {
        DoAnima();
        base.Enemy_GetDame(damage); // call function minus health
        KnocBack.instance.KnocB(rb, this.gameObject, Data_Player.Instance.trsForm_Player);   
        
    }

    protected override void DoAnima()
    {
        StartCoroutine(Anim_GhostHit());
    }

    IEnumerator Ghost_Doge()
    {
        StartCoroutine(Anim_GhostDoge());
        enemy_fly_moving.enabled = false;
        yield return new WaitForSeconds(0.25f);
        enemy_fly_moving.enabled = true;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Vector2 randomPosition = new Vector2(randomX, randomY);       
        transform.position = randomPosition;
    }
    IEnumerator Anim_GhostDoge()
    {
        anim.SetBool("IsDoge", true);
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("IsDoge", false);
    }

    IEnumerator Anim_GhostHit()
    {
        anim.SetBool("IsHit", true);
        yield return new WaitForSeconds(0.13f);
        anim.SetBool("IsHit", false);
    }

    IEnumerator Anim_GhostDie()
    {
        anim.SetBool("Die", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

   
    // Ghost cause Damage Player
    private void GhostGiveDame()
    {
        Data_Player.Instance.health_Player.Player_MinusHealth(Specifications.Instance.dame_Enemy);
    }

    // check trigger ghost 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // if enemy collision with Bullet do Ghost_Doge
        {
            StartCoroutine(Ghost_Doge());
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("GhostGiveDame", 0, 0.02f);
            Debug.Log("Ghost Attack");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CancelInvoke("GhostGiveDame");
        }
    }
}
