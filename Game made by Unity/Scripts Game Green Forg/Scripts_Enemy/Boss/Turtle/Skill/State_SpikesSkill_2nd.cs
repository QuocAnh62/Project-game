using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_SpikesSkill_2nd : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] protected float rotateSpeed = 600f;
    [SerializeField] protected float speed = 27f;
    private float time_waitForAddForce = 0.35f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    
    void Update()
    {
        Caculate_Missile();
    }

    private void Caculate_Missile()
    {
        Vector2 direction = (Vector2)Data_Player.Instance.trsForm_Player.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;
       
        addForce(rotateAmount);
    }

    private void addForce(float rotateAmount)
    {
        time_waitForAddForce -= Time.deltaTime;

        if(time_waitForAddForce >=0)        
            rb.angularVelocity = -rotateAmount * rotateSpeed;       
        else
        {
            rb.angularVelocity = -0f;
            rb.velocity = transform.up * speed;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Data_Player.Instance.health_Player.BossTurtle_MinusHealthPlayer(Specifications.Instance.dame_Boss);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Tile"))
            Destroy(this.gameObject, 0.2f);
    }
}
