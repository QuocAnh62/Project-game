using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Animator anim;

    public Vector2 boxSize;
    public LayerMask groundLayer;

    private float castDis = 1f;
    public float hight_jump = 0f;

    protected bool Isjump = false;
    protected bool CanJump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        anim.SetFloat("JumpFall", rb.velocity.y);
    }


    protected void Jump()
    {
        if (isGrounded() && Isjump)
        {
            AudioManager.Instance.PlayEffect(AudioManager.Instance.Player_Jump);
            Normal_Jump();
           
        }        
        else if (CanJump)
        {
            AudioManager.Instance.PlayEffect(AudioManager.Instance.Player_Jump);  
            
            rb.velocity = new Vector2(rb.velocity.x, 14f);
            CanJump = false;
            StartCoroutine(Djump());
        }
    }

    private void Normal_Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, hight_jump * 2);
        Isjump = false;
        anim.SetBool("isJump", !Isjump);
        CanJump = true;
    }

    private IEnumerator Djump()
    {
        anim.SetBool("isJump", Isjump);
        anim.SetBool("DJump", true);
        yield return new WaitForSeconds(0.3f); // always 0.3f
        anim.SetBool("DJump", false);
        anim.SetBool("isJump", !Isjump);
        
    }

   

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDis, groundLayer))
        {
            return true;            
        }
        else
        {
            return false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDis, boxSize);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Isjump = true;
        anim.SetBool("isJump", !Isjump);
    }
}
