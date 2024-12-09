using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_2_Move : MonoBehaviour
{ 
    public GameObject Player;

    public static float speed_Boss;
    public float speed;
    Rigidbody2D rb;

    void Start()
    {
        rb  = GetComponent<Rigidbody2D>();
        speed_Boss = speed;
    }


    private void Update()
    {
        Vector2 DirPlayer = Player.transform.position - transform.position;     
        rb.velocity = new Vector2(0, DirPlayer.y) * speed_Boss;       
        if(Boss_ReceiveDame.currenthealth <= 0)
        {
            rb.velocity = Vector2.zero;
            Destroy(GetComponent<Boss_2_Move>());
        }
    }


}
