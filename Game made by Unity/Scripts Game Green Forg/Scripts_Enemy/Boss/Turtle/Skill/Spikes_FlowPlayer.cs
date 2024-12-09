using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Spikes_FlowPlayer : MonoBehaviour
{
    public float speed = 9;
    public float rotateSpeed = 280f;

    private Rigidbody2D rb;
    private float time = 0.3f;

    void Start()
    {
        enabled = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Missile();
    }

    private void Missile()
    {
        Vector2 direction = (Vector2)Data_Player.Instance.trsForm_Player.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.velocity = transform.up * speed;

       AddRotation(rotateAmount);
        
    }

    private void AddRotation(float rotateAmount)
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            rb.angularVelocity = - rotateAmount * rotateSpeed;
            time = 0;
        }
    }


}
