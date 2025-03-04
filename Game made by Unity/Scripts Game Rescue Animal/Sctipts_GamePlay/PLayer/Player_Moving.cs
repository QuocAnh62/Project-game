using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Moving : Player_LookRotation
{
    private Rigidbody rb;
    private Animator anim;
    public bool isFinishLine_1st = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    protected void FixedUpdate()
    {
        Move();
        LookRotation();       
        DoAnim();

        Player_FinishLine1st();
    }

    private void Move()
    {
        rb.velocity =
         new Vector3(joystick.Horizontal * Parameter_Manager.Instance.speedPlayer, rb.velocity.y, joystick.Vertical * Parameter_Manager.Instance.speedPlayer);
    }

    private void DoAnim()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }

    private void Player_FinishLine1st()
    {
        if(isFinishLine_1st == true)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = Vector3.forward * Parameter_Manager.Instance.speedPlayer;
        }
    }
}
