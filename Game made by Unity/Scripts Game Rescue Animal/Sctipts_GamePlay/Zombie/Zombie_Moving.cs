using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Zombie_Moving : MonoBehaviour
{   
    private Animator anim;
    private Rigidbody rb;

    private float time_Move;
    // private float speed = 10f;

    private void Start()
    {
        time_Move = PlayerPrefs.GetFloat("Time Zombie Move");

        rb = GetComponent<Rigidbody>(); 
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        time_Move -= Time.deltaTime;       
    }

    private void FixedUpdate()
    {
        if (time_Move <= 0)
        {
            time_Move = 0;
            Moving();            
        }
    }

    protected void Moving()
    {
        float moveAmount = Parameter_Zombie.Instance.speedZombie * Time.deltaTime;

         anim.SetFloat("speed", 0.15f);

        rb.MovePosition(transform.position + transform.forward * moveAmount); // zombie move by position
    }
}
