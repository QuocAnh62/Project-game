using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Grid_Move : MonoBehaviour
{
    [Header("----------Speed----------")]
    public float currenspeed = 150f;

    Rigidbody2D rb;
   
    void Start()
    {               
        rb = GetComponent<Rigidbody2D>();   
    }   
    private void FixedUpdate()
    {        
        rb.velocity = (Vector2.left * currenspeed) * Time.deltaTime;
    }  
   
}
