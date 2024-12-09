using System.Collections;
using UnityEngine;

public class Player_Move : Player_Jump
{
    private TrailRenderer tr;
    private bool canDash = true;
    private bool isDashing;
    private float dashPower = 30f;
    private float dashTime = 0.15f;
    private float dashCoolDown = 0.9f;


    private Vector2 Move_Input;

    public float speed = 9f;
    private void Awake()
    {
        tr = GetComponent<TrailRenderer>();
    }
    void Start()
    {       
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        Flip();   

        if (Input.GetButtonDown("Jump"))
        {
             Jump();
        }

        Run();
        Cast_Dash();

        Move_Input.x = Input.GetAxis("Horizontal");                       
        anim.SetFloat("Walk", Mathf.Abs(rb.velocity.x));
    }

    private void FixedUpdate()
    {
        if (isDashing) { return; }
        if (Mathf.Abs(Move_Input.x) > 0.1f)
        {
            rb.velocity = new Vector2(Move_Input.x * speed, rb.velocity.y);
        }
        else
        {
            // set velocity to 0
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }


    private void Run()
    {
        if (Input.GetButton("Fire3"))
        {
            speed = 12f;
        }
        else if (Input.GetButtonUp("Fire3")) speed = 9f;
    }


    private void Cast_Dash()
    {
        if (isDashing) { return; }
        
        if (Input.GetButtonDown("Fire1") && canDash)
        {
            AudioManager.Instance.PlayEffect(AudioManager.Instance.Player_Dash);
            StartCoroutine(Dash());
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        float oriGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);

        tr.emitting = false;
        rb.gravityScale = oriGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;

    }

    void Flip()
    {
        if (Move_Input.x != 0)
        {
            if (Move_Input.x > 0)
            {
               transform.localScale = Vector3.one;
            }
            else
            {
               transform.localScale = new Vector3(-1, 1, 0);
            }
        }
    }
}

    
