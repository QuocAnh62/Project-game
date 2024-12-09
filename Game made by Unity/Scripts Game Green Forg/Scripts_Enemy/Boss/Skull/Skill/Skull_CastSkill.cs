using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class Skull_CastSkill : Skill_Boss
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private float time;
    [SerializeField] private float resetTime;
    
    private float dashPower = 40f;
    private float dashTime = 0.23f;
    //private float dashCoolDown = 0.9f;

    void Update()
    {
        time -= Time.deltaTime;

        calculate();       
        if(time <= 0)
        {
            Cast_Skill();
            time = resetTime;
        }
        
    }

    private void Cast_Skill()
    {
        int dex = Random.Range(0, 2);
        // Debug.Log("randon " + dex);
        switch (dex)
        {

            case 0:
                Cast_DropDown();
                break;

            case 1:
                fireBall();
                break;

        }
    }


    protected void Cast_DropDown()
    {
        Transform skull = transform.parent; // this is transform parent Skull of transform childrent cast_Skill
        skull.parent.position = Data_Player.Instance.trsForm_Player.position + new Vector3(0, 6f, 0);
        
        StartCoroutine(dropdown());
        
    }
    private IEnumerator dropdown()
    {
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.65f);
     
        float oriGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(0f, transform.localScale.y * -dashPower);
        tr.emitting = true;      

        yield return new WaitForSeconds(dashTime);

        dame_DropDown();

        yield return new WaitForSeconds(0.4f);

        rb.velocity = new Vector2(0f, transform.localScale.y * 6);

        tr.emitting = false;
        rb.gravityScale = oriGravity;       
        
    }

    private void dame_DropDown()
    {
        Vector3 dir = Data_Player.Instance.trsForm_Player.position - this.transform.parent.position;
        Debug.Log(dir.magnitude);

        if (dir.magnitude <= 3.5f)
        {
            Data_Player.Instance.health_Player.BossSkull_MinusHealthPlayer(Specifications.Instance.dame_Boss);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tile") || collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector2.zero;          
        }       
    }
}

