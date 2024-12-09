using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject FireBall_Perfab;
    public Transform ShootPoint;
    public float SpeedBall;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootFireBall();
        }
    }

    private void ShootFireBall()
    {
        GameObject fireBall = Instantiate(FireBall_Perfab, ShootPoint.position, Quaternion.identity);
        Rigidbody2D rb = fireBall.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootPoint.right * SpeedBall, ForceMode2D.Impulse);
        Destroy(fireBall,3f);    
    }
}
