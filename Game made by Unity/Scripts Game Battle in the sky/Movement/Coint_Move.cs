using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coint_Move : MonoBehaviour
{
    private Data data;
    Rigidbody2D rb;
    void Start()
    {
        data = GameObject.FindWithTag("Data").GetComponent<Data>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.left * data.speed * Time.deltaTime;
    }
}
